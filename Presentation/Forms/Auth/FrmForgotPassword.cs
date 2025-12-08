using System;
using System.Drawing;
using System.Windows.Forms;
using StudentCourseManagement.Applications.Auth;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.Auth
{

    public partial class FrmForgotPassword : Form
    {
        private readonly IForgotPasswordService _service;

        public FrmForgotPassword()
        {
            InitializeComponent();

            _service = ServicesFactory.CreateForgotPasswordService();

            CustomizeUI();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CustomizeUI()
        {
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 73, 94);

            

            StyleButton(btnSendOtp, Color.FromArgb(52, 152, 219));

            btnBack.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            btnBack.ForeColor = Color.FromArgb(41, 128, 185);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
        }

        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private async void btnSendOtp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            bool ok = await _service.SendOtpAsync(email);

            if (!ok)
            {
                MessageBox.Show("Email không tồn tại hoặc lỗi hệ thống.");
                return;
            }

            MessageBox.Show("OTP đã được gửi đến email của bạn.");

            var frm = new FrmEnterOtp(email, _service);
            frm.Show();
            this.Hide();
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }
    }
}
