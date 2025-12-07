using System.Drawing.Drawing2D;

namespace StudentCourseManagement.Presentation.Forms.Student
{
    partial class FrmStudentManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpPhoto;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox grpList;

        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Button btnSelectPhoto;

        private System.Windows.Forms.Label lblStudentId, lblFullName, lblMajor, lblSpecialization, lblClass,
            lblFaculty, lblPassword,
            lblGender, lblPhone, lblCCCD, lblEmail, lblYear, lblAddress, lblStatus;

        private System.Windows.Forms.TextBox txtStudentId, txtFullName, txtMajor, txtSpecialization, txtClass,
            txtFaculty, txtPassword,
            txtPhone, txtCCCD, txtEmail, txtYear, txtAddress;

        private System.Windows.Forms.ComboBox cmbGender, cmbStatus;
        private System.Windows.Forms.Button btnAdd, btnUpdate, btnDelete;
        private System.Windows.Forms.DataGridView dgvStudents;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlSearch;

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
            lblMajor = new Label();
            txtMajor = new TextBox();
            lblSpecialization = new Label();
            txtSpecialization = new TextBox();
            lblClass = new Label();
            txtClass = new TextBox();
            lblFaculty = new Label();
            txtFaculty = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblCCCD = new Label();
            txtCCCD = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblYear = new Label();
            txtYear = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
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
            btnSelectPhoto.Click += btnSelectPhoto_Click;
            // 
            // grpDetail
            // 
            grpDetail.Controls.Add(lblStudentId);
            grpDetail.Controls.Add(txtStudentId);
            grpDetail.Controls.Add(lblFullName);
            grpDetail.Controls.Add(txtFullName);
            grpDetail.Controls.Add(lblMajor);
            grpDetail.Controls.Add(txtMajor);
            grpDetail.Controls.Add(lblSpecialization);
            grpDetail.Controls.Add(txtSpecialization);
            grpDetail.Controls.Add(lblClass);
            grpDetail.Controls.Add(txtClass);
            grpDetail.Controls.Add(lblFaculty);
            grpDetail.Controls.Add(txtFaculty);
            grpDetail.Controls.Add(lblPassword);
            grpDetail.Controls.Add(txtPassword);
            grpDetail.Controls.Add(lblGender);
            grpDetail.Controls.Add(cmbGender);
            grpDetail.Controls.Add(lblPhone);
            grpDetail.Controls.Add(txtPhone);
            grpDetail.Controls.Add(lblCCCD);
            grpDetail.Controls.Add(txtCCCD);
            grpDetail.Controls.Add(lblEmail);
            grpDetail.Controls.Add(txtEmail);
            grpDetail.Controls.Add(lblYear);
            grpDetail.Controls.Add(txtYear);
            grpDetail.Controls.Add(lblAddress);
            grpDetail.Controls.Add(txtAddress);
            grpDetail.Controls.Add(lblStatus);
            grpDetail.Controls.Add(cmbStatus);
            grpDetail.Controls.Add(btnAdd);
            grpDetail.Controls.Add(btnUpdate);
            grpDetail.Controls.Add(btnDelete);
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
            txtStudentId.Location = new Point(135, 32);
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
            // lblMajor
            // 
            lblMajor.Location = new Point(22, 75);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new Size(100, 23);
            lblMajor.TabIndex = 4;
            lblMajor.Text = "Ngành:";
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(135, 72);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(220, 30);
            txtMajor.TabIndex = 5;
            // 
            // lblSpecialization
            // 
            lblSpecialization.Location = new Point(518, 75);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(127, 23);
            lblSpecialization.TabIndex = 6;
            lblSpecialization.Text = "Chuyên ngành:";
            // 
            // txtSpecialization
            // 
            txtSpecialization.Location = new Point(652, 72);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new Size(220, 30);
            txtSpecialization.TabIndex = 7;
            // 
            // lblClass
            // 
            lblClass.Location = new Point(22, 115);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(100, 23);
            lblClass.TabIndex = 8;
            lblClass.Text = "Lớp:";
            // 
            // txtClass
            // 
            txtClass.Location = new Point(135, 113);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(220, 30);
            txtClass.TabIndex = 9;
            // 
            // lblFaculty
            // 
            lblFaculty.Location = new Point(518, 115);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(100, 23);
            lblFaculty.TabIndex = 10;
            lblFaculty.Text = "Khoa:";
            // 
            // txtFaculty
            // 
            txtFaculty.Location = new Point(652, 113);
            txtFaculty.Name = "txtFaculty";
            txtFaculty.Size = new Size(220, 30);
            txtFaculty.TabIndex = 11;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(22, 155);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(135, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(220, 30);
            txtPassword.TabIndex = 13;
            // 
            // lblGender
            // 
            lblGender.Location = new Point(518, 155);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(100, 23);
            lblGender.TabIndex = 14;
            lblGender.Text = "Giới tính:";
            // 
            // cmbGender
            // 
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbGender.Location = new Point(652, 153);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(220, 31);
            cmbGender.TabIndex = 15;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(22, 196);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 16;
            lblPhone.Text = "SĐT:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(135, 193);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 30);
            txtPhone.TabIndex = 17;
            // 
            // lblCCCD
            // 
            lblCCCD.Location = new Point(518, 196);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(100, 23);
            lblCCCD.TabIndex = 18;
            lblCCCD.Text = "CCCD:";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(652, 193);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(220, 30);
            txtCCCD.TabIndex = 19;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(22, 236);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(135, 233);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 30);
            txtEmail.TabIndex = 21;
            // 
            // lblYear
            // 
            lblYear.Location = new Point(518, 236);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(100, 23);
            lblYear.TabIndex = 22;
            lblYear.Text = "Năm học:";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(652, 233);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(220, 30);
            txtYear.TabIndex = 23;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(22, 276);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(100, 23);
            lblAddress.TabIndex = 24;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(135, 273);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(220, 30);
            txtAddress.TabIndex = 25;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(518, 276);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 26;
            lblStatus.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            cmbStatus.Items.AddRange(new object[] { "Đang học", "Đã tốt nghiệp", "Bảo lưu" });
            cmbStatus.Location = new Point(652, 273);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(220, 31);
            cmbStatus.TabIndex = 27;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(277, 318);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 34);
            btnAdd.TabIndex = 28;
            btnAdd.Text = "Thêm";
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(396, 318);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 34);
            btnUpdate.TabIndex = 29;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(518, 318);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "Xóa";
            btnDelete.Click += btnDelete_Click_1;
            // 
            // grpList
            // 
            grpList.Controls.Add(dgvStudents);
            grpList.Dock = DockStyle.Bottom;
            grpList.Font = new Font("Segoe UI", 10F);
            grpList.Location = new Point(0, 455);
            grpList.Name = "grpList";
            grpList.Size = new Size(1251, 258);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Danh sách Sinh viên";
            // 
            // dgvStudents
            // 
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.ColumnHeadersHeight = 29;
            dgvStudents.Dock = DockStyle.Bottom;
            dgvStudents.Location = new Point(3, 29);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1245, 226);
            dgvStudents.TabIndex = 0;
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
