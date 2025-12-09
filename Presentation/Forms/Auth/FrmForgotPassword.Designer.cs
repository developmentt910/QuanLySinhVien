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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Stencil", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(192, 0, 192);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(401, 53);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MNI HIALLSHAPE";
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(60, 60, 60);
            lblEmail.Location = new Point(124, 176);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(70, 23);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(124, 202);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(674, 31);
            txtEmail.TabIndex = 5;
            // 
            // btnSendOtp
            // 
            btnSendOtp.BackColor = Color.FromArgb(0, 120, 215);
            btnSendOtp.Cursor = Cursors.Hand;
            btnSendOtp.FlatAppearance.BorderSize = 0;
            btnSendOtp.FlatStyle = FlatStyle.Flat;
            btnSendOtp.ForeColor = Color.White;
            btnSendOtp.Location = new Point(319, 265);
            btnSendOtp.Name = "btnSendOtp";
            btnSendOtp.Size = new Size(157, 33);
            btnSendOtp.TabIndex = 9;
            btnSendOtp.Text = "Tiếp tục";
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
            btnBack.Location = new Point(664, 335);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(214, 31);
            btnBack.TabIndex = 11;
            btnBack.Text = "<- Quay lại đăng nhập";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Display", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 63);
            label1.Name = "label1";
            label1.Size = new Size(216, 40);
            label1.TabIndex = 12;
            label1.Text = "Quên mật khẩu ?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(124, 117);
            label2.Name = "label2";
            label2.Size = new Size(821, 26);
            label2.TabIndex = 13;
            label2.Text = "Nếu bạn quên mật khẩu, hãy làm theo những bước sau đây để khôi phục lại mật khẩu của bạn.  ";
            // 
            // FrmForgotPassword
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(963, 364);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnSendOtp);
            Controls.Add(btnBack);
            Name = "FrmForgotPassword";
            ResumeLayout(false);
            PerformLayout();


        }
        private Label label1;
        private Label label2;
    }
}