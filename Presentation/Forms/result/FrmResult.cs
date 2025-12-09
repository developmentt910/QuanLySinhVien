using ClosedXML.Excel;
using StudentCourseManagement.Applications;
using StudentCourseManagement.Applications.Curriculum;
using StudentCourseManagement.Applications.Students.Dtos;
using StudentCourseManagement.Infrastructure.Data;
using StudentCourseManagement.Infrastructure.Repositories.An;

namespace StudentCourseManagement.Presentation.Forms.result
{
    public partial class FrmResult : Form
    {
        private readonly ResultService resultService;

        private StudentDtos currentStudent = null;
        private bool isUpdating = false;

        public FrmResult()
        {
            InitializeComponent();

            // FIX: Program.Configuration
            var conn = new SqlConnectionFactory(Program.Configuration);

            // FIX: Inject DAO
            resultService = new ResultService(new ResultDao(conn));

            InitEvents();
        }

        private void InitEvents()
        {
            dgvDiem.CellValueChanged += (s, e) =>
            {
                if (isUpdating || e.RowIndex < 0) return;
                UpdateRow(e.RowIndex);
            };

            dgvDiem.SelectionChanged += (s, e) =>
            {
                if (!isUpdating) LoadRowToInput();
            };

            txtScore1.KeyUp += (s, e) => UpdateSelectedRow();
            txtScore2.KeyUp += (s, e) => UpdateSelectedRow();
            txtExam.KeyUp += (s, e) => UpdateSelectedRow();

            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;

            // 🔥 Thêm đoạn này để đổi học kỳ thì load lại môn học
            cbHocKy.SelectedIndexChanged += (s, e) =>
            {
                if (currentStudent != null && cbHocKy.SelectedItem != null)
                {
                    LoadSubjectTable(cbHocKy.SelectedItem.ToString());
                }
            };
        }


        // ------------------- SEARCH -------------------
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string msv = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(msv))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!");
                return;
            }

            currentStudent = resultService.FindByMSV(msv);

            if (currentStudent == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
                return;
            }

            // ===== HIỂN THỊ THÔNG TIN SINH VIÊN =====
            txtHoTen.Text = currentStudent.FullName ?? "";
            txtKhoa.Text = currentStudent.FacultyName ?? "";
            txtNganh.Text = currentStudent.MajorName ?? "";
            txtChuyenNganh.Text = currentStudent.SpecializationName ?? "";
            txtLop.Text = currentStudent.ClassName ?? "";

            LoadSemesters();
            LoadSubjectTable(cbHocKy.SelectedItem.ToString());

        }

        // ------------------- LOAD SEMETERS -------------------
        private void LoadSemesters()
        {
            cbHocKy.Items.Clear();

            if (currentStudent?.CohortYear == null)
                return;

            var semesters = resultService.GetSemestersForStudent(currentStudent.CohortYear);

            foreach (string sem in semesters)
                cbHocKy.Items.Add(sem);

            if (cbHocKy.Items.Count > 0)
                cbHocKy.SelectedIndex = 0;
        }


        // ------------------- LOAD SUBJECT + SCORE -------------------
        private void LoadSubjectTable(string semesterCode)
        {
            var subjects = resultService.GetSubjectsForSemester(
                currentStudent.SpecializationId,
                semesterCode
            );

            var scores = resultService.GetSavedScores(currentStudent.Id)
                                      .ToDictionary(x => x.SubjectId, x => x);

            DataTable table = new DataTable();
            table.Columns.Add("STT");
            table.Columns.Add("Tên môn học");
            table.Columns.Add("Tín chỉ");
            table.Columns.Add("Điểm TP1");
            table.Columns.Add("Điểm TP2");
            table.Columns.Add("Trung bình điểm");
            table.Columns.Add("Được dự thi");
            table.Columns.Add("Điểm thi");
            table.Columns.Add("Điểm tổng kết");
            table.Columns.Add("Xếp loại");


            int stt = 1;

            foreach (var s in subjects)
            {
                scores.TryGetValue(s.SubjectId, out var old);

                table.Rows.Add(
                stt++,
                s.SubjectName,
                s.Credits,
                old?.Midterm?.ToString() ?? "",
                old?.Other?.ToString() ?? "",
                old != null ? (old.FinalNumeric ?? 0).ToString("0.0") : "",
                old != null ? (((old.Midterm + old.Other) / 2f) >= 4 ? "✓" : "✗") : "",
                old?.Final?.ToString() ?? "",
                old?.FinalNumeric?.ToString() ?? "",
                old?.LetterGrade ?? ""
            );


            }

            dgvDiem.DataSource = table;
        }


        // ------------------- CALCULATE -------------------
        private void UpdateRow(int row)
        {
            isUpdating = true;

            var table = (DataTable)dgvDiem.DataSource;

            float tp1 = Parse(table.Rows[row][3]);
            float tp2 = Parse(table.Rows[row][4]);

            float avg = (tp1 + tp2) / 2f;
            table.Rows[row][5] = avg.ToString("0.0");   // trung bình

            bool allowed = avg >= 4;
            table.Rows[row][6] = allowed ? "✓" : "✗";   // được dự thi

            float exam = Parse(table.Rows[row][7]);

            float finalScore = allowed ? (tp1 * 0.3f + tp2 * 0.3f + exam * 0.4f) : 0;

            table.Rows[row][8] = finalScore.ToString("0.0");   // điểm tổng kết
            table.Rows[row][9] = GetRank(finalScore);          // xếp loại


            isUpdating = false;
        }





        private string GetRank(float s)
        {
            if (s >= 8.5f) return "A";
            if (s >= 7.8f) return "B+";
            if (s >= 7.0f) return "B";
            if (s >= 6.3f) return "C+";
            if (s >= 5.5f) return "C";
            if (s >= 4.8f) return "D+";
            if (s >= 4.0f) return "D";
            return "F";
        }



        private float Parse(object v)
        {
            if (v == null || v.ToString() == "") return 0;
            float.TryParse(v.ToString(), out float val);
            return val;
        }

        // ------------------- SYNC INPUT -------------------
        private void UpdateSelectedRow()
        {
            if (isUpdating) return;

            int row = dgvDiem.CurrentCell?.RowIndex ?? -1;
            if (row < 0) return;

            var table = (DataTable)dgvDiem.DataSource;

            table.Rows[row][3] = txtScore1.Text;   // TP1
            table.Rows[row][4] = txtScore2.Text;   // TP2
            table.Rows[row][7] = txtExam.Text;     // Điểm thi (index 7)



            UpdateRow(row);
        }

        private void LoadRowToInput()
        {
            int row = dgvDiem.CurrentCell?.RowIndex ?? -1;
            if (row < 0) return;

            var table = (DataTable)dgvDiem.DataSource;

            txtScore1.Text = table.Rows[row][3].ToString();
            txtScore2.Text = table.Rows[row][4].ToString();
            txtExam.Text = table.Rows[row][7].ToString();   // Điểm thi index 7


        }

        // ------------------- SAVE -------------------
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Vui lòng tìm sinh viên trước!");
                return;
            }

            var table = (DataTable)dgvDiem.DataSource;

            foreach (DataRow row in table.Rows)
            {
                Guid subjectId = resultService.FindSubjectIdByName(row[1].ToString());

                ResultSubjectDto dto = new ResultSubjectDto()
                {
                    UserId = currentStudent.Id,
                    SubjectId = subjectId,
                    Midterm = Parse(row[3]),        // TP1
                    Other = Parse(row[4]),          // TP2
                    Final = Parse(row[7]),          // Điểm thi
                    FinalNumeric = Parse(row[8]),   // Điểm tổng kết
                    LetterGrade = row[9].ToString(),
                    Passed = row[6].ToString() == "✓",
                };


                resultService.SaveScore(dto);
            }

            MessageBox.Show("Lưu điểm thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Vui lòng tìm sinh viên trước!");
                return;
            }

            int row = dgvDiem.CurrentCell?.RowIndex ?? -1;
            if (row < 0)
            {
                MessageBox.Show("Vui lòng chọn môn học để xóa điểm!");
                return;
            }

            var table = (DataTable)dgvDiem.DataSource;
            string subjectName = table.Rows[row][1].ToString();

            Guid subjectId = resultService.FindSubjectIdByName(subjectName);

            if (subjectId == Guid.Empty)
            {
                MessageBox.Show("Không tìm thấy môn học trong hệ thống!");
                return;
            }

            // Xác nhận người dùng
            if (MessageBox.Show($"Bạn có chắc muốn xóa điểm môn '{subjectName}'?",
                                "Xác nhận xóa",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning)
                == DialogResult.No)
                return;

            // Gọi service để xóa
            resultService.DeleteScore(currentStudent.Id, subjectId);

            // Refresh lại table
            LoadSubjectTable(cbHocKy.SelectedItem.ToString());

            MessageBox.Show("Xóa điểm thành công!");
        }


        // package ClosedXML
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (dgvDiem.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            save.FileName = $"BangDiem_{currentStudent.StudentCode}.xlsx";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Bảng điểm");

                    int row = 1;

                    // ==== TIÊU ĐỀ TRƯỜNG ====
                    ws.Cell(row, 1).Value = "TRƯỜNG ĐẠI HỌC ĐIỆN LỰC";
                    ws.Range(row, 1, row, 10).Merge().Style
                        .Font.SetBold().Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row++;

                    // ==== TIÊU ĐỀ BẢNG ====
                    ws.Cell(row, 1).Value = "BẢNG ĐIỂM HỌC TẬP";
                    ws.Range(row, 1, row, 10).Merge().Style
                        .Font.SetBold().Font.SetFontSize(14)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    row += 2;

                    // ==== THÔNG TIN SINH VIÊN ====
                    ws.Cell(row, 1).Value = $"Họ và tên: {txtHoTen.Text}";
                    ws.Cell(row, 5).Value = $"Mã SV: {currentStudent.StudentCode}";
                    row++;

                    ws.Cell(row, 1).Value = $"Khoa: {txtKhoa.Text}";
                    ws.Cell(row, 5).Value = $"Ngành: {txtNganh.Text}";
                    row++;

                    ws.Cell(row, 1).Value = $"Chuyên ngành: {txtChuyenNganh.Text}";
                    ws.Cell(row, 5).Value = $"Lớp: {txtLop.Text}";
                    row += 2;

                    // ==== HEADER BẢNG ====
                    for (int i = 0; i < dgvDiem.Columns.Count; i++)
                    {
                        ws.Cell(row, i + 1).Value = dgvDiem.Columns[i].HeaderText;
                    }

                    var headerRange = ws.Range(row, 1, row, dgvDiem.Columns.Count);
                    headerRange.Style.Font.SetBold();
                    headerRange.Style.Fill.SetBackgroundColor(XLColor.AliceBlue);
                    headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    row++;

                    // ==== DỮ LIỆU ====
                    foreach (DataGridViewRow dgRow in dgvDiem.Rows)
                    {
                        if (!dgRow.IsNewRow)
                        {
                            for (int col = 0; col < dgvDiem.Columns.Count; col++)
                            {
                                ws.Cell(row, col + 1).Value = dgRow.Cells[col].Value?.ToString();
                            }

                            row++;
                        }
                    }

                    // Tạo border cho toàn bộ bảng
                    var tableRange = ws.Range((row - dgvDiem.Rows.Count - 1), 1, (row - 1), dgvDiem.Columns.Count);
                    tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    tableRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    // Auto-fit cột
                    ws.Columns().AdjustToContents();

                    workbook.SaveAs(save.FileName);
                }

                MessageBox.Show("Xuất Excel thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }

        }
    }
}
