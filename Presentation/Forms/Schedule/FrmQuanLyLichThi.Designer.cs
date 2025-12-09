namespace StudentCourseManagement.Presentation.Forms.Schedule
{
    partial class FrmQuanLyLichThi
    {
        private System.ComponentModel.IContainer components = null;

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
            dgvLichThi = new DataGridView();
            groupBox1 = new GroupBox();
            cboChuyenNganh = new ComboBox();
            label9 = new Label();
            cboNganh = new ComboBox();
            label10 = new Label();
            cboKhoa = new ComboBox();
            label11 = new Label();
            cboSemester = new ComboBox();
            label8 = new Label();
            txtPhongThi = new TextBox();
            label7 = new Label();
            cboHinhThucThi = new ComboBox();
            label6 = new Label();
            numThoiGianLamBai = new NumericUpDown();
            label5 = new Label();
            dtpExamDateTime = new DateTimePicker();
            label3 = new Label();
            cboMonHoc = new ComboBox();
            label2 = new Label();
            cboLopHoc = new ComboBox();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            lblTitle = new Label();
            ((ISupportInitialize)dgvLichThi).BeginInit();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)numThoiGianLamBai).BeginInit();
            SuspendLayout();
            // 
            // dgvLichThi
            // 
            dgvLichThi.AllowUserToAddRows = false;
            dgvLichThi.AllowUserToDeleteRows = false;
            dgvLichThi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichThi.Location = new Point(16, 439);
            dgvLichThi.Margin = new Padding(3, 5, 3, 5);
            dgvLichThi.MultiSelect = false;
            dgvLichThi.Name = "dgvLichThi";
            dgvLichThi.ReadOnly = true;
            dgvLichThi.RowHeadersWidth = 51;
            dgvLichThi.RowTemplate.Height = 24;
            dgvLichThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichThi.Size = new Size(1198, 340);
            dgvLichThi.TabIndex = 0;
            dgvLichThi.CellClick += dgvLichThi_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(cboChuyenNganh);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(cboNganh);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cboKhoa);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cboSemester);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtPhongThi);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboHinhThucThi);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numThoiGianLamBai);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpExamDateTime);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboMonHoc);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboLopHoc);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(16, 62);
            groupBox1.Margin = new Padding(3, 5, 3, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 5, 3, 5);
            groupBox1.Size = new Size(1198, 322);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lịch thi";
            // 
            // cboChuyenNganh
            // 
            cboChuyenNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboChuyenNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboChuyenNganh.FormattingEnabled = true;
            cboChuyenNganh.Location = new Point(163, 185);
            cboChuyenNganh.Margin = new Padding(3, 5, 3, 5);
            cboChuyenNganh.Name = "cboChuyenNganh";
            cboChuyenNganh.Size = new Size(271, 33);
            cboChuyenNganh.TabIndex = 21;
            cboChuyenNganh.SelectedIndexChanged += cboChuyenNganh_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 185);
            label9.Name = "label9";
            label9.Size = new Size(147, 25);
            label9.TabIndex = 20;
            label9.Text = "Chuyên ngành:";
            // 
            // cboNganh
            // 
            cboNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboNganh.FormattingEnabled = true;
            cboNganh.Location = new Point(163, 126);
            cboNganh.Margin = new Padding(3, 5, 3, 5);
            cboNganh.Name = "cboNganh";
            cboNganh.Size = new Size(271, 33);
            cboNganh.TabIndex = 19;
            cboNganh.SelectedIndexChanged += cboNganh_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 126);
            label10.Name = "label10";
            label10.Size = new Size(76, 25);
            label10.TabIndex = 18;
            label10.Text = "Ngành:";
            // 
            // cboKhoa
            // 
            cboKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(163, 64);
            cboKhoa.Margin = new Padding(3, 5, 3, 5);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(271, 33);
            cboKhoa.TabIndex = 17;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 64);
            label11.Name = "label11";
            label11.Size = new Size(65, 25);
            label11.TabIndex = 16;
            label11.Text = "Khoa:";
            // 
            // cboSemester
            // 
            cboSemester.FormattingEnabled = true;
            cboSemester.Location = new Point(961, 190);
            cboSemester.Margin = new Padding(3, 5, 3, 5);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(206, 33);
            cboSemester.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(818, 195);
            label8.Name = "label8";
            label8.Size = new Size(78, 25);
            label8.TabIndex = 14;
            label8.Text = "Học kỳ:";
            // 
            // txtPhongThi
            // 
            txtPhongThi.Location = new Point(961, 126);
            txtPhongThi.Margin = new Padding(3, 5, 3, 5);
            txtPhongThi.Name = "txtPhongThi";
            txtPhongThi.Size = new Size(206, 30);
            txtPhongThi.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(818, 131);
            label7.Name = "label7";
            label7.Size = new Size(100, 25);
            label7.TabIndex = 12;
            label7.Text = "Phòng thi:";
            // 
            // cboHinhThucThi
            // 
            cboHinhThucThi.FormattingEnabled = true;
            cboHinhThucThi.Location = new Point(961, 64);
            cboHinhThucThi.Margin = new Padding(3, 5, 3, 5);
            cboHinhThucThi.Name = "cboHinhThucThi";
            cboHinhThucThi.Size = new Size(206, 33);
            cboHinhThucThi.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(818, 69);
            label6.Name = "label6";
            label6.Size = new Size(125, 25);
            label6.TabIndex = 10;
            label6.Text = "Hình thức thi:";
            // 
            // numThoiGianLamBai
            // 
            numThoiGianLamBai.Location = new Point(611, 189);
            numThoiGianLamBai.Margin = new Padding(3, 5, 3, 5);
            numThoiGianLamBai.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numThoiGianLamBai.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numThoiGianLamBai.Name = "numThoiGianLamBai";
            numThoiGianLamBai.Size = new Size(176, 30);
            numThoiGianLamBai.TabIndex = 9;
            numThoiGianLamBai.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(441, 189);
            label5.Name = "label5";
            label5.Size = new Size(156, 25);
            label5.TabIndex = 8;
            label5.Text = "Thời gian (phút):";
            // 
            // dtpExamDateTime
            // 
            dtpExamDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpExamDateTime.Format = DateTimePickerFormat.Custom;
            dtpExamDateTime.Location = new Point(547, 126);
            dtpExamDateTime.Margin = new Padding(3, 5, 3, 5);
            dtpExamDateTime.Name = "dtpExamDateTime";
            dtpExamDateTime.Size = new Size(248, 30);
            dtpExamDateTime.TabIndex = 5;
            dtpExamDateTime.Value = new DateTime(2025, 12, 9, 21, 48, 5, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(441, 126);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 4;
            label3.Text = "Ngày thi:";
            // 
            // cboMonHoc
            // 
            cboMonHoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMonHoc.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(547, 64);
            cboMonHoc.Margin = new Padding(3, 5, 3, 5);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(248, 33);
            cboMonHoc.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(441, 69);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 2;
            label2.Text = "Môn học:";
            // 
            // cboLopHoc
            // 
            cboLopHoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboLopHoc.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboLopHoc.FormattingEnabled = true;
            cboLopHoc.Location = new Point(163, 248);
            cboLopHoc.Margin = new Padding(3, 5, 3, 5);
            cboLopHoc.Name = "cboLopHoc";
            cboLopHoc.Size = new Size(271, 33);
            cboLopHoc.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 248);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "Lớp học:";
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(283, 364);
            btnThem.Margin = new Padding(3, 5, 3, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 58);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(403, 364);
            btnSua.Margin = new Padding(3, 5, 3, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 58);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(523, 364);
            btnXoa.Margin = new Padding(3, 5, 3, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 58);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuu.Location = new Point(741, 364);
            btnLuu.Margin = new Padding(3, 5, 3, 5);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 58);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHuy.Location = new Point(861, 364);
            btnHuy.Margin = new Padding(3, 5, 3, 5);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(112, 58);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.Highlight;
            lblTitle.Location = new Point(16, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1198, 40);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "QUẢN LÝ LỊCH THI";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmQuanLyLichThi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 799);
            Controls.Add(lblTitle);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Controls.Add(dgvLichThi);
            Margin = new Padding(3, 5, 3, 5);
            Name = "FrmQuanLyLichThi";
            Text = "Quản lý Lịch thi";
            Load += FrmQuanLyLichThi_Load;
            ((ISupportInitialize)dgvLichThi).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)numThoiGianLamBai).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLichThi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpExamDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numThoiGianLamBai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhongThi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboHinhThucThi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboChuyenNganh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTitle;
    }
}