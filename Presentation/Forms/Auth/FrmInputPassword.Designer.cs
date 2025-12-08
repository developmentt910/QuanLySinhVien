namespace StudentCourseManagement.Presentation.Forms.Auth
{
    partial class FrmInputPassword
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
            sqlCommand1 = new SqlCommand();
            label2 = new Label();
            txtNew = new TextBox();
            txtReNew = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 78);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhập mật khẩu mới";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 163);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập lại";
            // 
            // txtNew
            // 
            txtNew.Location = new Point(309, 78);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(389, 27);
            txtNew.TabIndex = 2;
            // 
            // txtReNew
            // 
            txtReNew.Location = new Point(309, 163);
            txtReNew.Name = "txtReNew";
            txtReNew.Size = new Size(389, 27);
            txtReNew.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(643, 261);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(145, 33);
            btnSend.TabIndex = 4;
            btnSend.Text = "Gửi yêu cầu";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // FrmInputPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 306);
            Controls.Add(btnSend);
            Controls.Add(txtReNew);
            Controls.Add(txtNew);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmInputPassword";
            Text = "FrmInputPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private SqlCommand sqlCommand1;
        private Label label2;
        private TextBox txtNew;
        private TextBox txtReNew;
        private Button btnSend;
    }
}