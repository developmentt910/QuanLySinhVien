namespace StudentCourseManagement.Presentation.Forms.Schedule
{
    partial class FrmQuanLyThoiKhoaBieu
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
            groupBoxFilter = new GroupBox();
            btnLoad = new Button();
            cboKyHoc = new ComboBox();
            label5 = new Label();
            cboLopHoc = new ComboBox();
            label4 = new Label();
            cboChuyenNganh = new ComboBox();
            label3 = new Label();
            cboNganh = new ComboBox();
            label2 = new Label();
            cboKhoa = new ComboBox();
            label1 = new Label();
            dgvSchedules = new DataGridView();
            groupBoxAdd = new GroupBox();
            numEndPeriod = new NumericUpDown();
            label13 = new Label();
            numStartPeriod = new NumericUpDown();
            label12 = new Label();
            dtpLessonDate = new DateTimePicker();
            label11 = new Label();
            btnRemove = new Button();
            btnAdd = new Button();
            btnSua = new Button();
            btnReload = new Button();
            txtPhongHoc = new TextBox();
            label8 = new Label();
            txtGiaoVien = new TextBox();
            label7 = new Label();
            cboMonHoc = new ComboBox();
            label6 = new Label();
            lblTitle = new Label();
            groupBoxFilter.SuspendLayout();
            ((ISupportInitialize)dgvSchedules).BeginInit();
            groupBoxAdd.SuspendLayout();
            ((ISupportInitialize)numEndPeriod).BeginInit();
            ((ISupportInitialize)numStartPeriod).BeginInit();
            SuspendLayout();
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(btnLoad);
            groupBoxFilter.Controls.Add(cboKyHoc);
            groupBoxFilter.Controls.Add(label5);
            groupBoxFilter.Controls.Add(cboLopHoc);
            groupBoxFilter.Controls.Add(label4);
            groupBoxFilter.Controls.Add(cboChuyenNganh);
            groupBoxFilter.Controls.Add(label3);
            groupBoxFilter.Controls.Add(cboNganh);
            groupBoxFilter.Controls.Add(label2);
            groupBoxFilter.Controls.Add(cboKhoa);
            groupBoxFilter.Controls.Add(label1);
            groupBoxFilter.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxFilter.Location = new Point(15, 50);
            groupBoxFilter.Margin = new Padding(4, 5, 4, 5);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Padding = new Padding(4, 5, 4, 5);
            groupBoxFilter.Size = new Size(1394, 195);
            groupBoxFilter.TabIndex = 0;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Bộ lọc Thời khóa biểu";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(1026, 123);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(148, 50);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Tải TKB";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // cboKyHoc
            // 
            cboKyHoc.FormattingEnabled = true;
            cboKyHoc.Location = new Point(680, 128);
            cboKyHoc.Margin = new Padding(4, 5, 4, 5);
            cboKyHoc.Name = "cboKyHoc";
            cboKyHoc.Size = new Size(319, 33);
            cboKyHoc.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(599, 133);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 25);
            label5.TabIndex = 8;
            label5.Text = "Kì học:";
            // 
            // cboLopHoc
            // 
            cboLopHoc.FormattingEnabled = true;
            cboLopHoc.Location = new Point(94, 128);
            cboLopHoc.Margin = new Padding(4, 5, 4, 5);
            cboLopHoc.Name = "cboLopHoc";
            cboLopHoc.Size = new Size(405, 33);
            cboLopHoc.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 133);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 6;
            label4.Text = "Lớp:";
            // 
            // cboChuyenNganh
            // 
            cboChuyenNganh.FormattingEnabled = true;
            cboChuyenNganh.Location = new Point(855, 61);
            cboChuyenNganh.Margin = new Padding(4, 5, 4, 5);
            cboChuyenNganh.Name = "cboChuyenNganh";
            cboChuyenNganh.Size = new Size(318, 33);
            cboChuyenNganh.TabIndex = 5;
            cboChuyenNganh.SelectedIndexChanged += cboChuyenNganh_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(686, 66);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(147, 25);
            label3.TabIndex = 4;
            label3.Text = "Chuyên ngành:";
            // 
            // cboNganh
            // 
            cboNganh.FormattingEnabled = true;
            cboNganh.Location = new Point(425, 61);
            cboNganh.Margin = new Padding(4, 5, 4, 5);
            cboNganh.Name = "cboNganh";
            cboNganh.Size = new Size(240, 33);
            cboNganh.TabIndex = 3;
            cboNganh.SelectedIndexChanged += cboNganh_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 66);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 2;
            label2.Text = "Ngành:";
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(94, 61);
            cboKhoa.Margin = new Padding(4, 5, 4, 5);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(228, 33);
            cboKhoa.TabIndex = 1;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 66);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 0;
            label1.Text = "Khoa:";
            // 
            // dgvSchedules
            // 
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.AllowUserToDeleteRows = false;
            dgvSchedules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedules.Location = new Point(15, 254);
            dgvSchedules.Margin = new Padding(4, 5, 4, 5);
            dgvSchedules.MultiSelect = false;
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.ReadOnly = true;
            dgvSchedules.RowHeadersWidth = 51;
            dgvSchedules.RowTemplate.Height = 24;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.Size = new Size(1392, 363);
            dgvSchedules.TabIndex = 1;
            dgvSchedules.CellClick += dgvSchedules_CellClick;
            // 
            // groupBoxAdd
            // 
            groupBoxAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxAdd.Controls.Add(numEndPeriod);
            groupBoxAdd.Controls.Add(label13);
            groupBoxAdd.Controls.Add(numStartPeriod);
            groupBoxAdd.Controls.Add(label12);
            groupBoxAdd.Controls.Add(dtpLessonDate);
            groupBoxAdd.Controls.Add(label11);
            groupBoxAdd.Controls.Add(btnRemove);
            groupBoxAdd.Controls.Add(btnAdd);
            groupBoxAdd.Controls.Add(btnSua);
            groupBoxAdd.Controls.Add(btnReload);
            groupBoxAdd.Controls.Add(txtPhongHoc);
            groupBoxAdd.Controls.Add(label8);
            groupBoxAdd.Controls.Add(txtGiaoVien);
            groupBoxAdd.Controls.Add(label7);
            groupBoxAdd.Controls.Add(cboMonHoc);
            groupBoxAdd.Controls.Add(label6);
            groupBoxAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBoxAdd.Location = new Point(15, 627);
            groupBoxAdd.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdd.Name = "groupBoxAdd";
            groupBoxAdd.Padding = new Padding(4, 5, 4, 5);
            groupBoxAdd.Size = new Size(1394, 273);
            groupBoxAdd.TabIndex = 2;
            groupBoxAdd.TabStop = false;
            groupBoxAdd.Text = "Thêm/Xóa/Sửa môn học";
            // 
            // numEndPeriod
            // 
            numEndPeriod.Location = new Point(680, 200);
            numEndPeriod.Margin = new Padding(4, 5, 4, 5);
            numEndPeriod.Maximum = new decimal(new int[] { 14, 0, 0, 0 });
            numEndPeriod.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numEndPeriod.Name = "numEndPeriod";
            numEndPeriod.Size = new Size(146, 30);
            numEndPeriod.TabIndex = 13;
            numEndPeriod.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(599, 205);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(83, 25);
            label13.TabIndex = 12;
            label13.Text = "Tiết KT:";
            // 
            // numStartPeriod
            // 
            numStartPeriod.Location = new Point(436, 200);
            numStartPeriod.Margin = new Padding(4, 5, 4, 5);
            numStartPeriod.Maximum = new decimal(new int[] { 14, 0, 0, 0 });
            numStartPeriod.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStartPeriod.Name = "numStartPeriod";
            numStartPeriod.Size = new Size(139, 30);
            numStartPeriod.TabIndex = 11;
            numStartPeriod.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(340, 205);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(83, 25);
            label12.TabIndex = 10;
            label12.Text = "Tiết BĐ:";
            // 
            // dtpLessonDate
            // 
            dtpLessonDate.Format = DateTimePickerFormat.Short;
            dtpLessonDate.Location = new Point(129, 200);
            dtpLessonDate.Margin = new Padding(4, 5, 4, 5);
            dtpLessonDate.Name = "dtpLessonDate";
            dtpLessonDate.Size = new Size(193, 30);
            dtpLessonDate.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(21, 205);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(101, 25);
            label11.TabIndex = 8;
            label11.Text = "Ngày học:";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(1221, 189);
            btnRemove.Margin = new Padding(4, 5, 4, 5);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(148, 50);
            btnRemove.TabIndex = 9;
            btnRemove.Text = "Xóa";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(909, 189);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(148, 50);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(1065, 189);
            btnSua.Margin = new Padding(4, 5, 4, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(148, 50);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(1221, 87);
            btnReload.Margin = new Padding(4, 5, 4, 5);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(148, 50);
            btnReload.TabIndex = 6;
            btnReload.Text = "Làm mới";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // txtPhongHoc
            // 
            txtPhongHoc.Location = new Point(680, 130);
            txtPhongHoc.Margin = new Padding(4, 5, 4, 5);
            txtPhongHoc.Name = "txtPhongHoc";
            txtPhongHoc.Size = new Size(493, 30);
            txtPhongHoc.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(599, 134);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(75, 25);
            label8.TabIndex = 4;
            label8.Text = "Phòng:";
            // 
            // txtGiaoVien
            // 
            txtGiaoVien.Location = new Point(129, 130);
            txtGiaoVien.Margin = new Padding(4, 5, 4, 5);
            txtGiaoVien.Name = "txtGiaoVien";
            txtGiaoVien.Size = new Size(445, 30);
            txtGiaoVien.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 134);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(100, 25);
            label7.TabIndex = 2;
            label7.Text = "Giáo viên:";
            // 
            // cboMonHoc
            // 
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(129, 61);
            cboMonHoc.Margin = new Padding(4, 5, 4, 5);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(1044, 33);
            cboMonHoc.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 66);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(94, 25);
            label6.TabIndex = 0;
            label6.Text = "Môn học:";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(15, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1394, 32);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "QUẢN LÝ THỜI KHÓA BIỂU";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmQuanLyThoiKhoaBieu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 919);
            Controls.Add(lblTitle);
            Controls.Add(groupBoxAdd);
            Controls.Add(dgvSchedules);
            Controls.Add(groupBoxFilter);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1250, 800);
            Name = "FrmQuanLyThoiKhoaBieu";
            Text = "Quản lý Thời khóa biểu";
            Load += FrmQuanLyThoiKhoaBieu_Load;
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            ((ISupportInitialize)dgvSchedules).EndInit();
            groupBoxAdd.ResumeLayout(false);
            groupBoxAdd.PerformLayout();
            ((ISupportInitialize)numEndPeriod).EndInit();
            ((ISupportInitialize)numStartPeriod).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboChuyenNganh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cboKyHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPhongHoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaoVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpLessonDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numEndPeriod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numStartPeriod;
        private System.Windows.Forms.Label label12;
        private Button btnSua;
        private Button btnReload;
        private Label lblTitle;
    }
}