using StudentCourseManagement.Applications.Students;
using StudentCourseManagement.Applications.Students.Dtos;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace StudentCourseManagement.Presentation.Forms.Student
{
    public partial class FrmStudentManagement : Form
    {
        private readonly StudentService _service;

        public FrmStudentManagement()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var factory = new SqlConnectionFactory(config);
            var studentRepository = new StudentRepository(factory);
            _service = new StudentService(studentRepository);

            LoadStudents();
        }

        // ==========================
        // LOAD DANH SÁCH SINH VIÊN
        // ==========================
        private void LoadStudents()
        {
            try
            {
                var students = _service.GetAllStudents();
                dgvStudents.AutoGenerateColumns = true;
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // ✅ THÊM SINH VIÊN
        // ==========================
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                var s = new StudentDto
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Faculty = txtFaculty.Text.Trim(),          // ✅ KHOA
                    Major = txtMajor.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = cmbStatus.Text,
                    Year = txtYear.Text.Trim(),
                    Password = txtPassword.Text.Trim()        // ✅ MẬT KHẨU
                };

                _service.AddStudent(s);
                LoadStudents();

                MessageBox.Show("✅ Thêm sinh viên thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi thêm sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // ✅ CẬP NHẬT SINH VIÊN
        // ==========================
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                var s = new StudentDto
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Faculty = txtFaculty.Text.Trim(),          // ✅ KHOA
                    Major = txtMajor.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = cmbStatus.Text,
                    Year = txtYear.Text.Trim(),
                    Password = txtPassword.Text.Trim()        // ✅ đổi nếu nhập
                };

                _service.UpdateStudent(s);
                LoadStudents();

                MessageBox.Show("✅ Cập nhật sinh viên thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi cập nhật: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // ✅ XÓA SINH VIÊN
        // ==========================
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV cần xóa!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?",
                "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _service.DeleteStudent(txtStudentId.Text.Trim());
                    LoadStudents();

                    MessageBox.Show("✅ Xóa sinh viên thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Lỗi khi xóa: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================
        // ✅ CLICK GRID → ĐỔ LÊN FORM
        // ==========================
        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStudents.Rows[e.RowIndex];

            txtStudentId.Text = row.Cells["StudentId"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            txtFaculty.Text = row.Cells["Faculty"].Value?.ToString();   // ✅ KHOA
            txtMajor.Text = row.Cells["Major"].Value?.ToString();
            txtSpecialization.Text = row.Cells["Specialization"].Value?.ToString();
            txtClass.Text = row.Cells["ClassName"].Value?.ToString();
            cmbGender.Text = row.Cells["Gender"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            cmbStatus.Text = row.Cells["Status"].Value?.ToString();
            txtYear.Text = row.Cells["Year"].Value?.ToString();

            txtPassword.Clear(); // ❗ không hiển thị mật khẩu
        }

        // ==========================
        // ✅ CLEAR FORM
        // ==========================
        private void ClearForm()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtFaculty.Clear();
            txtMajor.Clear();
            txtSpecialization.Clear();
            txtClass.Clear();
            cmbGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtCCCD.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbStatus.SelectedIndex = -1;
            txtYear.Clear();
            txtPassword.Clear();
            picStudent.Image = null;
        }

        // ==========================
        // ✅ TÌM SINH VIÊN
        // ==========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập Mã SV để tìm!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var student = _service.GetStudentById(keyword);
                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên!",
                        "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtStudentId.Text = student.StudentId;
                txtFullName.Text = student.FullName;
                txtFaculty.Text = student.Faculty;       // ✅
                txtMajor.Text = student.Major;
                txtSpecialization.Text = student.Specialization;
                txtClass.Text = student.ClassName;
                cmbGender.Text = student.Gender;
                txtPhone.Text = student.Phone;
                txtCCCD.Text = student.CCCD;
                txtEmail.Text = student.Email;
                txtAddress.Text = student.Address;
                cmbStatus.Text = student.Status;
                txtYear.Text = student.Year;

                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi tìm sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================
        // ✅ CHỌN ẢNH SINH VIÊN
        // ==========================
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
