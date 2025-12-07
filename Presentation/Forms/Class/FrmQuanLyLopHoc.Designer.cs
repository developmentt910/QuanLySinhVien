using System.ComponentModel;
// Đặt namespace này cho đúng với thư mục của bạn
namespace StudentCourseManagement.Presentation.Forms.Class
{
    partial class FrmQuanLyLopHoc
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
            dgvLopHoc = new DataGridView();
            groupBox1 = new GroupBox();
            btnTaiLop = new Button();
            txtCoVan = new TextBox();
            label7 = new Label();
            cboChuyenNganh = new ComboBox();
            label6 = new Label();
            cboNganh = new ComboBox();
            label5 = new Label();
            cboKhoa = new ComboBox();
            label4 = new Label();
            numSiSo = new NumericUpDown();
            txtTenLop = new TextBox();
            txtMaLop = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            lblTitle = new Label();
            ((ISupportInitialize)dgvLopHoc).BeginInit();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)numSiSo).BeginInit();
            SuspendLayout();
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.AllowUserToAddRows = false;
            dgvLopHoc.AllowUserToDeleteRows = false;
            dgvLopHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Location = new Point(16, 439);
            dgvLopHoc.Margin = new Padding(3, 5, 3, 5);
            dgvLopHoc.MultiSelect = false;
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.RowHeadersWidth = 51;
            dgvLopHoc.RowTemplate.Height = 24;
            dgvLopHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLopHoc.Size = new Size(970, 325);
            dgvLopHoc.TabIndex = 0;
            dgvLopHoc.CellClick += dgvLopHoc_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtCoVan);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboChuyenNganh);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboNganh);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboKhoa);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(numSiSo);
            groupBox1.Controls.Add(txtTenLop);
            groupBox1.Controls.Add(txtMaLop);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(16, 62);
            groupBox1.Margin = new Padding(3, 5, 3, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 5, 3, 5);
            groupBox1.Size = new Size(970, 322);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lớp học";
            // 
            // btnTaiLop
            // 
            btnTaiLop.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaiLop.Location = new Point(848, 364);
            btnTaiLop.Margin = new Padding(3, 5, 3, 5);
            btnTaiLop.Name = "btnTaiLop";
            btnTaiLop.Size = new Size(112, 58);
            btnTaiLop.TabIndex = 16;
            btnTaiLop.Text = "Tải Lớp";
            btnTaiLop.UseVisualStyleBackColor = true;
            btnTaiLop.Click += btnTaiLop_Click;
            // 
            // txtCoVan
            // 
            txtCoVan.Location = new Point(653, 255);
            txtCoVan.Margin = new Padding(3, 5, 3, 5);
            txtCoVan.Name = "txtCoVan";
            txtCoVan.Size = new Size(285, 30);
            txtCoVan.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 260);
            label7.Name = "label7";
            label7.Size = new Size(113, 25);
            label7.TabIndex = 14;
            label7.Text = "Cố vấn HT:";
            // 
            // cboChuyenNganh
            // 
            cboChuyenNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboChuyenNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboChuyenNganh.FormattingEnabled = true;
            cboChuyenNganh.Location = new Point(181, 192);
            cboChuyenNganh.Margin = new Padding(3, 5, 3, 5);
            cboChuyenNganh.Name = "cboChuyenNganh";
            cboChuyenNganh.Size = new Size(303, 33);
            cboChuyenNganh.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 192);
            label6.Name = "label6";
            label6.Size = new Size(147, 25);
            label6.TabIndex = 12;
            label6.Text = "Chuyên ngành:";
            // 
            // cboNganh
            // 
            cboNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboNganh.FormattingEnabled = true;
            cboNganh.Location = new Point(181, 126);
            cboNganh.Margin = new Padding(3, 5, 3, 5);
            cboNganh.Name = "cboNganh";
            cboNganh.Size = new Size(303, 33);
            cboNganh.TabIndex = 11;
            cboNganh.SelectedIndexChanged += cboNganh_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 126);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 10;
            label5.Text = "Ngành:";
            // 
            // cboKhoa
            // 
            cboKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(181, 61);
            cboKhoa.Margin = new Padding(3, 5, 3, 5);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(303, 33);
            cboKhoa.TabIndex = 9;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 61);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 8;
            label4.Text = "Khoa:";
            // 
            // numSiSo
            // 
            numSiSo.Location = new Point(653, 192);
            numSiSo.Margin = new Padding(3, 5, 3, 5);
            numSiSo.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numSiSo.Name = "numSiSo";
            numSiSo.Size = new Size(287, 30);
            numSiSo.TabIndex = 7;
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(653, 126);
            txtTenLop.Margin = new Padding(3, 5, 3, 5);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(285, 30);
            txtTenLop.TabIndex = 5;
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(653, 64);
            txtMaLop.Margin = new Padding(3, 5, 3, 5);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(285, 30);
            txtMaLop.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(516, 198);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 2;
            label3.Text = "Sĩ số:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(516, 131);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên lớp:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(516, 69);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã lớp:";
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(124, 364);
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
            btnSua.Location = new Point(244, 364);
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
            btnXoa.Location = new Point(364, 364);
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
            btnLuu.Location = new Point(610, 364);
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
            btnHuy.Location = new Point(730, 364);
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
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(16, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(970, 40);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "QUẢN LÝ LỚP HỌC";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmQuanLyLopHoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 782);
            Controls.Add(btnTaiLop);
            Controls.Add(lblTitle);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Controls.Add(dgvLopHoc);
            Margin = new Padding(3, 5, 3, 5);
            Name = "FrmQuanLyLopHoc";
            Text = "Quản lý Lớp học";
            Load += FrmQuanLyLopHoc_Load;
            ((ISupportInitialize)dgvLopHoc).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)numSiSo).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numSiSo;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cboChuyenNganh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCoVan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTaiLop; // Khai báo nút mới
    }
}