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

    private void LoadHocKyData()
    {
        cboHocKy.DataSource = _scheduleService.GetSemesters();
        cboHocKy.DisplayMember = "DisplayName";
        cboHocKy.ValueMember = "DisplayName";
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
            Guid facultyId = (Guid)drv["Id"];
            LoadNganhData(facultyId);
            cboNganh.Enabled = true;
        }
        else cboNganh.Enabled = false;
        cboChuyenNganh.Enabled = false;
    }

    private void cboNganh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboNganh.SelectedItem is DataRowView drv)
        {
            Guid majorId = (Guid)drv["Id"];
            currentMajorId = majorId;
            LoadChuyenNganhData(majorId);
            cboChuyenNganh.Enabled = true;
        }
        else cboChuyenNganh.Enabled = false;
    }

    #endregion

    #region Quản lý trạng thái

    private void SetFilterState(bool enabled)
    {
        groupBoxFilter.Enabled = enabled;
    }

    private void SetActionState(bool enabled)
    {
        groupBoxActions.Enabled = enabled;
        if (!enabled)
        {
            ClearMonHocInfo();
        }
    }

    private void ClearMonHocInfo()
    {
        txtMaMonHoc.Text = "";
        txtMaHocPhan.Text = "";
        txtSoTinChi.Text = "";
        txtTietLT.Text = "";
        txtTietTH.Text = "";
    }

    #endregion

    #region Sự kiện chính (Load, Thêm, Xóa)

    private void btnLoad_Click(object sender, EventArgs e)
    {
        if (cboChuyenNganh.SelectedValue == null || cboHocKy.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn đầy đủ Chuyên ngành và Học kỳ.", "Thông báo");
            return;
        }

        currentSpecializationId = (Guid)cboChuyenNganh.SelectedValue;
        currentHocKy = cboHocKy.SelectedValue!.ToString()!;
        lblTieuDeKhung.Text = $"Chương trình khung: {cboChuyenNganh.Text} ({currentHocKy})";

        LoadFilteredMonHocData(currentMajorId, currentSpecializationId);
        LoadChuongTrinhKhung();

        SetFilterState(false);
        SetActionState(true);
    }

    private void LoadChuongTrinhKhung()
    {
        DataTable dtKhung = _curriculumService.GetCurriculumDetails(currentSpecializationId, currentHocKy);
        dgvChuongTrinhKhung.DataSource = dtKhung;

        if (dgvChuongTrinhKhung.Columns.Count > 0)
        {
            dgvChuongTrinhKhung.Columns["CurriculumId"].Visible = false;
            dgvChuongTrinhKhung.Columns["SubjectId"].Visible = false;
            dgvChuongTrinhKhung.Columns["SubjectCode"].HeaderText = "Mã Môn Học";
            dgvChuongTrinhKhung.Columns["SubjectName"].HeaderText = "Tên Môn Học";
            dgvChuongTrinhKhung.Columns["Credit"].HeaderText = "Tín chỉ";
            dgvChuongTrinhKhung.Columns["LectureHours"].HeaderText = "Giờ LT";
            dgvChuongTrinhKhung.Columns["PracticeHours"].HeaderText = "Giờ TH";
        }

        FilterAvailableMonHoc();
    }

    private void FilterAvailableMonHoc()
    {
        var idMonHocInGrid = new List<Guid>();
        foreach (DataGridViewRow row in dgvChuongTrinhKhung.Rows)
        {
            idMonHocInGrid.Add((Guid)row.Cells["SubjectId"].Value);
        }

        DataTable dtAvailable = dtAllMonHoc.Copy();

        foreach (DataRow row in dtAvailable.Rows)
        {
            if (idMonHocInGrid.Contains((Guid)row["Id"]))
            {
                row.Delete();
            }
        }
        dtAvailable.AcceptChanges();

        cboChonMonHoc.DataSource = dtAvailable;
        cboChonMonHoc.DisplayMember = "SubjectName";
        cboChonMonHoc.ValueMember = "Id";
        cboChonMonHoc.SelectedIndex = -1;
    }

    private void btnAddMonHoc_Click(object sender, EventArgs e)
    {
        if (cboChonMonHoc.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn một môn học để thêm.", "Thông báo");
            return;
        }

        Guid subjectIdCanThem = (Guid)cboChonMonHoc.SelectedValue;

        _curriculumService.AddSubjectToCurriculum(currentSpecializationId, subjectIdCanThem, currentHocKy);

        LoadChuongTrinhKhung();
    }

    private void btnRemoveMonHoc_Click(object sender, EventArgs e)
    {
        if (dgvChuongTrinhKhung.SelectedRows.Count == 0)
        {
            MessageBox.Show("Vui lòng chọn một môn học trong lưới để xóa.", "Thông báo");
            return;
        }

        Guid curriculumIdCanXoa = (Guid)dgvChuongTrinhKhung.SelectedRows[0].Cells["CurriculumId"].Value;
        string tenMonHoc = dgvChuongTrinhKhung.SelectedRows[0].Cells["SubjectName"].Value.ToString()!;

        if (MessageBox.Show($"Bạn có chắc muốn xóa môn '{tenMonHoc}' khỏi chương trình khung này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            _curriculumService.RemoveSubjectFromCurriculum(curriculumIdCanXoa);

            LoadChuongTrinhKhung();
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

    #endregion
}