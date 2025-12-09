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
            label1 = new Label();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(30, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(257, 25);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "OTP đã gửi tới email của bạn";
            // 
            // txtOtp
            // 
            txtOtp.Font = new Font("Segoe UI", 12F);
            txtOtp.Location = new Point(80, 112);
            txtOtp.Name = "txtOtp";
            txtOtp.Size = new Size(416, 34);
            txtOtp.TabIndex = 1;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.FromArgb(46, 204, 113);
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = Color.Black;
            btnVerify.Location = new Point(117, 183);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(158, 40);
            btnVerify.TabIndex = 2;
            btnVerify.Text = "Xác nhận OTP";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            // 
            // btnResend
            // 
            btnResend.BackColor = Color.FromArgb(0, 192, 192);
            btnResend.FlatStyle = FlatStyle.Flat;
            btnResend.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResend.ForeColor = Color.Black;
            btnResend.Location = new Point(300, 183);
            btnResend.Name = "btnResend";
            btnResend.Size = new Size(158, 40);
            btnResend.TabIndex = 3;
            btnResend.Text = "Gửi lại mã";
            btnResend.UseVisualStyleBackColor = false;
            btnResend.Click += btnResend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(80, 92);
            label1.Name = "label1";
            label1.Size = new Size(114, 17);
            label1.TabIndex = 4;
            label1.Text = "Vui lòng nhập OTP";
            // 
            // FrmEnterOtp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 249);
            Controls.Add(label1);
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

        private Label label1;
    }
}
