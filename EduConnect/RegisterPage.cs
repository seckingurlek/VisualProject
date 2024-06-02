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
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            string role = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;"))
            {
                connect.Open();
                SqlTransaction transaction = connect.BeginTransaction();
                SqlCommand command = connect.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText =
                        "INSERT INTO Users (FirstName, LastName, Email, Password, Roles) OUTPUT INSERTED.UserID VALUES (@FirstName, @LastName, @Email, @Password, @Roles)";
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Roles", role);

                    int userId = (int)command.ExecuteScalar();

                    if (role == "Parent")
                    {
                        // Show ParentSignUpForm to select student
                        command.CommandText = "INSERT INTO Parents (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
                        command.ExecuteNonQuery();
                    }
                    else if (role == "Student")
                    {
                        // Insert into Students table
                        command.CommandText = "INSERT INTO Students (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
                        command.ExecuteNonQuery();
                    }
                    else if (role == "Teacher")
                    {
                        // Insert into Teachers table
                        command.CommandText = "INSERT INTO Teachers (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
                        command.ExecuteNonQuery();
                    }
                    else if (role == "Admin")
                    {
                        // Admin role, no additional tables needed
                    }

                    transaction.Commit();
                    MessageBox.Show("User registered successfully!");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }




            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
