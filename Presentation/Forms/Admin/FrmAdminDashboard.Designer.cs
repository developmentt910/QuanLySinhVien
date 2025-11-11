namespace StudentCourseManagement.Presentation.Forms.Admin
{
    partial class FrmAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            heThongToolStripMenuItem = new ToolStripMenuItem();
            quanLySinhVienToolStripMenuItem = new ToolStripMenuItem();
            quanLyTongHopToolStripMenuItem = new ToolStripMenuItem();
            kyHocToolStripMenuItem = new ToolStripMenuItem();
            khoaToolStripMenuItem = new ToolStripMenuItem();
            lopHocToolStripMenuItem = new ToolStripMenuItem();
            monHocToolStripMenuItem = new ToolStripMenuItem();
            chươngTrìnhKhungToolStripMenuItem = new ToolStripMenuItem();
            thoiKhoaBieuToolStripMenuItem = new ToolStripMenuItem();
            lichThiToolStripMenuItem = new ToolStripMenuItem();
            lichHocToolStripMenuItem = new ToolStripMenuItem();
            thongKeBaoCaoToolStripMenuItem = new ToolStripMenuItem();
            troGiupToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { heThongToolStripMenuItem, quanLySinhVienToolStripMenuItem, quanLyTongHopToolStripMenuItem, thongKeBaoCaoToolStripMenuItem, troGiupToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(919, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            heThongToolStripMenuItem.Size = new Size(103, 29);
            heThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // quanLySinhVienToolStripMenuItem
            // 
            quanLySinhVienToolStripMenuItem.Name = "quanLySinhVienToolStripMenuItem";
            quanLySinhVienToolStripMenuItem.Size = new Size(163, 29);
            quanLySinhVienToolStripMenuItem.Text = "Quản lý sinh viên";
            // 
            // quanLyTongHopToolStripMenuItem
            // 
            quanLyTongHopToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kyHocToolStripMenuItem, khoaToolStripMenuItem, lopHocToolStripMenuItem, monHocToolStripMenuItem, thoiKhoaBieuToolStripMenuItem });
            quanLyTongHopToolStripMenuItem.Name = "quanLyTongHopToolStripMenuItem";
            quanLyTongHopToolStripMenuItem.Size = new Size(169, 29);
            quanLyTongHopToolStripMenuItem.Text = "Quản lý tổng hợp";
            // 
            // kyHocToolStripMenuItem
            // 
            kyHocToolStripMenuItem.Name = "kyHocToolStripMenuItem";
            kyHocToolStripMenuItem.Size = new Size(231, 34);
            kyHocToolStripMenuItem.Text = "Kỳ học";
            // 
            // khoaToolStripMenuItem
            // 
            khoaToolStripMenuItem.Name = "khoaToolStripMenuItem";
            khoaToolStripMenuItem.Size = new Size(231, 34);
            khoaToolStripMenuItem.Text = "Khoa";
            // 
            // lopHocToolStripMenuItem
            // 
            lopHocToolStripMenuItem.Name = "lopHocToolStripMenuItem";
            lopHocToolStripMenuItem.Size = new Size(231, 34);
            lopHocToolStripMenuItem.Text = "Lớp học";
            lopHocToolStripMenuItem.Click += lopHocToolStripMenuItem_Click;
            // 
            // monHocToolStripMenuItem
            // 
            monHocToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chươngTrìnhKhungToolStripMenuItem });
            monHocToolStripMenuItem.Name = "monHocToolStripMenuItem";
            monHocToolStripMenuItem.Size = new Size(231, 34);
            monHocToolStripMenuItem.Text = "Môn học";
            // 
            // chươngTrìnhKhungToolStripMenuItem
            // 
            chươngTrìnhKhungToolStripMenuItem.Name = "chươngTrìnhKhungToolStripMenuItem";
            chươngTrìnhKhungToolStripMenuItem.Size = new Size(274, 34);
            chươngTrìnhKhungToolStripMenuItem.Text = "Chương trình khung";
            chươngTrìnhKhungToolStripMenuItem.Click += chuongTrinhKhungToolStripMenuItem_Click;
            // 
            // thoiKhoaBieuToolStripMenuItem
            // 
            thoiKhoaBieuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lichThiToolStripMenuItem, lichHocToolStripMenuItem });
            thoiKhoaBieuToolStripMenuItem.Name = "thoiKhoaBieuToolStripMenuItem";
            thoiKhoaBieuToolStripMenuItem.Size = new Size(231, 34);
            thoiKhoaBieuToolStripMenuItem.Text = "Thời khóa biểu";
            // 
            // lichThiToolStripMenuItem
            // 
            lichThiToolStripMenuItem.Name = "lichThiToolStripMenuItem";
            lichThiToolStripMenuItem.Size = new Size(270, 34);
            lichThiToolStripMenuItem.Text = "Lịch thi";
            lichThiToolStripMenuItem.Click += lichThiToolStripMenuItem_Click;
            // 
            // lichHocToolStripMenuItem
            // 
            lichHocToolStripMenuItem.Name = "lichHocToolStripMenuItem";
            lichHocToolStripMenuItem.Size = new Size(270, 34);
            lichHocToolStripMenuItem.Text = "Lịch học";
            lichHocToolStripMenuItem.Click += lichHocToolStripMenuItem_Click;
            // 
            // thongKeBaoCaoToolStripMenuItem
            // 
            thongKeBaoCaoToolStripMenuItem.Name = "thongKeBaoCaoToolStripMenuItem";
            thongKeBaoCaoToolStripMenuItem.Size = new Size(182, 29);
            thongKeBaoCaoToolStripMenuItem.Text = "Thống kê / Báo cáo";
            // 
            // troGiupToolStripMenuItem
            // 
            troGiupToolStripMenuItem.Name = "troGiupToolStripMenuItem";
            troGiupToolStripMenuItem.Size = new Size(93, 29);
            troGiupToolStripMenuItem.Text = "Trợ giúp";
            troGiupToolStripMenuItem.Click += troGiupToolStripMenuItem_Click;
            // 
            // FrmAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmAdminDashboard";
            Text = "Admin Dashboard";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLySinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyTongHopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kyHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lopHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoiKhoaBieuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lichThiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lichHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeBaoCaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troGiupToolStripMenuItem;
        private ToolStripMenuItem chươngTrìnhKhungToolStripMenuItem;
    }
}