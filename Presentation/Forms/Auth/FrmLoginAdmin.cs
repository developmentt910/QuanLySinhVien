using StudentCourseManagement.Applications.Auth;
using StudentCourseManagement.Presentation.Forms.Admin;


namespace StudentCourseManagement.Presentation.Forms.Auth
{
    public partial class FrmLoginAdmin : Form
    {
        private readonly LoginService _loginService;

        public FrmLoginAdmin()
        {
            InitializeComponent();
            var usersReader = ServicesFactory.CreateUsersReader();
            var throttle = new ThrottleService(ServicesFactory.CreateThrottleStore());
            var captcha = new CaptchaVerifier(ServicesFactory.CreateCaptcha());
            var rosterR = ServicesFactory.CreateRosterReader();
            var userW = ServicesFactory.CreateUsersWriter();
            _loginService = new LoginService(usersReader, throttle, rosterR, userW, captcha);
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
                Password = txtPassword.Text.Trim(),
                CaptchaInput = txtCaptchaInput.Text.Trim(),
                CaptchaToken = lblCaptchaCode.Text,
            };

            if ((string.IsNullOrWhiteSpace(dto.PrivilegeCode)) ||
                 string.IsNullOrWhiteSpace(dto.Password))
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

    
    }
}

