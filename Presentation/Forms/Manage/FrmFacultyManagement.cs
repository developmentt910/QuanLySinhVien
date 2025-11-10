using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.ManageCourse
{
    public partial class FrmFacultyManagement : Form
    {
        public FrmFacultyManagement()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đăngNhậpToolStripMenuItem = new ToolStripMenuItem();
            quanLýSinhViênToolStripMenuItem = new ToolStripMenuItem();
            thôngTinSinhViênToolStripMenuItem = new ToolStripMenuItem();
            kếtQuảHọcTậpToolStripMenuItem = new ToolStripMenuItem();
            đánhGiáRènLuyệnToolStripMenuItem = new ToolStripMenuItem();
            quảnLýTổngHợpToolStripMenuItem = new ToolStripMenuItem();
            họcKỳToolStripMenuItem = new ToolStripMenuItem();
            khoaToolStripMenuItem = new ToolStripMenuItem();
            ngànhToolStripMenuItem = new ToolStripMenuItem();
            chuyênNgànhToolStripMenuItem = new ToolStripMenuItem();
            lớpHọcToolStripMenuItem = new ToolStripMenuItem();
            mônHọcToolStripMenuItem = new ToolStripMenuItem();
            chươngTrìnhKhungToolStripMenuItem = new ToolStripMenuItem();
            thờiKhóaBiểuToolStripMenuItem = new ToolStripMenuItem();
            thốngKêBáoCáoToolStripMenuItem = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(315, 51);
            label1.Name = "label1";
            label1.Size = new Size(183, 32);
            label1.TabIndex = 0;
            label1.Text = "Quản lý học kỳ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quanLýSinhViênToolStripMenuItem, quảnLýTổngHợpToolStripMenuItem, thốngKêBáoCáoToolStripMenuItem, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(842, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngNhậpToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            đăngNhậpToolStripMenuItem.Size = new Size(224, 26);
            đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
            // 
            // quanLýSinhViênToolStripMenuItem
            // 
            quanLýSinhViênToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinSinhViênToolStripMenuItem, kếtQuảHọcTậpToolStripMenuItem, đánhGiáRènLuyệnToolStripMenuItem });
            quanLýSinhViênToolStripMenuItem.Name = "quanLýSinhViênToolStripMenuItem";
            quanLýSinhViênToolStripMenuItem.Size = new Size(134, 24);
            quanLýSinhViênToolStripMenuItem.Text = "Quản lý sinh viên";
            // 
            // thôngTinSinhViênToolStripMenuItem
            // 
            thôngTinSinhViênToolStripMenuItem.Name = "thôngTinSinhViênToolStripMenuItem";
            thôngTinSinhViênToolStripMenuItem.Size = new Size(224, 26);
            thôngTinSinhViênToolStripMenuItem.Text = "Thông tin sinh viên";
            // 
            // kếtQuảHọcTậpToolStripMenuItem
            // 
            kếtQuảHọcTậpToolStripMenuItem.Name = "kếtQuảHọcTậpToolStripMenuItem";
            kếtQuảHọcTậpToolStripMenuItem.Size = new Size(224, 26);
            kếtQuảHọcTậpToolStripMenuItem.Text = "Kết quả học tập";
            // 
            // đánhGiáRènLuyệnToolStripMenuItem
            // 
            đánhGiáRènLuyệnToolStripMenuItem.Name = "đánhGiáRènLuyệnToolStripMenuItem";
            đánhGiáRènLuyệnToolStripMenuItem.Size = new Size(224, 26);
            đánhGiáRènLuyệnToolStripMenuItem.Text = "Đánh giá rèn luyện";
            // 
            // quảnLýTổngHợpToolStripMenuItem
            // 
            quảnLýTổngHợpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { họcKỳToolStripMenuItem, khoaToolStripMenuItem, ngànhToolStripMenuItem, chuyênNgànhToolStripMenuItem, lớpHọcToolStripMenuItem, mônHọcToolStripMenuItem, chươngTrìnhKhungToolStripMenuItem, thờiKhóaBiểuToolStripMenuItem });
            quảnLýTổngHợpToolStripMenuItem.Name = "quảnLýTổngHợpToolStripMenuItem";
            quảnLýTổngHợpToolStripMenuItem.Size = new Size(138, 24);
            quảnLýTổngHợpToolStripMenuItem.Text = "Quản lý tổng hợp";
            // 
            // họcKỳToolStripMenuItem
            // 
            họcKỳToolStripMenuItem.Name = "họcKỳToolStripMenuItem";
            họcKỳToolStripMenuItem.Size = new Size(224, 26);
            họcKỳToolStripMenuItem.Text = "Học kỳ";
            // 
            // khoaToolStripMenuItem
            // 
            khoaToolStripMenuItem.Name = "khoaToolStripMenuItem";
            khoaToolStripMenuItem.Size = new Size(224, 26);
            khoaToolStripMenuItem.Text = "Khoa";
            // 
            // ngànhToolStripMenuItem
            // 
            ngànhToolStripMenuItem.Name = "ngànhToolStripMenuItem";
            ngànhToolStripMenuItem.Size = new Size(224, 26);
            ngànhToolStripMenuItem.Text = "Ngành";
            // 
            // chuyênNgànhToolStripMenuItem
            // 
            chuyênNgànhToolStripMenuItem.Name = "chuyênNgànhToolStripMenuItem";
            chuyênNgànhToolStripMenuItem.Size = new Size(224, 26);
            chuyênNgànhToolStripMenuItem.Text = "Chuyên ngành";
            // 
            // lớpHọcToolStripMenuItem
            // 
            lớpHọcToolStripMenuItem.Name = "lớpHọcToolStripMenuItem";
            lớpHọcToolStripMenuItem.Size = new Size(224, 26);
            lớpHọcToolStripMenuItem.Text = "Lớp học";
            // 
            // mônHọcToolStripMenuItem
            // 
            mônHọcToolStripMenuItem.Name = "mônHọcToolStripMenuItem";
            mônHọcToolStripMenuItem.Size = new Size(224, 26);
            mônHọcToolStripMenuItem.Text = "Môn học";
            // 
            // chươngTrìnhKhungToolStripMenuItem
            // 
            chươngTrìnhKhungToolStripMenuItem.Name = "chươngTrìnhKhungToolStripMenuItem";
            chươngTrìnhKhungToolStripMenuItem.Size = new Size(224, 26);
            chươngTrìnhKhungToolStripMenuItem.Text = "Chương trình khung";
            // 
            // thờiKhóaBiểuToolStripMenuItem
            // 
            thờiKhóaBiểuToolStripMenuItem.Name = "thờiKhóaBiểuToolStripMenuItem";
            thờiKhóaBiểuToolStripMenuItem.Size = new Size(224, 26);
            thờiKhóaBiểuToolStripMenuItem.Text = "Thời khóa biểu";
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            thốngKêBáoCáoToolStripMenuItem.Size = new Size(152, 24);
            thốngKêBáoCáoToolStripMenuItem.Text = "Thống kê / Báo cáo";
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(78, 24);
            trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 119);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Ngành:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 165);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 3;
            label3.Text = "Học kỳ:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(229, 111);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(486, 28);
            comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(229, 157);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(486, 28);
            comboBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(141, 216);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 6;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(367, 216);
            button2.Name = "button2";
            button2.Size = new Size(102, 38);
            button2.TabIndex = 7;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(600, 216);
            button3.Name = "button3";
            button3.Size = new Size(102, 38);
            button3.TabIndex = 8;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            // 
            // FrmFacultyManagement
            // 
            ClientSize = new Size(842, 501);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "FrmFacultyManagement";
            Text = "FrmFacultyManagement.";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private ToolStripMenuItem quanLýSinhViênToolStripMenuItem;
        private ToolStripMenuItem thôngTinSinhViênToolStripMenuItem;
        private ToolStripMenuItem kếtQuảHọcTậpToolStripMenuItem;
        private ToolStripMenuItem đánhGiáRènLuyệnToolStripMenuItem;
        private ToolStripMenuItem quảnLýTổngHợpToolStripMenuItem;
        private ToolStripMenuItem họcKỳToolStripMenuItem;
        private ToolStripMenuItem khoaToolStripMenuItem;
        private ToolStripMenuItem ngànhToolStripMenuItem;
        private ToolStripMenuItem chuyênNgànhToolStripMenuItem;
        private ToolStripMenuItem lớpHọcToolStripMenuItem;
        private ToolStripMenuItem mônHọcToolStripMenuItem;
        private ToolStripMenuItem chươngTrìnhKhungToolStripMenuItem;
        private ToolStripMenuItem thờiKhóaBiểuToolStripMenuItem;
        private ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
