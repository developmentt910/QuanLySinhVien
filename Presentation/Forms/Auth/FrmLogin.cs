
using Microsoft.VisualBasic.ApplicationServices;
using StudentCourseManagement.Presentation.Forms.Auth;
using System.Drawing.Drawing2D;

namespace StudentCourseManagement.Forms.Auth
{
    public partial class FrmLogin : Form
    {
        private readonly LoginService _loginService;
        private Panel card;

        public FrmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;

            var usersReader = ServicesFactory.CreateRosterReader();
            var captcha = new CaptchaVerifier(ServicesFactory.CreateCaptcha());
            var rosterR = ServicesFactory.CreateRosterReader();
            var userW = ServicesFactory.CreateUsersWriter();
            _loginService = new LoginService(usersReader, rosterR, userW, captcha);
           



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
                PrivilegeCode = txtMSV.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                CaptchaInput = txtCaptchaInput.Text.Trim(),
                CaptchaToken = lblCaptchaCode.Text,
            };

            var (user, error) = await _loginService.LoginAsync(dto);

            if (error != null)
            {
                MessageBox.Show(error, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblCaptchaCode.Text = _loginService.GenerateCaptcha();
                txtCaptchaInput.Clear();
                return;
            }

            // user đăng nhập thành công
            //_loggedInUserId = user.Id;

            MessageBox.Show($"Chào mừng {user.FullName}!", "Thành công");

            var frm = new FrmAdminDashboard(ServicesFactory.CreateAdminService(), user.Id);
            frm.Show();
            this.Hide();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrmForgotPassword frmForgotPassword = new FrmForgotPassword();
            frmForgotPassword.Show();
            this.Hide();
        }


        
    }
}
