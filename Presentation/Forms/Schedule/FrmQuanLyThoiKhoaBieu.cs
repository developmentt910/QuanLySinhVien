using System;
using System.Data;
using System.Windows.Forms;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using StudentCourseManagement.Domain.Abstractions.Services;

namespace StudentCourseManagement.Presentation.Forms.Schedule
{
    public partial class FrmQuanLyThoiKhoaBieu : Form
    {
        private string currentClassId = "";
        private string currentSemesterId = "";
        private Guid currentMajorId = Guid.Empty;
        private Guid currentSpecializationId = Guid.Empty;
        private DataTable dtAvailableSubjects = new DataTable();
        private readonly IScheduleService _scheduleService;

        public FrmQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
            _scheduleService = ServicesFactory.CreateScheduleService();
        }

        private void FrmQuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            dtpLessonDate.Format = DateTimePickerFormat.Short;
            LoadKhoaData();
            LoadKyHocData();
            StyleHelper.ApplyFormStyle(this);
            cboNganh.Enabled = false;
            cboChuyenNganh.Enabled = false;
            cboLopHoc.Enabled = false;
            groupBoxAdd.Enabled = false;
        }

        private void LoadKhoaData()
        {
            cboKhoa.DataSource = _scheduleService.GetFaculties();
            cboKhoa.DisplayMember = "FacultyName";
            cboKhoa.ValueMember = "Id";
            cboKhoa.SelectedIndex = -1;
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? facultyId = null;
            if (cboKhoa.SelectedItem is DataRowView drv)
                facultyId = drv["Id"]?.ToString();

            if (!string.IsNullOrEmpty(facultyId))
            {
                cboNganh.DataSource = _scheduleService.GetMajorsByFaculty(facultyId);
                cboNganh.DisplayMember = "MajorName";
                cboNganh.ValueMember = "Id";
                cboNganh.SelectedIndex = -1;
                cboNganh.Enabled = true;
            }
            else
            {
                cboNganh.Enabled = false;
                cboChuyenNganh.Enabled = false;
                cboLopHoc.Enabled = false;
            }
        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? majorIdStr = null;
            if (cboNganh.SelectedItem is DataRowView drv)
                majorIdStr = drv["Id"]?.ToString();

            if (!string.IsNullOrEmpty(majorIdStr))
            {
                currentMajorId = new Guid(majorIdStr);
                cboChuyenNganh.DataSource = _scheduleService.GetSpecializationsByMajor(majorIdStr);
                cboChuyenNganh.DisplayMember = "SpecializationName";
                cboChuyenNganh.ValueMember = "Id";
                cboChuyenNganh.SelectedIndex = -1;
                cboChuyenNganh.Enabled = true;
            }
            else
            {
                cboChuyenNganh.Enabled = false;
                cboLopHoc.Enabled = false;
            }
        }

        private void cboChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenNganh.SelectedItem is not DataRowView drv) return;

            currentSpecializationId = new Guid(drv["Id"].ToString());

            cboLopHoc.DataSource = _scheduleService.GetClassesBySpecialization(currentSpecializationId.ToString());
            cboLopHoc.DisplayMember = "ClassName";
            cboLopHoc.ValueMember = "Id";
            cboLopHoc.SelectedIndex = -1;
            cboLopHoc.Enabled = true;
        }

        private void LoadKyHocData()
        {
            cboKyHoc.DataSource = _scheduleService.GetSemesters();
            cboKyHoc.DisplayMember = "DisplayName";
            cboKyHoc.ValueMember = "Id";
            cboKyHoc.SelectedIndex = -1;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedItem == null || cboKyHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Lớp học và Học kỳ!");
                return;
            }

            currentClassId = ((DataRowView)cboLopHoc.SelectedItem)["Id"].ToString();
            currentSemesterId = ((DataRowView)cboKyHoc.SelectedItem)["Id"].ToString();

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAllSubjects();
            groupBoxAdd.Enabled = true;
        }

        private void LoadScheduleData(string classId, string semesterId)
        {
            dgvSchedules.DataSource = _scheduleService.GetSchedules(classId, semesterId);

            if (dgvSchedules.Columns.Count > 0)
            {
                dgvSchedules.Columns["Id"].Visible = false;
                dgvSchedules.Columns["SubjectId"].Visible = false;

                dgvSchedules.Columns["ClassName"].HeaderText = "Lớp";
                dgvSchedules.Columns["SubjectCode"].HeaderText = "Mã môn";
                dgvSchedules.Columns["SubjectName"].HeaderText = "Tên môn học";
                dgvSchedules.Columns["TeacherName"].HeaderText = "Giáo viên";
                dgvSchedules.Columns["Room"].HeaderText = "Phòng học";
                dgvSchedules.Columns["Semester"].HeaderText = "Học kỳ";
                dgvSchedules.Columns["LessonDate"].HeaderText = "Ngày học";
                dgvSchedules.Columns["StartPeriod"].HeaderText = "Tiết BĐ";
                dgvSchedules.Columns["EndPeriod"].HeaderText = "Tiết KT";
            }
        }

        private void LoadAllSubjects()
        {
            dtAvailableSubjects = _scheduleService.GetAllSubjectDetailsBySpecialization(
                currentMajorId,
                currentSpecializationId);

            cboMonHoc.DataSource = dtAvailableSubjects;
            cboMonHoc.DisplayMember = "SubjectName";
            cboMonHoc.ValueMember = "Id";
            cboMonHoc.SelectedIndex = -1;
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            cboMonHoc.SelectedIndex = -1;
            txtGiaoVien.Clear();
            txtPhongHoc.Clear();
            numStartPeriod.Value = 1;
            numEndPeriod.Value = 1;
            dtpLessonDate.Value = DateTime.Today;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học!");
                return;
            }

            string subjectId = ((DataRowView)cboMonHoc.SelectedItem)["Id"].ToString();
            string teacherName = txtGiaoVien.Text.Trim();
            string room = txtPhongHoc.Text.Trim();
            DateTime lessonDate = dtpLessonDate.Value.Date;
            int startPeriod = (int)numStartPeriod.Value;
            int endPeriod = (int)numEndPeriod.Value;

            foreach (DataGridViewRow row in dgvSchedules.Rows)
            {
                if (row.IsNewRow) continue;

                DateTime gridDate = Convert.ToDateTime(row.Cells["LessonDate"].Value).Date;
                int gridStart = Convert.ToInt32(row.Cells["StartPeriod"].Value);
                int gridEnd = Convert.ToInt32(row.Cells["EndPeriod"].Value);

                bool trungNgay = gridDate == lessonDate;
                bool trungGiaoNhau = startPeriod <= gridEnd && endPeriod >= gridStart;
                bool trungTrungCap = startPeriod == gridStart && endPeriod == gridEnd;

                if (trungNgay && (trungGiaoNhau || trungTrungCap))
                {
                    MessageBox.Show("Khung tiết này trong ngày đã tồn tại!");
                    return;
                }
            }

            if (_scheduleService.IsTeacherBusy(teacherName, lessonDate, startPeriod, endPeriod))
            {
                MessageBox.Show("Giáo viên đã có lớp khác trùng tiết trong thời gian này!");
                return;
            }

            _scheduleService.AddSchedule(
                currentClassId, subjectId, teacherName, room,
                currentSemesterId, lessonDate, startPeriod, endPeriod);

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAllSubjects();

            MessageBox.Show("✅ Thêm lịch học thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch học để sửa!");
                return;
            }

            string scheduleId = dgvSchedules.SelectedRows[0].Cells["Id"].Value.ToString();
            string subjectId = ((DataRowView)cboMonHoc.SelectedItem)["Id"].ToString();
            string teacherName = txtGiaoVien.Text.Trim();
            string room = txtPhongHoc.Text.Trim();
            DateTime lessonDate = dtpLessonDate.Value.Date;
            int startPeriod = (int)numStartPeriod.Value;
            int endPeriod = (int)numEndPeriod.Value;

            foreach (DataGridViewRow row in dgvSchedules.Rows)
            {
                if (row.IsNewRow) continue;

                string gridScheduleId = row.Cells["Id"].Value.ToString();
                if (gridScheduleId == scheduleId) continue;

                DateTime gridDate = Convert.ToDateTime(row.Cells["LessonDate"].Value).Date;
                int gridStart = Convert.ToInt32(row.Cells["StartPeriod"].Value);
                int gridEnd = Convert.ToInt32(row.Cells["EndPeriod"].Value);

                bool trungNgay = gridDate == lessonDate;
                bool trungGiaoNhau = startPeriod <= gridEnd && endPeriod >= gridStart;
                bool trungTrungCap = startPeriod == gridStart && endPeriod == gridEnd;

                if (trungNgay && (trungGiaoNhau || trungTrungCap))
                {
                    MessageBox.Show("Khung tiết sửa bị trùng lịch!");
                    return;
                }
            }

            if (_scheduleService.IsTeacherBusy(teacherName, lessonDate, startPeriod, endPeriod, scheduleId))
            {
                MessageBox.Show("Giáo viên đã có lớp khác trùng tiết trong thời gian này!");
                return;
            }

            _scheduleService.UpdateSchedule(
                scheduleId, subjectId, teacherName, room,
                lessonDate, startPeriod, endPeriod);

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAllSubjects();

            MessageBox.Show("✅ Cập nhật lịch học thành công!");
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lịch học để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string scheduleId = dgvSchedules.SelectedRows[0].Cells["Id"].Value.ToString();

            _scheduleService.RemoveSchedule(scheduleId);

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAllSubjects();

            MessageBox.Show("✅ Xóa lịch học thành công!");
        }

        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSchedules.Rows[e.RowIndex];

            txtGiaoVien.Text = row.Cells["TeacherName"].Value.ToString();
            txtPhongHoc.Text = row.Cells["Room"].Value.ToString();
            dtpLessonDate.Value = Convert.ToDateTime(row.Cells["LessonDate"].Value);
            numStartPeriod.Value = Convert.ToDecimal(row.Cells["StartPeriod"].Value);
            numEndPeriod.Value = Convert.ToDecimal(row.Cells["EndPeriod"].Value);
        }

    }
}
