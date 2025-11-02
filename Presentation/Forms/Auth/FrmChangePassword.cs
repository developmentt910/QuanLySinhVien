
namespace StudentCourseManagement.Forms.Auth
{
    public partial class FrmChangePassword : Form
    {
        private readonly PasswordChangeService _changeService;

        public FrmChangePassword(PasswordChangeService changeService)
        {
            InitializeComponent();
            _changeService = changeService;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            string oldPwd = txtOldPassword.Text.Trim();
            string newPwd = txtNewPassword.Text.Trim();
            string confirmPwd = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(oldPwd) || string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(confirmPwd))
            {
                ShowMessage("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            if (newPwd != confirmPwd)
            {
                ShowMessage("Mật khẩu mới và xác nhận không khớp.");
                return;
            }

            ShowMessage("Đổi mật khẩu thành công!", Color.Green);
            ClearInputs();
        }

        private void ShowMessage(string text, Color? color = null)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = color ?? Color.Red;
            lblMessage.Visible = true;
        }

        private void ClearInputs()
        {
            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }
    }
}
