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
    public partial class AddAcademicStaffDetailsPage : Form
    {
        private string connectionString = "Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;";
        public AddAcademicStaffDetailsPage()
        {
            InitializeComponent();
            TeacherLoader();
        }

        //20-24 loadteacher <-- TeacherLoader
        private void TeacherLoader()
        {
            string query = "SELECT TeacherID, FirstName, LastName FROM Teachers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string teacherName = $"{reader["FirstName"]} {reader["LastName"]}";
                    object teacherIdObject = reader["TeacherID"];
                    int teacherId = teacherIdObject != DBNull.Value ? (int)teacherIdObject : 0;
                    comboBoxTeachers.Items.Add(new ComboBoxItem(teacherName, teacherId));
                }
            }
        }

        // <-- loadteacherdetails teacherloaderdetails 44-145
        private void TeacherLoaderDetails(int teacherId)
        {
            string query = "SELECT * FROM Teachers WHERE TeacherID = @TeacherID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherID", teacherId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tbFirstName.Text = reader["FirstName"] as string ?? string.Empty; ;
                    tbSurname.Text = reader["LastName"] as string ?? string.Empty;
                    tbSubject.Text = reader["Subject"] as string ?? string.Empty; ;
                    tbPhoneNumber.Text = reader["PhoneNumber"] as string ?? string.Empty;
                }
                else
                {
                    tbFirstName.Text = string.Empty;
                    tbSurname.Text = string.Empty;
                    tbPhoneNumber.Text = string.Empty;
                    tbSubject.Text = string.Empty;

                }
            }
        }

        // <-- 72 95 updateteacherdetails -teacherupdaterdetails
        private void TeacherUpdaterDetails(int teacherId)
        {
            string query = "UPDATE Teachers SET FirstName = @FirstName, LastName = @LastName, Subject = @Subject, PhoneNumber = @PhoneNumber WHERE TeacherID = @TeacherID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherID", teacherId);
                command.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                command.Parameters.AddWithValue("@LastName", tbSurname.Text);
                command.Parameters.AddWithValue("@Subject", tbSubject.Text);
                command.Parameters.AddWithValue("@PhoneNumber", tbPhoneNumber.Text);

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Teacher details updated successfully");
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxTeachers.SelectedItem;
            int studentId = selectedItem.Value;
            TeacherUpdaterDetails(studentId);
            //panel1.Controls.Clear();
            //Admin admin = new Admin();
            //panel1.Controls.Add(admin);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxTeachers.SelectedItem;
            int teacherId = selectedItem.Value;
            TeacherLoaderDetails(teacherId);
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
