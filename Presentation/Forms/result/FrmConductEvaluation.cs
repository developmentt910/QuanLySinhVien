using Microsoft.Data.SqlClient;
using StudentCourseManagement.Applications;
using StudentCourseManagement.Domain.Abstractions.Repositories;
using StudentCourseManagement.Domain.Entities;
using StudentCourseManagement.Presentation.WinForms.Bootstrap; // (Hoặc namespace của Service)
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.result
{
    public partial class FrmConductEvaluation : Form
    {
        // [SỬA] Chỉ cần 1 Service
        private readonly IConductEvaluationRepository _service;

        private Guid _currentRosterId = Guid.Empty;

        public FrmConductEvaluation()
        {
            InitializeComponent();

            // [SỬA] Lấy Service từ Factory
            _service = ServicesFactory.CreateConductEvaluationService();
            // (Đã xóa IScheduleService)

            txtDiemRenLuyen.TextChanged += TxtDiemRenLuyen_TextChanged;
            dgvRenLuyen.SelectionChanged += dgvRenLuyen_SelectionChanged;

            LoadHocKiComboBox();
        }

        // [SỬA] Dùng _service (IConductEvaluationService) để tải học kỳ
        private void LoadHocKiComboBox()
        {
            cboHocKi.DataSource = _service.GetSemestersForEvaluation();
            cboHocKi.ValueMember = "Id";
            cboHocKi.DisplayMember = "DisplayName";
            cboHocKi.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSv.Text))
            {
                MessageBox.Show("Nhập mã sinh viên cần tìm.");
                return;
            }

            DataRow studentInfo = _service.GetStudentInfoByCode(txtMaSv.Text.Trim());

            if (studentInfo == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên.");
                ClearStudentInfo();
                return;
            }

            _currentRosterId = (Guid)studentInfo["Id"];
            LoadStudentInfo(studentInfo);
            LoadEvaluationGrid(_currentRosterId);
        }

        private void ClearStudentInfo()
        {
            dgvRenLuyen.DataSource = null;
            txtHoTen.Clear();
            txtKhoa.Clear();
            txtLop.Clear();
            ClearInputFields();
        }

        private void LoadStudentInfo(DataRow row)
        {
            txtHoTen.Text = row["FullName"]?.ToString();
            txtLop.Text = row["ClassName"]?.ToString();
            txtKhoa.Text = row["FacultyName"]?.ToString();
        }

        private void LoadEvaluationGrid(Guid rosterId)
        {
            var list = _service.GetEvaluations(rosterId);

            dgvRenLuyen.AutoGenerateColumns = false;
            dgvRenLuyen.Columns.Clear();

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Học kỳ",
                DataPropertyName = "SemesterName",
                Name = "SemesterName",
                Width = 150
            });

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm rèn luyện",
                DataPropertyName = "Score",
                Name = "Score",
                Width = 120
            });

            dgvRenLuyen.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ghi chú",
                DataPropertyName = "Comment",
                Name = "Comment",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvRenLuyen.DataSource = list;
        }

        private void TxtDiemRenLuyen_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDiemRenLuyen.Text, out int score))
            {
                txtXepLoai.Text = score >= 90 ? "Xuất sắc" :
                                  score >= 80 ? "Tốt" :
                                  score >= 65 ? "Khá" :
                                  score >= 50 ? "Trung bình" : "Yếu";
            }
            else
            {
                txtXepLoai.Clear();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_currentRosterId == Guid.Empty)
            {
                MessageBox.Show("Vui lòng tìm sinh viên trước.");
                return;
            }

            if (!int.TryParse(txtDiemRenLuyen.Text, out int score))
            {
                MessageBox.Show("Điểm rèn luyện phải là số nguyên.");
                return;
            }

            if (cboHocKi.SelectedValue == null)
            {
                MessageBox.Show("Chọn học kỳ.");
                return;
            }

            Guid selectedSemesterId = (Guid)cboHocKi.SelectedValue;

            // --- KIỂM TRA TỒN TẠI ---
            var existingEval = _service.GetEvaluations(_currentRosterId)
                                       .FirstOrDefault(e => e.SemesterId == selectedSemesterId);
            if (existingEval != null)
            {
                MessageBox.Show("Sinh viên này đã có đánh giá cho học kỳ đã chọn.");
                return;
            }

            var eval = new TrainingEvaluation
            {
                UserId = _currentRosterId,
                SemesterId = selectedSemesterId,
                Score = score,
                Comment = txtGhiChu.Text
            };

            _service.AddEvaluation(eval);
            LoadEvaluationGrid(_currentRosterId);
            ClearInputFields();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_currentRosterId == Guid.Empty || dgvRenLuyen.CurrentRow == null) return;

            if (!int.TryParse(txtDiemRenLuyen.Text, out int score))
            {
                MessageBox.Show("Điểm rèn luyện phải là số nguyên.");
                return;
            }

            if (dgvRenLuyen.CurrentRow.DataBoundItem is not TrainingEvaluation eval) return;

            eval.Score = score;
            eval.SemesterId = (Guid)cboHocKi.SelectedValue;
            eval.Comment = txtGhiChu.Text;

            _service.UpdateEvaluation(eval);
            LoadEvaluationGrid(_currentRosterId);
            ClearInputFields();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_currentRosterId == Guid.Empty || dgvRenLuyen.CurrentRow == null) return;

            if (dgvRenLuyen.CurrentRow.DataBoundItem is not TrainingEvaluation eval) return;

            _service.DeleteEvaluation(eval.Id);

            LoadEvaluationGrid(_currentRosterId);
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtDiemRenLuyen.Clear();
            txtXepLoai.Clear();
            txtGhiChu.Clear();
        }

        private void dgvRenLuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRenLuyen.CurrentRow == null) return;
            if (dgvRenLuyen.CurrentRow.DataBoundItem is not TrainingEvaluation eval) return;

            txtDiemRenLuyen.Text = eval.Score.ToString();
            txtGhiChu.Text = eval.Comment ?? "";
            cboHocKi.SelectedValue = eval.SemesterId;
        }

        private void cboHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}