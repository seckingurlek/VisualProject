using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduConnect
{
    public partial class ParentsProfilePage : Form
    {

        private SqlConnection connect =
            new SqlConnection
                ("Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;");

        public ParentsProfilePage()
        {
            InitializeComponent();
            ParentsInfoLoader();
        }
        // 24-28 LoadParentsInfo --> ParentsInfoLoader

        private void ParentsInfoLoader()
        {
            UserSession session = UserSession.Instance;
            lbl2Name.Text = session.FirstName;
            lbl2Surname.Text = session.LastName;
            lbl2Email.Text = session.Email;
            lbl2PhoneNumber.Text = session.PhoneNumber;
            lbl2Occupation.Text = session.Occupation;
        }

        private void btnAddBalance_Click(object sender, EventArgs e)
        {
            AddBalancePage addBalancePage = new AddBalancePage();
            addBalancePage.Show();
            this.Hide();
        }

        private void btnRestrict_Click(object sender, EventArgs e)
        {
            RestrictPage restrictPage = new RestrictPage();
            restrictPage.Show();
            this.Hide();
        }

        private void btnStudentResults_Click(object sender, EventArgs e)
        {
            ExamResultsPage examResultsPage = new ExamResultsPage();
            examResultsPage.Show();
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

        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void MainBackground_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
