using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StudentCourseManagement.Presentation.Forms.Student
{
    partial class FrmStudentManagement
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpPhoto;
        private GroupBox grpDetail;
        private GroupBox grpList;

        private PictureBox picStudent;
        private Button btnSelectPhoto;

        private Label lblStudentId, lblFullName,
                     lblFaculty, lblMajor, lblSpecialization, lblClass,
                     lblPassword,
                     lblGender, lblPhone, lblCCCD, lblYear, lblAddress, lblStatus;

        private TextBox txtStudentId, txtFullName,
                         txtPassword,
                        txtPhone, txtCCCD, txtYear, txtAddress;

        private ComboBox cmbFacultySql, cmbMajorSql, cmbSpecializationSql, cmbClassSql;
        private ComboBox cmbGender, cmbStatus;
        private Button btnAdd, btnUpdate, btnDelete, btnRefresh;
        private DataGridView dgvStudents;

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpPhoto = new GroupBox();
            picStudent = new PictureBox();
            btnSelectPhoto = new Button();
            grpDetail = new GroupBox();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblFaculty = new Label();
            cmbFacultySql = new ComboBox();
            lblMajor = new Label();
            cmbMajorSql = new ComboBox();
            lblSpecialization = new Label();
            cmbSpecializationSql = new ComboBox();
            lblClass = new Label();
            cmbClassSql = new ComboBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblCCCD = new Label();
            txtCCCD = new TextBox();
            lblYear = new Label();
            txtYear = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            grpList = new GroupBox();
            dgvStudents = new DataGridView();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlSearch = new Panel();
            grpPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picStudent).BeginInit();
            grpDetail.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            pnlSearch.SuspendLayout();
            SuspendLayout();
            // 
            // grpPhoto
            // 
            grpPhoto.Controls.Add(picStudent);
            grpPhoto.Controls.Add(btnSelectPhoto);
            grpPhoto.Font = new Font("Segoe UI", 10F);
            grpPhoto.Location = new Point(14, 59);
            grpPhoto.Name = "grpPhoto";
            grpPhoto.Size = new Size(225, 349);
            grpPhoto.TabIndex = 2;
            grpPhoto.TabStop = false;
            grpPhoto.Text = "Ảnh Sinh viên";
            // 
            // picStudent
            // 
            picStudent.BorderStyle = BorderStyle.FixedSingle;
            picStudent.ErrorImage = null;
            picStudent.InitialImage = null;
            picStudent.Location = new Point(6, 52);
            picStudent.Name = "picStudent";
            picStudent.Size = new Size(202, 230);
            picStudent.SizeMode = PictureBoxSizeMode.Zoom;
            picStudent.TabIndex = 0;
            picStudent.TabStop = false;
            // 
            // btnSelectPhoto
            // 
            btnSelectPhoto.FlatStyle = FlatStyle.Flat;
            btnSelectPhoto.Location = new Point(53, 288);
            btnSelectPhoto.Name = "btnSelectPhoto";
            btnSelectPhoto.Size = new Size(112, 34);
            btnSelectPhoto.TabIndex = 1;
            btnSelectPhoto.Text = "Chọn ảnh";
            btnSelectPhoto.UseVisualStyleBackColor = true;
            btnSelectPhoto.Click += btnSelectPhoto_Click;
            // 
            // grpDetail
            // 
            grpDetail.Controls.Add(lblStudentId);
            grpDetail.Controls.Add(txtStudentId);
            grpDetail.Controls.Add(lblFullName);
            grpDetail.Controls.Add(txtFullName);
            grpDetail.Controls.Add(lblFaculty);
            grpDetail.Controls.Add(cmbFacultySql);
            grpDetail.Controls.Add(lblMajor);
            grpDetail.Controls.Add(cmbMajorSql);
            grpDetail.Controls.Add(lblSpecialization);
            grpDetail.Controls.Add(cmbSpecializationSql);
            grpDetail.Controls.Add(lblClass);
            grpDetail.Controls.Add(cmbClassSql);
            grpDetail.Controls.Add(lblPassword);
            grpDetail.Controls.Add(txtPassword);
            grpDetail.Controls.Add(lblGender);
            grpDetail.Controls.Add(cmbGender);
            grpDetail.Controls.Add(lblPhone);
            grpDetail.Controls.Add(txtPhone);
            grpDetail.Controls.Add(lblCCCD);
            grpDetail.Controls.Add(txtCCCD);
            grpDetail.Controls.Add(lblYear);
            grpDetail.Controls.Add(txtYear);
            grpDetail.Controls.Add(lblAddress);
            grpDetail.Controls.Add(txtAddress);
            grpDetail.Controls.Add(lblStatus);
            grpDetail.Controls.Add(cmbStatus);
            grpDetail.Controls.Add(btnAdd);
            grpDetail.Controls.Add(btnUpdate);
            grpDetail.Controls.Add(btnDelete);
            grpDetail.Controls.Add(btnRefresh);
            grpDetail.Font = new Font("Segoe UI", 10F);
            grpDetail.Location = new Point(248, 59);
            grpDetail.Name = "grpDetail";
            grpDetail.Size = new Size(990, 390);
            grpDetail.TabIndex = 1;
            grpDetail.TabStop = false;
            grpDetail.Text = "Thông tin chi tiết";
            // 
            // lblStudentId
            // 
            lblStudentId.Location = new Point(22, 34);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(100, 23);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Mã SV:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(157, 34);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(220, 30);
            txtStudentId.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.Location = new Point(518, 34);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 23);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và Tên:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(652, 32);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(220, 30);
            txtFullName.TabIndex = 3;
            // 
            // lblFaculty
            // 
            lblFaculty.Location = new Point(22, 75);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(100, 23);
            lblFaculty.TabIndex = 4;
            lblFaculty.Text = "Khoa:";
            // 
            // cmbFacultySql
            // 
            cmbFacultySql.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFacultySql.Location = new Point(157, 72);
            cmbFacultySql.Name = "cmbFacultySql";
            cmbFacultySql.Size = new Size(220, 31);
            cmbFacultySql.TabIndex = 5;
            // 
            // lblMajor
            // 
            lblMajor.Location = new Point(22, 115);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(100, 23);
            lblMajor.TabIndex = 8;
            lblMajor.Text = "Ngành:";
            // 
            // cmbMajorSql
            // 
            cmbMajorSql.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMajorSql.Location = new Point(157, 109);
            cmbMajorSql.Name = "cmbMajorSql";
            cmbMajorSql.Size = new Size(220, 31);
            cmbMajorSql.TabIndex = 9;
            // 
            // lblSpecialization
            // 
            lblSpecialization.Location = new Point(22, 155);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(127, 23);
            lblSpecialization.TabIndex = 12;
            lblSpecialization.Text = "Chuyên ngành:";
            // 
            // cmbSpecializationSql
            // 
            cmbSpecializationSql.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecializationSql.Location = new Point(157, 151);
            cmbSpecializationSql.Name = "cmbSpecializationSql";
            cmbSpecializationSql.Size = new Size(220, 31);
            cmbSpecializationSql.TabIndex = 13;
            // 
            // lblClass
            // 
            lblClass.Location = new Point(22, 195);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(100, 23);
            lblClass.TabIndex = 16;
            lblClass.Text = "Lớp:";
            // 
            // cmbClassSql
            // 
            cmbClassSql.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassSql.Location = new Point(157, 192);
            cmbClassSql.Name = "cmbClassSql";
            cmbClassSql.Size = new Size(220, 31);
            cmbClassSql.TabIndex = 17;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(22, 235);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 20;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(157, 232);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(220, 30);
            txtPassword.TabIndex = 21;
            // 
            // lblGender
            // 
            lblGender.Location = new Point(518, 75);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 23);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbGender.Location = new Point(652, 72);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(220, 31);
            cmbGender.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(518, 115);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "SĐT:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(652, 112);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 30);
            txtPhone.TabIndex = 11;
            // 
            // lblCCCD
            // 
            lblCCCD.Location = new Point(518, 155);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(100, 23);
            lblCCCD.TabIndex = 14;
            lblCCCD.Text = "CCCD:";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(652, 152);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(220, 30);
            txtCCCD.TabIndex = 15;
            // 
            // lblYear
            // 
            lblYear.Location = new Point(518, 199);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(100, 23);
            lblYear.TabIndex = 22;
            lblYear.Text = "Năm học:";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(652, 195);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(220, 30);
            txtYear.TabIndex = 23;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(22, 275);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 24;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(157, 272);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(220, 30);
            txtAddress.TabIndex = 25;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(518, 239);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 26;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Đang học", "Đã tốt nghiệp", "Bảo lưu" });
            cmbStatus.Location = new Point(652, 239);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(220, 31);
            cmbStatus.TabIndex = 27;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(250, 318);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 34);
            btnAdd.TabIndex = 28;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(370, 318);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 34);
            btnUpdate.TabIndex = 29;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(489, 318);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(612, 318);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 34);
            btnRefresh.TabIndex = 31;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grpList
            // 
            grpList.Controls.Add(dgvStudents);
            grpList.Dock = DockStyle.Bottom;
            grpList.Font = new Font("Segoe UI", 10F);
            grpList.Location = new Point(0, 455);
            grpList.Name = "grpList";
            grpList.Size = new Size(1251, 258);
            grpList.TabIndex = 3;
            grpList.TabStop = false;
            grpList.Text = "Danh sách Sinh viên";
            // 
            // dgvStudents
            // 
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.ColumnHeadersHeight = 29;
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(3, 26);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1245, 229);
            dgvStudents.TabIndex = 0;
            dgvStudents.CellClick += dgvStudents_CellClick;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(20, 12);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(147, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm (Mã SV):";
            lblSearch.Click += lblSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(185, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(681, 30);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(880, 9);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1251, 45);
            pnlSearch.TabIndex = 0;
            // 
            // FrmStudentManagement
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1251, 713);
            Controls.Add(pnlSearch);
            Controls.Add(grpList);
            Controls.Add(grpDetail);
            Controls.Add(grpPhoto);
            Font = new Font("Segoe UI", 10F);
            Name = "FrmStudentManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Sinh viên";
            grpPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picStudent).EndInit();
            grpDetail.ResumeLayout(false);
            grpDetail.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ResumeLayout(false);
        }
    }
}
