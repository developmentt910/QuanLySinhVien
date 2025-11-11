using StudentCourseManagement.Applications.Services;
using StudentCourseManagement.Presentation.Forms.Admin;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using StudentCourseManagement.Applications.Auth;
using StudentCourseManagement.Applications.Security;
using System;
using System.Windows.Forms;
using System.Linq;

namespace StudentCourseManagement.Presentation.Forms.Auth
{
    public partial class FrmLoginAdmin : Form
    {
        private readonly LoginService _loginService;
        private bool isLoggedIn = false; 

        public FrmLoginAdmin()
        {
            InitializeComponent();
            var usersReader = ServicesFactory.CreateUsersReader();
            var throttle = new ThrottleService(ServicesFactory.CreateThrottleStore());
            var captcha = new CaptchaVerifier(ServicesFactory.CreateCaptcha());
            var rosterR = ServicesFactory.CreateRosterReader();
            var userW = ServicesFactory.CreateUsersWriter();
            _loginService = new LoginService(usersReader, throttle, rosterR, userW, captcha);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLoginAdmin_FormClosed);
        }

        private void FrmLoginAdmin_Load(object sender, EventArgs e)
        {
            lblCaptchaCode.Text = _loginService.GenerateCaptcha();
        }

        private void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            lblCaptchaCode.Text = _loginService.GenerateCaptcha();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var dto = new LoginDto
            {
                PrivilegeCode = txtMDQ.Text.Trim(),
                CaptchaInput = txtCaptchaInput.Text.Trim(),
                CaptchaToken = lblCaptchaCode.Text,
            };

            if (string.IsNullOrWhiteSpace(dto.PrivilegeCode))
            {
                MessageBox.Show("Vui lòng nhập mã đặc quyền", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = await _loginService.LoginAsync(dto);

            if (!result.Ok)
            {
                MessageBox.Show(result.Error, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblCaptchaCode.Text = _loginService.GenerateCaptcha();
                txtCaptchaInput.Clear();
                return;
            }
            MessageBox.Show($"Chào mừng {result.Value.FullName}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var userService = new AdminService(
                   ServicesFactory.CreateUsersReader(),
                   ServicesFactory.CreateUsersWriter()
               );

            Guid userId = result.Value.Id;

            FrmAdminDashboard adminForm = new FrmAdminDashboard(userService, userId);

            adminForm.FormClosed += (s, args) =>
            {
                if (adminForm.IsLoggingOut)
                {
                    this.isLoggedIn = false; 
                    this.Show(); 
                    lblCaptchaCode.Text = _loginService.GenerateCaptcha();
                    txtCaptchaInput.Clear();
                    txtMDQ.Clear();
                }
                else
                {
                    Application.Exit();
                }
            };

            this.isLoggedIn = true; 
            adminForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmRegister = Application.OpenForms.OfType<FrmRegister>().FirstOrDefault();
            if (frmRegister != null)
            {
                frmRegister.Show();
            }
            else
            {
                FrmRegister newFrmRegister = new FrmRegister();
                newFrmRegister.Show();
            }

            this.isLoggedIn = true; 
            this.Close(); 
        }

        private void FrmLoginAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggedIn)
            {
                var frmRegister = Application.OpenForms.OfType<FrmRegister>().FirstOrDefault();
                frmRegister?.Close();
            }
        }
    }
}