namespace StudentCourseManagement.Presentation.Forms.Auth
{
    partial class FrmLoginAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblMDQ = new Label();
            sqlCommand1 = new SqlCommand();
            lblCaptchaCode = new Label();
            btnRefreshCaptcha = new Button();
            lbl = new Label();
            txtCaptchaInput = new TextBox();
            txtMDQ = new TextBox();
            btnLogin = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(233, 25);
            label1.Name = "label1";
            label1.Size = new Size(316, 31);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP QUẢN LÝ VIÊN\r\n";
            // 
            // lblMDQ
            // 
            lblMDQ.AutoSize = true;
            lblMDQ.Location = new Point(177, 104);
            lblMDQ.Name = "lblMDQ";
            lblMDQ.Size = new Size(102, 20);
            lblMDQ.TabIndex = 1;
            lblMDQ.Text = "Mã đặc quyền";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // lblCaptchaCode
            // 
            lblCaptchaCode.AutoSize = true;
            lblCaptchaCode.Location = new Point(637, 169);
            lblCaptchaCode.Name = "lblCaptchaCode";
            lblCaptchaCode.Size = new Size(0, 20);
            lblCaptchaCode.TabIndex = 7;
            lblCaptchaCode.TextAlign = ContentAlignment.TopRight;
            // 
            // btnRefreshCaptcha
            // 
            btnRefreshCaptcha.Location = new Point(709, 165);
            btnRefreshCaptcha.Name = "btnRefreshCaptcha";
            btnRefreshCaptcha.Size = new Size(32, 29);
            btnRefreshCaptcha.TabIndex = 9;
            btnRefreshCaptcha.Text = "🔄";
            btnRefreshCaptcha.UseVisualStyleBackColor = true;
            btnRefreshCaptcha.Click += btnRefreshCaptcha_Click;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(177, 162);
            lbl.Name = "lbl";
            lbl.Size = new Size(79, 20);
            lbl.TabIndex = 10;
            lbl.Text = "Mã bảo vệ";
            // 
            // txtCaptchaInput
            // 
            txtCaptchaInput.Location = new Point(389, 162);
            txtCaptchaInput.Name = "txtCaptchaInput";
            txtCaptchaInput.Size = new Size(207, 27);
            txtCaptchaInput.TabIndex = 11;
            // 
            // txtMDQ
            // 
            txtMDQ.Location = new Point(389, 101);
            txtMDQ.Name = "txtMDQ";
            txtMDQ.Size = new Size(207, 27);
            txtMDQ.TabIndex = 13;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(249, 253);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(154, 29);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(460, 262);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(157, 20);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quay về trang đăng ký";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // FrmLoginAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(btnLogin);
            Controls.Add(txtMDQ);
            Controls.Add(txtCaptchaInput);
            Controls.Add(lbl);
            Controls.Add(btnRefreshCaptcha);
            Controls.Add(lblCaptchaCode);
            Controls.Add(lblMDQ);
            Controls.Add(label1);
            Name = "FrmLoginAdmin";
            Load += FrmLoginAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblMDQ;
        private SqlCommand sqlCommand1;
        private Label lblCaptchaCode;
        private Button btnRefreshCaptcha;
        private Label lbl;
        private TextBox txtCaptchaInput;
        private TextBox txtMDQ;
        private Button btnLogin;
        private LinkLabel linkLabel1;
    }
}