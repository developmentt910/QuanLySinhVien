using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.Auth
{
    partial class FrmEnterOtp
    {
        private System.ComponentModel.IContainer components = null;

        // 🔥 BẮT BUỘC KHAI BÁO FIELD Ở ĐÂY (ĐỂ FORM BIẾT TỒN TẠI CONTROL)
        private Label lblEmail;
        private TextBox txtOtp;
        private Button btnVerify;
        private Button btnResend;

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
            lblEmail = new Label();
            txtOtp = new TextBox();
            btnVerify = new Button();
            btnResend = new Button();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(30, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(243, 23);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "OTP đã gửi tới email của bạn";
            // 
            // txtOtp
            // 
            txtOtp.Font = new Font("Segoe UI", 12F);
            txtOtp.Location = new Point(101, 85);
            txtOtp.Name = "txtOtp";
            txtOtp.PlaceholderText = "Nhập mã OTP 6 số";
            txtOtp.Size = new Size(416, 34);
            txtOtp.TabIndex = 1;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(46, 204, 113);
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(47, 157);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(226, 40);
            btnVerify.TabIndex = 2;
            btnVerify.Text = "Xác nhận OTP";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // btnResend
            // 
            btnResend.BackColor = Color.FromArgb(52, 152, 219);
            btnResend.FlatStyle = FlatStyle.Flat;
            btnResend.ForeColor = Color.White;
            btnResend.Location = new Point(350, 157);
            btnResend.Name = "btnResend";
            btnResend.Size = new Size(226, 40);
            btnResend.TabIndex = 3;
            btnResend.Text = "Gửi lại mã";
            btnResend.UseVisualStyleBackColor = false;
            btnResend.Click += btnResend_Click;
            // 
            // FrmEnterOtp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 260);
            Controls.Add(lblEmail);
            Controls.Add(txtOtp);
            Controls.Add(btnVerify);
            Controls.Add(btnResend);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmEnterOtp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác thực OTP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
