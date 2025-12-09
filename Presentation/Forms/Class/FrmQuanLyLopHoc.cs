using System;
using System.Data;
using System.Windows.Forms;
using StudentCourseManagement.Domain.Abstractions.Services;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.Class
{
    public partial class FrmQuanLyLopHoc : Form
    {
        private readonly IScheduleService _scheduleService;
        private readonly IClassService _classService;

        private bool isAdding = false;
        private bool isEditing = false;
        private Guid selectedClassId = Guid.Empty;
        private bool isBindingFromGrid = false;

        public FrmQuanLyLopHoc()
        {
            InitializeComponent();
            _scheduleService = ServicesFactory.CreateScheduleService();
            _classService = ServicesFactory.CreateClassService();
        }

        private void FrmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            LoadKhoaData();
            SetControlState(false);
            StyleHelper.ApplyFormStyle(this);

            txtMaLop.Enabled = false;
            txtTenLop.Enabled = false;
            numSiSo.Enabled = false;
            txtCoVan.Enabled = false;
        }

        #region Tải dữ liệu ComboBox liên kết (Cascading)

        private void LoadKhoaData()
        {
            cboKhoa.DataSource = _scheduleService.GetFaculties();
            cboKhoa.DisplayMember = "FacultyName";
            cboKhoa.ValueMember = "Id";
            cboKhoa.SelectedIndex = -1;
        }

        private void LoadNganhData(Guid facultyId)
        {
            cboNganh.DataSource = _scheduleService.GetMajorsByFaculty(facultyId.ToString());
            cboNganh.DisplayMember = "MajorName";
            cboNganh.ValueMember = "Id";
            cboNganh.SelectedIndex = -1;
        }

        private void LoadChuyenNganhData(Guid majorId)
        {
            cboChuyenNganh.DataSource = _scheduleService.GetSpecializationsByMajor(majorId.ToString());
            cboChuyenNganh.DisplayMember = "SpecializationName";
            cboChuyenNganh.ValueMember = "Id";
            cboChuyenNganh.SelectedIndex = -1;
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingFromGrid) return;
            if (cboKhoa.SelectedItem is DataRowView drv)
            {
                LoadNganhData((Guid)drv["Id"]);
                cboNganh.Enabled = true;
            }
            else cboNganh.Enabled = false;

            cboChuyenNganh.DataSource = new DataTable();
            cboChuyenNganh.Enabled = false;
        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingFromGrid) return;
            if (cboNganh.SelectedItem is DataRowView drv)
            {
                LoadChuyenNganhData((Guid)drv["Id"]);
                cboChuyenNganh.Enabled = true;
            }
            else
            {
                cboChuyenNganh.DataSource = new DataTable();
                cboChuyenNganh.Enabled = false;
            }
        }

        #endregion

        #region Logic CRUD

        private void btnTaiLop_Click(object? sender, EventArgs e)
        {
            Guid? facultyId = null;
            Guid? majorId = null;
            Guid? specializationId = null;

            if (cboKhoa.SelectedValue != null)
                facultyId = (Guid)cboKhoa.SelectedValue;

            if (cboNganh.SelectedValue != null)
                majorId = (Guid)cboNganh.SelectedValue;

            if (cboChuyenNganh.SelectedValue != null)
                specializationId = (Guid)cboChuyenNganh.SelectedValue;

            if (facultyId == null)
            {
                MessageBox.Show("Vui lòng chọn ít nhất là Khoa.", "Thông báo");
                return;
            }

            dgvLopHoc.DataSource = _classService.GetFilteredClasses(facultyId, majorId, specializationId);

            FormatGridView();
            ClearInput();
        }

        private void FormatGridView()
        {
            if (dgvLopHoc.Columns.Count > 0)
            {
                dgvLopHoc.Columns["Id"].Visible = false;
                dgvLopHoc.Columns["SpecializationId"].Visible = false;
                dgvLopHoc.Columns["MajorId"].Visible = false;
                dgvLopHoc.Columns["FacultyId"].Visible = false;

                dgvLopHoc.Columns["ClassCode"].HeaderText = "Mã Lớp";
                dgvLopHoc.Columns["ClassName"].HeaderText = "Tên Lớp";

                if (dgvLopHoc.Columns.Contains("StudentCount"))
                    dgvLopHoc.Columns["StudentCount"].HeaderText = "Sĩ Số";
                if (dgvLopHoc.Columns.Contains("AdvisorName"))
                    dgvLopHoc.Columns["AdvisorName"].HeaderText = "Cố vấn";
            }
        }

        private void SetControlState(bool isEditingOrAdding)
        {
            txtMaLop.Enabled = isEditingOrAdding;
            txtTenLop.Enabled = isEditingOrAdding;
            numSiSo.Enabled = isEditingOrAdding;
            txtCoVan.Enabled = isEditingOrAdding;

            btnLuu.Enabled = isEditingOrAdding;
            btnHuy.Enabled = isEditingOrAdding;

            btnThem.Enabled = !isEditingOrAdding;
            btnSua.Enabled = !isEditingOrAdding;
            btnXoa.Enabled = !isEditingOrAdding;

            dgvLopHoc.Enabled = !isEditingOrAdding;

            cboKhoa.Enabled = !isEditingOrAdding;
            cboNganh.Enabled = !isEditingOrAdding;
            cboChuyenNganh.Enabled = !isEditingOrAdding;
            btnTaiLop.Enabled = !isEditingOrAdding;

            groupBox1.Enabled = true;
        }

        private void ClearInput()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            numSiSo.Value = 0;
            txtCoVan.Text = "";
            selectedClassId = Guid.Empty;
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isBindingFromGrid = true;
                DataGridViewRow row = dgvLopHoc.Rows[e.RowIndex];

                Guid maKhoa = (Guid)row.Cells["FacultyId"].Value;
                Guid maNganh = (Guid)row.Cells["MajorId"].Value;
                Guid maChuyenNganh = (Guid)row.Cells["SpecializationId"].Value;

                cboKhoa.SelectedValue = maKhoa;
                LoadNganhData(maKhoa);
                cboNganh.Enabled = true;
                cboNganh.SelectedValue = maNganh;
                LoadChuyenNganhData(maNganh);
                cboChuyenNganh.Enabled = true;
                cboChuyenNganh.SelectedValue = maChuyenNganh;

                selectedClassId = (Guid)row.Cells["Id"].Value;
                txtMaLop.Text = row.Cells["ClassCode"].Value.ToString();
                txtTenLop.Text = row.Cells["ClassName"].Value.ToString();

                var studentCount = row.Cells["StudentCount"].Value;
                numSiSo.Value = (studentCount == DBNull.Value || studentCount == null) ? 0 : Convert.ToDecimal(studentCount);

                var advisorName = row.Cells["AdvisorName"].Value;
                txtCoVan.Text = (advisorName == DBNull.Value || advisorName == null) ? "" : advisorName.ToString();

                isBindingFromGrid = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboChuyenNganh.SelectedValue == null || cboNganh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng Tải lớp theo Khoa, Ngành và Chuyên ngành trước khi thêm.", "Thông báo");
                return;
            }

            isAdding = true;
            isEditing = false;
            ClearInput();
            SetControlState(true);
            txtMaLop.Enabled = true;
            txtMaLop.Focus();

            cboKhoa.Enabled = false;
            cboNganh.Enabled = false;
            cboChuyenNganh.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp để sửa.", "Thông báo");
                return;
            }
            isAdding = false;
            isEditing = true;
            SetControlState(true);
            txtMaLop.Enabled = true;

            cboKhoa.Enabled = false;
            cboNganh.Enabled = false;
            cboChuyenNganh.Enabled = false;

            txtTenLop.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp để xóa.", "Thông báo");
                return;
            }
            string maLop = txtMaLop.Text;
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp '{maLop}'?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _classService.RemoveClass(selectedClassId);
                MessageBox.Show("Xóa thành công!");

                btnTaiLop_Click(null, null);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboChuyenNganh.SelectedValue == null || cboNganh.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMaLop.Text) || string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Khoa, Ngành, Chuyên ngành, Mã lớp, Tên lớp).", "Lỗi");
                return;
            }

            Guid majorId = (Guid)cboNganh.SelectedValue;
            Guid specializationId = (Guid)cboChuyenNganh.SelectedValue;
            string classCode = txtMaLop.Text.Trim();
            string className = txtTenLop.Text.Trim();
            int studentCount = (int)numSiSo.Value;
            string advisorName = txtCoVan.Text.Trim();
            if (isAdding)
            {
                if (_classService.CheckClassCodeExists(classCode))
                {
                    MessageBox.Show("Mã lớp này đã tồn tại. Vui lòng nhập mã khác.", "Lỗi");
                    txtMaLop.Focus();
                    return;
                }
                if (_classService.CheckClassNameExists(className))
                {
                    MessageBox.Show("Tên lớp này đã tồn tại!", "Lỗi trùng tên");
                    txtTenLop.Focus();
                    return;
                }

                _classService.AddClass(classCode, className, studentCount, advisorName, majorId, specializationId);
                MessageBox.Show("Thêm mới thành công!");
            }
            else if (isEditing)
            {
                if (_classService.CheckClassCodeExists(classCode, selectedClassId))
                {
                    MessageBox.Show("Mã lớp này đã tồn tại. Vui lòng nhập mã khác.", "Lỗi");
                    txtMaLop.Focus();
                    return;
                }

                if (_classService.CheckClassNameExists(className, selectedClassId))
                {
                    MessageBox.Show("Tên lớp này đã tồn tại!", "Lỗi trùng tên");
                    txtTenLop.Focus();
                    return;
                }

                _classService.UpdateClass(
                    selectedClassId,
                    classCode,
                    className,
                    studentCount,
                    advisorName,
                    majorId,
                    specializationId
                );

                MessageBox.Show("Cập nhật thành công!");
            }

            btnTaiLop_Click(null, null);
            SetControlState(false);
            isAdding = false;
            isEditing = false;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            isAdding = false;
            isEditing = false;

            if (dgvLopHoc.SelectedRows.Count > 0)
            {
                dgvLopHoc_CellClick(dgvLopHoc, new DataGridViewCellEventArgs(0, dgvLopHoc.SelectedRows[0].Index));
            }
            else
            {
                ClearInput();
            }
        }
        #endregion
    }
}