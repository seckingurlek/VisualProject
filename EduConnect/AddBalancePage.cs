using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EduConnect
{
    public partial class AddBalancePage : Form
    {
        private string connectionString = @"Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True";
        public AddBalancePage()
        {
            InitializeComponent();

            LoadParentInfo();
            
           
        }
        private void LoadParentInfo()
        {
            UserSession session = UserSession.Instance;
            int parentID = session.UserId; // Giriş yapan parent'ın ID'sini al
            MessageBox.Show(session.FirstName + session.LastName + session.Email );

            if (parentID != 0) // Parent ID 0 değilse devam et
            {
                string studentName;
                decimal studentBalance;

                // Öğrencinin adını ve bakiyesini al
                GetStudentInfo(parentID, out studentName, out studentBalance);

                if (studentName != null) // Öğrenci adı null değilse devam et
                {
                    tbName.Text = studentName; // Öğrenci adını tbName kontrolüne yazdır
                    tbAmount2.Text = studentBalance.ToString();              // Öğrencinin bakiyesini kullanmak isterseniz burada kullanabilirsiniz
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı."); // Öğrenci adı bulunamadıysa hata mesajı göster
                }
            }
            else
            {
                MessageBox.Show("ParentID bulunamadı."); // ParentID bulunamadıysa hata mesajı göster
            }
        }

        private void GetStudentInfo(int parentID, out string studentName, out decimal studentBalance)
        {
            studentName = null;
            studentBalance = 0;

            // Veritabanından öğrencinin adını ve bakiyesini almak için gerekli sorguyu yapın
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT s.FirstName, s.Balance FROM Students s WHERE s.ParentID = @ParentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ParentID", parentID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        studentName = reader["FirstName"].ToString();
                        studentBalance = (decimal)reader["Balance"];
                    }
                    reader.Close();
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btAddBalance_Click(object sender, EventArgs e)
        {

        }

        private void tbName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainBackground_Click(object sender, EventArgs e)
        {

        }
    }
}
