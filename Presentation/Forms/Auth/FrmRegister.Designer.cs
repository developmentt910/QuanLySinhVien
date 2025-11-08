using System.Drawing;
using System.Windows.Forms;

namespace StudentCourseManagement.Forms.Auth
{
    partial class FrmRegister
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            flpRole = new FlowLayoutPanel();
            rdoStudent = new RadioButton();
            rdoAdmin = new RadioButton();
            lblTitle = new Label();
            tlpInfo = new TableLayoutPanel();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblCccd = new Label();
            txtCccd = new TextBox();
            lblPhone = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            tlpRoot = new TableLayoutPanel();
            tlpRoleBlock = new TableLayoutPanel();
            pnlStudent = new Panel();
            tlpStudent = new TableLayoutPanel();
            lblStudentCode = new Label();
            txtStudentCode = new TextBox();
            pnlAdmin = new Panel();
            tlpAdmin = new TableLayoutPanel();
            txtPrivCode = new TextBox();
            lblPrivCode = new Label();
            flpActions = new FlowLayoutPanel();
            btnRegister = new Button();
            lnkToLogin = new LinkLabel();
            lnkToStudent = new LinkLabel();
            flpRole.SuspendLayout();
            tlpInfo.SuspendLayout();
            tlpRoot.SuspendLayout();
            tlpRoleBlock.SuspendLayout();
            pnlStudent.SuspendLayout();
            tlpStudent.SuspendLayout();
            pnlAdmin.SuspendLayout();
            tlpAdmin.SuspendLayout();
            flpActions.SuspendLayout();
            SuspendLayout();
            // 
            // flpRole
            // 
            flpRole.AutoSize = true;
            flpRole.Controls.Add(rdoStudent);
            flpRole.Controls.Add(rdoAdmin);
            flpRole.Location = new Point(15, 217);
            flpRole.Name = "flpRole";
            flpRole.Size = new Size(215, 30);
            flpRole.TabIndex = 2;
            flpRole.WrapContents = false;
            // 
            // rdoStudent
            // 
            rdoStudent.AutoSize = true;
            rdoStudent.CausesValidation = false;
            rdoStudent.Checked = true;
            rdoStudent.Location = new Point(3, 3);
            rdoStudent.Name = "rdoStudent";
            rdoStudent.Size = new Size(89, 24);
            rdoStudent.TabIndex = 0;
            rdoStudent.TabStop = true;
            rdoStudent.Text = "Sinh viên";
            rdoStudent.UseVisualStyleBackColor = true;
            rdoStudent.CheckedChanged += rdoRole_CheckedChanged;
            // 
            // rdoAdmin
            // 
            rdoAdmin.AutoSize = true;
            rdoAdmin.CausesValidation = false;
            rdoAdmin.Location = new Point(98, 3);
            rdoAdmin.Name = "rdoAdmin";
            rdoAdmin.Size = new Size(114, 24);
            rdoAdmin.TabIndex = 1;
            rdoAdmin.Text = "Quản trị viên";
            rdoAdmin.UseVisualStyleBackColor = true;
            rdoAdmin.CheckedChanged += rdoRole_CheckedChanged;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(363, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(247, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // tlpInfo
            // 
            tlpInfo.AutoSize = true;
            tlpInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpInfo.ColumnCount = 2;
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInfo.Controls.Add(lblFullName, 0, 0);
            tlpInfo.Controls.Add(txtFullName, 1, 0);
            tlpInfo.Controls.Add(lblPassword, 0, 1);
            tlpInfo.Controls.Add(txtPassword, 1, 1);
            tlpInfo.Controls.Add(lblCccd, 0, 2);
            tlpInfo.Controls.Add(txtCccd, 1, 2);
            tlpInfo.Controls.Add(lblPhone, 0, 3);
            tlpInfo.Controls.Add(lblEmail, 0, 4);
            tlpInfo.Controls.Add(txtEmail, 1, 4);
            tlpInfo.Controls.Add(txtPhone, 1, 3);
            tlpInfo.Dock = DockStyle.Top;
            tlpInfo.Location = new Point(15, 46);
            tlpInfo.Name = "tlpInfo";
            tlpInfo.RowCount = 5;
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.Size = new Size(944, 165);
            tlpInfo.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(0, 6);
            lblFullName.Margin = new Padding(0, 6, 8, 6);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(73, 20);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Họ và tên";
            // 
            // txtFullName
            // 
            txtFullName.Dock = DockStyle.Fill;
            txtFullName.Location = new Point(472, 3);
            txtFullName.Margin = new Padding(0, 3, 0, 3);
            txtFullName.MaxLength = 100;
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Vd: Đặng Thị Linh";
            txtFullName.Size = new Size(472, 27);
            txtFullName.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(0, 39);
            lblPassword.Margin = new Padding(0, 6, 8, 6);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(472, 36);
            txtPassword.Margin = new Padding(0, 3, 0, 3);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Nhập mật khẩu mạnh";
            txtPassword.Size = new Size(472, 27);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblCccd
            // 
            lblCccd.AutoSize = true;
            lblCccd.Location = new Point(0, 72);
            lblCccd.Margin = new Padding(0, 6, 8, 6);
            lblCccd.Name = "lblCccd";
            lblCccd.Size = new Size(47, 20);
            lblCccd.TabIndex = 4;
            lblCccd.Text = "CCCD";
            // 
            // txtCccd
            // 
            txtCccd.Dock = DockStyle.Fill;
            txtCccd.Location = new Point(472, 69);
            txtCccd.Margin = new Padding(0, 3, 0, 3);
            txtCccd.MaxLength = 12;
            txtCccd.Name = "txtCccd";
            txtCccd.PlaceholderText = "Nhập 12 chữ số ...";
            txtCccd.Size = new Size(472, 27);
            txtCccd.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(0, 105);
            lblPhone.Margin = new Padding(0, 6, 8, 6);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(36, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "SĐT";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(0, 138);
            lblEmail.Margin = new Padding(0, 6, 8, 6);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(472, 135);
            txtEmail.Margin = new Padding(0, 3, 0, 3);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Vd: danglinhloveu@gmail.com";
            txtEmail.Size = new Size(472, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Location = new Point(472, 102);
            txtPhone.Margin = new Padding(0, 3, 0, 3);
            txtPhone.MaxLength = 20;
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "+84xxxxxxxxx hoặc 0xxxxxxxxx";
            txtPhone.Size = new Size(472, 27);
            txtPhone.TabIndex = 3;
            // 
            // tlpRoot
            // 
            tlpRoot.AutoSize = true;
            tlpRoot.ColumnCount = 1;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.Controls.Add(tlpInfo, 0, 1);
            tlpRoot.Controls.Add(lblTitle, 0, 0);
            tlpRoot.Controls.Add(flpRole, 0, 3);
            tlpRoot.Controls.Add(tlpRoleBlock, 0, 4);
            tlpRoot.Controls.Add(flpActions, 0, 5);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(12);
            tlpRoot.RowCount = 7;
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle());
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpRoot.Size = new Size(974, 489);
            tlpRoot.TabIndex = 0;
            // 
            // tlpRoleBlock
            // 
            tlpRoleBlock.AutoSize = true;
            tlpRoleBlock.ColumnCount = 1;
            tlpRoleBlock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoleBlock.Controls.Add(pnlStudent, 0, 0);
            tlpRoleBlock.Controls.Add(pnlAdmin, 0, 1);
            tlpRoleBlock.Dock = DockStyle.Top;
            tlpRoleBlock.Location = new Point(15, 253);
            tlpRoleBlock.Name = "tlpRoleBlock";
            tlpRoleBlock.RowCount = 2;
            tlpRoleBlock.RowStyles.Add(new RowStyle());
            tlpRoleBlock.RowStyles.Add(new RowStyle());
            tlpRoleBlock.Size = new Size(944, 127);
            tlpRoleBlock.TabIndex = 0;
            // 
            // pnlStudent
            // 
            pnlStudent.AutoSize = true;
            pnlStudent.Controls.Add(tlpStudent);
            pnlStudent.Dock = DockStyle.Top;
            pnlStudent.Location = new Point(3, 3);
            pnlStudent.Name = "pnlStudent";
            pnlStudent.Size = new Size(938, 59);
            pnlStudent.TabIndex = 0;
            // 
            // tlpStudent
            // 
            tlpStudent.AutoSize = true;
            tlpStudent.ColumnCount = 2;
            tlpStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tlpStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81F));
            tlpStudent.Controls.Add(lblStudentCode, 0, 0);
            tlpStudent.Controls.Add(txtStudentCode, 1, 0);
            tlpStudent.Location = new Point(0, 9);
            tlpStudent.Name = "tlpStudent";
            tlpStudent.RowCount = 1;
            tlpStudent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpStudent.Size = new Size(838, 47);
            tlpStudent.TabIndex = 0;
            // 
            // lblStudentCode
            // 
            lblStudentCode.AutoSize = true;
            lblStudentCode.Location = new Point(3, 0);
            lblStudentCode.Name = "lblStudentCode";
            lblStudentCode.Size = new Size(91, 20);
            lblStudentCode.TabIndex = 0;
            lblStudentCode.Text = "Mã sinh viên";
            // 
            // txtStudentCode
            // 
            txtStudentCode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStudentCode.Location = new Point(159, 10);
            txtStudentCode.Margin = new Padding(0, 3, 0, 3);
            txtStudentCode.Name = "txtStudentCode";
            txtStudentCode.PlaceholderText = "MSV do trường cấp";
            txtStudentCode.Size = new Size(679, 27);
            txtStudentCode.TabIndex = 0;
            // 
            // pnlAdmin
            // 
            pnlAdmin.AutoSize = true;
            pnlAdmin.Controls.Add(tlpAdmin);
            pnlAdmin.Location = new Point(3, 68);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(853, 56);
            pnlAdmin.TabIndex = 1;
            pnlAdmin.Visible = false;
            // 
            // tlpAdmin
            // 
            tlpAdmin.AutoSize = true;
            tlpAdmin.ColumnCount = 2;
            tlpAdmin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tlpAdmin.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81F));
            tlpAdmin.Controls.Add(txtPrivCode, 1, 0);
            tlpAdmin.Controls.Add(lblPrivCode, 0, 0);
            tlpAdmin.Location = new Point(-3, 3);
            tlpAdmin.Name = "tlpAdmin";
            tlpAdmin.RowCount = 1;
            tlpAdmin.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpAdmin.Size = new Size(853, 50);
            tlpAdmin.TabIndex = 0;
            tlpAdmin.Visible = false;
            // 
            // txtPrivCode
            // 
            txtPrivCode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPrivCode.Location = new Point(162, 11);
            txtPrivCode.Margin = new Padding(0, 3, 0, 3);
            txtPrivCode.Name = "txtPrivCode";
            txtPrivCode.PlaceholderText = "Mã cấp hệ thống";
            txtPrivCode.Size = new Size(691, 27);
            txtPrivCode.TabIndex = 0;
            // 
            // lblPrivCode
            // 
            lblPrivCode.AllowDrop = true;
            lblPrivCode.AutoSize = true;
            lblPrivCode.Location = new Point(3, 0);
            lblPrivCode.Name = "lblPrivCode";
            lblPrivCode.Size = new Size(102, 20);
            lblPrivCode.TabIndex = 0;
            lblPrivCode.Text = "Mã đặc quyền";
            // 
            // flpActions
            // 
            flpActions.AutoSize = true;
            flpActions.Controls.Add(btnRegister);
            flpActions.Controls.Add(lnkToLogin);
            flpActions.Controls.Add(lnkToStudent);
            flpActions.Dock = DockStyle.Top;
            flpActions.Location = new Point(15, 386);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(944, 40);
            flpActions.TabIndex = 3;
            flpActions.WrapContents = false;
            // 
            // btnRegister
            // 
            btnRegister.AutoSize = true;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.Location = new Point(3, 3);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(177, 33);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Đăng Ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lnkToLogin
            // 
            lnkToLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lnkToLogin.AutoSize = true;
            lnkToLogin.CausesValidation = false;
            lnkToLogin.Location = new Point(186, 0);
            lnkToLogin.Name = "lnkToLogin";
            lnkToLogin.Size = new Size(205, 40);
            lnkToLogin.TabIndex = 0;
            lnkToLogin.TabStop = true;
            lnkToLogin.Text = "Đã có tài khoản Quản lý viên?\r\n\r\n";
            lnkToLogin.LinkClicked += lnkToLogin_LinkClicked;
            // 
            // lnkToStudent
            // 
            lnkToStudent.AutoSize = true;
            lnkToStudent.Location = new Point(397, 0);
            lnkToStudent.Name = "lnkToStudent";
            lnkToStudent.Size = new Size(183, 20);
            lnkToStudent.TabIndex = 2;
            lnkToStudent.TabStop = true;
            lnkToStudent.Text = "Đã có tài khoản Sinh viên?";
            lnkToStudent.LinkClicked += lnkToStudent_LinkClicked;
            // 
            // FrmRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 489);
            Controls.Add(tlpRoot);
            Name = "FrmRegister";
            Text = "FrmRegister";
            flpRole.ResumeLayout(false);
            flpRole.PerformLayout();
            tlpInfo.ResumeLayout(false);
            tlpInfo.PerformLayout();
            tlpRoot.ResumeLayout(false);
            tlpRoot.PerformLayout();
            tlpRoleBlock.ResumeLayout(false);
            tlpRoleBlock.PerformLayout();
            pnlStudent.ResumeLayout(false);
            pnlStudent.PerformLayout();
            tlpStudent.ResumeLayout(false);
            tlpStudent.PerformLayout();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            tlpAdmin.ResumeLayout(false);
            tlpAdmin.PerformLayout();
            flpActions.ResumeLayout(false);
            flpActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpRole;
        private RadioButton rdoStudent;
        private RadioButton rdoAdmin;
        private Label lblTitle;
        private TableLayoutPanel tlpInfo;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblCccd;
        private TextBox txtCccd;
        private Label lblPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TableLayoutPanel tlpRoot;
        private TableLayoutPanel tlpRoleBlock;
        private Panel pnlStudent;
        private TableLayoutPanel tlpStudent;
        private Label lblStudentCode;
        private TextBox txtStudentCode;
        private Panel pnlAdmin;
        private TableLayoutPanel tlpAdmin;
        private Label lblPrivCode;
        private TextBox txtPrivCode;
        private FlowLayoutPanel flpActions;
        private Button btnRegister;
        private LinkLabel lnkToLogin;
        private LinkLabel lnkToStudent;
    }
}
