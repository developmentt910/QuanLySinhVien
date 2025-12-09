namespace StudentCourseManagement.Forms.Auth
{
    partial class FrmLogin
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnLogin = new Button();
            txtMSV = new TextBox();
            txtPassword = new TextBox();
            txtCaptchaInput = new TextBox();
            btnRefreshCaptcha = new Button();
            linkLabel1 = new LinkLabel();
            lblCaptchaCode = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(185, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(551, 38);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP TÀI KHOẢN QUẢN LÝ VIÊN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 120);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 1;
            label2.Text = "Mã đặc quyền";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 182);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 252);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 3;
            label4.Text = "Mã bảo vệ";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Info;
            btnLogin.Location = new Point(261, 351);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(182, 54);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_ClickAsync;
            // 
            // txtMSV
            // 
            txtMSV.Location = new Point(320, 111);
            txtMSV.Margin = new Padding(4, 4, 4, 4);
            txtMSV.Name = "txtMSV";
            txtMSV.Size = new Size(483, 31);
            txtMSV.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(320, 174);
            txtPassword.Margin = new Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(483, 31);
            txtPassword.TabIndex = 6;
            // 
            // txtCaptchaInput
            // 
            txtCaptchaInput.Location = new Point(320, 244);
            txtCaptchaInput.Margin = new Padding(4, 4, 4, 4);
            txtCaptchaInput.Name = "txtCaptchaInput";
            txtCaptchaInput.Size = new Size(483, 31);
            txtCaptchaInput.TabIndex = 7;
            // 
            // btnRefreshCaptcha
            // 
            btnRefreshCaptcha.BackColor = SystemColors.Info;
            btnRefreshCaptcha.Location = new Point(884, 242);
            btnRefreshCaptcha.Margin = new Padding(4, 4, 4, 4);
            btnRefreshCaptcha.Name = "btnRefreshCaptcha";
            btnRefreshCaptcha.Size = new Size(40, 36);
            btnRefreshCaptcha.TabIndex = 8;
            btnRefreshCaptcha.Text = "🔄";
            btnRefreshCaptcha.UseVisualStyleBackColor = false;
            btnRefreshCaptcha.Click += btnRefreshCaptcha_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(574, 361);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(134, 25);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lblCaptchaCode
            // 
            lblCaptchaCode.AutoSize = true;
            lblCaptchaCode.Location = new Point(811, 248);
            lblCaptchaCode.Margin = new Padding(4, 0, 4, 0);
            lblCaptchaCode.Name = "lblCaptchaCode";
            lblCaptchaCode.Size = new Size(0, 25);
            lblCaptchaCode.TabIndex = 11;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 452);
            Controls.Add(lblCaptchaCode);
            Controls.Add(linkLabel1);
            Controls.Add(btnRefreshCaptcha);
            Controls.Add(txtCaptchaInput);
            Controls.Add(txtPassword);
            Controls.Add(txtMSV);
            Controls.Add(btnLogin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FrmLogin";
            Text = "ĐĂNG NHẬP";
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnLogin;
        private TextBox txtMSV;
        private TextBox txtPassword;
        private TextBox txtCaptchaInput;
        private Button btnRefreshCaptcha;
        private LinkLabel linkLabel1;
        private Label lblCaptchaCode;
    }
}