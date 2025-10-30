using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using StudentCourseManagement.Applications.Dtos;
using StudentCourseManagement.Applications.Validation;
using StudentCourseManagement.Presentation.Forms.Auth;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Forms.Auth
{
    public partial class FrmRegister : Form
    {
        private readonly RegistrationService _registration;
        private readonly ErrorProvider _err;
        private readonly Dictionary<Control, Label> _inlineErrors = new();

        public FrmRegister()
        {
            InitializeComponent();

            _registration = new RegistrationService(
                userR: ServicesFactory.CreateUsersReader(),
                userW: ServicesFactory.CreateUsersWriter(),
              
                otpR: ServicesFactory.CreateOtpReader(),
                otpW: ServicesFactory.CreateOtpWriter(),
                email: ServicesFactory.CreateEmail(),
                clock: ServicesFactory.CreateClock(),
                rosterR: ServicesFactory.CreateRosterReader()
            );

            _err = new ErrorProvider(this) { BlinkStyle = ErrorBlinkStyle.NeverBlink };

            this.Load += FrmRegister_Load;
        }

        private void FrmRegister_Load(object? sender, EventArgs e)
        {
            tlpRoleBlock.AutoSize = true;
            tlpRoleBlock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpRoleBlock.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tlpRoleBlock.RowStyles.Clear();
            tlpRoleBlock.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpRoleBlock.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            rdoStudent.Checked = true;
            rdoAdmin.Checked = false;

            WrapWithInlineError(txtFullName, tlpInfo);
            WrapWithInlineError(txtPassword, tlpInfo);
            WrapWithInlineError(txtCccd, tlpInfo);
            WrapWithInlineError(txtPhone, tlpInfo);
            WrapWithInlineError(txtEmail, tlpInfo);

            WrapWithInlineError(txtStudentCode, tlpStudent);
            WrapWithInlineError(txtPrivCode, tlpAdmin);

            ApplyRoleUI();
        }


        private void ApplyRoleUI()
        {
            if (rdoAdmin.Checked && rdoStudent.Checked) rdoStudent.Checked = false;
            if (rdoStudent.Checked && rdoAdmin.Checked) rdoAdmin.Checked = false;

            bool isStudent = rdoStudent.Checked && !rdoAdmin.Checked;
            bool isAdmin = rdoAdmin.Checked && !rdoStudent.Checked;

            pnlStudent.Visible = tlpStudent.Visible = isStudent;
            pnlAdmin.Visible = tlpAdmin.Visible = isAdmin;

            txtStudentCode.CausesValidation = isStudent;
            txtPrivCode.CausesValidation = isAdmin;

            if (!isStudent) SetInlineError(txtStudentCode, null);
            if (!isAdmin) SetInlineError(txtPrivCode, null);

            tlpRoleBlock.PerformLayout();

            System.Diagnostics.Debug.WriteLine(
                $"[RoleUI] Student={isStudent}, Admin={isAdmin}, pnlStudent={pnlStudent.Visible}, pnlAdmin={pnlAdmin.Visible}");
        }

        private void WrapWithInlineError(TextBox box, TableLayoutPanel parentTlp)
        {
            if (box.Parent != parentTlp) return;

            var pos = parentTlp.GetPositionFromControl(box);

            var inner = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };
            inner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            inner.RowStyles.Add(new RowStyle()); 
            inner.RowStyles.Add(new RowStyle()); 

            parentTlp.Controls.Remove(box);
            box.Margin = new Padding(0, 3, 0, 0);
            box.Dock = DockStyle.Top;
            inner.Controls.Add(box, 0, 0);

            var lbl = new Label
            {
                AutoSize = true,
                ForeColor = Color.Firebrick,
                Font = new Font(box.Font, FontStyle.Italic),
                Text = "",
                Margin = new Padding(0, 2, 0, 3),
                Dock = DockStyle.Top
            };
            inner.Controls.Add(lbl, 0, 1);

            parentTlp.Controls.Add(inner, pos.Column, pos.Row);
            _inlineErrors[box] = lbl;
        }

        private void SetInlineError(Control c, string? message)
        {
            _err.SetError(c, string.IsNullOrWhiteSpace(message) ? "" : message);
            if (_inlineErrors.TryGetValue(c, out var lbl))
                lbl.Text = message ?? "";
        }

        private void ClearAllInlineErrors()
        {
            _err.Clear();
            foreach (var lbl in _inlineErrors.Values) lbl.Text = "";
        }


        private void rdoRole_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender == rdoAdmin && rdoAdmin.Checked) rdoStudent.Checked = false;
            if (sender == rdoStudent && rdoStudent.Checked) rdoAdmin.Checked = false;

            ApplyRoleUI();
        }

        private void lnkToLogin_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Đi tới trang Đăng nhập.",
                "Chuyển trang", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();

        }

        private async void btnRegister_Click(object? sender, EventArgs e)
        {
            ClearAllInlineErrors();

            ApplyRoleUI();

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Vui lòng sửa các lỗi hiển thị ngay dưới ô nhập.",
                    "Thiếu/Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new RegisterDto
            {
                FullName = txtFullName.Text,
                Password = txtPassword.Text,
                CCCD = txtCccd.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                StudentCode = pnlStudent.Visible ? txtStudentCode.Text.Trim() : null,
                PrivilegeCode = pnlAdmin.Visible ? txtPrivCode.Text.Trim() : null
            };

            var result = await _registration.RegisterAsync(dto, schoolEmailFromRoster: null, ct: CancellationToken.None);

            if (!result.Ok)
            {
                var msg = result.Error ?? "Đăng ký thất bại.";
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MapServerErrorToField(msg);
                return;
            }

            string message;
            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode))
            {
                message = "Tài khoản quản trị viên đã được tạo thành công! Mã OTP xác minh đã được gửi.";

                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmLoginAdmin frmLoginAdmin = new FrmLoginAdmin();
                frmLoginAdmin.Show();
            }
            else
            {
                message = "Đăng ký thành công! Mã OTP xác minh đã được gửi.\n\n" +
                          "Nếu bạn thuộc danh sách sinh viên của trường, thông tin học vụ đã được liên kết tự động.";

                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }

            this.Hide();
        }



        private void MapServerErrorToField(string error)
        {
            var e = error.ToLowerInvariant();

            if (e.Contains("email"))
                SetInlineError(txtEmail, error);
            else if (e.Contains("cccd"))
                SetInlineError(txtCccd, error);
            else if (e.Contains("msv") || e.Contains("sinh viên") || e.Contains("student"))
                SetInlineError(txtStudentCode, error);
            else if (e.Contains("mật khẩu") || e.Contains("password"))
                SetInlineError(txtPassword, error);
            else if (e.Contains("tên") || e.Contains("họ"))
                SetInlineError(txtFullName, error);
            else
                _ = MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void txtFullName_Validating(object? sender, CancelEventArgs e)
        {
            var norm = Normalizers.NormalizeFullName(txtFullName.Text);
            txtFullName.Text = norm;

            if (!RegexRules.IsMatch(norm, RegexRules.FullNameBasic))
            {
                SetInlineError(txtFullName, "Họ và tên không hợp lệ (chỉ chữ & khoảng trắng).");
                e.Cancel = true;
            }
            else SetInlineError(txtFullName, null);
        }

        private void txtPassword_Validating(object? sender, CancelEventArgs e)
        {
            if (!RegexRules.IsMatch(txtPassword.Text, RegexRules.PasswordStrong))
            {
                SetInlineError(txtPassword, "Mật khẩu ≥12 ký tự, có CHỮ HOA, SỐ và ký tự đặc biệt.");
                e.Cancel = true;
            }
            else SetInlineError(txtPassword, null);
        }

        private void txtCccd_Validating(object? sender, CancelEventArgs e)
        {
            if (!RegexRules.IsMatch(txtCccd.Text.Trim(), RegexRules.Cccd))
            {
                SetInlineError(txtCccd, "CCCD phải đúng 12 chữ số.");
                e.Cancel = true;
            }
            else SetInlineError(txtCccd, null);
        }

        private void txtPhone_Validating(object? sender, CancelEventArgs e)
        {
            var norm = Normalizers.NormalizePhoneToVN(txtPhone.Text);
            if (string.IsNullOrWhiteSpace(norm))
            {
                SetInlineError(txtPhone, "SĐT hợp lệ: +84xxxxxxxxx hoặc 0xxxxxxxxx.");
                e.Cancel = true;
            }
            else
            {
                txtPhone.Text = norm;
                SetInlineError(txtPhone, null);
            }
        }

        private void txtEmail_Validating(object? sender, CancelEventArgs e)
        {
            var v = txtEmail.Text.Trim();
            if (!RegexRules.IsMatch(v, RegexRules.Email))
            {
                SetInlineError(txtEmail, "Email không hợp lệ.");
                e.Cancel = true;
            }
            else
            {
                txtEmail.Text = Normalizers.NormalizeEmail(v);
                SetInlineError(txtEmail, null);
            }
        }

        private void txtStudentCode_Validating(object? sender, CancelEventArgs e)
        {
            if (pnlStudent.Visible && string.IsNullOrWhiteSpace(txtStudentCode.Text))
            {
                SetInlineError(txtStudentCode, "Vui lòng nhập Mã sinh viên.");
                e.Cancel = true;
            }
            else SetInlineError(txtStudentCode, null);
        }

        private void txtPrivCode_Validating(object? sender, CancelEventArgs e)
        {
            if (pnlAdmin.Visible && string.IsNullOrWhiteSpace(txtPrivCode.Text))
            {
                SetInlineError(txtPrivCode, "Vui lòng nhập Mã đặc quyền.");
                e.Cancel = true;
            }
            else SetInlineError(txtPrivCode, null);
        }

      
    }
}
