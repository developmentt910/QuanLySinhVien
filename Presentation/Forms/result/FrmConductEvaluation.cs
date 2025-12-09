using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.result
{
    public partial class FrmConductEvaluation : Form
    {
        private readonly IConductEvaluationRepository _service;
        private Guid _currentRosterId = Guid.Empty;

        private bool _isLoadingSemester = false;
        private bool _isSelectingRow = false;

        public FrmConductEvaluation()
        {
            InitializeComponent();
            _service = ServicesFactory.CreateConductEvaluationService();

            txtDiemRenLuyen.TextChanged += TxtDiemRenLuyen_TextChanged;
            dgvRenLuyen.SelectionChanged += dgvRenLuyen_SelectionChanged;
            cboHocKi.SelectedIndexChanged += cboHocKi_SelectedIndexChanged;
        }

        // =====================================================
        // LOAD HỌC KỲ + CHỌN HỌC KỲ MỚI NHẤT
        // =====================================================
        private void LoadHocKiComboBox()
        {
            if (_currentRosterId == Guid.Empty) return;

            _isLoadingSemester = true;

            var dt = _service.GetSemestersForEvaluation(_currentRosterId);

            cboHocKi.DataSource = dt;
            cboHocKi.ValueMember = "Id";
            cboHocKi.DisplayMember = "DisplayName";

            // Auto chọn kỳ mới nhất
            cboHocKi.SelectedIndex = (dt.Rows.Count > 0 ? dt.Rows.Count - 1 : -1);

            _isLoadingSemester = false;
        }

        // =====================================================
        // TÌM KIẾM SINH VIÊN
        // =====================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaSv.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã sinh viên.");
                return;
            }

            DataRow info = _service.GetStudentInfoByCode(txtMaSv.Text.Trim());
            if (info == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên.");
                return;
            }

            _currentRosterId = (Guid)info["Id"];

            txtHoTen.Text = info["FullName"].ToString();
            txtLop.Text = info["ClassName"].ToString();
            txtKhoa.Text = info["FacultyName"].ToString();

            LoadHocKiComboBox();
            LoadFullGrid();
            ResetForm();

            dgvRenLuyen.ClearSelection();
        }

        // =====================================================
        // LOAD GRID
        // =====================================================
        private void LoadFullGrid()
        {
            var list = _service.GetEvaluations(_currentRosterId);

            dgvRenLuyen.Columns.Clear();
            dgvRenLuyen.AutoGenerateColumns = false;

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Học kỳ",
                DataPropertyName = "SemesterName",
                Width = 200
            });

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm rèn luyện",
                DataPropertyName = "Score",
                Width = 120
            });

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Xếp loại",
                DataPropertyName = "RankName",
                Width = 150
            });

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ghi chú",
                DataPropertyName = "Comment",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvRenLuyen.DataSource = list;
            dgvRenLuyen.ClearSelection();
        }

        // =====================================================
        // TỰ ĐỘNG XẾP LOẠI KHI NHẬP ĐIỂM
        // =====================================================
        private void TxtDiemRenLuyen_TextChanged(object sender, EventArgs e)
        {
            if (_isSelectingRow) return;

            if (int.TryParse(txtDiemRenLuyen.Text, out int score))
            {
                txtXepLoai.Text =
                    score >= 90 ? "Xuất sắc" :
                    score >= 80 ? "Tốt" :
                    score >= 65 ? "Khá" :
                    score >= 50 ? "Trung bình" :
                    "Yếu";
            }
            // ❌ Không xóa txtXepLoai khi nhập dở, tránh lỗi nhập "70"
        }

        // =====================================================
        // THÊM
        // =====================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_currentRosterId == Guid.Empty)
            {
                MessageBox.Show("Chưa chọn sinh viên.");
                return;
            }

            if (!int.TryParse(txtDiemRenLuyen.Text, out int score))
            {
                MessageBox.Show("Điểm rèn luyện phải là số.");
                return;
            }

            if (cboHocKi.SelectedValue == null)
            {
                MessageBox.Show("Chọn học kỳ.");
                return;
            }

            Guid semesterId = (Guid)cboHocKi.SelectedValue;

            // Không cho trùng học kỳ
            if (_service.GetEvaluations(_currentRosterId)
                        .Any(e => e.SemesterId == semesterId))
            {
                MessageBox.Show("Đã có đánh giá cho học kỳ này.");
                return;
            }

            _service.AddEvaluation(new TrainingEvaluation
            {
                UserId = _currentRosterId,
                SemesterId = semesterId,
                Score = score,
                Comment = txtGhiChu.Text
            });

            LoadFullGrid();                // load lại bảng
            cboHocKi.SelectedValue = semesterId; // giữ đúng học kỳ
            ResetForm();
            dgvRenLuyen.ClearSelection();
        }

        // =====================================================
        // SỬA
        // =====================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvRenLuyen.CurrentRow?.DataBoundItem is not TrainingEvaluation eval) return;

            eval.Score = int.Parse(txtDiemRenLuyen.Text);
            eval.Comment = txtGhiChu.Text;

            _service.UpdateEvaluation(eval);

            LoadFullGrid();
            ResetForm();
        }

        // =====================================================
        // XÓA
        // =====================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvRenLuyen.CurrentRow?.DataBoundItem is not TrainingEvaluation eval) return;

            _service.DeleteEvaluation(eval.Id);

            LoadFullGrid();
            ResetForm();
        }

        // =====================================================
        // CLICK CHỌN DÒNG TRONG GRID
        // =====================================================
        private void dgvRenLuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRenLuyen.CurrentRow?.DataBoundItem is not TrainingEvaluation eval) return;

            _isSelectingRow = true;

            cboHocKi.SelectedValue = eval.SemesterId;
            txtDiemRenLuyen.Text = eval.Score.ToString();
            txtGhiChu.Text = eval.Comment;
            txtXepLoai.Text = eval.RankName;

            _isSelectingRow = false;
        }

        // =====================================================
        // CHỌN HỌC KỲ TRONG COMBOBOX
        // =====================================================
        private void cboHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingSemester) return;
            if (_currentRosterId == Guid.Empty) return;

            if (cboHocKi.SelectedValue is not Guid semesterId) return;

            var eval = _service.GetEvaluations(_currentRosterId)
                               .FirstOrDefault(x => x.SemesterId == semesterId);

            if (eval == null)
            {
                ResetForm();
                return;
            }

            txtDiemRenLuyen.Text = eval.Score.ToString();
            txtGhiChu.Text = eval.Comment;
            txtXepLoai.Text = eval.RankName;
        }

        // =====================================================
        // RESET FORM
        // =====================================================
        private void ResetForm()
        {
            txtDiemRenLuyen.Clear();
            txtGhiChu.Clear();
            txtXepLoai.Clear();
        }
    }
}
