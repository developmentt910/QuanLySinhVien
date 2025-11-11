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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnFAQ = new System.Windows.Forms.Button();
            this.btnSupport = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSupport = new System.Windows.Forms.Panel();
            this.lblSupportEmail = new System.Windows.Forms.Label();
            this.lblSupportPhone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFAQ = new System.Windows.Forms.Panel();
            this.linkFAQ3 = new System.Windows.Forms.LinkLabel();
            this.linkFAQ2 = new System.Windows.Forms.LinkLabel();
            this.linkFAQ1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.txtAboutInfo = new System.Windows.Forms.TextBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSupport.SuspendLayout();
            this.pnlFAQ.SuspendLayout();
            this.pnlAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlMenu.Controls.Add(this.btnAbout);
            this.pnlMenu.Controls.Add(this.btnFAQ);
            this.pnlMenu.Controls.Add(this.btnSupport);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 364);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(0, 100);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAbout.Size = new System.Drawing.Size(200, 50);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "Thông tin";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnFAQ
            // 
            this.btnFAQ.FlatAppearance.BorderSize = 0;
            this.btnFAQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFAQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFAQ.Location = new System.Drawing.Point(0, 50);
            this.btnFAQ.Name = "btnFAQ";
            this.btnFAQ.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnFAQ.Size = new System.Drawing.Size(200, 50);
            this.btnFAQ.TabIndex = 1;
            this.btnFAQ.Text = "Hướng dẫn (FAQ)";
            this.btnFAQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFAQ.UseVisualStyleBackColor = true;
            this.btnFAQ.Click += new System.EventHandler(this.btnFAQ_Click);
            // 
            // btnSupport
            // 
            this.btnSupport.FlatAppearance.BorderSize = 0;
            this.btnSupport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupport.Location = new System.Drawing.Point(0, 0);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSupport.Size = new System.Drawing.Size(200, 50);
            this.btnSupport.TabIndex = 0;
            this.btnSupport.Text = "Hỗ trợ Kỹ thuật";
            this.btnSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupport.UseVisualStyleBackColor = true;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Controls.Add(this.pnlSupport);
            this.pnlContent.Controls.Add(this.pnlFAQ);
            this.pnlContent.Controls.Add(this.pnlAbout);
            this.pnlContent.Location = new System.Drawing.Point(200, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(584, 310);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlSupport
            // 
            this.pnlSupport.BackColor = System.Drawing.Color.White;
            this.pnlSupport.Controls.Add(this.lblSupportEmail);
            this.pnlSupport.Controls.Add(this.lblSupportPhone);
            this.pnlSupport.Controls.Add(this.label2);
            this.pnlSupport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSupport.Location = new System.Drawing.Point(0, 0);
            this.pnlSupport.Name = "pnlSupport";
            this.pnlSupport.Size = new System.Drawing.Size(584, 310);
            this.pnlSupport.TabIndex = 0;
            // 
            // lblSupportEmail
            // 
            this.lblSupportEmail.AutoSize = true;
            this.lblSupportEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupportEmail.Location = new System.Drawing.Point(30, 130);
            this.lblSupportEmail.Name = "lblSupportEmail";
            this.lblSupportEmail.Size = new System.Drawing.Size(263, 25);
            this.lblSupportEmail.TabIndex = 6;
            this.lblSupportEmail.Text = "Email hỗ trợ: taokyngucfan2k5@edu.vn";
            // 
            // lblSupportPhone
            // 
            this.lblSupportPhone.AutoSize = true;
            this.lblSupportPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupportPhone.Location = new System.Drawing.Point(30, 90);
            this.lblSupportPhone.Name = "lblSupportPhone";
            this.lblSupportPhone.Size = new System.Drawing.Size(209, 25);
            this.lblSupportPhone.TabIndex = 5;
            this.lblSupportPhone.Text = "Hotline: 1900 3636 (IT)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thông tin Hỗ trợ Kỹ thuật";
            // 
            // pnlFAQ
            // 
            this.pnlFAQ.BackColor = System.Drawing.Color.White;
            this.pnlFAQ.Controls.Add(this.linkFAQ3);
            this.pnlFAQ.Controls.Add(this.linkFAQ2);
            this.pnlFAQ.Controls.Add(this.linkFAQ1);
            this.pnlFAQ.Controls.Add(this.label3);
            this.pnlFAQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFAQ.Location = new System.Drawing.Point(0, 0);
            this.pnlFAQ.Name = "pnlFAQ";
            this.pnlFAQ.Size = new System.Drawing.Size(584, 310);
            this.pnlFAQ.TabIndex = 1;
            // 
            // linkFAQ3
            // 
            this.linkFAQ3.AutoSize = true;
            this.linkFAQ3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkFAQ3.Location = new System.Drawing.Point(30, 150);
            this.linkFAQ3.Name = "linkFAQ3";
            this.linkFAQ3.Size = new System.Drawing.Size(465, 25);
            this.linkFAQ3.TabIndex = 7;
            this.linkFAQ3.TabStop = true;
            this.linkFAQ3.Text = "Tại sao tôi không thấy môn học ở form Chương trình khung?";
            this.linkFAQ3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFAQ3_LinkClicked);
            // 
            // linkFAQ2
            // 
            this.linkFAQ2.AutoSize = true;
            this.linkFAQ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkFAQ2.Location = new System.Drawing.Point(30, 110);
            this.linkFAQ2.Name = "linkFAQ2";
            this.linkFAQ2.Size = new System.Drawing.Size(309, 25);
            this.linkFAQ2.TabIndex = 6;
            this.linkFAQ2.TabStop = true;
            this.linkFAQ2.Text = "Làm thế nào để thêm một Lịch thi?";
            this.linkFAQ2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFAQ2_LinkClicked);
            // 
            // linkFAQ1
            // 
            this.linkFAQ1.AutoSize = true;
            this.linkFAQ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkFAQ1.Location = new System.Drawing.Point(30, 70);
            this.linkFAQ1.Name = "linkFAQ1";
            this.linkFAQ1.Size = new System.Drawing.Size(342, 25);
            this.linkFAQ1.TabIndex = 5;
            this.linkFAQ1.TabStop = true;
            this.linkFAQ1.Text = "Làm thế nào để thêm một Thời khóa biểu?";
            this.linkFAQ1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFAQ1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Câu hỏi thường gặp";
            // 
            // pnlAbout
            // 
            this.pnlAbout.BackColor = System.Drawing.Color.White;
            this.pnlAbout.Controls.Add(this.txtAboutInfo);
            this.pnlAbout.Controls.Add(this.lblCopyright);
            this.pnlAbout.Controls.Add(this.lblVersion);
            this.pnlAbout.Controls.Add(this.lblAppName);
            this.pnlAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAbout.Location = new System.Drawing.Point(0, 0);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(584, 310);
            this.pnlAbout.TabIndex = 2;
            // 
            // txtAboutInfo
            // 
            this.txtAboutInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAboutInfo.BackColor = System.Drawing.Color.White;
            this.txtAboutInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAboutInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAboutInfo.Location = new System.Drawing.Point(33, 140);
            this.txtAboutInfo.Multiline = true;
            this.txtAboutInfo.Name = "txtAboutInfo";
            this.txtAboutInfo.ReadOnly = true;
            this.txtAboutInfo.Size = new System.Drawing.Size(528, 150);
            this.txtAboutInfo.TabIndex = 8;
            this.txtAboutInfo.Text = "Phần mềm được phát triển bởi [taokyngucfan] nhằm mục đích quản lý toàn diện ng" +
    "hiệp vụ đào tạo sinh viên.";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(28, 105);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(326, 25);
            this.lblCopyright.TabIndex = 7;
            this.lblCopyright.Text = "Copyright © 2025 [Tên Trường/Bạn]";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(28, 70);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(147, 25);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "Phiên bản: 1.0.0";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(28, 30);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(351, 29);
            this.lblAppName.TabIndex = 5;
            this.lblAppName.Text = "Hệ thống Quản lý Sinh viên";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(660, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 364);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "FrmHelp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trợ giúp & Thông tin";
            this.Load += new System.EventHandler(this.FrmHelp_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlSupport.ResumeLayout(false);
            this.pnlSupport.PerformLayout();
            this.pnlFAQ.ResumeLayout(false);
            this.pnlFAQ.PerformLayout();
            this.pnlAbout.ResumeLayout(false);
            this.pnlAbout.PerformLayout();
            this.ResumeLayout(false);

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