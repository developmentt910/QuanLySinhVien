using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentCourseManagement.Presentation.Forms.Schedule;

namespace StudentCourseManagement.Presentation.Forms.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        public FrmAdminDashboard()
        {
            InitializeComponent();
        }

        // Sự kiện mở Form Quản lý TKB (Lịch học)
        private void lichHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuanLyThoiKhoaBieu frm = new FrmQuanLyThoiKhoaBieu();
            frm.ShowDialog();
        }

        // Sự kiện mở Form Quản lý Lịch Thi
        private void lichThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuanLyLichThi frm = new FrmQuanLyLichThi();
            frm.ShowDialog();
        }
    }
}