namespace StudentCourseManagement.Presentation.Forms.result
{
    partial class FrmFaculty
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
            label3 = new Label();
            txtTenKhoa = new TextBox();
            btnThayDoi = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            dgv = new DataGridView();
            CLCode = new DataGridViewTextBoxColumn();
            CLName = new DataGridViewTextBoxColumn();
            btnThem = new Button();
            label4 = new Label();
            txtMaKhoa = new TextBox();
            ((ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(453, 33);
            label1.Name = "label1";
            label1.Size = new Size(226, 38);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ KHOA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 188);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 2;
            label3.Text = "Tên khoa";
            // 
            // txtTenKhoa
            // 
            txtTenKhoa.Location = new Point(149, 185);
            txtTenKhoa.Name = "txtTenKhoa";
            txtTenKhoa.Size = new Size(312, 27);
            txtTenKhoa.TabIndex = 4;
            // 
            // btnThayDoi
            // 
            btnThayDoi.Location = new Point(715, 163);
            btnThayDoi.Name = "btnThayDoi";
            btnThayDoi.Size = new Size(94, 29);
            btnThayDoi.TabIndex = 5;
            btnThayDoi.Text = "Thay đổi";
            btnThayDoi.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(845, 162);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(972, 162);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { CLCode, CLName });
            dgv.Location = new Point(66, 238);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(1000, 297);
            dgv.TabIndex = 8;
            // 
            // CLCode
            // 
            CLCode.HeaderText = "Mã khoa";
            CLCode.MinimumWidth = 6;
            CLCode.Name = "CLCode";
            CLCode.Width = 500;
            // 
            // CLName
            // 
            CLName.HeaderText = "Tên khoa";
            CLName.MinimumWidth = 6;
            CLName.Name = "CLName";
            CLName.Width = 500;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(585, 162);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 131);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 10;
            label4.Text = "Mã khoa";
            // 
            // txtMaKhoa
            // 
            txtMaKhoa.Location = new Point(149, 128);
            txtMaKhoa.Name = "txtMaKhoa";
            txtMaKhoa.Size = new Size(312, 27);
            txtMaKhoa.TabIndex = 11;
            // 
            // FrmFaculty
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 575);
            Controls.Add(txtMaKhoa);
            Controls.Add(label4);
            Controls.Add(btnThem);
            Controls.Add(dgv);
            Controls.Add(btnXoa);
            Controls.Add(btnLuu);
            Controls.Add(btnThayDoi);
            Controls.Add(txtTenKhoa);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FrmFaculty";
            Text = "FrmFaculty";
            ((ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox txtTenKhoa;
        private Button btnThayDoi;
        private Button btnLuu;
        private Button btnXoa;
        private DataGridView dgv;
        private Button btnThem;
        private Label label4;
        private TextBox txtMaKhoa;
        private DataGridViewTextBoxColumn CLCode;
        private DataGridViewTextBoxColumn CLName;
    }
}