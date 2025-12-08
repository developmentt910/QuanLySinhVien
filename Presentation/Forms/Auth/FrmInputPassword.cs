using StudentCourseManagement.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StudentCourseManagement.Presentation.Forms.Auth
{
    public partial class FrmInputPassword : Form
    {
        private readonly IForgotPasswordService _service;
        private readonly string _email;
        public FrmInputPassword(IForgotPasswordService service, string email)
        {
            InitializeComponent();
            _service = service;
            _email = email;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string newPass = txtNew.Text.Trim();
            string rePass = txtReNew.Text.Trim();

            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(rePass))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != rePass)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           await _service.UpdatePasswordAsync(_email, newPass);


            MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Close();

        }
    }
}
