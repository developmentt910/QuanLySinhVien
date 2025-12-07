namespace StudentCourseManagement.Presentation.Forms.Auth
{
    partial class FrmForgotPassword
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
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Text = "FrmForgorPassword";
        //}

        #endregion
        private Label lblTitle;
        private Label lblEmail;

        private TextBox txtEmail;

        private Button btnSendOtp;
        private Button btnBack;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSendOtp = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 160);
            lblTitle.Location = new Point(140, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(253, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUÊN MẬT KHẨU";
            // 
            // lblEmail
            // 
            lblEmail.ForeColor = Color.FromArgb(60, 60, 60);
            lblEmail.Location = new Point(57, 111);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(70, 23);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(192, 107);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 31);
            txtEmail.TabIndex = 5;
            // 
            // btnSendOtp
            // 
            btnSendOtp.BackColor = Color.FromArgb(0, 120, 215);
            btnSendOtp.Cursor = Cursors.Hand;
            btnSendOtp.FlatAppearance.BorderSize = 0;
            btnSendOtp.FlatStyle = FlatStyle.Flat;
            btnSendOtp.ForeColor = Color.White;
            btnSendOtp.Location = new Point(172, 193);
            btnSendOtp.Name = "btnSendOtp";
            btnSendOtp.Size = new Size(157, 33);
            btnSendOtp.TabIndex = 9;
            btnSendOtp.Text = "Gửi yêu cầu";
            btnSendOtp.UseVisualStyleBackColor = false;
            btnSendOtp.Click += btnSendOtp_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.FromArgb(0, 102, 204);
            btnBack.Location = new Point(336, 293);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 31);
            btnBack.TabIndex = 11;
            btnBack.Text = "← Quay lại đăng nhập";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // FrmForgotPassword
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(532, 336);
            Controls.Add(lblTitle);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnSendOtp);
            Controls.Add(btnBack);
            Name = "FrmForgotPassword";
            ResumeLayout(false);
            PerformLayout();


        }




    }
}