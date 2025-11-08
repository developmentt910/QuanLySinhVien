using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StudentCourseManagement.Forms.Auth
{
    public partial class FrmRegister : Form
    {
        private readonly RegistrationService _registration;
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

            this.Load += FrmRegister_Load;
        }

        private void FrmRegister_Load(object? sender, EventArgs e)
        {

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
            bool isStudent = rdoStudent.Checked;

            pnlStudent.Visible = tlpStudent.Visible = isStudent;
            pnlAdmin.Visible = tlpAdmin.Visible = !isStudent;

            txtStudentCode.CausesValidation = isStudent;
            txtPrivCode.CausesValidation = !isStudent;

            txtPassword.Visible = lblPassword.Visible = isStudent;

            SetInlineError(isStudent ? txtPrivCode : txtStudentCode, null);



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

            // add textbox in new layer
            parentTlp.Controls.Remove(box);
            box.Margin = new Padding(0, 3, 0, 0);
            box.Dock = DockStyle.Top;
            inner.Controls.Add(box, 0, 0);


            // create label hthi loi
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
            if (_inlineErrors.TryGetValue(c, out var lbl))
                lbl.Text = message ?? "";
        }

        private void ClearAllInlineErrors()
        {
            foreach (var lbl in _inlineErrors.Values)
                lbl.Text = "";
        }

        private void rdoRole_CheckedChanged(object? sender, EventArgs e)
        {
            
            ApplyRoleUI();
        }

        private void lnkToLogin_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLoginAdmin frmLoginAdmin = new FrmLoginAdmin();
            frmLoginAdmin.Show();
            this.Hide();
        }

        private async void btnRegister_Click(object? sender, EventArgs e)
        {
            ClearAllInlineErrors();
            ApplyRoleUI();

            var dto = new RegisterDto
            {
                FullName = txtFullName.Text,
                Password = pnlStudent.Visible ? txtPassword.Text : null,
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
                MapServerErrorToField(msg);
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode))
            {
                MessageBox.Show("Tài khoản quản trị viên đã được tạo thành công! Mã OTP xác minh đã được gửi.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new FrmLoginAdmin().Show();
            }
            else
            {
                MessageBox.Show("Đăng ký thành công! Mã OTP xác minh đã được gửi.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new FrmLogin().Show();
            }

            this.Hide();
        }

        private void MapServerErrorToField(string error)
        {
            var e = error.ToLowerInvariant();

            if (e.Contains("email")) SetInlineError(txtEmail, error);
            else if (e.Contains("cccd")) SetInlineError(txtCccd, error);
            else if (e.Contains("msv") || e.Contains("sinh viên") || e.Contains("student")) SetInlineError(txtStudentCode, error);
            else if (e.Contains("mật khẩu") || e.Contains("password")) SetInlineError(txtPassword, error);
            else if (e.Contains("tên") || e.Contains("họ")) SetInlineError(txtFullName, error);
        }

        private void lnkToStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
