using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentCourseManagement.Applications.SemesterApp;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.Manage
{
    public partial class FrmSemesterManagement : Form
    {
        private readonly SemesterService _semesterService;
        private List<Domain.Entities.Semester> _semesters = new();
        private Domain.Entities.Semester? _selectedSemester;

        public FrmSemesterManagement()
        {
            InitializeComponent();

            _semesterService = ServicesFactory.CreateSemesterService();

            // Đăng ký sự kiện
            this.Load += FrmSemesterManagement_Load;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            button1.Click += BtnAdd_Click;
            button2.Click += BtnUpdate_Click;
            button3.Click += BtnDelete_Click;
            button4.Click += BtnRefresh_Click;
        }

        private async void FrmSemesterManagement_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this);
            try
            {
                await LoadSemestersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSemestersAsync()
        {
            try
            {
                var semesters = await _semesterService.GetAllSemestersAsync();
                _semesters = semesters.ToList();

                listBox1.DataSource = null;
                listBox1.DisplayMember = "SemesterName";
                listBox1.ValueMember = "Id";
                listBox1.DataSource = _semesters;

                if (_semesters.Any())
                {
                    listBox1.SelectedIndex = 0;
                }
                else
                {
                    ClearSelectedSemesterInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học kỳ: {ex.Message}", "Lỗi",
         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Domain.Entities.Semester semester)
            {
                _selectedSemester = semester;
                DisplaySemesterInfo(semester);
            }
            else
            {
                ClearSelectedSemesterInfo();
            }
        }

        private void DisplaySemesterInfo(Domain.Entities.Semester semester)
        {
            lblSemesterCode.Text = $"Mã: {semester.SemesterCode}";
            lblSemesterName.Text = $"Tên: {semester.SemesterName}";
            lblAcademicYear.Text = $"Năm học: {semester.AcademicYear}";
        }

        private void ClearSelectedSemesterInfo()
        {
            _selectedSemester = null;
            lblSemesterCode.Text = "Mã: -";
            lblSemesterName.Text = "Tên: -";
            lblAcademicYear.Text = "Năm học: -";
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var addForm = new FrmAddEditSemester())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var result = await _semesterService.CreateSemesterAsync(
                  addForm.SemesterCode,
                addForm.SemesterName,
             addForm.AcademicYear);

                        if (result.Ok)
                        {
                            MessageBox.Show("Thêm học kỳ thành công!", "Thông báo",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadSemestersAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi: {result.Error}", "Lỗi",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm học kỳ: {ex.Message}", "Lỗi",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedSemester == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ cần sửa!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var editForm = new FrmAddEditSemester(_selectedSemester))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var result = await _semesterService.UpdateSemesterAsync(
                     _selectedSemester.Id,
                        editForm.SemesterCode,
               editForm.SemesterName,
                    editForm.AcademicYear);

                        if (result.Ok)
                        {
                            MessageBox.Show("Cập nhật học kỳ thành công!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadSemestersAsync();
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi: {result.Error}", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật học kỳ: {ex.Message}", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSemester == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ cần xóa!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
  $"Bạn có chắc chắn muốn xóa học kỳ '{_selectedSemester.SemesterName}'?\n\n" +
       "Lưu ý: Xóa học kỳ có thể ảnh hưởng đến các dữ liệu liên quan (lịch học, lịch thi).",
     "Xác nhận xóa",
    MessageBoxButtons.YesNo,
      MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var result = await _semesterService.DeleteSemesterAsync(_selectedSemester.Id);

                if (result.Ok)
                {
                    MessageBox.Show("Xóa học kỳ thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadSemestersAsync();
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result.Error}\n\n" +
                    "Có thể học kỳ này đang được sử dụng trong hệ thống.", "Lỗi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa học kỳ: {ex.Message}", "Lỗi",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadSemestersAsync();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            listBox1 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox1 = new GroupBox();
            lblAcademicYear = new Label();
            lblSemesterName = new Label();
            lblSemesterCode = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(315, 51);
            label1.Name = "label1";
            label1.Size = new Size(225, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản lý học kỳ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 105);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 2;
            label2.Text = "Danh sách học kỳ:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(30, 128);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(350, 284);
            listBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(30, 430);
            button1.Name = "button1";
            button1.Size = new Size(80, 38);
            button1.TabIndex = 6;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(120, 430);
            button2.Name = "button2";
            button2.Size = new Size(80, 38);
            button2.TabIndex = 7;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(210, 430);
            button3.Name = "button3";
            button3.Size = new Size(80, 38);
            button3.TabIndex = 8;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(300, 430);
            button4.Name = "button4";
            button4.Size = new Size(80, 38);
            button4.TabIndex = 9;
            button4.Text = "Làm mới";
            button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAcademicYear);
            groupBox1.Controls.Add(lblSemesterName);
            groupBox1.Controls.Add(lblSemesterCode);
            groupBox1.Location = new Point(410, 128);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 150);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin học kỳ";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lblAcademicYear
            // 
            lblAcademicYear.AutoSize = true;
            lblAcademicYear.Location = new Point(20, 105);
            lblAcademicYear.Name = "lblAcademicYear";
            lblAcademicYear.Size = new Size(82, 20);
            lblAcademicYear.TabIndex = 2;
            lblAcademicYear.Text = "Năm học: -";
            // 
            // lblSemesterName
            // 
            lblSemesterName.AutoSize = true;
            lblSemesterName.Location = new Point(20, 70);
            lblSemesterName.Name = "lblSemesterName";
            lblSemesterName.Size = new Size(45, 20);
            lblSemesterName.TabIndex = 1;
            lblSemesterName.Text = "Tên: -";
            // 
            // lblSemesterCode
            // 
            lblSemesterCode.AutoSize = true;
            lblSemesterCode.Location = new Point(20, 35);
            lblSemesterCode.Name = "lblSemesterCode";
            lblSemesterCode.Size = new Size(43, 20);
            lblSemesterCode.TabIndex = 0;
            lblSemesterCode.Text = "Mã: -";
            // 
            // FrmSemesterManagement
            // 
            ClientSize = new Size(867, 506);
            Controls.Add(groupBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FrmSemesterManagement";
            Text = "Quản lý học kỳ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private GroupBox groupBox1;
        private Label lblSemesterCode;
        private Label lblSemesterName;
        private Label lblAcademicYear;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    // Form phụ để thêm/sửa học kỳ
    internal class FrmAddEditSemester : Form
    {
    private TextBox txtSemesterCode;
        private TextBox txtSemesterName;
  private TextBox txtAcademicYear;
        private Button btnOK;
        private Button btnCancel;

  public string SemesterCode => txtSemesterCode.Text.Trim();
      public string SemesterName => txtSemesterName.Text.Trim();
    public string AcademicYear => txtAcademicYear.Text.Trim();

        public FrmAddEditSemester(Domain.Entities.Semester? semester = null)
        {
            InitializeComponents();

            if (semester != null)
{
   // Chế độ sửa
       this.Text = "Sửa học kỳ";
              txtSemesterCode.Text = semester.SemesterCode;
      txtSemesterName.Text = semester.SemesterName;
      txtAcademicYear.Text = semester.AcademicYear;
            }
  else
       {
       // Chế độ thêm mới
     this.Text = "Thêm học kỳ mới";
                var currentYear = DateTime.Now.Year;
    txtSemesterCode.Text = $"{currentYear}_HK1";
       txtSemesterName.Text = $"Học kỳ 1 năm học {currentYear}-{currentYear + 1}";
        txtAcademicYear.Text = $"{currentYear}-{currentYear + 1}";
         }
      }

        private void InitializeComponents()
        {
      this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
          this.MinimizeBox = false;

            int yPos = 20;
            int labelWidth = 120;
   int controlLeft = labelWidth + 30;

       // Mã học kỳ
            var lblCode = new Label { Text = "Mã học kỳ:", Left = 20, Top = yPos, Width = labelWidth };
    txtSemesterCode = new TextBox { Left = controlLeft, Top = yPos - 3, Width = 300 };
   this.Controls.Add(lblCode);
            this.Controls.Add(txtSemesterCode);
            yPos += 40;

  // Tên học kỳ
            var lblName = new Label { Text = "Tên học kỳ:", Left = 20, Top = yPos, Width = labelWidth };
            txtSemesterName = new TextBox { Left = controlLeft, Top = yPos - 3, Width = 300 };
      this.Controls.Add(lblName);
            this.Controls.Add(txtSemesterName);
         yPos += 40;

    // Năm học
            var lblYear = new Label { Text = "Năm học:", Left = 20, Top = yPos, Width = labelWidth };
      txtAcademicYear = new TextBox { Left = controlLeft, Top = yPos - 3, Width = 300 };
 this.Controls.Add(lblYear);
    this.Controls.Add(txtAcademicYear);
    yPos += 50;

   // Buttons
    btnOK = new Button { Text = "Lưu", Left = controlLeft, Top = yPos, Width = 90, DialogResult = DialogResult.OK };
       btnCancel = new Button { Text = "Hủy", Left = controlLeft + 100, Top = yPos, Width = 90, DialogResult = DialogResult.Cancel };
      btnOK.Click += BtnOK_Click;

      this.Controls.Add(btnOK);
    this.Controls.Add(btnCancel);
this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

  private void BtnOK_Click(object sender, EventArgs e)
    {
        // Validate
            if (string.IsNullOrWhiteSpace(txtSemesterCode.Text))
       {
    MessageBox.Show("Vui lòng nhập mã học kỳ!", "Thông báo",
  MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtSemesterCode.Focus();
         this.DialogResult = DialogResult.None;
              return;
        }

            if (string.IsNullOrWhiteSpace(txtSemesterName.Text))
   {
                MessageBox.Show("Vui lòng nhập tên học kỳ!", "Thông báo",
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
txtSemesterName.Focus();
    this.DialogResult = DialogResult.None;
  return;
   }

            if (string.IsNullOrWhiteSpace(txtAcademicYear.Text))
       {
          MessageBox.Show("Vui lòng nhập năm học!", "Thông báo",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
         txtAcademicYear.Focus();
     this.DialogResult = DialogResult.None;
     return;
     }
        }
    }
}
