namespace StudentCourseManagement.Presentation.Forms.result
{
    partial class FrmResult
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;

        private Label lblHoTen;
        private TextBox txtHoTen;

        private Label lblKhoa;
        private TextBox txtKhoa;

        private Label lblNganh;
        private TextBox txtNganh;

        private Label lblChuyenNganh;
        private TextBox txtChuyenNganh;

        private Label lblLop;
        private TextBox txtLop;

        private Label lblHocKy;
        private ComboBox cbHocKy;

        private Label lblScore1;
        private TextBox txtScore1;
        private Label lblScore2;
        private TextBox txtScore2;
        private Label lblExam;
        private TextBox txtExam;

        private Button btnSave;
        private Button btnDelete;
        private Button btnBack;

        private Label lblDetail;
        private DataGridView dgvDiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblKhoa = new Label();
            txtKhoa = new TextBox();
            lblNganh = new Label();
            txtNganh = new TextBox();
            lblChuyenNganh = new Label();
            txtChuyenNganh = new TextBox();
            lblLop = new Label();
            txtLop = new TextBox();
            lblHocKy = new Label();
            cbHocKy = new ComboBox();
            lblScore1 = new Label();
            txtScore1 = new TextBox();
            lblScore2 = new Label();
            txtScore2 = new TextBox();
            lblExam = new Label();
            txtExam = new TextBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            lblDetail = new Label();
            dgvDiem = new DataGridView();
            ((ISupportInitialize)dgvDiem).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.Location = new Point(509, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(413, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "KẾT QUẢ HỌC TẬP";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(26, 104);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(450, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(486, 104);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(40, 26);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍";
            // 
            // lblHoTen
            // 
            lblHoTen.Location = new Point(102, 158);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(100, 23);
            lblHoTen.TabIndex = 5;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(265, 155);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(180, 27);
            txtHoTen.TabIndex = 6;
            // 
            // lblKhoa
            // 
            lblKhoa.Location = new Point(509, 161);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(100, 23);
            lblKhoa.TabIndex = 7;
            lblKhoa.Text = "Khoa";
            // 
            // txtKhoa
            // 
            txtKhoa.Location = new Point(690, 158);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.Size = new Size(188, 27);
            txtKhoa.TabIndex = 8;
            // 
            // lblNganh
            // 
            lblNganh.Location = new Point(509, 206);
            lblNganh.Name = "lblNganh";
            lblNganh.Size = new Size(100, 23);
            lblNganh.TabIndex = 13;
            lblNganh.Text = "Ngành";
            // 
            // txtNganh
            // 
            txtNganh.Location = new Point(690, 207);
            txtNganh.Name = "txtNganh";
            txtNganh.Size = new Size(188, 27);
            txtNganh.TabIndex = 14;
            // 
            // lblChuyenNganh
            // 
            lblChuyenNganh.Location = new Point(970, 161);
            lblChuyenNganh.Name = "lblChuyenNganh";
            lblChuyenNganh.Size = new Size(128, 23);
            lblChuyenNganh.TabIndex = 9;
            lblChuyenNganh.Text = "Chuyên ngành";
            // 
            // txtChuyenNganh
            // 
            txtChuyenNganh.Location = new Point(1104, 158);
            txtChuyenNganh.Name = "txtChuyenNganh";
            txtChuyenNganh.Size = new Size(180, 27);
            txtChuyenNganh.TabIndex = 10;
            // 
            // lblLop
            // 
            lblLop.Location = new Point(970, 206);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(100, 23);
            lblLop.TabIndex = 15;
            lblLop.Text = "Lớp";
            // 
            // txtLop
            // 
            txtLop.Location = new Point(1104, 204);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(180, 27);
            txtLop.TabIndex = 16;
            // 
            // lblHocKy
            // 
            lblHocKy.Location = new Point(102, 203);
            lblHocKy.Name = "lblHocKy";
            lblHocKy.Size = new Size(100, 23);
            lblHocKy.TabIndex = 11;
            lblHocKy.Text = "Học Kỳ";
            // 
            // cbHocKy
            // 
            cbHocKy.Location = new Point(265, 201);
            cbHocKy.Name = "cbHocKy";
            cbHocKy.Size = new Size(180, 28);
            cbHocKy.TabIndex = 12;
            // 
            // lblScore1
            // 
            lblScore1.Location = new Point(102, 263);
            lblScore1.Name = "lblScore1";
            lblScore1.Size = new Size(157, 23);
            lblScore1.TabIndex = 17;
            lblScore1.Text = "Điểm thành phần 1";
            // 
            // txtScore1
            // 
            txtScore1.Location = new Point(265, 260);
            txtScore1.Name = "txtScore1";
            txtScore1.Size = new Size(180, 27);
            txtScore1.TabIndex = 18;
            // 
            // lblScore2
            // 
            lblScore2.Location = new Point(509, 261);
            lblScore2.Name = "lblScore2";
            lblScore2.Size = new Size(149, 23);
            lblScore2.TabIndex = 19;
            lblScore2.Text = "Điểm thành phần 2";
            // 
            // txtScore2
            // 
            txtScore2.Location = new Point(690, 257);
            txtScore2.Name = "txtScore2";
            txtScore2.Size = new Size(188, 27);
            txtScore2.TabIndex = 20;
            // 
            // lblExam
            // 
            lblExam.Location = new Point(970, 260);
            lblExam.Name = "lblExam";
            lblExam.Size = new Size(100, 23);
            lblExam.TabIndex = 21;
            lblExam.Text = "Điểm thi";
            // 
            // txtExam
            // 
            txtExam.Location = new Point(1104, 256);
            txtExam.Name = "txtExam";
            txtExam.Size = new Size(180, 27);
            txtExam.TabIndex = 22;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1144, 60);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 40);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1325, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(60, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xóa";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(1334, 320);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 24;
            btnBack.Text = "Quay lại";
            // 
            // lblDetail
            // 
            lblDetail.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblDetail.ForeColor = Color.Blue;
            lblDetail.Location = new Point(30, 336);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(100, 23);
            lblDetail.TabIndex = 23;
            lblDetail.Text = "Nội dung chi tiết";
            // 
            // dgvDiem
            // 
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.BackgroundColor = Color.White;
            dgvDiem.ColumnHeadersHeight = 29;
            dgvDiem.Location = new Point(30, 371);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.RowHeadersWidth = 51;
            dgvDiem.Size = new Size(1404, 318);
            dgvDiem.TabIndex = 25;
            // 
            // FrmResult
            // 
            ClientSize = new Size(1458, 725);
            Controls.Add(lblTitle);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblKhoa);
            Controls.Add(txtKhoa);
            Controls.Add(lblChuyenNganh);
            Controls.Add(txtChuyenNganh);
            Controls.Add(lblHocKy);
            Controls.Add(cbHocKy);
            Controls.Add(lblNganh);
            Controls.Add(txtNganh);
            Controls.Add(lblLop);
            Controls.Add(txtLop);
            Controls.Add(lblScore1);
            Controls.Add(txtScore1);
            Controls.Add(lblScore2);
            Controls.Add(txtScore2);
            Controls.Add(lblExam);
            Controls.Add(txtExam);
            Controls.Add(lblDetail);
            Controls.Add(btnBack);
            Controls.Add(dgvDiem);
            Name = "FrmResult";
            Text = "Kết quả học tập";
            ((ISupportInitialize)dgvDiem).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
