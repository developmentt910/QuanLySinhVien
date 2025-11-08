using StudentCourseManagement.Applications.Services;

namespace StudentCourseManagement.Presentation.Forms.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        private readonly AdminService _userService;
        private User _currentUser; // quản lý viên hiện tại

        public FrmAdminDashboard(AdminService userService, Guid userId)
        {
            InitializeComponent();
            _userService = userService;

            _ = LoadUserDataAsync(userId);

            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnUploadImage.Click += BtnUploadImage_Click;
        }

        private async Task LoadUserDataAsync(Guid userId)
        {
            try
            {
                _currentUser = await _userService.GetUserByIdAsync(userId);

                if (_currentUser != null)
                {
                    txtFullName.Text = _currentUser.FullName;
                    txtRole.Text = _currentUser.Role;
                    txtGender.Text = _currentUser.Gender;
                    txtCCCD.Text = _currentUser.CCCD;
                    txtPhone.Text = _currentUser.PhoneE164;
                    txtEmail.Text = _currentUser.EmailNormalized;

                    if (_currentUser.ProfileImage != null && _currentUser.ProfileImage.Length > 0)
                    {
                        using var ms = new MemoryStream(_currentUser.ProfileImage);
                        pictureBoxProfile.Image = Image.FromStream(ms);
                    }

                    SetTextBoxesReadOnly(true);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin quản lý viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetTextBoxesReadOnly(false);
        }

        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            txtFullName.ReadOnly = isReadOnly;
            txtGender.ReadOnly = isReadOnly;
            txtCCCD.ReadOnly = isReadOnly;
            txtPhone.ReadOnly = isReadOnly;
        }

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfile.Image?.Dispose(); // giải phóng ảnh cũ nếu có
                pictureBoxProfile.Image = Image.FromFile(ofd.FileName);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentUser == null) return;

                _currentUser.FullName = txtFullName.Text.Trim();
                _currentUser.Gender = txtGender.Text.Trim();
                _currentUser.CCCD = txtCCCD.Text.Trim();
                _currentUser.PhoneE164 = txtPhone.Text.Trim();

                if (pictureBoxProfile.Image != null)
                {
                    using var ms = new MemoryStream();
                    pictureBoxProfile.Image.Save(ms, pictureBoxProfile.Image.RawFormat);
                    _currentUser.ProfileImage = ms.ToArray();
                }

                await _userService.UpdateUserInfoAsync(_currentUser);

                MessageBox.Show("Cập nhật thông tin quản lý viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetTextBoxesReadOnly(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoginAdmin frmLogin = new FrmLoginAdmin();
            frmLogin.Show();

            this.Close(); 
        }
    }
}
