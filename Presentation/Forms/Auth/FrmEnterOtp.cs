using System;
using System.Drawing;
using System.Windows.Forms;
using StudentCourseManagement.Domain.Abstractions.Repositories;

namespace StudentCourseManagement.Presentation.Forms.Auth
{
    public partial class FrmEnterOtp : Form
    {
        private readonly string _email;
        private readonly IForgotPasswordService _service;
        private Guid currentUserId;
        private PasswordChangeService changeService;

        public FrmEnterOtp(string email, IForgotPasswordService service)
        {
            InitializeComponent();
            _email = email;
            _service = service;

            lblEmail.Text = $"Mã OTP đã được gửi đến: {_email}";
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            string otp = txtOtp.Text.Trim();

            if (otp.Length != 6)
            {
                MessageBox.Show("OTP phải gồm 6 chữ số.");
                return;
            }

            var userId = await _service.GetUserIdByEmailAsync(_email);
            if (userId == null)
            {
                MessageBox.Show("Email không tồn tại.");
                return;
            }

            bool valid = await _service.VerifyOtpAsync(userId.Value, otp);

            if (!valid)
            {
                MessageBox.Show("OTP không đúng hoặc đã hết hạn.");
                return;
            }

            // Mở form đặt lại mật khẩu
            var frm = new FrmChangePassword(changeService, currentUserId);
            frm.Show();
            this.Hide();
        }

        private async void btnResend_Click(object sender, EventArgs e)
        {
            bool ok = await _service.SendOtpAsync(_email);

            if (ok)
                MessageBox.Show("Mã OTP mới đã được gửi.");
            else
                MessageBox.Show("Không thể gửi lại OTP. Vui lòng thử lại.");
        }
    }
}
