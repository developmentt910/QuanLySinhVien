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
using StudentCourseManagement.Applications.SpecializationApp;
using StudentCourseManagement.Presentation.WinForms.Bootstrap;

namespace StudentCourseManagement.Presentation.Forms.Manage
{
    public partial class FrmSpecManage : Form
    {
        private readonly FacultyService _facultyService;
        private readonly MajorService _majorService;
        private readonly SpecializationService _specService;
        private List<Domain.Entities.Faculty> _faculties = new();
        private List<Domain.Entities.Major> _majors = new();
        private List<Domain.Entities.Specialization> _specializations = new();
        private Domain.Entities.Faculty? _selectedFaculty;
        private Domain.Entities.Major? _selectedMajor;
        private Domain.Entities.Specialization? _selectedSpec;

        public FrmSpecManage()
        {
            InitializeComponent();

            _facultyService = ServicesFactory.CreateFacultyService();
            _majorService = ServicesFactory.CreateMajorService();
            _specService = ServicesFactory.CreateSpecializationService();

            this.Load += FrmSpecManage_Load;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            listSpec.SelectedIndexChanged += ListSpec_SelectedIndexChanged;
            addBtn.Click += AddBtn_Click;
            editBtn.Click += EditBtn_Click;
            delBtn.Click += DelBtn_Click;
        }

        private async void FrmSpecManage_Load(object sender, EventArgs e)
        {
            StyleHelper.ApplyFormStyle(this);
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
                    ClearMajorComboBox();
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
            if (comboBox1.SelectedItem is Domain.Entities.Faculty faculty)
            {
                _selectedFaculty = faculty;
                await LoadMajorsByFacultyAsync(faculty.Id);
            }
        }

        private async Task LoadMajorsByFacultyAsync(Guid facultyId)
        {
            try
            {
                var majors = await _majorService.GetMajorsByFacultyAsync(facultyId);
                _majors = majors.ToList();

                comboBox2.DataSource = null;
                comboBox2.DisplayMember = "MajorName";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = _majors;

                if (_majors.Any())
                {
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    ClearSpecializationList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách ngành: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is Domain.Entities.Major major)
            {
                _selectedMajor = major;
                await LoadSpecializationsByMajorAsync(major.Id);
            }
        }

        private async Task LoadSpecializationsByMajorAsync(Guid majorId)
        {
            try
            {
                var specs = await _specService.GetByMajorAsync(majorId);
                _specializations = specs.ToList();

                listSpec.DataSource = null;
                listSpec.DisplayMember = "SpecializationName";
                listSpec.ValueMember = "Id";
                listSpec.DataSource = _specializations;

                if (_specializations.Any())
                {
                    listSpec.SelectedIndex = 0;
                }
                else
                {
                    ClearSpecInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chuyên ngành: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSpec.SelectedItem is Domain.Entities.Specialization spec)
            {
                _selectedSpec = spec;
                DisplaySpecInfo(spec);
            }
            else
            {
                ClearSpecInfo();
            }
        }

        private void DisplaySpecInfo(Domain.Entities.Specialization spec)
        {
            groupBoxSpec.Controls.Clear();

            var lblFaculty = new Label
            {
                Text = $"Khoa: {_selectedFaculty?.FacultyName ?? "-"}",
                Left = 20,
                Top = 30,
                AutoSize = true
            };
            var lblMajor = new Label
            {
                Text = $"Ngành: {_selectedMajor?.MajorName ?? "-"}",
                Left = 20,
                Top = 60,
                AutoSize = true
            };
            var lblSpec = new Label
            {
                Text = $"Chuyên ngành: {spec.SpecializationName}",
                Left = 20,
                Top = 90,
                AutoSize = true
            };

            groupBoxSpec.Controls.Add(lblFaculty);
            groupBoxSpec.Controls.Add(lblMajor);
            groupBoxSpec.Controls.Add(lblSpec);
        }

        private void ClearSpecInfo()
        {
            _selectedSpec = null;
            groupBoxSpec.Controls.Clear();
        }

        private void ClearMajorComboBox()
        {
            _majors.Clear();
            comboBox2.DataSource = null;
            ClearSpecializationList();
        }

        private void ClearSpecializationList()
        {
            _specializations.Clear();
            listSpec.DataSource = null;
            ClearSpecInfo();
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            if (_selectedMajor == null)
            {
                MessageBox.Show("Vui lòng chọn ngành trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var addForm = new FrmAddEditSpec(_selectedFaculty!, _selectedMajor))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var result = await _specService.CreateSpecializationAsync(
                            addForm.SpecName,
                            _selectedMajor.Id);

                        if (result.Ok)
                        {
                            MessageBox.Show("Thêm chuyên ngành thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadSpecializationsByMajorAsync(_selectedMajor.Id);
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi: {result.Error}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm chuyên ngành: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void EditBtn_Click(object sender, EventArgs e)
        {
            if (_selectedSpec == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var editForm = new FrmAddEditSpec(_selectedFaculty!, _selectedMajor!, _selectedSpec))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var result = await _specService.UpdateSpecializationAsync(
                            _selectedSpec.Id,
                            editForm.SpecName,
                            _selectedMajor!.Id);

                        if (result.Ok)
                        {
                            MessageBox.Show("Cập nhật chuyên ngành thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadSpecializationsByMajorAsync(_selectedMajor!.Id);
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi: {result.Error}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật chuyên ngành: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void DelBtn_Click(object sender, EventArgs e)
        {
            if (_selectedSpec == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên ngành cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chuyên ngành '{_selectedSpec.SpecializationName}'?\n\n" +
                "Lưu ý: Xóa chuyên ngành có thể ảnh hưởng đến các dữ liệu liên quan.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var result = await _specService.DeleteSpecializationAsync(_selectedSpec.Id);

                if (result.Ok)
                {
                    MessageBox.Show("Xóa chuyên ngành thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadSpecializationsByMajorAsync(_selectedMajor!.Id);
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result.Error}\n\n" +
                                    "Có thể chuyên ngành này đang được sử dụng trong hệ thống.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chuyên ngành: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal class FrmAddEditSpec : Form
        {
            private TextBox txtSpecName;
            private Button btnOK;
            private Button btnCancel;
            private Label lblFaculty;
            private Label lblMajor;

            public string SpecName => txtSpecName.Text.Trim();

            public FrmAddEditSpec(
                Domain.Entities.Faculty faculty,
                Domain.Entities.Major major,
                Domain.Entities.Specialization? spec = null)
            {
                InitializeComponents(faculty, major);

                if (spec != null)
                {
                    this.Text = "Sửa chuyên ngành";
                    txtSpecName.Text = spec.SpecializationName;
                }
                else
                {
                    this.Text = "Thêm chuyên ngành mới";
                }
            }

            private void InitializeComponents(
                Domain.Entities.Faculty faculty,
                Domain.Entities.Major major)
            {
                this.Size = new Size(450, 260);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;

                int yPos = 20;
                int labelWidth = 120;
                int controlLeft = labelWidth + 30;

                var lblFacultyLabel = new Label { Text = "Khoa:", Left = 20, Top = yPos, Width = labelWidth };
                lblFaculty = new Label { Text = faculty.FacultyName, Left = controlLeft, Top = yPos, Width = 280, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
                this.Controls.Add(lblFacultyLabel);
                this.Controls.Add(lblFaculty);
                yPos += 35;

                var lblMajorLabel = new Label { Text = "Ngành:", Left = 20, Top = yPos, Width = labelWidth };
                lblMajor = new Label { Text = major.MajorName, Left = controlLeft, Top = yPos, Width = 280, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
                this.Controls.Add(lblMajorLabel);
                this.Controls.Add(lblMajor);
                yPos += 35;

                var lblName = new Label { Text = "Tên chuyên ngành:", Left = 20, Top = yPos, Width = labelWidth };
                txtSpecName = new TextBox { Left = controlLeft, Top = yPos - 3, Width = 280 };
                this.Controls.Add(lblName);
                this.Controls.Add(txtSpecName);
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
                if (string.IsNullOrWhiteSpace(txtSpecName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên chuyên ngành!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpecName.Focus();
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
        }
    }
}
