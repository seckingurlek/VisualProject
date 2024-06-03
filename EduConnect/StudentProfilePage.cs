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
    public partial class StudentProfilePage : Form
    {
        public StudentProfilePage()
        {
            InitializeComponent();
            LoadStudentInfo();
        }

        private void btnExamResults_Click(object sender, EventArgs e)
        {
            ExamResultsPage examResultsPage = new ExamResultsPage();
            examResultsPage.Show();
            this.Hide();
        }

        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            TimeTablePage timeTablePage = new TimeTablePage();
            timeTablePage.Show();
            this.Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            AttandancePage attandancePage = new AttandancePage();
            attandancePage.Show();
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

        private void LoadStudentInfo()
        {
            UserSession session = UserSession.Instance;

            lbl2Name.Text = session.FirstName;
            lbl2Surname.Text = session.LastName;
            lbl2Email.Text = session.Email;
            lbl2Balance.Text = session.Balance.ToString("C");
          //  labelParentName.Text = session.ParentName;
            lbl2BirtDAte.Text = session.DateOfBirth;
            lbl2Class.Text = session.StudentClass;

        }

        private void txtBirthDate_Click(object sender, EventArgs e)
        {

        }

        private void txtReligion_Click(object sender, EventArgs e)
        {

        }

        private void lblGrade_Click(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StudentProfilePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CateriaPage cateriaPage = new CateriaPage();    
            cateriaPage.Show();
            this.Hide();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lbl2Surname_Click(object sender, EventArgs e)
        {

        }
    }
}
