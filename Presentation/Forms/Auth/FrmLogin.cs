
using StudentCourseManagement.Applications.Security;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer.Auth;
using StudentCourseManagement.Presentation.Forms.Admin;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Forms.Auth
{
    public partial class FrmLogin : Form 
    {
        private readonly LoginService _loginService;

        public FrmLogin()
        {
            InitializeComponent();

            var usersReader = ServicesFactory.CreateUsersReader();
            var throttle = new ThrottleService(ServicesFactory.CreateThrottleStore());
            var captcha = new CaptchaVerifier(ServicesFactory.CreateCaptcha());
            _loginService = new LoginService(usersReader, throttle, captcha);

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblCaptchaCode.Text = _loginService.GenerateCaptcha();
        }

        private void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            lblCaptchaCode.Text = _loginService.GenerateCaptcha();
        }

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            var dto = new LoginDto
            {
                StudentCodeOrEmail = txtMSV.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                CaptchaInput = txtCaptchaInput.Text.Trim(),
                CaptchaToken = lblCaptchaCode.Text
            };

            if (string.IsNullOrWhiteSpace(dto.StudentCodeOrEmail) || string.IsNullOrWhiteSpace(dto.Password))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            FrmAdminDashboard adminForm = new FrmAdminDashboard();
            adminForm.FormClosed += (s, args) => this.Close();
            adminForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var usersReader = ServicesFactory.CreateUsersReader();
            var usersWriter = ServicesFactory.CreateUsersWriter();
            var changeService = new PasswordChangeService(usersReader, usersWriter);

            using (var frmChangePassword = new FrmChangePassword(changeService))
            {
                this.Hide();
                frmChangePassword.ShowDialog(); // modal form
            }
        }
    }
}
