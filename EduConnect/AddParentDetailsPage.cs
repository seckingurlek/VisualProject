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
using static EduConnect.AddStudentDetailsPage;

namespace EduConnect
{
    public partial class AddParentDetailsPage : Form
    {
        private string connectionString = "Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;";
        public AddParentDetailsPage()
        {
            InitializeComponent();
            ParentsLoaderFunc();
        }
        //22-24 LoadParents-- ParentsLoaderFunc
        private void ParentsLoaderFunc()
        {
            string query = "SELECT ParentID, FirstName, LastName FROM Parents";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string studentName = $"{reader["FirstName"]} {reader["LastName"]}";
                    comboBox1.Items.Add(new ComboBoxItem(studentName, (int)reader["ParentID"]));
                }
            }
        }
        // 40-156  LoadParentDetails ---  ParentDetailsLoader
        private void ParentDetailsLoader(int parentId)
        {
            string query = "SELECT * FROM Parents WHERE ParentID = @ParentID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParentID", parentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tbName.Text = reader["FirstName"] as string ?? string.Empty;
                    ;
                    tbSurname.Text = reader["LastName"] as string ?? string.Empty;
                    tbOccupation.Text = reader["Occupation"] as string ?? string.Empty;
                    tbPhoneNumber.Text = reader["PhoneNumber"] as string ?? string.Empty;
                    tbEmail.Text = reader["email"] as string ?? string.Empty;

                }
                else
                {
                    tbName.Text = string.Empty;
                    tbSurname.Text = string.Empty;
                    tbOccupation.Text = string.Empty;
                    tbPhoneNumber.Text = string.Empty;
                }
            }
        }
        // 70- 112    UpdateParentDetails--- ParentDetailsUpdater
        private void ParentDetailsUpdater(int parentId)
        {
            string query =
                "UPDATE Parents SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Occupation = @Occupation WHERE ParentID = @ParentID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParentID", parentId);
                command.Parameters.AddWithValue("@FirstName", tbName.Text);
                command.Parameters.AddWithValue("@LastName", tbSurname.Text);
                command.Parameters.AddWithValue("@PhoneNumber", tbPhoneNumber.Text);
                command.Parameters.AddWithValue("@Occupation", tbOccupation.Text);

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Parent details updated successfull. ");

            }
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            ComboBoxItem selectedItem = (ComboBoxItem)comboBox1.SelectedItem;
            int parentId = selectedItem.Value;
            ParentDetailsUpdater(parentId);
            MainBackground.Controls.Clear();
            // Admin admin = new Admin();
           // panel1.Controls.Add(admin);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox1.SelectedItem;
            int studentId = selectedItem.Value;
            ParentDetailsLoader(studentId);
        }
    }
}
