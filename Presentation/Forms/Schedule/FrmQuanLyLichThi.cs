using System_Data = System.Data;
using System;
using System.Windows.Forms;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using StudentCourseManagement.Domain.Abstractions.Services;
using System.Data;

namespace StudentCourseManagement.Presentation.Forms.Schedule
{
    public partial class FrmQuanLyLichThi : Form
    {
        private readonly IScheduleService _scheduleService;
        private readonly IExamScheduleService _examScheduleService;

        private bool isAdding = false;
        private bool isEditing = false;

        private Guid selectedExam_ID = Guid.Empty;

        private bool isBindingFromGrid = false;

        public FrmQuanLyLichThi()
        {
            InitializeComponent();
            _scheduleService = ServicesFactory.CreateScheduleService();
            _examScheduleService = ServicesFactory.CreateExamScheduleService();
        }

        private void FrmQuanLyLichThi_Load(object sender, EventArgs e)
        {
            dtpExamDateTime.Format = DateTimePickerFormat.Custom;
            dtpExamDateTime.CustomFormat = "dd/MM/yyyy HH:mm";

            LoadData();
            LoadKhoaData();
            LoadMonHocData();
            LoadHinhThucThiData();
            LoadSemesterData();

            SetControlState(false);
        }

        #region Tải dữ liệu ComboBox

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

        private void LoadLopHocData(Guid specializationId)
        {
            cboLopHoc.DataSource = _scheduleService.GetClassesBySpecialization(specializationId.ToString());
            cboLopHoc.DisplayMember = "ClassName";
            cboLopHoc.ValueMember = "Id";
            cboLopHoc.SelectedIndex = -1;
        }

        private void LoadMonHocData()
        {
            cboMonHoc.DataSource = _scheduleService.GetSubjects();
            cboMonHoc.DisplayMember = "SubjectName";
            cboMonHoc.ValueMember = "Id";
            cboMonHoc.SelectedIndex = -1;
        }

        private void LoadSemesterData()
        {
            cboSemester.DataSource = _scheduleService.GetSemesters();
            cboSemester.DisplayMember = "DisplayName";
            cboSemester.ValueMember = "Id";
            cboSemester.SelectedIndex = -1;
        }

        private void LoadHinhThucThiData()
        {
            cboHinhThucThi.Items.Clear();
            cboHinhThucThi.Items.Add("Tự luận");
            cboHinhThucThi.Items.Add("Trắc nghiệm");
            cboHinhThucThi.Items.Add("Vấn đáp");
            cboHinhThucThi.Items.Add("Thực hành");
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingFromGrid) return;
            if (cboKhoa.SelectedItem is System_Data.DataRowView drv)
            {
                Guid facultyId = (Guid)drv["Id"];
                LoadNganhData(facultyId);
                cboNganh.Enabled = true;
                cboChuyenNganh.DataSource = null;
                cboChuyenNganh.Enabled = false;
                cboLopHoc.DataSource = null;
                cboLopHoc.Enabled = false;
            }
        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingFromGrid) return;
            if (cboNganh.SelectedItem is System_Data.DataRowView drv)
            {
                Guid majorId = (Guid)drv["Id"];
                LoadChuyenNganhData(majorId);
                cboChuyenNganh.Enabled = true;
                cboLopHoc.DataSource = null;
                cboLopHoc.Enabled = false;
            }
        }

        private void cboChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingFromGrid) return;
            if (cboChuyenNganh.SelectedItem is System_Data.DataRowView drv)
            {
                Guid specializationId = (Guid)drv["Id"];
                LoadLopHocData(specializationId);
                cboLopHoc.Enabled = true;
            }
            else
            {
                cboLopHoc.DataSource = null;
                cboLopHoc.Enabled = false;
            }
        }

        #endregion

        #region Logic CRUD

        private void LoadData()
        {
            dgvLichThi.DataSource = _examScheduleService.GetExamSchedules();
            if (dgvLichThi.Columns.Count > 0)
            {
                dgvLichThi.Columns["Id"].Visible = false;
                dgvLichThi.Columns["ClassId"].Visible = false;
                dgvLichThi.Columns["SubjectId"].Visible = false;
                dgvLichThi.Columns["SemesterId"].Visible = false;
                dgvLichThi.Columns["SpecializationId"].Visible = false;
                dgvLichThi.Columns["MajorId"].Visible = false;
                dgvLichThi.Columns["FacultyId"].Visible = false;

                dgvLichThi.Columns["SubjectName"].DisplayIndex = 0;
                dgvLichThi.Columns["SubjectName"].HeaderText = "Môn thi";

                dgvLichThi.Columns["ClassName"].DisplayIndex = 1;
                dgvLichThi.Columns["ClassName"].HeaderText = "Lớp";

                dgvLichThi.Columns["ExamDate"].DisplayIndex = 2;
                dgvLichThi.Columns["ExamDate"].HeaderText = "Ngày thi";
                dgvLichThi.Columns["ExamDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                dgvLichThi.Columns["ExamDuration"].DisplayIndex = 3;
                dgvLichThi.Columns["ExamDuration"].HeaderText = "Thời gian (phút)";

                dgvLichThi.Columns["ExamType"].DisplayIndex = 4;
                dgvLichThi.Columns["ExamType"].HeaderText = "Hình thức thi";

                dgvLichThi.Columns["Room"].DisplayIndex = 5;
                dgvLichThi.Columns["Room"].HeaderText = "Phòng thi";

                dgvLichThi.Columns["SemesterDisplayName"].DisplayIndex = 6;
                dgvLichThi.Columns["SemesterDisplayName"].HeaderText = "Học kỳ";
            }
        }

        private void SetControlState(bool enabled)
        {
            cboKhoa.Enabled = enabled;
            cboMonHoc.Enabled = enabled;
            cboSemester.Enabled = enabled;
            dtpExamDateTime.Enabled = enabled;
            numThoiGianLamBai.Enabled = enabled;
            cboHinhThucThi.Enabled = enabled;
            txtPhongThi.Enabled = enabled;

            btnLuu.Enabled = enabled;
            btnHuy.Enabled = enabled;

            btnThem.Enabled = !enabled;
            btnSua.Enabled = !enabled;
            btnXoa.Enabled = !enabled;
            dgvLichThi.Enabled = !enabled;

            if (!enabled)
            {
                cboNganh.Enabled = false;
                cboChuyenNganh.Enabled = false;
                cboLopHoc.Enabled = false;
            }
        }

        private void ClearInput()
        {
            cboKhoa.SelectedIndex = -1;
            cboNganh.DataSource = null;
            cboChuyenNganh.DataSource = null;
            cboLopHoc.DataSource = null;
            cboMonHoc.SelectedIndex = -1;
            cboSemester.SelectedIndex = -1;
            dtpExamDateTime.Value = DateTime.Now;
            numThoiGianLamBai.Value = 60;
            cboHinhThucThi.SelectedIndex = -1;
            txtPhongThi.Text = "";
            selectedExam_ID = Guid.Empty;
        }

        private void dgvLichThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isBindingFromGrid = true;
                DataGridViewRow row = dgvLichThi.Rows[e.RowIndex];

                Guid maKhoa = (Guid)row.Cells["FacultyId"].Value;
                Guid maNganh = (Guid)row.Cells["MajorId"].Value;
                Guid maChuyenNganh = (Guid)row.Cells["SpecializationId"].Value;
                Guid maLop = (Guid)row.Cells["ClassId"].Value;

                cboKhoa.SelectedValue = maKhoa;
                LoadNganhData(maKhoa);
                cboNganh.Enabled = true;
                cboNganh.SelectedValue = maNganh;
                LoadChuyenNganhData(maNganh);
                cboChuyenNganh.Enabled = true;
                cboChuyenNganh.SelectedValue = maChuyenNganh;
                LoadLopHocData(maChuyenNganh);
                cboLopHoc.Enabled = true;
                cboLopHoc.SelectedValue = maLop;

                selectedExam_ID = (Guid)row.Cells["Id"].Value;
                cboMonHoc.SelectedValue = (Guid)row.Cells["SubjectId"].Value;
                cboSemester.SelectedValue = (Guid)row.Cells["SemesterId"].Value;
                dtpExamDateTime.Value = Convert.ToDateTime(row.Cells["ExamDate"].Value);

                var duration = row.Cells["ExamDuration"].Value;
                numThoiGianLamBai.Value = (duration == DBNull.Value || duration == null) ? 60 : Convert.ToDecimal(duration);

                var examType = row.Cells["ExamType"].Value;
                cboHinhThucThi.SelectedItem = (examType == DBNull.Value || examType == null) ? null : examType.ToString();

                txtPhongThi.Text = row.Cells["Room"].Value.ToString();

                isBindingFromGrid = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            ClearInput();
            SetControlState(true);
            cboKhoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLichThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch thi để sửa.", "Thông báo");
                return;
            }
            isAdding = false;
            isEditing = true;
            SetControlState(true);
            cboNganh.Enabled = true;
            cboChuyenNganh.Enabled = true;
            cboLopHoc.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch thi để xóa.", "Thông báo");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lịch thi này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _examScheduleService.RemoveExamSchedule(selectedExam_ID);
                MessageBox.Show("Xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedValue == null || cboMonHoc.SelectedValue == null || cboHinhThucThi.SelectedItem == null || cboSemester.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Lớp, Môn học, Học kỳ, Hình thức thi.", "Lỗi");
                return;
            }

            Guid lopId = (Guid)cboLopHoc.SelectedValue;
            Guid monHocId = (Guid)cboMonHoc.SelectedValue;
            Guid semesterId = (Guid)cboSemester.SelectedValue;
            DateTime examDate = dtpExamDateTime.Value;
            int thoiGian = (int)numThoiGianLamBai.Value;
            string hinhThuc = cboHinhThucThi.SelectedItem.ToString()!;
            string phongThi = txtPhongThi.Text.Trim();

            if (isAdding)
            {
                _examScheduleService.AddExamSchedule(lopId, monHocId, semesterId, phongThi, examDate, thoiGian, hinhThuc);
                MessageBox.Show("Thêm mới thành công!");
            }
            else if (isEditing)
            {
                _examScheduleService.UpdateExamSchedule(selectedExam_ID, lopId, monHocId, semesterId, phongThi, examDate, thoiGian, hinhThuc);
                MessageBox.Show("Cập nhật thành công!");
            }

            LoadData();
            SetControlState(false);
            isAdding = false;
            isEditing = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            isAdding = false;
            isEditing = false;

            if (dgvLichThi.SelectedRows.Count > 0)
            {
                dgvLichThi_CellClick(dgvLichThi, new DataGridViewCellEventArgs(0, dgvLichThi.SelectedRows[0].Index));
            }
            else
            {
                ClearInput();
            }
        }
        #endregion
    }
}