using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentCourseManagement.Presentation.Forms.Student;

namespace StudentCourseManagement.Presentation.Forms.Admin
{
    public partial class FrmAdminDashboard : Form
    {
        public FrmAdminDashboard()
        {
            InitializeComponent();
        }

        private void quảnLýThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentManagement frm = new FrmStudentManagement();
            frm.ShowDialog();
        }

        

       




    }
}