using StudentCourseManagement.Applications.Students;
using StudentCourseManagement.Applications.Students.Dtos;
using StudentCourseManagement.Infrastructure.Repositories.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.Student
{
    public partial class FrmStudentManagement : Form
    {
        private readonly StudentService _service;
        private byte[] _selectedImageBytes;
        private string _oldStudentCode;
        public FrmStudentManagement()
        {
            InitializeComponent();
            picStudent.Image = null;
            picStudent.InitialImage = null;
            picStudent.ErrorImage = null;
            picStudent.ImageLocation = null;


            cmbSpecializationSql.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMajorSql.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFacultySql.DropDownStyle = ComboBoxStyle.DropDownList;


            // Load config SQL
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var factory = new SqlConnectionFactory(config);
            var repo = new StudentRepository(factory);
            _service = new StudentService(repo);

            SetupCombobox();
            LoadStudents();

        }

        // =========================
        // SETUP COMBOBOX
        // =========================
        private void SetupCombobox()
        {
            // ✅ CLEAR TOÀN BỘ TRƯỚC
            cmbGender.Items.Clear();
            cmbStatus.Items.Clear();

            cmbFacultySql.DataSource = null;
            cmbFacultySql.Items.Clear();

            cmbMajorSql.DataSource = null;
            cmbMajorSql.Items.Clear();

            cmbSpecializationSql.DataSource = null;
            cmbSpecializationSql.Items.Clear();

            // ✅ LOAD KHOA
            var faculties = _service.GetFaculties();
            cmbFacultySql.DataSource = new BindingSource(faculties, null);
            cmbFacultySql.DisplayMember = "Value";
            cmbFacultySql.ValueMember = "Key";

            // ✅ GIỚI TÍNH
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbFacultySql.SelectedIndex = -1;
            // ✅ TRẠNG THÁI
            cmbStatus.Items.AddRange(new object[] { "Đang học", "Đã tốt nghiệp", "Bảo lưu" });

            // ✅ GỠ EVENT CŨ ĐỂ TRÁNH GỌI LẶP
            cmbFacultySql.SelectedIndexChanged -= cmbFacultySql_SelectedIndexChanged;
            cmbMajorSql.SelectedIndexChanged -= cmbMajorSql_SelectedIndexChanged;

            // ✅ GẮN LẠI EVENT
            cmbFacultySql.SelectedIndexChanged += cmbFacultySql_SelectedIndexChanged;
            cmbMajorSql.SelectedIndexChanged += cmbMajorSql_SelectedIndexChanged;
            cmbSpecializationSql.SelectedIndexChanged += cmbSpecializationSql_SelectedIndexChanged;

        }




        // =========================
        // LOAD DANH SÁCH
        // =========================
        private void LoadStudents()
        {
            try
            {
                var data = _service.GetAllStudents();
                foreach (var s in data)
                {
                    Console.WriteLine(
                        $"SV: {s.StudentId} | Major: {s.Major} | Specialization: [{s.Specialization}]"
                    );
                }
                // XÓA TOÀN BỘ CỘT CŨ TRONG DESIGNER
                dgvStudents.DataSource = null;
                dgvStudents.Columns.Clear();

                // TỰ SINH CỘT THEO StudentDto
                dgvStudents.AutoGenerateColumns = true;
                dgvStudents.DataSource = data;

                string[] hideCols =
 {
    "FacultyId",
    "ClassId",
    "MajorId",
    "SpecializationId",
    "ProfileImage"   // ✅ ẨN CỘT ẢNH
};


                foreach (var name in hideCols)
                {
                    if (dgvStudents.Columns[name] != null)
                        dgvStudents.Columns[name].Visible = false;
                }



                dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";
                dgvStudents.Columns["FullName"].HeaderText = "Họ và Tên";
                dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
                dgvStudents.Columns["Faculty"].HeaderText = "Khoa";
                dgvStudents.Columns["Major"].HeaderText = "Ngành";
                dgvStudents.Columns["Specialization"].HeaderText = "Chuyên ngành";
                dgvStudents.Columns["ClassName"].HeaderText = "Lớp";
                dgvStudents.Columns["Phone"].HeaderText = "SĐT";
                dgvStudents.Columns["CCCD"].HeaderText = "CCCD";
                dgvStudents.Columns["Email"].HeaderText = "Email";
                dgvStudents.Columns["Address"].HeaderText = "Địa chỉ";
                dgvStudents.Columns["Status"].HeaderText = "Trạng thái";
                dgvStudents.Columns["Year"].HeaderText = "Năm học";
                dgvStudents.Columns["Password"].HeaderText = "Mật khẩu";

                dgvStudents.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách: " + ex.Message);
            }
        }

        // =========================
        // THÊM
        // =========================
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                // ✅ CHẶN NẾU CHƯA ĐIỀN ĐỦ
                if (!IsValidStudentInput())
                    return;

                var dto = GetDtoFromForm();
                _service.AddStudent(dto);

                LoadStudents();
                ClearForm();

                MessageBox.Show("✅ Thêm sinh viên thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi thêm: " + ex.Message);
            }
        }



        // =========================
        // CẬP NHẬT
        // =========================
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_oldStudentCode))
                {
                    MessageBox.Show("❌ Chưa chọn sinh viên để cập nhật!");
                    return;
                }

                var dto = GetDtoFromForm();

                _service.UpdateStudent(dto, _oldStudentCode);   // ✅ TRUYỀN MÃ CŨ

                LoadStudents();
                ClearForm();

                MessageBox.Show("✅ Cập nhật thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi cập nhật: " + ex.Message);
            }
        }



        // =========================
        // XÓA
        // =========================
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _service.DeleteStudent(txtStudentId.Text.Trim());

                    LoadStudents();
                    ClearForm();

                    MessageBox.Show("✅ Đã xóa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi xóa: " + ex.Message);
                }
            }
        }



        // =========================
        // CLICK GRID → ĐỔ FORM
        // =========================
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            picStudent.Image = null;
            picStudent.ErrorImage = null;
            if (dgvStudents.Rows[e.RowIndex].DataBoundItem is not StudentDto s)
                return;

            // ===== ĐỔ THÔNG TIN FORM =====
            txtStudentId.Text = s.StudentId;
            _oldStudentCode = s.StudentId;
            txtFullName.Text = s.FullName;

            SelectItemByText(cmbFacultySql, s.Faculty);

            cmbMajorSql.BeginInvoke(new Action(() =>
            {
                SelectItemByText(cmbMajorSql, s.Major);

                cmbSpecializationSql.BeginInvoke(new Action(() =>
                {
                    SelectItemByText(cmbSpecializationSql, s.Specialization);

                    cmbClassSql.BeginInvoke(new Action(() =>
                    {
                        SelectItemByText(cmbClassSql, s.ClassName);
                    }));
                }));
            }));

            cmbGender.Text = s.Gender;
            txtPhone.Text = s.Phone;
            txtCCCD.Text = s.CCCD;
            txtYear.Text = s.Year;
            txtAddress.Text = s.Address;
            cmbStatus.Text = s.Status;
            txtPassword.Text = s.Password;

            // ===== ✅ HIỂN THỊ ẢNH (QUAN TRỌNG NHẤT) =====
            if (s.ProfileImage != null && s.ProfileImage.Length > 0)
            {
                using var ms = new MemoryStream(s.ProfileImage);
                picStudent.Image = Image.FromStream(ms);
            }
            else
            {
                picStudent.Image = null;
            }
        }




        // =========================
        // TÌM KIẾM
        // =========================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var key = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(key)) return;

            var sv = _service.GetStudentById(key);
            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy!");
                ClearStudentImage();   // ✅ Bắt buộc clear khi không có
                return;
            }

            txtStudentId.Text = sv.StudentId;
            txtFullName.Text = sv.FullName;
            cmbFacultySql.Text = sv.Faculty;
            cmbMajorSql.Text = sv.Major;
            cmbSpecializationSql.Text = sv.Specialization;
            SelectItemByText(cmbClassSql, sv.ClassName);
            cmbGender.Text = sv.Gender;
            txtPhone.Text = sv.Phone;
            txtCCCD.Text = sv.CCCD;
            txtYear.Text = sv.Year;
            txtAddress.Text = sv.Address;
            cmbStatus.Text = sv.Status;

            _oldStudentCode = sv.StudentId;

            // ✅✅✅ PHẦN QUAN TRỌNG NHẤT – LOAD ẢNH
            if (sv.ProfileImage != null && sv.ProfileImage.Length > 0)
            {
                using var ms = new MemoryStream(sv.ProfileImage);
                picStudent.Image?.Dispose();
                picStudent.Image = Image.FromStream(ms);

                _selectedImageBytes = sv.ProfileImage; // ✅ BẮT BUỘC GÁN LẠI
            }
            else
            {
                ClearStudentImage();
            }
        }


        // =========================
        // DTO TỪ FORM
        // =========================
        private StudentDto GetDtoFromForm()
        {
            return new StudentDto
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),

                // ✅✅✅ BỔ SUNG DÒNG QUAN TRỌNG NHẤT
                FacultyId = cmbFacultySql.SelectedValue is Guid f ? f : (Guid?)null,

                // ✅ GIỮ NGUYÊN CÁC DÒNG NÀY
                MajorId = cmbMajorSql.SelectedValue is Guid m ? m : (Guid?)null,
                SpecializationId = cmbSpecializationSql.SelectedValue is Guid s ? s : (Guid?)null,
                ClassId = cmbClassSql.SelectedValue is Guid c ? c : (Guid?)null,

                // ✅ TEXT CHỈ ĐỂ HIỂN THỊ
                Faculty = cmbFacultySql.Text,
                Major = cmbMajorSql.Text,
                Specialization = cmbSpecializationSql.Text,
                ClassName = cmbClassSql.Text,

                Gender = cmbGender.Text,
                Phone = txtPhone.Text.Trim(),
                CCCD = txtCCCD.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Year = txtYear.Text.Trim(),
                Status = cmbStatus.Text switch
                {
                    "Bảo lưu" => "PAUSED",
                    "Đã tốt nghiệp" => "ALUMNI",
                    _ => "User"
                },

                ProfileImage = _selectedImageBytes
                    ?? (dgvStudents.CurrentRow?.DataBoundItem as StudentDto)?.ProfileImage,

                Email = txtStudentId.Text.Trim() + "@epu.edu.vn",

                Password = string.IsNullOrWhiteSpace(txtPassword.Text)
                    ? null
                    : txtPassword.Text.Trim()
            };
        }





        // =========================
        // CLEAR FORM
        // =========================
        private void ClearForm()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            cmbClassSql.SelectedIndex = -1;
            txtPassword.Clear();
            txtPhone.Clear();
            txtCCCD.Clear();

            txtYear.Clear();
            txtAddress.Clear();

            cmbFacultySql.SelectedIndex = -1;
            cmbMajorSql.SelectedIndex = -1;
            cmbSpecializationSql.SelectedIndex = -1;

            cmbGender.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            picStudent.Image = null;
            _selectedImageBytes = null;
            ClearStudentImage();      // ✅ QUAN TRỌNG
            _oldStudentCode = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtSearch.Clear();

            LoadStudents();          // ✅ BẮT BUỘC CALL LẠI
            dgvStudents.ClearSelection();
        }


        // =========================
        // CHỌN ẢNH
        // =========================
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            // ✅ CHẶN KHI CHƯA NHẬP MÃ SINH VIÊN
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Mã sinh viên trước khi chọn ảnh!",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtStudentId.Focus();
                return;
            }

            using var ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image?.Dispose();                 // ✅ GIẢI PHÓNG ẢNH CŨ
                picStudent.ImageLocation = ofd.FileName;
                _selectedImageBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void cmbFacultySql_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFacultySql.SelectedValue is Guid facultyId)
            {
                var majors = _service.GetMajorsByFaculty(facultyId); // Dictionary<Guid,string>

                // ✅ CHUYỂN SANG LIST ĐỂ BIND CHO CHẮC
                var majorList = majors.ToList();   // List<KeyValuePair<Guid,string>>

                cmbMajorSql.DataSource = null;     // clear trước cho sạch
                cmbMajorSql.DisplayMember = "Value";
                cmbMajorSql.ValueMember = "Key";
                cmbMajorSql.DataSource = majorList;

                cmbMajorSql.SelectedIndex = -1;
            }
        }


        private void cmbMajorSql_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMajorSql.SelectedValue is Guid majorId)
            {
                // RESET CHUYÊN NGÀNH & LỚP
                cmbSpecializationSql.DataSource = null;
                cmbSpecializationSql.Items.Clear();

                cmbClassSql.DataSource = null;
                cmbClassSql.Items.Clear();

                // LOAD CHUYÊN NGÀNH
                var specs = _service.GetSpecializationsByMajor(majorId);

                cmbSpecializationSql.DataSource = new BindingSource(specs, null);
                cmbSpecializationSql.DisplayMember = "Value";
                cmbSpecializationSql.ValueMember = "Key";

                cmbSpecializationSql.SelectedIndex = -1;
            }
        }

        private void SelectItemByText(ComboBox combo, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                combo.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < combo.Items.Count; i++)
            {
                var item = combo.Items[i];
                if (combo.GetItemText(item).Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }
        private void cmbSpecializationSql_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecializationSql.SelectedValue is Guid specId)
            {
                cmbClassSql.DataSource = null;
                cmbClassSql.Items.Clear();

                var classes = _service.GetClassesBySpecialization(specId);

                cmbClassSql.DataSource = new BindingSource(classes, null);
                cmbClassSql.DisplayMember = "Value";
                cmbClassSql.ValueMember = "Key";

                cmbClassSql.SelectedIndex = -1;
            }
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;

            if (dgvStudents.CurrentRow.DataBoundItem is StudentDto s)
            {
                if (s.ProfileImage != null && s.ProfileImage.Length > 0)
                {
                    using (var ms = new MemoryStream(s.ProfileImage))
                    {
                        picStudent.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picStudent.Image = null;
                }
            }
        }
        private void ClearStudentImage()
        {
            if (picStudent.Image != null)
            {
                picStudent.Image.Dispose();
                picStudent.Image = null;
            }

            _selectedImageBytes = null;
        }
        private bool CanUploadImage()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Mã sinh viên trước khi chọn ảnh!",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtStudentId.Focus();
                return false;
            }

            return true;
        }


        private bool IsValidStudentInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!");
                txtStudentId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên!");
                txtFullName.Focus();
                return false;
            }

            if (cmbFacultySql.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa!");
                return false;
            }

            if (cmbMajorSql.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Ngành!");
                return false;
            }

            if (cmbSpecializationSql.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Chuyên ngành!");
                return false;
            }

            if (cmbClassSql.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Lớp!");
                return false;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Giới tính!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!");
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD!");
                txtCCCD.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Vui lòng nhập Năm học!");
                txtYear.Focus();
                return false;
            }

            // ✅ BỔ SUNG: MẬT KHẨU
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!");
                txtPassword.Focus();
                return false;
            }

            // ✅ BỔ SUNG: ĐỊA CHỈ
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ!");
                txtAddress.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Trạng thái!");
                return false;
            }

            return true; // ✅ ĐẦY ĐỦ → CHO PHÉP THÊM
        }






        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblSearch_Click(object sender, EventArgs e) { }
    }
}