using iTextSharp.text;
using iTextSharp.text.pdf;
using StudentCourseManagement.Applications.Services;
using System.IO;
using System.Windows.Forms;



namespace StudentCourseManagement.Presentation.Forms.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        private readonly AdminService _userService;
        private Roster _currentUser;
        private Guid _currentUserId;

        public FrmAdminDashboard(AdminService userService, Guid userId)
        {
            InitializeComponent();
            _userService = userService;
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            _ = LoadUserDataAsync(userId);
            _currentUserId = userId;



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
                    txtPhone.Text = _currentUser.Phone164;
                    txtEmail.Text = _currentUser.EmailSchool;
                    txtMDQ.Text = _currentUser.PrivilegeCode;
                    txtDiaChi.Text = _currentUser.Address;

                    if (_currentUser.ProfileImage != null && _currentUser.ProfileImage.Length > 0)
                    {
                        using var ms = new MemoryStream(_currentUser.ProfileImage);
                        pictureBoxProfile.Image = System.Drawing.Image.FromStream(ms);
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
            txtMDQ.ReadOnly = isReadOnly;
            txtRole.ReadOnly = isReadOnly;
            txtDiaChi.ReadOnly = isReadOnly;
            txtEmail.ReadOnly = isReadOnly;
        }

        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        pictureBoxProfile.Image?.Dispose();
                        pictureBoxProfile.Image = System.Drawing.Image.FromStream(new MemoryStream(ms.ToArray()));
                    }
                }
            }
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentUser == null) return;

                _currentUser.FullName = txtFullName.Text.Trim();
                _currentUser.PrivilegeCode = txtMDQ.Text.Trim();
                _currentUser.Gender = txtGender.Text.Trim();
                _currentUser.Address = txtDiaChi.Text.Trim();
                _currentUser.CCCD = txtCCCD.Text.Trim();
                _currentUser.Phone164 = txtPhone.Text.Trim();

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
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();

            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmChangePassword frmChangePassword = new FrmChangePassword(
                            ServicesFactory.CreatePasswordChangeService(),
                            _currentUserId);
            frmChangePassword.Show();

            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Chọn nơi lưu file PDF...";
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FileName = "AdminInfo.pdf";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                string pdfPath = saveDialog.FileName;

                // Tạo Document PDF
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();

                // FONT HỖ TRỢ UNICODE
                BaseFont bf = BaseFont.CreateFont(
                    "c:/windows/fonts/arial.ttf",
                    BaseFont.IDENTITY_H,
                    BaseFont.EMBEDDED);

                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 14);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);

                // TIÊU ĐỀ
                Paragraph title = new Paragraph("THÔNG TIN QUẢN LÝ VIÊN\n\n", boldFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                // AVATAR
                if (pictureBoxProfile.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxProfile.Image.Save(ms, pictureBoxProfile.Image.RawFormat);
                        iTextSharp.text.Image avatar = iTextSharp.text.Image.GetInstance(ms.ToArray());

                        avatar.ScaleToFit(150, 150);
                        avatar.Alignment = Element.ALIGN_CENTER;

                        doc.Add(avatar);
                        doc.Add(new Paragraph("\n"));
                    }
                }

                // THÔNG TIN QUẢN LÝ
                doc.Add(new Paragraph("Họ tên: " + txtFullName.Text, normalFont));
                doc.Add(new Paragraph("Mã đặc quyền: " + txtMDQ.Text, normalFont));
                doc.Add(new Paragraph("CCCD: " + txtCCCD.Text, normalFont));
                doc.Add(new Paragraph("SĐT: " + txtPhone.Text, normalFont));
                doc.Add(new Paragraph("Email: " + txtEmail.Text, normalFont));
                doc.Add(new Paragraph("Giới tính: " + txtGender.Text, normalFont));
                doc.Add(new Paragraph("Địa chỉ: " + txtDiaChi.Text, normalFont));

                doc.Close();

                MessageBox.Show("Xuất file PDF thành công:\n" + pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message);
            }
        }
    }
}