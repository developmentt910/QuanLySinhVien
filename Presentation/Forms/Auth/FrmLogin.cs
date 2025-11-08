
namespace StudentCourseManagement.Forms.Auth
{
    public partial class FrmLogin : Form
    {
        private readonly LoginService _loginService;
        private readonly PasswordChangeService _changeService;

        public FrmLogin()
        {
            InitializeComponent();

            var usersReader = ServicesFactory.CreateUsersReader();
            var throttle = new ThrottleService(ServicesFactory.CreateThrottleStore());
            var captcha = new CaptchaVerifier(ServicesFactory.CreateCaptcha());
            var rosterR = ServicesFactory.CreateRosterReader();
            var userW = ServicesFactory.CreateUsersWriter();
            _loginService = new LoginService(usersReader, throttle, rosterR, userW, captcha);

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
                StudentCode = txtMSV.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                CaptchaInput = txtCaptchaInput.Text.Trim(),
                CaptchaToken = lblCaptchaCode.Text,
            };

            if ((string.IsNullOrWhiteSpace(dto.StudentCode)) ||
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

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChangePassword frmchangepasswprd = new FrmChangePassword(_changeService);
            frmchangepasswprd.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister frmregister  = new FrmRegister();
            frmregister.Show();
            this.Hide();
        }
    }
}
