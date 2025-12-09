using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentCourseManagement.Applications.Faculty;
using StudentCourseManagement.Applications.MajorApp;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.Manage
{
    public partial class FrmMajorManagement : Form
    {
        private readonly FacultyService _facultyService;
        private readonly MajorService _majorService;
 private List<Domain.Entities.Faculty> _faculties = new();
        private List<Domain.Entities.Major> _majors = new();
        private Domain.Entities.Faculty? _selectedFaculty;
      private Domain.Entities.Major? _selectedMajor;

      public FrmMajorManagement()
        {
      InitializeComponent();

            _facultyService = ServicesFactory.CreateFacultyService();
         _majorService = ServicesFactory.CreateMajorService();

        this.Load += FrmMajorManagement_Load;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
       listNganh.SelectedIndexChanged += ListNganh_SelectedIndexChanged;
            addBtn.Click += AddBtn_Click;
       editBtn.Click += EditBtn_Click;
     delBtn.Click += DelBtn_Click;
            refreshBtn.Click += RefreshBtn_Click;
        }

        private async void FrmMajorManagement_Load(object sender, EventArgs e)
        {
      try
  {
                await LoadFacultiesAsync();
       }
      catch (Exception ex)
       {
  MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private async Task LoadFacultiesAsync()
        {
      try
            {
           var faculties = await _facultyService.GetAllAsync();
      _faculties = faculties.ToList();

    comboBox1.DataSource = null;
      comboBox1.DisplayMember = "FacultyName";
           comboBox1.ValueMember = "Id";
                comboBox1.DataSource = _faculties;

         if (_faculties.Any())
            {
     comboBox1.SelectedIndex = 0;
        }
    else
       {
     ClearMajorList();
                }
            }
          catch (Exception ex)
          {
                MessageBox.Show($"Lỗi khi tải danh sách khoa: {ex.Message}", "Lỗi",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
        }

        private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
      if (comboBox1.SelectedItem is Domain.Entities.Faculty selectedFaculty)
            {
      _selectedFaculty = selectedFaculty;
        await LoadMajorsByFacultyAsync(selectedFaculty.Id);
        }
        }

        private async Task LoadMajorsByFacultyAsync(Guid facultyId)
        {
            try
  {
 var majors = await _majorService.GetMajorsByFacultyAsync(facultyId);
    _majors = majors.ToList();

 listNganh.DataSource = null;
     listNganh.DisplayMember = "MajorName";
     listNganh.ValueMember = "Id";
      listNganh.DataSource = _majors;

 if (_majors.Any())
          {
            listNganh.SelectedIndex = 0;
     }
         else
       {
             ClearMajorInfo();
      }
            }
            catch (Exception ex)
        {
     MessageBox.Show($"Lỗi khi tải danh sách ngành: {ex.Message}", "Lỗi",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
        }

        private void ListNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
      if (listNganh.SelectedItem is Domain.Entities.Major major)
       {
              _selectedMajor = major;
                DisplayMajorInfo(major);
          }
  else
         {
      ClearMajorInfo();
 }
        }

        private void DisplayMajorInfo(Domain.Entities.Major major)
 {
            lblFacultyName.Text = $"Khoa: {_selectedFaculty?.FacultyName ?? "-"}";
       lblMajorName.Text = $"Ngành: {major.MajorName}";
    }

    private void ClearMajorInfo()
     {
      _selectedMajor = null;
      lblFacultyName.Text = "Khoa: -";
    lblMajorName.Text = "Ngành: -";
        }

        private void ClearMajorList()
        {
            _majors.Clear();
  listNganh.DataSource = null;
            ClearMajorInfo();
 }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
   if (_selectedFaculty == null)
  {
         MessageBox.Show("Vui lòng chọn khoa trước!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return;
            }

      using (var addForm = new FrmAddEditMajor(_selectedFaculty))
       {
             if (addForm.ShowDialog() == DialogResult.OK)
 {
       try
  {
          var result = await _majorService.CreateMajorAsync(
       addForm.MajorName,
 _selectedFaculty.Id);

  if (result.Ok)
          {
        MessageBox.Show("Thêm ngành thành công!", "Thông báo",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
      await LoadMajorsByFacultyAsync(_selectedFaculty.Id);
        }
            else
            {
  MessageBox.Show($"Lỗi: {result.Error}", "Lỗi",
      MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
}
             catch (Exception ex)
{
            MessageBox.Show($"Lỗi khi thêm ngành: {ex.Message}", "Lỗi",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
                }
       }
    }

      private async void EditBtn_Click(object sender, EventArgs e)
        {
   if (_selectedMajor == null)
        {
          MessageBox.Show("Vui lòng chọn ngành cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
return;
            }

    using (var editForm = new FrmAddEditMajor(_selectedFaculty!, _selectedMajor))
      {
      if (editForm.ShowDialog() == DialogResult.OK)
{
    try
               {
      var result = await _majorService.UpdateMajorAsync(
 _selectedMajor.Id,
          editForm.MajorName,
_selectedFaculty!.Id);

        if (result.Ok)
        {
  MessageBox.Show("Cập nhật ngành thành công!", "Thông báo",
      MessageBoxButtons.OK, MessageBoxIcon.Information);
     await LoadMajorsByFacultyAsync(_selectedFaculty!.Id);
         }
  else
        {
     MessageBox.Show($"Lỗi: {result.Error}", "Lỗi",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
    }
     catch (Exception ex)
      {
          MessageBox.Show($"Lỗi khi cập nhật ngành: {ex.Message}", "Lỗi",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
        }
     }
        }

      private async void DelBtn_Click(object sender, EventArgs e)
        {
 if (_selectedMajor == null)
            {
    MessageBox.Show("Vui lòng chọn ngành cần xóa!", "Thông báo",
   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
  }

     var confirmResult = MessageBox.Show(
 $"Bạn có chắc chắn muốn xóa ngành '{_selectedMajor.MajorName}'?\n\n" +
       "Lưu ý: Xóa ngành có thể ảnh hưởng đến các dữ liệu liên quan.",
      "Xác nhận xóa",
     MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

 if (confirmResult != DialogResult.Yes)
  return;

        try
    {
      var result = await _majorService.DeleteMajorAsync(_selectedMajor.Id);

  if (result.Ok)
    {
            MessageBox.Show("Xóa ngành thành công!", "Thông báo",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
       await LoadMajorsByFacultyAsync(_selectedFaculty!.Id);
      }
         else
   {
    MessageBox.Show($"Lỗi: {result.Error}\n\n" +
            "Có thể ngành này đang được sử dụng trong hệ thống.", "Lỗi",
       MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
            }
    catch (Exception ex)
    {
              MessageBox.Show($"Lỗi khi xóa ngành: {ex.Message}", "Lỗi",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
     }
        }

        private async void RefreshBtn_Click(object sender, EventArgs e)
     {
         await LoadFacultiesAsync();
        }
    }

    internal class FrmAddEditMajor : Form
    {
    private TextBox txtMajorName;
        private Button btnOK;
        private Button btnCancel;
      private Label lblFaculty;

        public string MajorName => txtMajorName.Text.Trim();

        public FrmAddEditMajor(Domain.Entities.Faculty faculty, Domain.Entities.Major? major = null)
        {
      InitializeComponents(faculty);

            if (major != null)
            {
   this.Text = "Sửa ngành";
            txtMajorName.Text = major.MajorName;
         }
            else
       {
          this.Text = "Thêm ngành mới";
}
  }

    private void InitializeComponents(Domain.Entities.Faculty faculty)
   {
      this.Size = new Size(450, 220);
    this.StartPosition = FormStartPosition.CenterParent;
  this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

       int yPos = 20;
    int labelWidth = 100;
      int controlLeft = labelWidth + 30;

 var lblFacultyLabel = new Label { Text = "Khoa:", Left = 20, Top = yPos, Width = labelWidth };
            lblFaculty = new Label { Text = faculty.FacultyName, Left = controlLeft, Top = yPos, Width = 280, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            this.Controls.Add(lblFacultyLabel);
       this.Controls.Add(lblFaculty);
            yPos += 35;

    var lblName = new Label { Text = "Tên ngành:", Left = 20, Top = yPos, Width = labelWidth };
       txtMajorName = new TextBox { Left = controlLeft, Top = yPos - 3, Width = 280 };
 this.Controls.Add(lblName);
            this.Controls.Add(txtMajorName);
     yPos += 50;

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
      if (string.IsNullOrWhiteSpace(txtMajorName.Text))
  {
        MessageBox.Show("Vui lòng nhập tên ngành!", "Thông báo",
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
      txtMajorName.Focus();
                this.DialogResult = DialogResult.None;
  return;
 }
        }
    }
}
