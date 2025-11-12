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
using StudentCourseManagement.Applications.MajorApp;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.Manage
{
    public partial class FrmSemesterManagement : Form
    {
  private readonly SemesterService _semesterService;
     private readonly MajorService _majorService;
      private List<Domain.Entities.Major> _majors = new();
        private List<Domain.Entities.Semester> _semesters = new();
        private Domain.Entities.Semester? _selectedSemester;

      public FrmSemesterManagement()
        {
InitializeComponent();
          
    // Khởi tạo services
            _semesterService = ServicesFactory.CreateSemesterService();
            _majorService = ServicesFactory.CreateMajorService();
            
      // Đăng ký sự kiện
   this.Load += FrmSemesterManagement_Load;
        comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
      comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
          button1.Click += BtnAdd_Click;
 button2.Click += BtnUpdate_Click;
        button3.Click += BtnDelete_Click;
        }

        private async void FrmSemesterManagement_Load(object sender, EventArgs e)
        {
    try
      {
         await LoadMajorsAsync();
          }
   catch (Exception ex)
    {
           MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
  MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }

        private async Task LoadMajorsAsync()
   {
        try
            {
     var majors = await _majorService.GetAllMajorsAsync();
     _majors = majors.ToList();

             comboBox1.DataSource = null;
                comboBox1.DisplayMember = "MajorName";
    comboBox1.ValueMember = "Id";
              comboBox1.DataSource = _majors;

       if (_majors.Any())
          {
      comboBox1.SelectedIndex = 0;
       }
  }
        catch (Exception ex)
            {
   MessageBox.Show($"Lỗi khi tải danh sách ngành: {ex.Message}", "Lỗi",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  if (comboBox1.SelectedItem is Domain.Entities.Major selectedMajor)
          {
 await LoadSemestersByMajorAsync(selectedMajor.Id);
        }
        }

   private async Task LoadSemestersByMajorAsync(Guid majorId)
        {
   try
            {
var semesters = await _semesterService.GetSemestersByMajorAsync(majorId);
      _semesters = semesters.ToList();

      comboBox2.DataSource = null;
    comboBox2.DisplayMember = "SemesterName";
 comboBox2.ValueMember = "Id";
                comboBox2.DataSource = _semesters;

        if (_semesters.Any())
   {
         comboBox2.SelectedIndex = 0;
                }
                else
       {
          _selectedSemester = null;
             }
  }
            catch (Exception ex)
            {
        MessageBox.Show($"Lỗi khi tải danh sách học kỳ: {ex.Message}", "Lỗi",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
}
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
  {
     if (comboBox2.SelectedItem is Domain.Entities.Semester semester)
 {
   _selectedSemester = semester;
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
   if (comboBox1.SelectedItem == null)
      {
    MessageBox.Show("Vui lòng chọn ngành!", "Thông báo",
   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

  var selectedMajor = (Domain.Entities.Major)comboBox1.SelectedItem;

    // Mở form thêm học kỳ
            using (var addForm = new FrmAddEditSemester(selectedMajor.Id, selectedMajor.MajorName))
 {
      if (addForm.ShowDialog() == DialogResult.OK)
       {
   try
 {
   var result = await _semesterService.CreateSemesterAsync(
      addForm.SemesterName,
     addForm.Year,
      addForm.SemesterNumber,
     addForm.StartDate,
         addForm.EndDate,
       selectedMajor.Id);

               if (result.Ok)
            {
          MessageBox.Show("Thêm học kỳ thành công!", "Thông báo",
  MessageBoxButtons.OK, MessageBoxIcon.Information);
      await LoadSemestersByMajorAsync(selectedMajor.Id);
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

var selectedMajor = (Domain.Entities.Major)comboBox1.SelectedItem;

            // Mở form sửa học kỳ
            using (var editForm = new FrmAddEditSemester(
           selectedMajor.Id,
     selectedMajor.MajorName,
    _selectedSemester))
     {
        if (editForm.ShowDialog() == DialogResult.OK)
   {
  try
                {
         var result = await _semesterService.UpdateSemesterAsync(
         _selectedSemester.Id,
       editForm.SemesterName,
        editForm.Year,
      editForm.SemesterNumber,
     editForm.StartDate,
   editForm.EndDate,
     editForm.IsActive,
      selectedMajor.Id);

     if (result.Ok)
       {
       MessageBox.Show("Cập nhật học kỳ thành công!", "Thông báo",
  MessageBoxButtons.OK, MessageBoxIcon.Information);
     await LoadSemestersByMajorAsync(selectedMajor.Id);
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
                "Lưu ý: Xóa học kỳ có thể ảnh hưởng đến các dữ liệu liên quan (môn học, điểm số).",
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

             var selectedMajor = (Domain.Entities.Major)comboBox1.SelectedItem;
     await LoadSemestersByMajorAsync(selectedMajor.Id);
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

        private void InitializeComponent()
        {
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đăngNhậpToolStripMenuItem = new ToolStripMenuItem();
            quanLýSinhViênToolStripMenuItem = new ToolStripMenuItem();
            thôngTinSinhViênToolStripMenuItem = new ToolStripMenuItem();
            kếtQuảHọcTậpToolStripMenuItem = new ToolStripMenuItem();
            đánhGiáRènLuyệnToolStripMenuItem = new ToolStripMenuItem();
            quảnLýTổngHợpToolStripMenuItem = new ToolStripMenuItem();
            họcKỳToolStripMenuItem = new ToolStripMenuItem();
            khoaToolStripMenuItem = new ToolStripMenuItem();
            ngànhToolStripMenuItem = new ToolStripMenuItem();
            chuyênNgànhToolStripMenuItem = new ToolStripMenuItem();
            lớpHọcToolStripMenuItem = new ToolStripMenuItem();
            mônHọcToolStripMenuItem = new ToolStripMenuItem();
            chươngTrìnhKhungToolStripMenuItem = new ToolStripMenuItem();
            thờiKhóaBiểuToolStripMenuItem = new ToolStripMenuItem();
            thốngKêBáoCáoToolStripMenuItem = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(315, 51);
            label1.Name = "label1";
            label1.Size = new Size(183, 32);
            label1.TabIndex = 0;
            label1.Text = "Quản lý học kỳ";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quanLýSinhViênToolStripMenuItem, quảnLýTổngHợpToolStripMenuItem, thốngKêBáoCáoToolStripMenuItem, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(842, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngNhậpToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            đăngNhậpToolStripMenuItem.Size = new Size(224, 26);
            đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
            // 
            // quanLýSinhViênToolStripMenuItem
            // 
            quanLýSinhViênToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinSinhViênToolStripMenuItem, kếtQuảHọcTậpToolStripMenuItem, đánhGiáRènLuyệnToolStripMenuItem });
            quanLýSinhViênToolStripMenuItem.Name = "quanLýSinhViênToolStripMenuItem";
            quanLýSinhViênToolStripMenuItem.Size = new Size(134, 24);
            quanLýSinhViênToolStripMenuItem.Text = "Quản lý sinh viên";
            // 
            // thôngTinSinhViênToolStripMenuItem
            // 
            thôngTinSinhViênToolStripMenuItem.Name = "thôngTinSinhViênToolStripMenuItem";
            thôngTinSinhViênToolStripMenuItem.Size = new Size(224, 26);
            thôngTinSinhViênToolStripMenuItem.Text = "Thông tin sinh viên";
            // 
            // kếtQuảHọcTậpToolStripMenuItem
            // 
            kếtQuảHọcTậpToolStripMenuItem.Name = "kếtQuảHọcTậpToolStripMenuItem";
            kếtQuảHọcTậpToolStripMenuItem.Size = new Size(224, 26);
            kếtQuảHọcTậpToolStripMenuItem.Text = "Kết quả học tập";
            // 
            // đánhGiáRènLuyệnToolStripMenuItem
            // 
            đánhGiáRènLuyệnToolStripMenuItem.Name = "đánhGiáRènLuyệnToolStripMenuItem";
            đánhGiáRènLuyệnToolStripMenuItem.Size = new Size(224, 26);
            đánhGiáRènLuyệnToolStripMenuItem.Text = "Đánh giá rèn luyện";
            // 
            // quảnLýTổngHợpToolStripMenuItem
            // 
            quảnLýTổngHợpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { họcKỳToolStripMenuItem, khoaToolStripMenuItem, ngànhToolStripMenuItem, chuyênNgànhToolStripMenuItem, lớpHọcToolStripMenuItem, mônHọcToolStripMenuItem, chươngTrìnhKhungToolStripMenuItem, thờiKhóaBiểuToolStripMenuItem });
            quảnLýTổngHợpToolStripMenuItem.Name = "quảnLýTổngHợpToolStripMenuItem";
            quảnLýTổngHợpToolStripMenuItem.Size = new Size(138, 24);
            quảnLýTổngHợpToolStripMenuItem.Text = "Quản lý tổng hợp";
            // 
            // họcKỳToolStripMenuItem
            // 
            họcKỳToolStripMenuItem.Name = "họcKỳToolStripMenuItem";
            họcKỳToolStripMenuItem.Size = new Size(224, 26);
            họcKỳToolStripMenuItem.Text = "Học kỳ";
            // 
            // khoaToolStripMenuItem
            // 
            khoaToolStripMenuItem.Name = "khoaToolStripMenuItem";
            khoaToolStripMenuItem.Size = new Size(224, 26);
            khoaToolStripMenuItem.Text = "Khoa";
            // 
            // ngànhToolStripMenuItem
            // 
            ngànhToolStripMenuItem.Name = "ngànhToolStripMenuItem";
            ngànhToolStripMenuItem.Size = new Size(224, 26);
            ngànhToolStripMenuItem.Text = "Ngành";
            // 
            // chuyênNgànhToolStripMenuItem
            // 
            chuyênNgànhToolStripMenuItem.Name = "chuyênNgànhToolStripMenuItem";
            chuyênNgànhToolStripMenuItem.Size = new Size(224, 26);
            chuyênNgànhToolStripMenuItem.Text = "Chuyên ngành";
            // 
            // lớpHọcToolStripMenuItem
            // 
            lớpHọcToolStripMenuItem.Name = "lớpHọcToolStripMenuItem";
            lớpHọcToolStripMenuItem.Size = new Size(224, 26);
            lớpHọcToolStripMenuItem.Text = "Lớp học";
            // 
            // mônHọcToolStripMenuItem
            // 
            mônHọcToolStripMenuItem.Name = "mônHọcToolStripMenuItem";
            mônHọcToolStripMenuItem.Size = new Size(224, 26);
            mônHọcToolStripMenuItem.Text = "Môn học";
            // 
            // chươngTrìnhKhungToolStripMenuItem
            // 
            chươngTrìnhKhungToolStripMenuItem.Name = "chươngTrìnhKhungToolStripMenuItem";
            chươngTrìnhKhungToolStripMenuItem.Size = new Size(224, 26);
            chươngTrìnhKhungToolStripMenuItem.Text = "Chương trình khung";
            // 
            // thờiKhóaBiểuToolStripMenuItem
            // 
            thờiKhóaBiểuToolStripMenuItem.Name = "thờiKhóaBiểuToolStripMenuItem";
            thờiKhóaBiểuToolStripMenuItem.Size = new Size(224, 26);
            thờiKhóaBiểuToolStripMenuItem.Text = "Thời khóa biểu";
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            thốngKêBáoCáoToolStripMenuItem.Size = new Size(152, 24);
            thốngKêBáoCáoToolStripMenuItem.Text = "Thống kê / Báo cáo";
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(78, 24);
            trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(125, 119);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Ngành:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 165);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 3;
            label3.Text = "Học kỳ:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(229, 111);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(486, 28);
            comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(229, 157);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(486, 28);
            comboBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(141, 216);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 6;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(367, 216);
            button2.Name = "button2";
            button2.Size = new Size(102, 38);
            button2.TabIndex = 7;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(600, 216);
            button3.Name = "button3";
            button3.Size = new Size(102, 38);
            button3.TabIndex = 8;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            // 
            // FrmSemesterManagement
            // 
            ClientSize = new Size(842, 501);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MainMenuStrip = menuStrip1;
            Name = "FrmSemesterManagement";
            Text = "Quản lý học kỳ";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
     private Label label1;
        private MenuStrip menuStrip1;
    private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem đăngNhậpToolStripMenuItem;
    private ToolStripMenuItem quanLýSinhViênToolStripMenuItem;
        private ToolStripMenuItem thôngTinSinhViênToolStripMenuItem;
        private ToolStripMenuItem kếtQuảHọcTậpToolStripMenuItem;
        private ToolStripMenuItem đánhGiáRènLuyệnToolStripMenuItem;
      private ToolStripMenuItem quảnLýTổngHợpToolStripMenuItem;
        private ToolStripMenuItem họcKỳToolStripMenuItem;
        private ToolStripMenuItem khoaToolStripMenuItem;
    private ToolStripMenuItem ngànhToolStripMenuItem;
        private ToolStripMenuItem chuyênNgànhToolStripMenuItem;
        private ToolStripMenuItem lớpHọcToolStripMenuItem;
        private ToolStripMenuItem mônHọcToolStripMenuItem;
        private ToolStripMenuItem chươngTrìnhKhungToolStripMenuItem;
        private ToolStripMenuItem thờiKhóaBiểuToolStripMenuItem;
        private ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
      private Label label2;
        private Label label3;
     private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private Button button3;
    }

    // Form phụ để thêm/sửa học kỳ
    internal class FrmAddEditSemester : Form
    {
        private TextBox txtSemesterName;
        private NumericUpDown numYear;
      private NumericUpDown numSemesterNumber;
        private DateTimePicker dtpStartDate;
  private DateTimePicker dtpEndDate;
    private CheckBox chkIsActive;
  private Button btnOK;
        private Button btnCancel;
        private Label lblMajor;

        public string SemesterName => txtSemesterName.Text.Trim();
        public int Year => (int)numYear.Value;
        public int SemesterNumber => (int)numSemesterNumber.Value;
 public DateTime StartDate => dtpStartDate.Value;
        public DateTime EndDate => dtpEndDate.Value;
        public bool IsActive => chkIsActive.Checked;

        public FrmAddEditSemester(Guid majorId, string majorName, Domain.Entities.Semester? semester = null)
        {
            InitializeComponents(majorName);

     if (semester != null)
            {
// Chế độ sửa
           this.Text = "Sửa học kỳ";
            txtSemesterName.Text = semester.SemesterName;
    numYear.Value = semester.Year;
     numSemesterNumber.Value = semester.SemesterNumber;
          dtpStartDate.Value = semester.StartDate;
           dtpEndDate.Value = semester.EndDate;
       chkIsActive.Checked = semester.IsActive;
            }
  else
            {
   // Chế độ thêm mới
      this.Text = "Thêm học kỳ mới";
      numYear.Value = DateTime.Now.Year;
                numSemesterNumber.Value = 1;
          dtpStartDate.Value = DateTime.Now;
 dtpEndDate.Value = DateTime.Now.AddMonths(4);
          chkIsActive.Checked = true;
         }
     }

      private void InitializeComponents(string majorName)
        {
 this.Size = new Size(500, 400);
         this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

   int yPos = 20;
            int labelWidth = 120;
          int controlLeft = labelWidth + 30;

         // Ngành
         var lblMajorLabel = new Label { Text = "Ngành:", Left = 20, Top = yPos, Width = labelWidth };
  lblMajor = new Label { Text = majorName, Left = controlLeft, Top = yPos, Width = 300, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
    this.Controls.Add(lblMajorLabel);
            this.Controls.Add(lblMajor);
    yPos += 35;

            // Tên học kỳ
       var lblSemesterName = new Label { Text = "Tên học kỳ:", Left = 20, Top = yPos, Width = labelWidth };
     txtSemesterName = new TextBox { Left = controlLeft, Top = yPos - 3, Width = 300 };
            this.Controls.Add(lblSemesterName);
     this.Controls.Add(txtSemesterName);
            yPos += 35;

        // Năm học
        var lblYear = new Label { Text = "Năm học:", Left = 20, Top = yPos, Width = labelWidth };
     numYear = new NumericUpDown { Left = controlLeft, Top = yPos - 3, Width = 150, Minimum = 2000, Maximum = 2100 };
        this.Controls.Add(lblYear);
     this.Controls.Add(numYear);
            yPos += 35;

            // Học kỳ thứ
      var lblSemesterNumber = new Label { Text = "Học kỳ thứ:", Left = 20, Top = yPos, Width = labelWidth };
            numSemesterNumber = new NumericUpDown { Left = controlLeft, Top = yPos - 3, Width = 150, Minimum = 1, Maximum = 3 };
this.Controls.Add(lblSemesterNumber);
   this.Controls.Add(numSemesterNumber);
            yPos += 35;

     // Ngày bắt đầu
       var lblStartDate = new Label { Text = "Ngày bắt đầu:", Left = 20, Top = yPos, Width = labelWidth };
            dtpStartDate = new DateTimePicker { Left = controlLeft, Top = yPos - 3, Width = 200, Format = DateTimePickerFormat.Short };
      this.Controls.Add(lblStartDate);
    this.Controls.Add(dtpStartDate);
            yPos += 35;

            // Ngày kết thúc
  var lblEndDate = new Label { Text = "Ngày kết thúc:", Left = 20, Top = yPos, Width = labelWidth };
            dtpEndDate = new DateTimePicker { Left = controlLeft, Top = yPos - 3, Width = 200, Format = DateTimePickerFormat.Short };
            this.Controls.Add(lblEndDate);
            this.Controls.Add(dtpEndDate);
         yPos += 35;

            // Trạng thái
     chkIsActive = new CheckBox { Text = "Đang hoạt động", Left = controlLeft, Top = yPos, Width = 200 };
   this.Controls.Add(chkIsActive);
        yPos += 40;

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
         if (string.IsNullOrWhiteSpace(txtSemesterName.Text))
        {
     MessageBox.Show("Vui lòng nhập tên học kỳ!", "Thông báo",
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
           txtSemesterName.Focus();
        this.DialogResult = DialogResult.None;
           return;
       }

            if (dtpStartDate.Value >= dtpEndDate.Value)
         {
  MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc!", "Thông báo",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
         dtpStartDate.Focus();
  this.DialogResult = DialogResult.None;
return;
  }
     }
    }
}
