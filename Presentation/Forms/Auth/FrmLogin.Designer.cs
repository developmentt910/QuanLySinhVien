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
            label1.Location = new Point(148, 30);
            label1.Name = "label1";
            label1.Size = new Size(447, 31);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP TÀI KHOẢN QUẢN LÝ VIÊN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 96);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã đặc quyền";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 146);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 202);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 3;
            label4.Text = "Mã bảo vệ";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Info;
            btnLogin.Location = new Point(209, 281);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(146, 43);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_ClickAsync;
            // 
            // txtMSV
            // 
            txtMSV.Location = new Point(256, 89);
            txtMSV.Name = "txtMSV";
            txtMSV.Size = new Size(387, 27);
            txtMSV.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(256, 139);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(387, 27);
            txtPassword.TabIndex = 6;
            // 
            // txtCaptchaInput
            // 
            txtCaptchaInput.Location = new Point(256, 195);
            txtCaptchaInput.Name = "txtCaptchaInput";
            txtCaptchaInput.Size = new Size(387, 27);
            txtCaptchaInput.TabIndex = 7;
            // 
            // btnRefreshCaptcha
            // 
            btnRefreshCaptcha.BackColor = SystemColors.Info;
            btnRefreshCaptcha.Location = new Point(707, 194);
            btnRefreshCaptcha.Name = "btnRefreshCaptcha";
            btnRefreshCaptcha.Size = new Size(32, 29);
            btnRefreshCaptcha.TabIndex = 8;
            btnRefreshCaptcha.Text = "🔄";
            btnRefreshCaptcha.UseVisualStyleBackColor = false;
            btnRefreshCaptcha.Click += btnRefreshCaptcha_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(459, 289);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 20);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // lblCaptchaCode
            // 
            lblCaptchaCode.AutoSize = true;
            lblCaptchaCode.Location = new Point(649, 198);
            lblCaptchaCode.Name = "lblCaptchaCode";
            lblCaptchaCode.Size = new Size(0, 20);
            lblCaptchaCode.TabIndex = 11;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 362);
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