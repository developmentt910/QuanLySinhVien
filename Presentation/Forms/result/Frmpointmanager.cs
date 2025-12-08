using Microsoft.VisualBasic.ApplicationServices;
using StudentCourseManagement.Application.Services;
using StudentCourseManagement.Domain.Entities;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.result
{
    public partial class Frmpointmanager : Form
    {
        private PointManagerService _service;
        private Guid currentUserId ;
        private string studentCode;
        private Guid specializationId;

        public Frmpointmanager()
        {
            InitializeComponent();

            // Chỉ khởi tạo service và events khi runtime, không phải lúc Designer load
            if (!IsInDesignMode())
            {
                _service = new PointManagerService();
                lstMonhoc.SelectedIndexChanged += lstMonhoc_SelectedIndexChanged;

                btnTimKiem.Click += BtnTimKiem_Click;
           btnLuuDiem.Click += BtnLuuDiem_Click;
                cboHocKy.SelectedIndexChanged += CboHocKy_SelectedIndexChanged;



            }
        }

        /// <summary>
        /// Kiểm tra xem Form đang được load trong Designer hay runtime
        /// </summary>
        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        #region Event Handlers

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            var maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!");
                return;
            }

            var info = _service.GetStudentInfo(maSV);
            if (info == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
                return;
            }

            // Hiển thị thông tin sinh viên
            textTenSV.Text = info.FullName;
            txtLop.Text = info.ClassName;
            txtNganh.Text = info.MajorName;
            txtChuyenNganh.Text = info.SpecializationName;

            // Lưu thông tin cho việc load môn học
            currentUserId = info.Id;
            studentCode = info.StudentCode ?? "";
            specializationId = info.SpecializationId;

            // Load học kỳ
            LoadSemestersForStudent(currentUserId);
        }


        public void LoadSubjectsForSemester(Guid specializationId, string semesterCode, string studentCode)
        {
            List<ResultSubjectDto> subjects = _service.GetSubjectsForSemester(specializationId, semesterCode, studentCode);

            lstMonhoc.DataSource = null;
            lstMonhoc.Items.Clear();
            dgvChiTietDiem.Rows.Clear();

            if (subjects.Count == 0)
            {
                MessageBox.Show("Chưa có môn học cho học kỳ này hoặc thông tin sinh viên chưa đầy đủ.");
                return;
            }

            lstMonhoc.DataSource = subjects;
            lstMonhoc.DisplayMember = "SubjectName";
            lstMonhoc.ValueMember = "SubjectId";
        }


        private void LoadSemestersForStudent(Guid userId)
        {
            int cohortYear = _service.GetCohortYearFromUser(userId);
            var semesters = _service.GetSemestersForStudent(cohortYear);

            cboHocKy.SelectedIndexChanged -= CboHocKy_SelectedIndexChanged; // tránh trigger
            cboHocKy.Items.Clear();
            cboHocKy.Items.AddRange(semesters.ToArray());
            if (cboHocKy.Items.Count > 0)
                cboHocKy.SelectedIndex = 0;
            cboHocKy.SelectedIndexChanged += CboHocKy_SelectedIndexChanged;
        }


        private void lstMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMonhoc.SelectedItem is not ResultSubjectDto selectedSubject) return;

            dgvChiTietDiem.Rows.Clear();

            var result = _service.GetStudyResult(currentUserId, selectedSubject.SubjectId.ToString());
            if (result != null)
            {
                result.ComputeGrades(); // Tính điểm nếu chưa tính
                dgvChiTietDiem.Rows.Add(
                    selectedSubject.SubjectName,
                    result.Midterm?.ToString() ?? "",
                    result.Other?.ToString() ?? "",
                    result.Final?.ToString() ?? "",
                    result.FinalNumeric?.ToString("0.00") ?? "",
                    result.LetterGrade ?? "",
                    result.Passed == true ? "Đạt" : "Không đạt"
                );
            }
            else
            {
                dgvChiTietDiem.Rows.Add(selectedSubject.SubjectName, "", "", "", "", "", "");
            }
        }





        private void BtnLuuDiem_Click(object sender, EventArgs e)
        {
            if (lstMonhoc.Items.Count == 0) return;

            foreach (ResultSubjectDto subject in lstMonhoc.Items)
            {
                // Tìm row tương ứng
                DataGridViewRow row = dgvChiTietDiem.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells[0].Value?.ToString() == subject.SubjectName);

                if (row == null) continue;

                var result = new StudyResult
                {
                    UserId = currentUserId,
                    SubjectId = subject.SubjectId,
                    Midterm = double.TryParse(row.Cells[1].Value?.ToString(), out var m) ? m : (double?)null,
                    Other = double.TryParse(row.Cells[2].Value?.ToString(), out var o) ? o : (double?)null,
                    Final = double.TryParse(row.Cells[3].Value?.ToString(), out var f) ? f : (double?)null
                };

                result.ComputeGrades(); // Tính FinalNumeric, LetterGrade, Passed

                _service.SaveResult(result); // Lưu vào DB
            }

            MessageBox.Show("Đã lưu tất cả điểm!");
        }






        private void CboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHocKy.SelectedItem == null) return;

            string selectedSemester = cboHocKy.SelectedItem.ToString();

            lstMonhoc.SelectedIndexChanged -= lstMonhoc_SelectedIndexChanged; // tránh trigger
            lstMonhoc.DataSource = null;
            lstMonhoc.Items.Clear();
            dgvChiTietDiem.Rows.Clear();

            LoadSubjectsForSemester(specializationId, selectedSemester, studentCode);

            lstMonhoc.SelectedIndexChanged += lstMonhoc_SelectedIndexChanged;
        }




        #endregion

        private void label9_Click(object sender, EventArgs e)
        {

        }

    }
}
