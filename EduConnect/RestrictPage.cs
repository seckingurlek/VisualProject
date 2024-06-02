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
    public partial class RestrictPage : Form
    {
        public RestrictPage()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void btnStudents_Click_1(object sender, EventArgs e)
        {
            StudentProfilePage studentProfilePage = new StudentProfilePage();
            studentProfilePage.Show();
            this.Hide();
        }

        private void btnAcademicStaff_Click_1(object sender, EventArgs e)
        {
            AcademicStaffProfilePage academicStaffProfilePage = new AcademicStaffProfilePage();
            academicStaffProfilePage.Show();
            this.Hide();
        }

        private void btnCanteen_Click_1(object sender, EventArgs e)
        {
            CanteenPage canteenPage = new CanteenPage();
            canteenPage.Show();
            this.Hide();
        }

        private void btnParent_Click_1(object sender, EventArgs e)
        {
            ParentsProfilePage parentsProfilePage = new ParentsProfilePage();
            parentsProfilePage.Show();
            this.Hide();
        }
    }
}
