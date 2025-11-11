
using StudentCourseManagement.Applications.Students;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using StudentCourseManagement.Infrastructure.Data;

namespace StudentCourseManagement.Presentation.Forms.Student
{
    public partial class FrmStudentManagement : Form
    {
        private readonly StudentService _service;
        private void StyleTextbox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Margin = new Padding(3);
            txt.BackColor = Color.White;
        }

        private void RoundButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Silver;
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.BackColor = Color.White;
        }

        public FrmStudentManagement()
        {
            InitializeComponent();
            grpPhoto.BackColor = Color.White;
            grpDetail.BackColor = Color.White;
            grpList.BackColor = Color.White;

            StyleButton(btnAdd);
            StyleButton(btnUpdate);
            StyleButton(btnDelete);


            StyleButtonLight(btnSearch);
            StyleButtonLight(btnSelectPhoto);


            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var factory = new SqlConnectionFactory(config);
            var studentRepository = new StudentRepository(factory);
            _service = new StudentService(studentRepository);

            // Setup UI
            StyleTextbox(txtStudentId);
            StyleTextbox(txtFullName);
            StyleTextbox(txtMajor);
            StyleTextbox(txtSpecialization);
            StyleTextbox(txtClass);
            StyleTextbox(txtPhone);
            StyleTextbox(txtCCCD);
            StyleTextbox(txtEmail);
            StyleTextbox(txtYear);
            StyleTextbox(txtAddress);

            RoundButton(btnAdd);
            RoundButton(btnUpdate);
            RoundButton(btnDelete);

            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new object[] { "Đang học", "Đã tốt nghiệp", "Bảo lưu" });
            cmbGender.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                var students = _service.GetAllStudents();
                dgvStudents.AutoGenerateColumns = true;
                dgvStudents.DataSource = null;        // reset binding
                dgvStudents.DataSource = students;    // bind mới
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var s = new StudentCourseManagement.Applications.Students.Dtos.StudentDto
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Major = txtMajor.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = cmbStatus.Text,
                    Year = txtYear.Text.Trim()
                };

                _service.AddStudent(s);

                LoadStudents();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var s = new StudentCourseManagement.Applications.Students.Dtos.StudentDto
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Major = txtMajor.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = cmbStatus.Text,
                    Year = txtYear.Text.Trim()
                };

                _service.UpdateStudent(s);
                LoadStudents();
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _service.DeleteStudent(txtStudentId.Text.Trim());
                    LoadStudents();
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                txtStudentId.Text = row.Cells["StudentId"].Value?.ToString();
                txtFullName.Text = row.Cells["FullName"].Value?.ToString();
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
            }
        }

        private void ClearForm()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
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
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = this.Controls.Find("txtSearch", true).FirstOrDefault() as TextBox;
            if (txtSearch == null) return;

            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập Mã SV để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tìm sinh viên theo mã
                var student = _service.GetStudentById(keyword);
                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có mã " + keyword, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Đổ thông tin ra form
                txtStudentId.Text = student.StudentId;
                txtFullName.Text = student.FullName;
                txtMajor.Text = student.Major;
                txtSpecialization.Text = student.Specialization;
                txtClass.Text = student.ClassName;
                cmbGender.Text = student.Gender;
                txtPhone.Text = student.Phone;
                txtCCCD.Text = student.CCCD;
                txtEmail.Text = student.Email;
                txtAddress.Text = student.Address;
                cmbStatus.Text = student.Status;
                txtYear.Text = student.Year.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void cmbGender_Click(object? sender, EventArgs e)
        {
            cmbGender.DroppedDown = true;
        }

        private void cmbStatus_Click(object? sender, EventArgs e)
        {
            cmbStatus.DroppedDown = true;
        }

        private void lblSpecialization_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentId.Text))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Mã SV cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1️⃣ Lấy thông tin từ form
                var s = new StudentCourseManagement.Applications.Students.Dtos.StudentDto
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Major = txtMajor.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = cmbStatus.Text,
                    Year = txtYear.Text.Trim()
                };

                // 2️⃣ Gọi service cập nhật SQL
                _service.UpdateStudent(s);

                // 3️⃣ Cập nhật lại ngay trên DataGridView (nếu đang chọn dòng)
                if (dgvStudents.SelectedRows.Count > 0)
                {
                    var row = dgvStudents.SelectedRows[0];
                    row.Cells["FullName"].Value = s.FullName;
                    row.Cells["Major"].Value = s.Major;
                    row.Cells["Specialization"].Value = s.Specialization;
                    row.Cells["ClassName"].Value = s.ClassName;
                    row.Cells["Gender"].Value = s.Gender;
                    row.Cells["Phone"].Value = s.Phone;
                    row.Cells["CCCD"].Value = s.CCCD;
                    row.Cells["Email"].Value = s.Email;
                    row.Cells["Address"].Value = s.Address;
                    row.Cells["Status"].Value = s.Status;
                    row.Cells["Year"].Value = s.Year;
                }

                MessageBox.Show("✅ Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }
        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.LightGray;
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Cursor = Cursors.Hand;

            btn.Paint += (s, e) =>
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10; // bo góc mềm
                    Rectangle rect = btn.ClientRectangle;

                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();

                    btn.Region = new Region(path);
                }
                ;
            };
            // Bo góc nhẹ
            btn.Region = new Region(new GraphicsPath(
                new PointF[]
                {
            new PointF(3, 0),
            new PointF(btn.Width - 3, 0),
            new PointF(btn.Width, 3),
            new PointF(btn.Width, btn.Height - 3),
            new PointF(btn.Width - 3, btn.Height),
            new PointF(3, btn.Height),
            new PointF(0, btn.Height - 3),
            new PointF(0, 3)
                },
                new byte[] { 1, 1, 1, 1, 1, 1, 1, 1 }
            ));
        }
        private void StyleButtonLight(Button btn)
        {
            StyleButton(btn); // kế thừa style chung
            btn.FlatAppearance.BorderColor = Color.Gainsboro;
            btn.ForeColor = Color.DimGray;
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _service.DeleteStudent(txtStudentId.Text.Trim());
                    LoadStudents();
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Tạo đối tượng sinh viên mới
                var s = new StudentCourseManagement.Applications.Students.Dtos.StudentDto
                {
                    StudentId = txtStudentId.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Major = txtMajor.Text.Trim(),
                    Specialization = txtSpecialization.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Gender = cmbGender.Text,
                    Phone = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = cmbStatus.Text,
                    Year = txtYear.Text.Trim()
                };

                // 2️⃣ Gọi service thêm vào SQL
                _service.AddStudent(s);

                // 3️⃣ Cập nhật DataGridView — thêm trực tiếp dòng mới vào dưới cùng
                var source = dgvStudents.DataSource as List<StudentCourseManagement.Applications.Students.Dtos.StudentDto>;
                if (source != null)
                {
                    source.Add(s);
                    dgvStudents.DataSource = null;
                    dgvStudents.DataSource = source;
                }
                else
                {
                    LoadStudents(); // fallback nếu datasource chưa set
                }

                MessageBox.Show("✅ Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
