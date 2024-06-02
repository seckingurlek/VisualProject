using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduConnect
{
    public partial class AcademicStaffProfilePage : Form
    {
        public AcademicStaffProfilePage()
        {
            InitializeComponent();
        }

        private void btnStudentMarks_Click(object sender, EventArgs e)
        {
            AddStudentMarksPage addStudentMarksPage= new AddStudentMarksPage();
            addStudentMarksPage.Show();
            this.Hide();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentProfilePage studentProfilePage = new StudentProfilePage();
            studentProfilePage.Show();
            this.Hide();
        }

        private void btnAcademicStaff_Click(object sender, EventArgs e)
        {
            AcademicStaffProfilePage academicStaffProfilePage = new AcademicStaffProfilePage();
            academicStaffProfilePage.Show();
            this.Hide();
        }

        private void btnCanteen_Click(object sender, EventArgs e)
        {
            CanteenPage canteenPage = new CanteenPage();
            canteenPage.Show();
            this.Hide();
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            ParentsProfilePage parentsProfilePage = new ParentsProfilePage();
            parentsProfilePage.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }
    }
}
