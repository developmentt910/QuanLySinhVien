using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.Help
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();
        }

        private void FrmHelp_Load(object sender, EventArgs e)
        {
            pnlSupport.BringToFront();
            HighlightButton(btnSupport);
            StyleHelper.ApplyFormStyle(this);
        }

        private void HighlightButton(Button selectedButton)
        {
            Color activeColor = System.Drawing.Color.LightSkyBlue;
            Color inactiveColor = System.Drawing.Color.FromArgb(240, 240, 240);

            btnSupport.BackColor = inactiveColor;
            btnFAQ.BackColor = inactiveColor;
            btnAbout.BackColor = inactiveColor;

            selectedButton.BackColor = activeColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            pnlSupport.BringToFront();
            HighlightButton(btnSupport);
        }

        private void btnFAQ_Click(object sender, EventArgs e)
        {
            pnlFAQ.BringToFront();
            HighlightButton(btnFAQ);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            pnlAbout.BringToFront();
            HighlightButton(btnAbout);
        }

        #region Các câu hỏi FAQ

        private void linkFAQ1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Cách thêm Thời khóa biểu (TKB)";
            string message = "1. Chọn Khoa -> Ngành -> Chuyên ngành -> Lớp -> Học kỳ.\n" +
                             "2. Nhấn nút 'Tải TKB'.\n" +
                             "3. Chọn 'Môn học' (đã được lọc) từ danh sách.\n" +
                             "4. Điền thông tin Giáo viên, Phòng, Ngày, Tiết.\n" +
                             "5. Nhấn nút 'Thêm'.";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkFAQ2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Cách thêm Lịch thi";
            string message = "1. Chọn Khoa -> Ngành -> Chuyên ngành.\n" +
                             "2. ComboBox 'Lớp học' và 'Môn học' sẽ được tải tự động.\n" +
                             "3. Chọn Lớp, Môn, Học kỳ, Hình thức thi.\n" +
                             "4. Nhập Ngày/Giờ thi, Thời gian, Phòng thi.\n" +
                             "5. Nhấn nút 'Lưu'.";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkFAQ3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Lỗi: Không thấy môn học ở form CT Khung?";
            string message = "Đây là điều bình thường. Bạn phải chọn Khoa, Ngành, Chuyên ngành và Học kỳ, sau đó nhấn nút 'Tải'.\n\n" +
                             "Hệ thống sẽ tự động lọc các môn học thuộc chuyên ngành đó để bạn chọn.";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}