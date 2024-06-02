using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlDataAdapter = Microsoft.Data.SqlClient.SqlDataAdapter;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace EduConnect
{
    public partial class CanteenPage : Form
    {
        public CanteenPage()
        {
            InitializeComponent();

        }

        private SqlConnection connectionString =
           new SqlConnection(
               "Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;TrustServerCertificate=True;");

      

        private void MainBackground_Click(object sender, EventArgs e)
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

        private void CanteenPage_Load(object sender, EventArgs e)
        {
            try
            {
                // Tüm öğe verilerini almak için sorguyu güncelliyoruz
                string query = "SELECT * FROM CafeteriaItems";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connectionString);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cafeteria items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
