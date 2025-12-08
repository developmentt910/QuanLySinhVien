namespace StudentCourseManagement.Presentation.Forms.result
{
    partial class Frmpointmanager
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
            lstMonhoc = new ListBox();
            dgvChiTietDiem = new DataGridView();
            MonHoc = new DataGridViewTextBoxColumn();
            Midterm = new DataGridViewTextBoxColumn();
            Other = new DataGridViewTextBoxColumn();
            Finall = new DataGridViewTextBoxColumn();
            k = new DataGridViewTextBoxColumn();
            LetterGrade = new DataGridViewTextBoxColumn();
            Passed = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtMaSV = new TextBox();
            txtNganh = new TextBox();
            txtLop = new TextBox();
            textTenSV = new TextBox();
            txtChuyenNganh = new TextBox();
            btnLuuDiem = new Button();
            btnTimKiem = new Button();
            cboHocKy = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDiem).BeginInit();
            SuspendLayout();
            // 
            // lstMonhoc
            // 
            lstMonhoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstMonhoc.FormattingEnabled = true;
            lstMonhoc.Location = new Point(1, 201);
            lstMonhoc.Name = "lstMonhoc";
            lstMonhoc.Size = new Size(162, 364);
            lstMonhoc.TabIndex = 0;
            // 
            // dgvChiTietDiem
            // 
            dgvChiTietDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietDiem.Columns.AddRange(new DataGridViewColumn[] { MonHoc, Midterm, Other, Finall, k, LetterGrade, Passed });
            dgvChiTietDiem.Location = new Point(169, 201);
            dgvChiTietDiem.Name = "dgvChiTietDiem";
            dgvChiTietDiem.RowHeadersWidth = 51;
            dgvChiTietDiem.Size = new Size(1128, 354);
            dgvChiTietDiem.TabIndex = 1;
            // 
            // MonHoc
            // 
            MonHoc.HeaderText = "Tên môn học";
            MonHoc.MinimumWidth = 6;
            MonHoc.Name = "MonHoc";
            MonHoc.Width = 150;
            // 
            // Midterm
            // 
            Midterm.HeaderText = "Điểm giữa kì(20%)";
            Midterm.MinimumWidth = 6;
            Midterm.Name = "Midterm";
            Midterm.Width = 175;
            // 
            // Other
            // 
            Other.HeaderText = "Điểm khác(10%)";
            Other.MinimumWidth = 6;
            Other.Name = "Other";
            Other.Width = 175;
            // 
            // Finall
            // 
            Finall.HeaderText = "Điểm thi(70%)";
            Finall.MinimumWidth = 6;
            Finall.Name = "Finall";
            Finall.Width = 175;
            // 
            // k
            // 
            k.HeaderText = "Tổng kết môn";
            k.MinimumWidth = 6;
            k.Name = "k";
            k.Width = 150;
            // 
            // LetterGrade
            // 
            LetterGrade.HeaderText = "Điểm chữ";
            LetterGrade.MinimumWidth = 6;
            LetterGrade.Name = "LetterGrade";
            LetterGrade.Width = 125;
            // 
            // Passed
            // 
            Passed.HeaderText = "Kết quả";
            Passed.MinimumWidth = 6;
            Passed.Name = "Passed";
            Passed.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 20);
            label1.TabIndex = 2;
            label1.Text = "Thông tin sinh viên và học kì";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 42);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã SV:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 87);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngành:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 128);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 5;
            label4.Text = "Lớp học:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(561, 42);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 6;
            label5.Text = "Tên sinh viên";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(562, 87);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 7;
            label6.Text = "Chuyên ngành";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(562, 128);
            label7.Name = "label7";
            label7.Size = new Size(108, 20);
            label7.TabIndex = 8;
            label7.Text = "Học kì hiện tại";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(104, 35);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(263, 27);
            txtMaSV.TabIndex = 9;
            // 
            // txtNganh
            // 
            txtNganh.Location = new Point(104, 80);
            txtNganh.Name = "txtNganh";
            txtNganh.Size = new Size(263, 27);
            txtNganh.TabIndex = 10;
            // 
            // txtLop
            // 
            txtLop.Location = new Point(104, 121);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(263, 27);
            txtLop.TabIndex = 11;
            // 
            // textTenSV
            // 
            textTenSV.Location = new Point(684, 39);
            textTenSV.Name = "textTenSV";
            textTenSV.Size = new Size(220, 27);
            textTenSV.TabIndex = 12;
            // 
            // txtChuyenNganh
            // 
            txtChuyenNganh.Location = new Point(684, 87);
            txtChuyenNganh.Name = "txtChuyenNganh";
            txtChuyenNganh.Size = new Size(220, 27);
            txtChuyenNganh.TabIndex = 13;
            // 
            // btnLuuDiem
            // 
            btnLuuDiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuuDiem.Location = new Point(1191, 561);
            btnLuuDiem.Name = "btnLuuDiem";
            btnLuuDiem.Size = new Size(106, 33);
            btnLuuDiem.TabIndex = 15;
            btnLuuDiem.Text = "Lưu csdl";
            btnLuuDiem.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(394, 35);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 27);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // cboHocKy
            // 
            cboHocKy.FormattingEnabled = true;
            cboHocKy.Location = new Point(684, 125);
            cboHocKy.Name = "cboHocKy";
            cboHocKy.Size = new Size(220, 28);
            cboHocKy.TabIndex = 17;
            cboHocKy.SelectedIndexChanged += CboHocKy_SelectedIndexChanged;
            // 
            // Frmpointmanager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1305, 611);
            Controls.Add(cboHocKy);
            Controls.Add(btnTimKiem);
            Controls.Add(btnLuuDiem);
            Controls.Add(txtChuyenNganh);
            Controls.Add(textTenSV);
            Controls.Add(txtLop);
            Controls.Add(txtNganh);
            Controls.Add(txtMaSV);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvChiTietDiem);
            Controls.Add(lstMonhoc);
            Name = "Frmpointmanager";
            Text = "Frmpointmanager";
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMonhoc;
        private DataGridView dgvChiTietDiem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtMaSV;
        private TextBox txtNganh;
        private TextBox txtLop;
        private TextBox textTenSV;
        private TextBox txtChuyenNganh;
        private Button btnLuuDiem;
        private Button btnTimKiem;
        private DataGridViewTextBoxColumn MonHoc;
        private DataGridViewTextBoxColumn Midterm;
        private DataGridViewTextBoxColumn Other;
        private DataGridViewTextBoxColumn Finall;
        private DataGridViewTextBoxColumn k;
        private DataGridViewTextBoxColumn LetterGrade;
        private DataGridViewTextBoxColumn Passed;
        private ComboBox cboHocKy;
    }
}