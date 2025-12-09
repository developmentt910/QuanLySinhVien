using StudentCourseManagement.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseManagement.Presentation.Forms.result
{
    public partial class FrmFaculty : Form
    {
        private readonly FacultyService _facultyService;

        private string _selectedFacultyCode = null;
        private bool _isEditing = false;

        public FrmFaculty(FacultyService facultyService)
        {
            InitializeComponent();
            _facultyService = facultyService;

            Load += FrmFaculty_Load;

            btnThem.Click += BtnThem_Click;
            btnThayDoi.Click += BtnThayDoi_Click;
            btnLuu.Click += BtnLuu_Click;
            btnXoa.Click += BtnXoa_Click;

            dgv.SelectionChanged += Dgv_SelectionChanged;
        }

        // ============================
        // LOAD GRID
        // ============================
        private async void FrmFaculty_Load(object sender, EventArgs e)
        {
            await LoadGridAsync();
            SetEditingMode(false);
        }

        private async Task LoadGridAsync()
        {
            var list = await _facultyService.GetAllAsync();

            dgv.Rows.Clear();
            foreach (var f in list)
            {
                dgv.Rows.Add(f.FacultyCode, f.FacultyName);
            }

            dgv.ClearSelection();
        }

        private void SetEditingMode(bool enable)
        {
            txtMaKhoa.ReadOnly = false;   // Mã khoa nhập tay
            txtTenKhoa.ReadOnly = !enable;

            // Khi đang edit -> không cho click Thêm
            btnLuu.Enabled = enable;
            btnThayDoi.Enabled = !enable;
            btnThem.Enabled = !enable;
        }

        private void ResetForm()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";

            _selectedFacultyCode = null;
            dgv.ClearSelection();

            SetEditingMode(false);
        }

        // ============================
        // SELECT ROW
        // ============================
        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0) return;
            if (dgv.CurrentRow.Cells[0].Value == null) return;

            _selectedFacultyCode = dgv.CurrentRow.Cells[0].Value.ToString();

            txtMaKhoa.Text = _selectedFacultyCode;
            txtTenKhoa.Text = dgv.CurrentRow.Cells[1].Value?.ToString();

            _isEditing = false;
            SetEditingMode(false);
        }

        // ============================
        // ADD
        // ============================
        private void BtnThem_Click(object sender, EventArgs e)
        {
            ResetForm();
            _isEditing = false;
            SetEditingMode(true);
        }

        // ============================
        // EDIT
        // ============================
        private void BtnThayDoi_Click(object sender, EventArgs e)
        {
            if (_selectedFacultyCode == null)
            {
                MessageBox.Show("Vui lòng chọn khoa để sửa.");
                return;
            }

            _isEditing = true;
            SetEditingMode(true);
        }

        // ============================
        // SAVE
        // ============================
        private async void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
                {
                    MessageBox.Show("Mã khoa không được để trống!");
                    return;
                }

                var faculty = new Faculty
                {
                    FacultyCode = txtMaKhoa.Text.Trim(),
                    FacultyName = txtTenKhoa.Text.Trim()
                };

                if (!_isEditing) // ADD
                {
                    await _facultyService.CreateAsync(faculty);
                    MessageBox.Show("Thêm khoa thành công!");
                }
                else // UPDATE
                {
                    await _facultyService.UpdateAsync(faculty);
                    MessageBox.Show("Cập nhật khoa thành công!");
                }

                await LoadGridAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // ============================
        // DELETE
        // ============================
        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedFacultyCode == null)
            {
                MessageBox.Show("Vui lòng chọn khoa để xoá.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá khoa này?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                await _facultyService.DeleteAsync(_selectedFacultyCode);
                MessageBox.Show("Xoá khoa thành công!");

                await LoadGridAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
