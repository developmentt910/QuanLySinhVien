namespace StudentCourseManagement.Presentation.Forms.Manage
{
    partial class FrmSpecManage
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
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            listSpec = new ListBox();
            groupBoxSpec = new GroupBox();
            addBtn = new Button();
            editBtn = new Button();
            delBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 86);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 0;
            label1.Text = "Chọn khoa: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 135);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Chọn ngành";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(279, 22);
            label3.Name = "label3";
            label3.Size = new Size(331, 41);
            label3.TabIndex = 2;
            label3.Text = "Quản lý chuyên ngành";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(246, 78);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(275, 28);
            comboBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(246, 132);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(275, 28);
            comboBox2.TabIndex = 4;
            // 
            // listSpec
            // 
            listSpec.FormattingEnabled = true;
            listSpec.Location = new Point(28, 178);
            listSpec.Name = "listSpec";
            listSpec.Size = new Size(264, 264);
            listSpec.TabIndex = 5;
            // 
            // groupBoxSpec
            // 
            groupBoxSpec.Location = new Point(359, 178);
            groupBoxSpec.Name = "groupBoxSpec";
            groupBoxSpec.Size = new Size(392, 128);
            groupBoxSpec.TabIndex = 6;
            groupBoxSpec.TabStop = false;
            groupBoxSpec.Text = "Thông tin chi tiết:";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(328, 347);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(100, 48);
            addBtn.TabIndex = 7;
            addBtn.Text = "Thêm ";
            addBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(509, 347);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(94, 48);
            editBtn.TabIndex = 8;
            editBtn.Text = "Sửa";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // delBtn
            // 
            delBtn.Location = new Point(676, 347);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(94, 48);
            delBtn.TabIndex = 10;
            delBtn.Text = "Xóa";
            delBtn.UseVisualStyleBackColor = true;
            // 
            // FrmSpecManage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 475);
            Controls.Add(delBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(groupBoxSpec);
            Controls.Add(listSpec);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmSpecManage";
            Text = "FrmSpecManage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ListBox listSpec;
        private GroupBox groupBoxSpec;
        private Button addBtn;
        private Button editBtn;
        private Button delBtn;
    }
}