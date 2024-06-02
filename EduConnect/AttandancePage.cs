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
    public partial class AttandancePage : Form
    {
        private string connectionString =
           @"Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True";

        public AttandancePage()
        {
            InitializeComponent();
            StudentInfoLoader();
        }
        // loadstudentınfo <-- studentınfoloader 25-22
        private void StudentInfoLoader()
        {
            //UserSession session = UserSession.Instance;

            //labelFirstName.Text = session.FirstName;
            //labelLastName.Text = session.LastName;

        }
        private int GetStudentID(string firstName, string lastName)
        {
            int studentID = -1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentID FROM Students WHERE FirstName = @FirstName AND LastName = @LastName";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    studentID = Convert.ToInt32(result);
                }
            }
            return studentID;
        }
        private void btnQR_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            {
                UserSession session = UserSession.Instance;
                int studentID = GetStudentID(session.FirstName, session.LastName);

                if (studentID != -1)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Attendance (StudentID, Date, EntryTime) VALUES (@StudentID, GETDATE(), GETDATE())";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Welcome");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSession session = UserSession.Instance;
            int studentID = GetStudentID(session.FirstName, session.LastName);

            if (studentID != -1)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Attendance SET ExitTime = GETDATE() WHERE StudentID = @StudentID AND Date = CAST(GETDATE() AS DATE)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Goodbye");
                }
            }
        }

        private void btnNFC_Click(object sender, EventArgs e)
        {

        }
    }
}
