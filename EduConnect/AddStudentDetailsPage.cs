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
    public partial class AddStudentDetailsPage : Form
    {
        
        private string connectionString =
               @"Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;";
        public AddStudentDetailsPage()
        {
            InitializeComponent();
            StudentLoader();
            ParentLoader();
            ClassLoader();
            
        }
        private void AddStudentDetails_Load(object sender, EventArgs e)
        {

            StudentLoader();
            ParentLoader();
            ClassLoader();
        }

        // LoadStudents --  StudentLoader  36-30-22
        // LoadParents -- ParentLoader 31- 73 -23
        // LoadClass -- ClassLoader  24-32-91
        private void StudentLoader()
        {
            string query = "SELECT StudentID, FirstName, LastName FROM Students";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    MessageBox.Show("Connection Opened Successfully"); // Bağlantının açıldığını kontrol etmek için
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string studentName = $"{reader["FirstName"]} {reader["LastName"]}";
                        comboBoxSelectStudent.Items.Add(new ComboBoxItem(studentName, (int)reader["StudentID"]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(query, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string studentName = $"{reader["FirstName"]} {reader["LastName"]}";
            //        comboBoxSelectStudent.Items.Add(new ComboBoxItem(studentName, (int)reader["StudentID"]));
            //    }
            //}
        }
        private void ParentLoader()
        {
            string query = "SELECT ParentID, FirstName, LastName FROM Parents";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string parentName = $"{reader["FirstName"]} {reader["LastName"]}";
                    comboBoxParent.Items.Add(new ComboBoxItem(parentName, (int)reader["ParentID"]));
                }
            }
        }

        private void ClassLoader()
        {
            string query = "SELECT ClassID,ClassName FROM Classes";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string className = $"{reader["ClassName"]}";
                    comboBoxClass.Items.Add(new ComboBoxItem(className, (int)reader["ClassID"]));
                }
            }
        }

        private void LoadStudentDetails(int studentId)
        {
            string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
            MessageBox.Show("Methodun başı çalışıyo");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    tbName.Text = reader["FirstName"] as string ?? string.Empty;
                   // comboBoxParent.Text=reader["parent"] as string ?? string.Empty;

                   tbSurname.Text = reader["LastName"] as string ?? string.Empty;
                    tbBirthDate.Text = reader["DateOfBirth"] as string ?? string.Empty;

                      tbBalance.Text = reader["Balance"] as string ?? string.Empty;
                    //dateTimePickerDOB.Value = DateTime.Parse(reader["DateOfBirth"].ToString());
                    //textBoxAddress.Text = reader["Address"] as string ?? string.Empty;

                    object parentIdObject = reader["ParentID"];
                    int parentId = parentIdObject != DBNull.Value ? (int)parentIdObject : 0;

                    if (parentId != 0) // ParentID değeri atanmışsa
                    {
                        // ComboBox'ta ParentID'ye sahip öğeyi seç
                        comboBoxParent.SelectedItem = comboBoxParent.Items
                            .OfType<ComboBoxItem>()
                            .FirstOrDefault(i => i.Value == parentId);
                    }
                    else
                    {
                        // ParentID atanmamışsa, comboBoxParents'ı boşalt
                        comboBoxParent.SelectedItem = null;
                    }
                    object classIdObject = reader["ClassID"];
                    int classId = classIdObject != DBNull.Value ? (int)classIdObject : 0;

                    if (classId != 0)
                    {

                        comboBoxClass.SelectedItem = comboBoxClass.Items
                            .OfType<ComboBoxItem>()
                            .FirstOrDefault(i => i.Value == classId);
                    }
                    else
                    {

                        comboBoxClass.SelectedItem = null;
                    }
                    decimal balance = reader["Balance"] != DBNull.Value ? (decimal)reader["Balance"] : 0;
                    tbBalance.Text = balance.ToString();
                    // textBoxClassID.Text = reader["ClassID"] as string ?? string.Empty;
                    //textBoxBalance.Text = reader["Balance"] as string ?? string.Empty;
                }
                else
                {
                    tbName.Text = string.Empty;
                    tbSurname.Text = string.Empty;
                    lblBirthDate.Text = string.Empty;
                    comboBoxParent.SelectedItem = null;
                    comboBoxClass.Text = string.Empty;
                   tbBalance.Text = string.Empty;
                }
            }
        }
        private void UpdateStudentDetails(int studentId)
        {
            int parentId = 0;
            if (comboBoxParent.SelectedItem != null)
            {
                ComboBoxItem selectedParent = (ComboBoxItem)comboBoxParent.SelectedItem;
                parentId = selectedParent.Value;
            }
            int classId = 0;
            if (comboBoxClass.SelectedItem != null)
            {
                ComboBoxItem selectedClass = (ComboBoxItem)comboBoxClass.SelectedItem;
                classId = selectedClass.Value;
            }
            decimal balance = 0;
            if (!string.IsNullOrWhiteSpace(tbBalance.Text))
            {
                balance = decimal.Parse(tbBalance.Text);
            }

            string query = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, ParentID = @ParentID, ClassID = @ClassID, Balance = @Balance WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentId);
                command.Parameters.AddWithValue("@FirstName", tbName.Text);
                command.Parameters.AddWithValue("@LastName", tbSurname.Text );
                command.Parameters.AddWithValue("@DateOfBirth", tbBirthDate.Text);
                command.Parameters.AddWithValue("@ParentID", parentId);
                command.Parameters.AddWithValue("@ClassID", classId);
                command.Parameters.AddWithValue("@Balance", balance);

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Student details updated successfully.");
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
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxSelectStudent.SelectedItem;
            int studentId = selectedItem.Value;
            UpdateStudentDetails(studentId);
            MainBackground.Controls.Clear();
            AdminPage admin = new AdminPage();
            //MainBackground.Controls.Add(admin);
        }

        private void comboBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxSelectStudent.SelectedItem;
            int studentId = selectedItem.Value;
            LoadStudentDetails(studentId);
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

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void lblReligion_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxSelectStudent.SelectedItem;
            int studentId = selectedItem.Value;
            LoadStudentDetails(studentId);
        }

        private void lblClass_Click(object sender, EventArgs e)
        {

        }
    }
}
