namespace StudentCourseManagement.Presentation.Forms.Manage
{
    partial class FrmMajorManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            comboBox1 = new ComboBox();
            inputKhoa = new Label();
            groupBox1 = new GroupBox();
            lblMajorName = new Label();
            lblFacultyName = new Label();
            listNganh = new ListBox();
            addBtn = new Button();
            editBtn = new Button();
            delBtn = new Button();
            refreshBtn = new Button();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 30);
            label1.Name = "label1";
            label1.Size = new Size(190, 32);
            label1.TabIndex = 0;
            label1.Text = "Quản lý ngành";
            // 
            // inputKhoa
            // 
            inputKhoa.AutoSize = true;
            inputKhoa.Location = new Point(50, 100);
            inputKhoa.Name = "inputKhoa";
            inputKhoa.Size = new Size(82, 20);
            inputKhoa.TabIndex = 3;
            inputKhoa.Text = "Chọn khoa:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(150, 97);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(450, 28);
            comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 145);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 9;
            label2.Text = "Danh sách ngành:";
            // 
            // listNganh
            // 
            listNganh.FormattingEnabled = true;
            listNganh.ItemHeight = 20;
            listNganh.Location = new Point(50, 170);
            listNganh.Name = "listNganh";
            listNganh.Size = new Size(350, 204);
            listNganh.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMajorName);
            groupBox1.Controls.Add(lblFacultyName);
            groupBox1.Location = new Point(420, 170);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 120);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin ngành";
            // 
            // lblFacultyName
            // 
            lblFacultyName.AutoSize = true;
            lblFacultyName.Location = new Point(20, 35);
            lblFacultyName.Name = "lblFacultyName";
            lblFacultyName.Size = new Size(60, 20);
            lblFacultyName.TabIndex = 0;
            lblFacultyName.Text = "Khoa: -";
            // 
            // lblMajorName
            // 
            lblMajorName.AutoSize = true;
            lblMajorName.Location = new Point(20, 70);
            lblMajorName.Name = "lblMajorName";
            lblMajorName.Size = new Size(70, 20);
            lblMajorName.TabIndex = 1;
            lblMajorName.Text = "Ngành: -";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(50, 400);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(120, 38);
            addBtn.TabIndex = 5;
            addBtn.Text = "Thêm ngành";
            addBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(200, 400);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(120, 38);
            editBtn.TabIndex = 6;
            editBtn.Text = "Sửa ngành";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // delBtn
            // 
            delBtn.Location = new Point(350, 400);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(120, 38);
            delBtn.TabIndex = 7;
            delBtn.Text = "Xóa ngành";
            delBtn.UseVisualStyleBackColor = true;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(500, 400);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(120, 38);
            refreshBtn.TabIndex = 8;
            refreshBtn.Text = "Làm mới";
            refreshBtn.UseVisualStyleBackColor = true;
            // 
            // FrmMajorManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(label2);
            Controls.Add(listNganh);
            Controls.Add(refreshBtn);
            Controls.Add(delBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(groupBox1);
            Controls.Add(inputKhoa);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "FrmMajorManagement";
            Text = "Quản lý ngành";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label inputKhoa;
        private GroupBox groupBox1;
        private Label lblFacultyName;
        private Label lblMajorName;
        private ListBox listNganh;
        private Button addBtn;
        private Button editBtn;
        private Button delBtn;
        private Button refreshBtn;
        private Label label2;
    }
}