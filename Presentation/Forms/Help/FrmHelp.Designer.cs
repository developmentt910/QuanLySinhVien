namespace StudentCourseManagement.Presentation.Forms.Help
{
    partial class FrmHelp
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
            pnlMenu = new Panel();
            btnAbout = new Button();
            btnFAQ = new Button();
            btnSupport = new Button();
            pnlContent = new Panel();
            pnlSupport = new Panel();
            lblSupportEmail = new Label();
            lblSupportPhone = new Label();
            label2 = new Label();
            pnlFAQ = new Panel();
            linkFAQ3 = new LinkLabel();
            linkFAQ2 = new LinkLabel();
            linkFAQ1 = new LinkLabel();
            label3 = new Label();
            pnlAbout = new Panel();
            txtAboutInfo = new TextBox();
            lblCopyright = new Label();
            lblVersion = new Label();
            lblAppName = new Label();
            btnClose = new Button();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSupport.SuspendLayout();
            pnlFAQ.SuspendLayout();
            pnlAbout.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(240, 240, 240);
            pnlMenu.Controls.Add(btnAbout);
            pnlMenu.Controls.Add(btnFAQ);
            pnlMenu.Controls.Add(btnSupport);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(222, 455);
            pnlMenu.TabIndex = 0;
            // 
            // btnAbout
            // 
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAbout.Location = new Point(0, 125);
            btnAbout.Margin = new Padding(3, 4, 3, 4);
            btnAbout.Name = "btnAbout";
            btnAbout.Padding = new Padding(22, 0, 0, 0);
            btnAbout.Size = new Size(222, 62);
            btnAbout.TabIndex = 2;
            btnAbout.Text = "Thông tin";
            btnAbout.TextAlign = ContentAlignment.MiddleLeft;
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnFAQ
            // 
            btnFAQ.FlatAppearance.BorderSize = 0;
            btnFAQ.FlatStyle = FlatStyle.Flat;
            btnFAQ.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFAQ.Location = new Point(0, 62);
            btnFAQ.Margin = new Padding(3, 4, 3, 4);
            btnFAQ.Name = "btnFAQ";
            btnFAQ.Padding = new Padding(22, 0, 0, 0);
            btnFAQ.Size = new Size(222, 62);
            btnFAQ.TabIndex = 1;
            btnFAQ.Text = "Hướng dẫn (FAQ)";
            btnFAQ.TextAlign = ContentAlignment.MiddleLeft;
            btnFAQ.UseVisualStyleBackColor = true;
            btnFAQ.Click += btnFAQ_Click;
            // 
            // btnSupport
            // 
            btnSupport.FlatAppearance.BorderSize = 0;
            btnSupport.FlatStyle = FlatStyle.Flat;
            btnSupport.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSupport.Location = new Point(0, 0);
            btnSupport.Margin = new Padding(3, 4, 3, 4);
            btnSupport.Name = "btnSupport";
            btnSupport.Padding = new Padding(22, 0, 0, 0);
            btnSupport.Size = new Size(222, 62);
            btnSupport.TabIndex = 0;
            btnSupport.Text = "Hỗ trợ Kỹ thuật";
            btnSupport.TextAlign = ContentAlignment.MiddleLeft;
            btnSupport.UseVisualStyleBackColor = true;
            btnSupport.Click += btnSupport_Click;
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.Controls.Add(pnlSupport);
            pnlContent.Controls.Add(pnlFAQ);
            pnlContent.Controls.Add(pnlAbout);
            pnlContent.Location = new Point(222, 0);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(649, 388);
            pnlContent.TabIndex = 1;
            // 
            // pnlSupport
            // 
            pnlSupport.BackColor = Color.White;
            pnlSupport.Controls.Add(lblSupportEmail);
            pnlSupport.Controls.Add(lblSupportPhone);
            pnlSupport.Controls.Add(label2);
            pnlSupport.Dock = DockStyle.Fill;
            pnlSupport.Location = new Point(0, 0);
            pnlSupport.Margin = new Padding(3, 4, 3, 4);
            pnlSupport.Name = "pnlSupport";
            pnlSupport.Size = new Size(649, 388);
            pnlSupport.TabIndex = 0;
            // 
            // lblSupportEmail
            // 
            lblSupportEmail.AutoSize = true;
            lblSupportEmail.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSupportEmail.Location = new Point(33, 162);
            lblSupportEmail.Name = "lblSupportEmail";
            lblSupportEmail.Size = new Size(285, 25);
            lblSupportEmail.TabIndex = 6;
            lblSupportEmail.Text = "Email hỗ trợ: daihoc@edu.vn";
            // 
            // lblSupportPhone
            // 
            lblSupportPhone.AutoSize = true;
            lblSupportPhone.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSupportPhone.Location = new Point(33, 112);
            lblSupportPhone.Name = "lblSupportPhone";
            lblSupportPhone.Size = new Size(213, 25);
            lblSupportPhone.TabIndex = 5;
            lblSupportPhone.Text = "Hotline: 1900 8386 (IT)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 38);
            label2.Name = "label2";
            label2.Size = new Size(300, 29);
            label2.TabIndex = 4;
            label2.Text = "Thông tin Hỗ trợ Kỹ thuật";
            // 
            // pnlFAQ
            // 
            pnlFAQ.BackColor = Color.White;
            pnlFAQ.Controls.Add(linkFAQ3);
            pnlFAQ.Controls.Add(linkFAQ2);
            pnlFAQ.Controls.Add(linkFAQ1);
            pnlFAQ.Controls.Add(label3);
            pnlFAQ.Dock = DockStyle.Fill;
            pnlFAQ.Location = new Point(0, 0);
            pnlFAQ.Margin = new Padding(3, 4, 3, 4);
            pnlFAQ.Name = "pnlFAQ";
            pnlFAQ.Size = new Size(649, 388);
            pnlFAQ.TabIndex = 1;
            // 
            // linkFAQ3
            // 
            linkFAQ3.AutoSize = true;
            linkFAQ3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkFAQ3.Location = new Point(33, 188);
            linkFAQ3.Name = "linkFAQ3";
            linkFAQ3.Size = new Size(529, 25);
            linkFAQ3.TabIndex = 7;
            linkFAQ3.TabStop = true;
            linkFAQ3.Text = "Tại sao tôi không thấy môn học ở form Chương trình khung?";
            linkFAQ3.LinkClicked += linkFAQ3_LinkClicked;
            // 
            // linkFAQ2
            // 
            linkFAQ2.AutoSize = true;
            linkFAQ2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkFAQ2.Location = new Point(33, 138);
            linkFAQ2.Name = "linkFAQ2";
            linkFAQ2.Size = new Size(309, 25);
            linkFAQ2.TabIndex = 6;
            linkFAQ2.TabStop = true;
            linkFAQ2.Text = "Làm thế nào để thêm một Lịch thi?";
            linkFAQ2.LinkClicked += linkFAQ2_LinkClicked;
            // 
            // linkFAQ1
            // 
            linkFAQ1.AutoSize = true;
            linkFAQ1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkFAQ1.Location = new Point(33, 88);
            linkFAQ1.Name = "linkFAQ1";
            linkFAQ1.Size = new Size(377, 25);
            linkFAQ1.TabIndex = 5;
            linkFAQ1.TabStop = true;
            linkFAQ1.Text = "Làm thế nào để thêm một Thời khóa biểu?";
            linkFAQ1.LinkClicked += linkFAQ1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 38);
            label3.Name = "label3";
            label3.Size = new Size(239, 29);
            label3.TabIndex = 4;
            label3.Text = "Câu hỏi thường gặp";
            // 
            // pnlAbout
            // 
            pnlAbout.BackColor = Color.White;
            pnlAbout.Controls.Add(txtAboutInfo);
            pnlAbout.Controls.Add(lblCopyright);
            pnlAbout.Controls.Add(lblVersion);
            pnlAbout.Controls.Add(lblAppName);
            pnlAbout.Dock = DockStyle.Fill;
            pnlAbout.Location = new Point(0, 0);
            pnlAbout.Margin = new Padding(3, 4, 3, 4);
            pnlAbout.Name = "pnlAbout";
            pnlAbout.Size = new Size(649, 388);
            pnlAbout.TabIndex = 2;
            // 
            // txtAboutInfo
            // 
            txtAboutInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAboutInfo.BackColor = Color.White;
            txtAboutInfo.BorderStyle = BorderStyle.None;
            txtAboutInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAboutInfo.Location = new Point(37, 175);
            txtAboutInfo.Margin = new Padding(3, 4, 3, 4);
            txtAboutInfo.Multiline = true;
            txtAboutInfo.Name = "txtAboutInfo";
            txtAboutInfo.ReadOnly = true;
            txtAboutInfo.Size = new Size(587, 188);
            txtAboutInfo.TabIndex = 8;
            txtAboutInfo.Text = "Phần mềm được phát triển bởi [LMKATgi] nhằm mục đích quản lý toàn diện nghiệp vụ đào tạo sinh viên.";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCopyright.Location = new Point(31, 131);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(326, 25);
            lblCopyright.TabIndex = 7;
            lblCopyright.Text = "Copyright © 2025 [LMKAT]";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.Location = new Point(31, 88);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(154, 25);
            lblVersion.TabIndex = 6;
            lblVersion.Text = "Phiên bản: 1.0.0";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.Location = new Point(31, 38);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(327, 29);
            lblAppName.TabIndex = 5;
            lblAppName.Text = "Hệ thống Quản lý Sinh viên";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(733, 395);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(124, 45);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmHelp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(871, 455);
            Controls.Add(btnClose);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(886, 486);
            Name = "FrmHelp";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trợ giúp & Thông tin";
            Load += FrmHelp_Load;
            pnlMenu.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlSupport.ResumeLayout(false);
            pnlSupport.PerformLayout();
            pnlFAQ.ResumeLayout(false);
            pnlFAQ.PerformLayout();
            pnlAbout.ResumeLayout(false);
            pnlAbout.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnFAQ;
        private System.Windows.Forms.Button btnSupport;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSupport;
        private System.Windows.Forms.Panel pnlFAQ;
        private System.Windows.Forms.Panel pnlAbout;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSupportEmail;
        private System.Windows.Forms.Label lblSupportPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkFAQ3;
        private System.Windows.Forms.LinkLabel linkFAQ2;
        private System.Windows.Forms.LinkLabel linkFAQ1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAboutInfo;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAppName;
    }
}