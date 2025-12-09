using System.ComponentModel;
partial class FrmQuanLyChuongTrinhKhung
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
        cboHocKy = new ComboBox();
        label4 = new Label();
        cboChuyenNganh = new ComboBox();
        label3 = new Label();
        cboNganh = new ComboBox();
        label2 = new Label();
        cboKhoa = new ComboBox();
        label1 = new Label();
        dgvChuongTrinhKhung = new DataGridView();
        groupBoxActions = new GroupBox();
        txtTietTH = new TextBox();
        label10 = new Label();
        txtTietLT = new TextBox();
        label9 = new Label();
        txtSoTinChi = new TextBox();
        label8 = new Label();
        txtMaHocPhan = new TextBox();
        label7 = new Label();
        txtMaMonHoc = new TextBox();
        label6 = new Label();
        btnChangeFilter = new Button();
        btnRemoveMonHoc = new Button();
        btnAddMonHoc = new Button();
        cboChonMonHoc = new ComboBox();
        label5 = new Label();
        lblTieuDeKhung = new Label();
        lblTitle = new Label();
        groupBoxFilter.SuspendLayout();
        ((ISupportInitialize)dgvChuongTrinhKhung).BeginInit();
        groupBoxActions.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxFilter
        // 
        groupBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxFilter.Controls.Add(btnLoad);
        groupBoxFilter.Controls.Add(cboHocKy);
        groupBoxFilter.Controls.Add(label4);
        groupBoxFilter.Controls.Add(cboChuyenNganh);
        groupBoxFilter.Controls.Add(label3);
        groupBoxFilter.Controls.Add(cboNganh);
        groupBoxFilter.Controls.Add(label2);
        groupBoxFilter.Controls.Add(cboKhoa);
        groupBoxFilter.Controls.Add(label1);
        groupBoxFilter.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        groupBoxFilter.Location = new Point(12, 56);
        groupBoxFilter.Margin = new Padding(3, 4, 3, 4);
        groupBoxFilter.Name = "groupBoxFilter";
        groupBoxFilter.Padding = new Padding(3, 4, 3, 4);
        groupBoxFilter.Size = new Size(801, 160);
        groupBoxFilter.TabIndex = 0;
        groupBoxFilter.TabStop = false;
        groupBoxFilter.Text = "1. Chọn chương trình khung";
        // 
        // btnLoad
        // 
        btnLoad.Location = new Point(661, 90);
        btnLoad.Margin = new Padding(3, 4, 3, 4);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(130, 40);
        btnLoad.TabIndex = 4;
        btnLoad.Text = "Tải";
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // cboHocKy
        // 
        cboHocKy.FormattingEnabled = true;
        cboHocKy.Location = new Point(473, 98);
        cboHocKy.Margin = new Padding(3, 4, 3, 4);
        cboHocKy.Name = "cboHocKy";
        cboHocKy.Size = new Size(162, 28);
        cboHocKy.TabIndex = 3;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(402, 102);
        label4.Name = "label4";
        label4.Size = new Size(66, 20);
        label4.TabIndex = 6;
        label4.Text = "Học kỳ:";
        // 
        // cboChuyenNganh
        // 
        cboChuyenNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cboChuyenNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
        cboChuyenNganh.FormattingEnabled = true;
        cboChuyenNganh.Location = new Point(135, 98);
        cboChuyenNganh.Margin = new Padding(3, 4, 3, 4);
        cboChuyenNganh.Name = "cboChuyenNganh";
        cboChuyenNganh.Size = new Size(248, 28);
        cboChuyenNganh.TabIndex = 2;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(14, 102);
        label3.Name = "label3";
        label3.Size = new Size(120, 20);
        label3.TabIndex = 4;
        label3.Text = "Chuyên ngành:";
        // 
        // cboNganh
        // 
        cboNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cboNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
        cboNganh.FormattingEnabled = true;
        cboNganh.Location = new Point(473, 45);
        cboNganh.Margin = new Padding(3, 4, 3, 4);
        cboNganh.Name = "cboNganh";
        cboNganh.Size = new Size(280, 28);
        cboNganh.TabIndex = 1;
        cboNganh.SelectedIndexChanged += cboNganh_SelectedIndexChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(402, 49);
        label2.Name = "label2";
        label2.Size = new Size(62, 20);
        label2.TabIndex = 2;
        label2.Text = "Ngành:";
        // 
        // cboKhoa
        // 
        cboKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cboKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
        cboKhoa.FormattingEnabled = true;
        cboKhoa.Location = new Point(135, 45);
        cboKhoa.Margin = new Padding(3, 4, 3, 4);
        cboKhoa.Name = "cboKhoa";
        cboKhoa.Size = new Size(248, 28);
        cboKhoa.TabIndex = 0;
        cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(14, 49);
        label1.Name = "label1";
        label1.Size = new Size(52, 20);
        label1.TabIndex = 0;
        label1.Text = "Khoa:";
        // 
        // dgvChuongTrinhKhung
        // 
        dgvChuongTrinhKhung.AllowUserToAddRows = false;
        dgvChuongTrinhKhung.AllowUserToDeleteRows = false;
        dgvChuongTrinhKhung.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvChuongTrinhKhung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvChuongTrinhKhung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvChuongTrinhKhung.Location = new Point(12, 264);
        dgvChuongTrinhKhung.Margin = new Padding(3, 4, 3, 4);
        dgvChuongTrinhKhung.MultiSelect = false;
        dgvChuongTrinhKhung.Name = "dgvChuongTrinhKhung";
        dgvChuongTrinhKhung.ReadOnly = true;
        dgvChuongTrinhKhung.RowHeadersWidth = 51;
        dgvChuongTrinhKhung.RowTemplate.Height = 24;
        dgvChuongTrinhKhung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvChuongTrinhKhung.Size = new Size(801, 224);
        dgvChuongTrinhKhung.TabIndex = 1;
        dgvChuongTrinhKhung.CellClick += dgvChuongTrinhKhung_CellClick;
        // 
        // groupBoxActions
        // 
        groupBoxActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBoxActions.Controls.Add(txtTietTH);
        groupBoxActions.Controls.Add(label10);
        groupBoxActions.Controls.Add(txtTietLT);
        groupBoxActions.Controls.Add(label9);
        groupBoxActions.Controls.Add(txtSoTinChi);
        groupBoxActions.Controls.Add(label8);
        groupBoxActions.Controls.Add(txtMaHocPhan);
        groupBoxActions.Controls.Add(label7);
        groupBoxActions.Controls.Add(txtMaMonHoc);
        groupBoxActions.Controls.Add(label6);
        groupBoxActions.Controls.Add(btnChangeFilter);
        groupBoxActions.Controls.Add(btnRemoveMonHoc);
        groupBoxActions.Controls.Add(btnAddMonHoc);
        groupBoxActions.Controls.Add(cboChonMonHoc);
        groupBoxActions.Controls.Add(label5);
        groupBoxActions.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        groupBoxActions.Location = new Point(12, 495);
        groupBoxActions.Margin = new Padding(3, 4, 3, 4);
        groupBoxActions.Name = "groupBoxActions";
        groupBoxActions.Padding = new Padding(3, 4, 3, 4);
        groupBoxActions.Size = new Size(801, 213);
        groupBoxActions.TabIndex = 2;
        groupBoxActions.TabStop = false;
        groupBoxActions.Text = "2. Chỉnh sửa chương trình khung";
        // 
        // txtTietTH
        // 
        txtTietTH.Location = new Point(703, 95);
        txtTietTH.Margin = new Padding(3, 4, 3, 4);
        txtTietTH.Name = "txtTietTH";
        txtTietTH.ReadOnly = true;
        txtTietTH.Size = new Size(50, 26);
        txtTietTH.TabIndex = 22;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(638, 98);
        label10.Name = "label10";
        label10.Size = new Size(70, 20);
        label10.TabIndex = 21;
        label10.Text = "Tiết TH:";
        // 
        // txtTietLT
        // 
        txtTietLT.Location = new Point(578, 95);
        txtTietLT.Margin = new Padding(3, 4, 3, 4);
        txtTietLT.Name = "txtTietLT";
        txtTietLT.ReadOnly = true;
        txtTietLT.Size = new Size(50, 26);
        txtTietLT.TabIndex = 20;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(513, 98);
        label9.Name = "label9";
        label9.Size = new Size(67, 20);
        label9.TabIndex = 19;
        label9.Text = "Tiết LT:";
        // 
        // txtSoTinChi
        // 
        txtSoTinChi.Location = new Point(453, 95);
        txtSoTinChi.Margin = new Padding(3, 4, 3, 4);
        txtSoTinChi.Name = "txtSoTinChi";
        txtSoTinChi.ReadOnly = true;
        txtSoTinChi.Size = new Size(50, 26);
        txtSoTinChi.TabIndex = 18;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(393, 98);
        label8.Name = "label8";
        label8.Size = new Size(61, 20);
        label8.TabIndex = 17;
        label8.Text = "Số TC:";
        // 
        // txtMaHocPhan
        // 
        txtMaHocPhan.Location = new Point(286, 95);
        txtMaHocPhan.Margin = new Padding(3, 4, 3, 4);
        txtMaHocPhan.Name = "txtMaHocPhan";
        txtMaHocPhan.ReadOnly = true;
        txtMaHocPhan.Size = new Size(97, 26);
        txtMaHocPhan.TabIndex = 16;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(219, 98);
        label7.Name = "label7";
        label7.Size = new Size(66, 20);
        label7.TabIndex = 15;
        label7.Text = "Mã HP:";
        // 
        // txtMaMonHoc
        // 
        txtMaMonHoc.Location = new Point(83, 95);
        txtMaMonHoc.Margin = new Padding(3, 4, 3, 4);
        txtMaMonHoc.Name = "txtMaMonHoc";
        txtMaMonHoc.ReadOnly = true;
        txtMaMonHoc.Size = new Size(123, 26);
        txtMaMonHoc.TabIndex = 14;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(14, 98);
        label6.Name = "label6";
        label6.Size = new Size(69, 20);
        label6.TabIndex = 13;
        label6.Text = "Mã MH:";
        // 
        // btnChangeFilter
        // 
        btnChangeFilter.Location = new Point(623, 153);
        btnChangeFilter.Margin = new Padding(3, 4, 3, 4);
        btnChangeFilter.Name = "btnChangeFilter";
        btnChangeFilter.Size = new Size(130, 40);
        btnChangeFilter.TabIndex = 8;
        btnChangeFilter.Text = "Chọn lại";
        btnChangeFilter.UseVisualStyleBackColor = true;
        btnChangeFilter.Click += btnChangeFilter_Click;
        // 
        // btnRemoveMonHoc
        // 
        btnRemoveMonHoc.Location = new Point(18, 153);
        btnRemoveMonHoc.Margin = new Padding(3, 4, 3, 4);
        btnRemoveMonHoc.Name = "btnRemoveMonHoc";
        btnRemoveMonHoc.Size = new Size(188, 40);
        btnRemoveMonHoc.TabIndex = 7;
        btnRemoveMonHoc.Text = "Xóa môn đã chọn";
        btnRemoveMonHoc.UseVisualStyleBackColor = true;
        btnRemoveMonHoc.Click += btnRemoveMonHoc_Click;
        // 
        // btnAddMonHoc
        // 
        btnAddMonHoc.Location = new Point(623, 42);
        btnAddMonHoc.Margin = new Padding(3, 4, 3, 4);
        btnAddMonHoc.Name = "btnAddMonHoc";
        btnAddMonHoc.Size = new Size(130, 40);
        btnAddMonHoc.TabIndex = 6;
        btnAddMonHoc.Text = "Thêm";
        btnAddMonHoc.UseVisualStyleBackColor = true;
        btnAddMonHoc.Click += btnAddMonHoc_Click;
        // 
        // cboChonMonHoc
        // 
        cboChonMonHoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        cboChonMonHoc.AutoCompleteSource = AutoCompleteSource.ListItems;
        cboChonMonHoc.FormattingEnabled = true;
        cboChonMonHoc.Location = new Point(182, 46);
        cboChonMonHoc.Margin = new Padding(3, 4, 3, 4);
        cboChonMonHoc.Name = "cboChonMonHoc";
        cboChonMonHoc.Size = new Size(422, 28);
        cboChonMonHoc.TabIndex = 5;
        cboChonMonHoc.SelectedIndexChanged += cboChonMonHoc_SelectedIndexChanged;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(14, 50);
        label5.Name = "label5";
        label5.Size = new Size(157, 20);
        label5.TabIndex = 0;
        label5.Text = "Thêm môn học mới:";
        // 
        // lblTieuDeKhung
        // 
        lblTieuDeKhung.AutoSize = true;
        lblTieuDeKhung.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTieuDeKhung.Location = new Point(12, 229);
        lblTieuDeKhung.Name = "lblTieuDeKhung";
        lblTieuDeKhung.Size = new Size(263, 20);
        lblTieuDeKhung.TabIndex = 3;
        lblTieuDeKhung.Text = "Chưa chọn chương trình khung";
        // 
        // lblTitle
        // 
        lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(15, 14);
        lblTitle.Margin = new Padding(4, 0, 4, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(801, 40);
        lblTitle.TabIndex = 4;
        lblTitle.Text = "QUẢN LÝ CHƯƠNG TRÌNH KHUNG";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FrmQuanLyChuongTrinhKhung
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(825, 722);
        Controls.Add(lblTitle);
        Controls.Add(lblTieuDeKhung);
        Controls.Add(groupBoxActions);
        Controls.Add(dgvChuongTrinhKhung);
        Controls.Add(groupBoxFilter);
        Margin = new Padding(3, 4, 3, 4);
        Name = "FrmQuanLyChuongTrinhKhung";
        Text = "Quản lý Chương trình khung (Cập nhật)";
        Load += FrmQuanLyChuongTrinhKhung_Load;
        groupBoxFilter.ResumeLayout(false);
        groupBoxFilter.PerformLayout();
        ((ISupportInitialize)dgvChuongTrinhKhung).EndInit();
        groupBoxActions.ResumeLayout(false);
        groupBoxActions.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxFilter;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.ComboBox cboHocKy;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cboChuyenNganh;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cboNganh;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cboKhoa;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView dgvChuongTrinhKhung;
    private System.Windows.Forms.GroupBox groupBoxActions;
    private System.Windows.Forms.Button btnChangeFilter;
    private System.Windows.Forms.Button btnRemoveMonHoc;
    private System.Windows.Forms.Button btnAddMonHoc;
    private System.Windows.Forms.ComboBox cboChonMonHoc;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblTieuDeKhung;
    private System.Windows.Forms.TextBox txtTietTH;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtTietLT;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txtSoTinChi;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txtMaHocPhan;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtMaMonHoc;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label lblTitle;
}