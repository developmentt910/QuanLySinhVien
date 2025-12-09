using StudentCourseManagement.Applications;
using StudentCourseManagement.Applications.Curriculum;
using StudentCourseManagement.Applications.Students.Dtos;
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
            var conn = new SqlConnectionFactory(Program.Configuration);

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
        }

        // ------------------- SEARCH -------------------
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string msv = txtSearch.Text.Trim();
            if (msv == "")
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

            txtHoTen.Text = currentStudent.FullName;
            txtLop.Text = currentStudent.ClassName;
            txtNganh.Text = currentStudent.MajorName;
            txtChuyenNganh.Text = currentStudent.SpecializationName;
            txtKhoa.Text = currentStudent.FacultyName;

            LoadSubjectTable();
        }

        // ------------------- LOAD SUBJECT & SCORE -------------------
        private void LoadSubjectTable()
        {
            var subjects = resultService.GetSubjectsForStudent(currentStudent.SpecializationId);
            var scores = resultService.GetSavedScores(currentStudent.Id)
                                      .ToDictionary(x => x.SubjectId, x => x);

            DataTable table = new DataTable();
            table.Columns.Add("STT");
            table.Columns.Add("Tên môn");
            table.Columns.Add("Mã lớp");
            table.Columns.Add("Tín chỉ");
            table.Columns.Add("Điểm TP1");
            table.Columns.Add("Điểm TP2");
            table.Columns.Add("Điểm thi");
            table.Columns.Add("Điểm tổng kết");
            table.Columns.Add("Xếp loại");
            table.Columns.Add("Qua môn");

            int stt = 1;

            foreach (var s in subjects)
            {
                scores.TryGetValue(s.SubjectId, out var old);

                table.Rows.Add(
                    stt++,
                    s.SubjectName,
                    s.ClassName,
                    s.Credits,
                    old?.Midterm?.ToString() ?? "",
                    old?.Other?.ToString() ?? "",
                    old?.Final?.ToString() ?? "",
                    old?.FinalNumeric?.ToString() ?? "",
                    old?.LetterGrade ?? "",
                    old?.Passed == true ? "✓" : "✗"
                );
            }

            dgvDiem.DataSource = table;
        }


        // ------------------- CALCULATE -------------------
        private void UpdateRow(int row)
        {
            isUpdating = true;

            var table = (DataTable)dgvDiem.DataSource;

            float mid = Parse(table.Rows[row][4]);
            float other = Parse(table.Rows[row][5]);
            float exam = Parse(table.Rows[row][6]);

            // Được thi = Midterm + Other >= 4?
            bool allowed = ((mid + other) / 2f) >= 4;

            float finalScore = allowed ? (mid + other) * 0.3f + exam * 0.7f : 0;

            table.Rows[row][7] = finalScore.ToString("0.00");
            table.Rows[row][8] = GetRank(finalScore);
            table.Rows[row][9] = allowed ? "✓" : "✗";

            isUpdating = false;
        }

        private string GetRank(float s)
        {
            if (s >= 8.5) return "A";
            if (s >= 8.0) return "B+";
            if (s >= 7.0) return "B";
            if (s >= 6.5) return "C+";
            if (s >= 5.5) return "C";
            if (s >= 5.0) return "D+";
            if (s >= 4.0) return "D";
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

            table.Rows[row][4] = txtScore1.Text;
            table.Rows[row][5] = txtScore2.Text;
            table.Rows[row][6] = txtExam.Text;

            UpdateRow(row);
        }

        private void LoadRowToInput()
        {
            int row = dgvDiem.CurrentCell?.RowIndex ?? -1;
            if (row < 0) return;

            var table = (DataTable)dgvDiem.DataSource;

            txtScore1.Text = table.Rows[row][4].ToString();
            txtScore2.Text = table.Rows[row][5].ToString();
            txtExam.Text = table.Rows[row][6].ToString();
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

                float mid = Parse(row[4]);
                float other = Parse(row[5]);
                float exam = Parse(row[6]);
                float finalScore = Parse(row[7]);

                ResultSubjectDto dto = new ResultSubjectDto()
                {
                    UserId = currentStudent.Id,
                    SubjectId = subjectId,
                    Midterm = mid,
                    Other = other,
                    Final = exam,
                    FinalNumeric = finalScore,
                    LetterGrade = row[8].ToString(),
                    Passed = row[9].ToString() == "✓",
                };

                resultService.SaveScore(dto);
            }

            MessageBox.Show("Lưu điểm thành công!");
        }
    }
}
