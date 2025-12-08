using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;
using StudentCourseManagement.Domain.Abstractions.Services;
    public partial class FrmQuanLyChuongTrinhKhung : Form
    {
        private readonly IScheduleService _scheduleService;
        private readonly ICurriculumService _curriculumService;

        private Guid currentMajorId = Guid.Empty;
        private Guid currentSpecializationId = Guid.Empty;
        private string currentHocKy = "";

        private DataTable dtAllMonHoc = new DataTable();
        private DataTable dtFullCurriculum = new DataTable();

        public FrmQuanLyChuongTrinhKhung()
        {
            InitializeComponent();
            _scheduleService = ServicesFactory.CreateScheduleService();
            _curriculumService = ServicesFactory.CreateCurriculumService();
        }

        private void FrmQuanLyChuongTrinhKhung_Load(object sender, EventArgs e)
        {
            LoadKhoaData();
            LoadHocKyData();
            SetFilterState(true);
            SetActionState(false);
            StyleHelper.ApplyFormStyle(this);
    }

        #region Load Data

        private void LoadKhoaData()
        {
            
            var data = _scheduleService.GetFaculties();
            cboKhoa.DisplayMember = "FacultyName";
            cboKhoa.ValueMember = "Id";
            cboKhoa.DataSource = data;
            cboKhoa.SelectedIndex = -1;
        }

        private void LoadNganhData(Guid facultyId)
        {
            var data = _scheduleService.GetMajorsByFaculty(facultyId.ToString());
            cboNganh.DisplayMember = "MajorName";
            cboNganh.ValueMember = "Id";
            cboNganh.DataSource = data;
            cboNganh.SelectedIndex = -1;
        }

        private void LoadChuyenNganhData(Guid majorId)
        {
            var data = _scheduleService.GetSpecializationsByMajor(majorId.ToString());
            cboChuyenNganh.DisplayMember = "SpecializationName";
            cboChuyenNganh.ValueMember = "Id";
            cboChuyenNganh.DataSource = data;
            cboChuyenNganh.SelectedIndex = -1;
        }

    private void LoadHocKyData()
    {
        DataTable dtSemesters = _scheduleService.GetSemesters();
        if (dtSemesters != null && dtSemesters.Rows.Count > 0)
        {
            if (!dtSemesters.Columns.Contains("DisplayName"))
            {
                dtSemesters.Columns.Add("DisplayName", typeof(string), "SemesterName + ' (' + AcademicYear + ')'");
            }
        }
        cboHocKy.DisplayMember = "DisplayName";
        cboHocKy.ValueMember = "SemesterName";
        cboHocKy.DataSource = dtSemesters;
        cboHocKy.SelectedIndex = -1;
    }

    private void LoadFilteredMonHocData(Guid majorId, Guid specializationId)
        {
            dtAllMonHoc = _scheduleService.GetAllSubjectDetailsBySpecialization(majorId, specializationId);
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedItem is DataRowView drv)
            {
                LoadNganhData((Guid)drv["Id"]);
                cboNganh.Enabled = true;
            }
            else cboNganh.Enabled = false;
            cboChuyenNganh.Enabled = false;
        }

        private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNganh.SelectedItem is DataRowView drv)
            {
                currentMajorId = (Guid)drv["Id"];
                LoadChuyenNganhData(currentMajorId);
                cboChuyenNganh.Enabled = true;
            }
            else cboChuyenNganh.Enabled = false;
        }

    #endregion

    #region Main Logic

    // 1. Sự kiện bấm nút Tải
    private void btnLoad_Click(object sender, EventArgs e)
    {
        if (cboChuyenNganh.SelectedValue == null || cboHocKy.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn đầy đủ Chuyên ngành và Học kỳ.", "Thông báo");
            return;
        }
        currentSpecializationId = (Guid)cboChuyenNganh.SelectedValue;
        currentHocKy = cboHocKy.Text;
        string tenChuyenNganh = cboChuyenNganh.Text;
        string tenHocKy = cboHocKy.Text;
        lblTieuDeKhung.Text = $"Chương trình khung: {tenChuyenNganh} - {tenHocKy}";
        LoadFilteredMonHocData(currentMajorId, currentSpecializationId);
        dtFullCurriculum = _curriculumService.GetCurriculumDetails(
            currentSpecializationId,
            currentHocKy
        );

        if (dtFullCurriculum == null)
            dtFullCurriculum = new DataTable();
        LoadChuongTrinhKhung();
        SetFilterState(false);
        SetActionState(true);
    }

    private void LoadChuongTrinhKhung()
    {
        dgvChuongTrinhKhung.DataSource = dtFullCurriculum;

        if (dgvChuongTrinhKhung.Columns.Count > 0)
        {
            string[] colsToHide = { "CurriculumId", "SubjectId", "SpecializationId", "Id", "Semester" };
            foreach (string col in colsToHide)
            {
                if (dgvChuongTrinhKhung.Columns.Contains(col))
                    dgvChuongTrinhKhung.Columns[col].Visible = false;
            }
            if (dgvChuongTrinhKhung.Columns.Contains("SubjectCode"))
                dgvChuongTrinhKhung.Columns["SubjectCode"].HeaderText = "Mã MH";
            if (dgvChuongTrinhKhung.Columns.Contains("SubjectName"))
                dgvChuongTrinhKhung.Columns["SubjectName"].HeaderText = "Tên Môn Học";
            if (dgvChuongTrinhKhung.Columns.Contains("Credit"))
                dgvChuongTrinhKhung.Columns["Credit"].HeaderText = "Tín chỉ";
            if (dgvChuongTrinhKhung.Columns.Contains("LectureHours"))
                dgvChuongTrinhKhung.Columns["LectureHours"].HeaderText = "Giờ LT";
            if (dgvChuongTrinhKhung.Columns.Contains("PracticeHours"))
                dgvChuongTrinhKhung.Columns["PracticeHours"].HeaderText = "Giờ TH";
        }
        FilterAvailableMonHoc();
    }


    private void FilterAvailableMonHoc()
        {
            var usedSubjectIds = new List<Guid>();
            if (dtFullCurriculum != null && dtFullCurriculum.Rows.Count > 0)
            {
                foreach (DataRow row in dtFullCurriculum.Rows)
                {
                    if (row["SubjectId"] != DBNull.Value)
                    {
                        usedSubjectIds.Add((Guid)row["SubjectId"]);
                    }
                }
            }

            DataTable dtAvailable = dtAllMonHoc.Copy();

            for (int i = dtAvailable.Rows.Count - 1; i >= 0; i--)
            {
                Guid subjectId = (Guid)dtAvailable.Rows[i]["Id"];
                if (usedSubjectIds.Contains(subjectId))
                {
                    dtAvailable.Rows[i].Delete();
                }
            }
            dtAvailable.AcceptChanges();
            cboChonMonHoc.DataSource = null;
            cboChonMonHoc.DisplayMember = "SubjectName";
            cboChonMonHoc.ValueMember = "Id";
            cboChonMonHoc.DataSource = dtAvailable;
            cboChonMonHoc.SelectedIndex = -1;

            ClearMonHocInfo();
        }

        private void btnAddMonHoc_Click(object sender, EventArgs e)
        {
            if (cboChonMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một môn học để thêm.", "Thông báo");
                return;
            }

            Guid subjectIdCanThem = (Guid)cboChonMonHoc.SelectedValue;
            DataRow[] foundRows = dtFullCurriculum.Select($"SubjectId = '{subjectIdCanThem}'");
            if (foundRows.Length > 0)
            {
                string kyDaTonTai = foundRows[0]["Semester"].ToString()!;
                string tenMon = foundRows[0]["SubjectName"]?.ToString() ?? "Môn học";

                MessageBox.Show($"Môn học '{tenMon}' đã tồn tại trong chương trình khung ở: Học kỳ {kyDaTonTai}.\nKhông thể thêm trùng môn học.",
                                "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _curriculumService.AddSubjectToCurriculum(currentSpecializationId, subjectIdCanThem, currentHocKy);
                dtFullCurriculum = _curriculumService.GetCurriculumDetails(currentSpecializationId, "");
                LoadChuongTrinhKhung();

                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnRemoveMonHoc_Click(object sender, EventArgs e)
        {
            if (dgvChuongTrinhKhung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một môn học trong lưới để xóa.", "Thông báo");
                return;
            }

            string colNameId = "CurriculumId";
            if (!dgvChuongTrinhKhung.Columns.Contains(colNameId) && dgvChuongTrinhKhung.Columns.Contains("Id"))
            {
                colNameId = "Id";
            }

            Guid curriculumId = (Guid)dgvChuongTrinhKhung.SelectedRows[0].Cells[colNameId].Value;
            string tenMonHoc = dgvChuongTrinhKhung.SelectedRows[0].Cells["SubjectName"].Value.ToString()!;

            if (MessageBox.Show($"Bạn có chắc muốn xóa môn '{tenMonHoc}' khỏi kỳ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _curriculumService.RemoveSubjectFromCurriculum(curriculumId);

                    dtFullCurriculum = _curriculumService.GetCurriculumDetails(currentSpecializationId, "");
                    LoadChuongTrinhKhung();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnChangeFilter_Click(object sender, EventArgs e)
        {
            SetActionState(false);
            SetFilterState(true);
            dgvChuongTrinhKhung.DataSource = null;
            cboChonMonHoc.DataSource = null;
            lblTieuDeKhung.Text = "Chưa chọn chương trình khung";
            dtAllMonHoc.Clear();
            dtFullCurriculum.Clear();
            cboKhoa.Focus();
        }

        private void cboChonMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonMonHoc.SelectedItem is DataRowView drv)
            {
                txtMaMonHoc.Text = drv["SubjectCode"].ToString();
                txtMaHocPhan.Text = drv["SubjectCode"].ToString();
                txtSoTinChi.Text = drv["Credit"].ToString();
                txtTietLT.Text = drv["LectureHours"].ToString();
                txtTietTH.Text = drv["PracticeHours"].ToString();
            }
            else
            {
                ClearMonHocInfo();
            }
        }

        private void SetFilterState(bool enabled) { groupBoxFilter.Enabled = enabled; }
        private void SetActionState(bool enabled) { groupBoxActions.Enabled = enabled; if (!enabled) ClearMonHocInfo(); }
        private void ClearMonHocInfo()
        {
            txtMaMonHoc.Text = ""; txtMaHocPhan.Text = ""; txtSoTinChi.Text = "";
            txtTietLT.Text = ""; txtTietTH.Text = "";
        }
        private void dgvChuongTrinhKhung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvChuongTrinhKhung.Rows[e.RowIndex];
                txtMaMonHoc.Text = row.Cells["SubjectCode"].Value?.ToString();
                txtMaHocPhan.Text = row.Cells["SubjectCode"].Value?.ToString(); 
                txtSoTinChi.Text = row.Cells["Credit"].Value?.ToString();
                txtTietLT.Text = row.Cells["LectureHours"].Value?.ToString();
                txtTietTH.Text = row.Cells["PracticeHours"].Value?.ToString();

                btnRemoveMonHoc.Enabled = true;
            }
        }

    #endregion
}
