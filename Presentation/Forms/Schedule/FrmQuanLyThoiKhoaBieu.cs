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
            cboNganh.Enabled = false;
            cboChuyenNganh.Enabled = false;
            cboLopHoc.Enabled = false;
            groupBoxAdd.Enabled = false;
        }

        #region Load ComboBox Data

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
            {
                facultyId = drv["Id"]?.ToString();
            }

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
            {
                majorIdStr = drv["Id"]?.ToString();
            }

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
                currentMajorId = Guid.Empty;
                cboChuyenNganh.Enabled = false;
                cboLopHoc.Enabled = false;
            }
        }

        private void cboChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? specializationIdStr = null;
            if (cboChuyenNganh.SelectedItem is DataRowView drv)
            {
                specializationIdStr = drv["Id"]?.ToString();
            }

            if (!string.IsNullOrEmpty(specializationIdStr))
            {
                currentSpecializationId = new Guid(specializationIdStr);
                cboLopHoc.DataSource = _scheduleService.GetClassesBySpecialization(specializationIdStr);
                cboLopHoc.DisplayMember = "ClassName";
                cboLopHoc.ValueMember = "Id";
                cboLopHoc.SelectedIndex = -1;
                cboLopHoc.Enabled = true;

                // Tải môn học (nếu đã tải TKB)
                if (!string.IsNullOrEmpty(currentClassId) && !string.IsNullOrEmpty(currentSemesterId))
                {
                    LoadAvailableSubjects();
                }
            }
            else
            {
                currentSpecializationId = Guid.Empty;
                cboLopHoc.Enabled = false;
                cboMonHoc.DataSource = null; // Xóa môn học
            }
        }

        private void LoadKyHocData()
        {
            cboKyHoc.DataSource = _scheduleService.GetSemesters();
            cboKyHoc.DisplayMember = "DisplayName";
            cboKyHoc.ValueMember = "Id";
            cboKyHoc.SelectedIndex = -1;
        }

        #endregion

        private void ResetInputFields()
        {
            cboMonHoc.SelectedIndex = -1;
            txtGiaoVien.Clear();
            txtPhongHoc.Clear();
            dtpLessonDate.Value = DateTime.Now;
            numStartPeriod.Value = 1;
            numEndPeriod.Value = 1;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ResetInputFields();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string? classId = null;
            if (cboLopHoc.SelectedItem is DataRowView drvClass)
            {
                classId = drvClass["Id"]?.ToString();
            }

            string? semesterId = null;
            if (cboKyHoc.SelectedItem is DataRowView drvSemester)
            {
                semesterId = drvSemester["Id"]?.ToString();
            }

            if (string.IsNullOrEmpty(classId) || string.IsNullOrEmpty(semesterId))
            {
                MessageBox.Show("Vui lòng chọn Lớp học và Học kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currentClassId = classId;
            currentSemesterId = semesterId;

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAvailableSubjects();
            groupBoxAdd.Enabled = true;
            ResetInputFields();
        }

        private void LoadScheduleData(string classId, string semesterId)
        {
            dgvSchedules.DataSource = _scheduleService.GetSchedules(classId, semesterId);

            if (dgvSchedules.Columns.Count > 0)
            {
                dgvSchedules.Columns["Id"].Visible = false;
                dgvSchedules.Columns["SubjectId"].Visible = false;
                dgvSchedules.Columns["ClassName"].HeaderText = "Lớp";
                dgvSchedules.Columns["ClassName"].DisplayIndex = 0;
                dgvSchedules.Columns["SubjectCode"].HeaderText = "Mã Môn Học";
                dgvSchedules.Columns["SubjectName"].HeaderText = "Tên Môn Học";
                dgvSchedules.Columns["TeacherName"].HeaderText = "Giáo viên";
                dgvSchedules.Columns["Room"].HeaderText = "Phòng";
                dgvSchedules.Columns["Credit"].HeaderText = "Tín chỉ";
                dgvSchedules.Columns["LectureHours"].HeaderText = "Giờ LT";
                dgvSchedules.Columns["PracticeHours"].HeaderText = "Giờ TH";
                dgvSchedules.Columns["Semester"].HeaderText = "Học kỳ";
                dgvSchedules.Columns["LessonDate"].HeaderText = "Ngày học";
                dgvSchedules.Columns["StartPeriod"].HeaderText = "Tiết BĐ";
                dgvSchedules.Columns["EndPeriod"].HeaderText = "Tiết KT";
            }
        }
        private void LoadAvailableSubjects()
        {
            // Kiểm tra xem đã có đủ thông tin để lọc chưa
            if (string.IsNullOrEmpty(currentClassId) ||
                string.IsNullOrEmpty(currentSemesterId) ||
                currentMajorId == Guid.Empty ||
                currentSpecializationId == Guid.Empty)
            {
                cboMonHoc.DataSource = null;
                return;
            }

            // Gọi hàm mới với đầy đủ tham số
            dtAvailableSubjects = _scheduleService.GetAvailableSubjects(
                currentClassId,
                currentSemesterId,
                currentMajorId,
                currentSpecializationId);

            cboMonHoc.DataSource = dtAvailableSubjects;
            cboMonHoc.DisplayMember = "SubjectName";
            cboMonHoc.ValueMember = "Id";
            cboMonHoc.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string? subjectId = null;
            if (cboMonHoc.SelectedItem is DataRowView drvSubject)
            {
                subjectId = drvSubject["Id"]?.ToString();
            }

            if (string.IsNullOrEmpty(subjectId))
            {
                MessageBox.Show("Vui lòng chọn một môn học để thêm.", "Thông báo");
                return;
            }

            if (numEndPeriod.Value < numStartPeriod.Value)
            {
                MessageBox.Show("Tiết kết thúc không thể sớm hơn tiết bắt đầu.", "Lỗi");
                return;
            }

            string teacherName = txtGiaoVien.Text.Trim();
            string room = txtPhongHoc.Text.Trim();
            DateTime lessonDate = dtpLessonDate.Value;
            int startPeriod = (int)numStartPeriod.Value;
            int endPeriod = (int)numEndPeriod.Value;

            foreach (DataGridViewRow row in dgvSchedules.Rows)
            {
                string gridSubjectId = row.Cells["SubjectId"].Value?.ToString() ?? "";
                DateTime gridLessonDate = Convert.ToDateTime(row.Cells["LessonDate"].Value);
                int gridStartPeriod = Convert.ToInt32(row.Cells["StartPeriod"].Value);
                int gridEndPeriod = Convert.ToInt32(row.Cells["EndPeriod"].Value);

                if (gridSubjectId == subjectId && gridLessonDate.Date == lessonDate.Date)
                {
                    if (startPeriod <= gridEndPeriod && endPeriod >= gridStartPeriod)
                    {
                        MessageBox.Show(
                            $"Lỗi: Môn học này đã bị trùng lịch (Tiết {gridStartPeriod}-{gridEndPeriod}) vào ngày {gridLessonDate.ToShortDateString()}.",
                            "Trùng lịch học",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            _scheduleService.AddSchedule(currentClassId, subjectId, teacherName, room,
                                         currentSemesterId, lessonDate, startPeriod, endPeriod);

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAvailableSubjects();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một môn học từ lưới để xóa.", "Thông báo");
                return;
            }

            var cellValue = dgvSchedules.SelectedRows[0].Cells["Id"].Value;
            string? scheduleId = cellValue?.ToString();

            if (string.IsNullOrEmpty(scheduleId))
            {
                MessageBox.Show("Không thể lấy ID của lịch học. Dữ liệu có thể bị lỗi.", "Lỗi");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này khỏi thời khóa biểu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _scheduleService.RemoveSchedule(scheduleId);

            LoadScheduleData(currentClassId, currentSemesterId);
            LoadAvailableSubjects();
        }

        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSchedules.Rows[e.RowIndex];
                string subjectId = row.Cells["SubjectId"].Value?.ToString();
                string subjectName = row.Cells["SubjectName"].Value?.ToString();
                if (!string.IsNullOrEmpty(subjectId) && dtAvailableSubjects != null)
                {
                    DataRow[] foundRows = dtAvailableSubjects.Select($"Id = '{subjectId}'");

                    if (foundRows.Length == 0)
                    {
                        DataRow newRow = dtAvailableSubjects.NewRow();
                        newRow["Id"] = subjectId;
                        newRow["SubjectName"] = subjectName;
                        dtAvailableSubjects.Rows.InsertAt(newRow, 0); 
                    }
                    cboMonHoc.SelectedValue = subjectId;
                }
                txtGiaoVien.Text = row.Cells["TeacherName"].Value?.ToString();
                txtPhongHoc.Text = row.Cells["Room"].Value?.ToString();
                if (row.Cells["LessonDate"].Value != DBNull.Value && row.Cells["LessonDate"].Value != null)
                {
                    dtpLessonDate.Value = Convert.ToDateTime(row.Cells["LessonDate"].Value);
                }
                else
                {
                    dtpLessonDate.Value = DateTime.Now;
                }
                if (row.Cells["StartPeriod"].Value != DBNull.Value)
                    numStartPeriod.Value = Convert.ToDecimal(row.Cells["StartPeriod"].Value);
                else
                    numStartPeriod.Value = 1;

                if (row.Cells["EndPeriod"].Value != DBNull.Value)
                    numEndPeriod.Value = Convert.ToDecimal(row.Cells["EndPeriod"].Value);
                else
                    numEndPeriod.Value = 1;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lịch học trên lưới để sửa.", "Thông báo");
                return;
            }

            string? scheduleId = dgvSchedules.SelectedRows[0].Cells["Id"].Value?.ToString();
            if (string.IsNullOrEmpty(scheduleId))
            {
                MessageBox.Show("Không thể lấy ID của lịch học. Dữ liệu lỗi.", "Lỗi");
                return;
            }

            string? subjectId = null;
            if (cboMonHoc.SelectedItem is DataRowView drvSubject)
            {
                subjectId = drvSubject["Id"]?.ToString();
            }

            if (string.IsNullOrEmpty(subjectId))
            {
                MessageBox.Show("Vui lòng chọn một môn học (mới hoặc cũ) từ ComboBox.", "Lỗi");
                return;
            }

            if (numEndPeriod.Value < numStartPeriod.Value)
            {
                MessageBox.Show("Tiết kết thúc không thể sớm hơn tiết bắt đầu.", "Lỗi");
                return;
            }

            string teacherName = txtGiaoVien.Text.Trim();
            string room = txtPhongHoc.Text.Trim();
            DateTime lessonDate = dtpLessonDate.Value;
            int startPeriod = (int)numStartPeriod.Value;
            int endPeriod = (int)numEndPeriod.Value;

            try
            {
                _scheduleService.UpdateSchedule(scheduleId, subjectId, teacherName, room,
                                                lessonDate, startPeriod, endPeriod);

                LoadScheduleData(currentClassId, currentSemesterId);
                LoadAvailableSubjects();
                MessageBox.Show("Cập nhật lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}