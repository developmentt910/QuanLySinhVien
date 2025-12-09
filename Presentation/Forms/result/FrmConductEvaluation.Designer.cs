namespace StudentCourseManagement.Presentation.Forms.result
{
    partial class FrmConductEvaluation: Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtKhoa = new TextBox();
            txtMaSv = new TextBox();
            txtHoTen = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            label5 = new Label();
            label6 = new Label();
            txtLop = new TextBox();
            txtDiemRenLuyen = new TextBox();
            txtXepLoai = new TextBox();
            label7 = new Label();
            label8 = new Label();
            dgvRenLuyen = new DataGridView();
            label9 = new Label();
            btnXoa = new Button();
            label10 = new Label();
            cboHocKi = new ComboBox();
            btnTimKiem = new Button();
            txtGhiChu = new TextBox();
            label11 = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)dgvRenLuyen).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(372, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(423, 61);
            label1.TabIndex = 0;
            label1.Text = "Đánh giá rèn luyện";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 119);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(234, 32);
            label2.TabIndex = 1;
            label2.Text = "Thông tin sinh viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 186);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 25);
            label3.TabIndex = 2;
            label3.Text = "Mã SV";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(112, 236);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 3;
            label4.Text = "Họ tên";
            // 
            // txtKhoa
            // 
            txtKhoa.Location = new Point(236, 288);
            txtKhoa.Margin = new Padding(4, 4, 4, 4);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.Size = new Size(259, 31);
            txtKhoa.TabIndex = 4;
            // 
            // txtMaSv
            // 
            txtMaSv.Location = new Point(236, 178);
            txtMaSv.Margin = new Padding(4, 4, 4, 4);
            txtMaSv.Name = "txtMaSv";
            txtMaSv.Size = new Size(624, 31);
            txtMaSv.TabIndex = 5;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(236, 228);
            txtHoTen.Margin = new Padding(4, 4, 4, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(624, 31);
            txtHoTen.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(301, 826);
            btnThem.Margin = new Padding(4, 4, 4, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(136, 42);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(512, 826);
            btnSua.Margin = new Padding(4, 4, 4, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(136, 40);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(112, 296);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 25);
            label5.TabIndex = 9;
            label5.Text = "Khoa";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(522, 291);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 25);
            label6.TabIndex = 10;
            label6.Text = "Lớp";
            // 
            // txtLop
            // 
            txtLop.Location = new Point(604, 288);
            txtLop.Margin = new Padding(4, 4, 4, 4);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(256, 31);
            txtLop.TabIndex = 11;
            // 
            // txtDiemRenLuyen
            // 
            txtDiemRenLuyen.Location = new Point(202, 738);
            txtDiemRenLuyen.Margin = new Padding(4, 4, 4, 4);
            txtDiemRenLuyen.Name = "txtDiemRenLuyen";
            txtDiemRenLuyen.Size = new Size(362, 31);
            txtDiemRenLuyen.TabIndex = 12;
            // 
            // txtXepLoai
            // 
            txtXepLoai.Location = new Point(782, 738);
            txtXepLoai.Margin = new Padding(4, 4, 4, 4);
            txtXepLoai.Name = "txtXepLoai";
            txtXepLoai.Size = new Size(362, 31);
            txtXepLoai.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 741);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(131, 25);
            label7.TabIndex = 14;
            label7.Text = "Điểm rèn luyện";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(620, 741);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 15;
            label8.Text = "Xếp loại";
            // 
            // dgvRenLuyen
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRenLuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRenLuyen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRenLuyen.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvRenLuyen.DefaultCellStyle = dataGridViewCellStyle6;
            dgvRenLuyen.Location = new Point(22, 432);
            dgvRenLuyen.Margin = new Padding(4, 4, 4, 4);
            dgvRenLuyen.Name = "dgvRenLuyen";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvRenLuyen.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvRenLuyen.RowHeadersWidth = 51;
            dgvRenLuyen.Size = new Size(1168, 185);
            dgvRenLuyen.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.Highlight;
            label9.Location = new Point(29, 386);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(185, 30);
            label9.TabIndex = 17;
            label9.Text = "Nội dung chi tiết";
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(725, 824);
            btnXoa.Margin = new Padding(4, 4, 4, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(136, 42);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(44, 682);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(62, 25);
            label10.TabIndex = 20;
            label10.Text = "Học kì";
            // 
            // cboHocKi
            // 
            cboHocKi.FormattingEnabled = true;
            cboHocKi.Location = new Point(202, 672);
            cboHocKi.Margin = new Padding(4, 4, 4, 4);
            cboHocKi.Name = "cboHocKi";
            cboHocKi.Size = new Size(362, 33);
            cboHocKi.TabIndex = 21;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(900, 175);
            btnTimKiem.Margin = new Padding(4, 4, 4, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(136, 39);
            btnTimKiem.TabIndex = 22;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(782, 668);
            txtGhiChu.Margin = new Padding(4, 4, 4, 4);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(362, 31);
            txtGhiChu.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(620, 676);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(71, 25);
            label11.TabIndex = 24;
            label11.Text = "Ghi chú";
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Column1.DefaultCellStyle = dataGridViewCellStyle2;
            Column1.HeaderText = "Học kì";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 292;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Column2.DefaultCellStyle = dataGridViewCellStyle3;
            Column2.HeaderText = "Điểm rèn luyện";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 292;
            // 
            // Column3
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Column3.DefaultCellStyle = dataGridViewCellStyle4;
            Column3.HeaderText = "Xếp loại";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 292;
            // 
            // Column4
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Column4.DefaultCellStyle = dataGridViewCellStyle5;
            Column4.HeaderText = "Ghi chú";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 292;
            // 
            // FrmConductEvaluation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 892);
            Controls.Add(label11);
            Controls.Add(txtGhiChu);
            Controls.Add(btnTimKiem);
            Controls.Add(cboHocKi);
            Controls.Add(label10);
            Controls.Add(btnXoa);
            Controls.Add(label9);
            Controls.Add(dgvRenLuyen);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtXepLoai);
            Controls.Add(txtDiemRenLuyen);
            Controls.Add(txtLop);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaSv);
            Controls.Add(txtKhoa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FrmConductEvaluation";
            Text = "FrmConductEvaluation";
            ((ISupportInitialize)dgvRenLuyen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtKhoa;
        private TextBox txtMaSv;
        private TextBox txtHoTen;
        private Button btnThem;
        private Button btnSua;
        private Label label5;
        private Label label6;
        private TextBox txtLop;
        private TextBox txtDiemRenLuyen;
        private TextBox txtXepLoai;
        private Label label7;
        private Label label8;
        private DataGridView dgvRenLuyen;
        private Label label9;
        private Button btnXoa;
        private Label label10;
        private ComboBox cboHocKi;
        private Button btnTimKiem;
        private TextBox txtGhiChu;
        private Label label11;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}