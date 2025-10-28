namespace StudentCourseManagement.Forms.Auth
{
    partial class FrmChangePassword
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
            btnChange = new Button();
            txtOldPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            linkLabel1 = new LinkLabel();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(282, 18);
            label1.Name = "label1";
            label1.Size = new Size(184, 31);
            label1.TabIndex = 0;
            label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(184, 82);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu cũ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(184, 140);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(184, 197);
            label4.Name = "label4";
            label4.Size = new Size(161, 20);
            label4.TabIndex = 3;
            label4.Text = "Xác thực mật khẩu mới";
            // 
            // btnChange
            // 
            btnChange.Location = new Point(115, 278);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(135, 29);
            btnChange.TabIndex = 4;
            btnChange.Text = "Đổi mật khẩu";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(452, 75);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(125, 27);
            txtOldPassword.TabIndex = 5;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(452, 133);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(125, 27);
            txtNewPassword.TabIndex = 6;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(452, 190);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(125, 27);
            txtConfirmPassword.TabIndex = 7;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(606, 287);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(129, 20);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quay lại trang chủ";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(371, 287);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(81, 20);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "Thông báo";
            // 
            // FrmChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMessage);
            Controls.Add(linkLabel1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtOldPassword);
            Controls.Add(btnChange);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmChangePassword";
            Text = "ChangePasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnChange;
        private TextBox txtOldPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private LinkLabel linkLabel1;
        private Label lblMessage;
    }
}