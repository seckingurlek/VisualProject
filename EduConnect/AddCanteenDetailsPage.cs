using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace EduConnect
{
    public partial class AddCanteenDetailsPage : Form
    {
        private string connectionString = "Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;TrustServerCertificate=True";
        public AddCanteenDetailsPage()
        {
            InitializeComponent();
            LoadItems();
        }

        private void LoadItems()
        {
            listBox1.Items.Clear();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ItemID, ItemName, Price, Stock FROM CafeteriaItems";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string item = $"{reader["ItemID"]} - {reader["ItemName"]} - Price: {reader["Price"]} TL - Stock: {reader["Stock"]}";
                    listBox1.Items.Add(item);
                }
            }
        }


        private void UpdateStock(int amount)
        {
            string selectedItem = listBox1.SelectedItem.ToString();
            int itemId = int.Parse(selectedItem.Split(' ')[0]);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE CafeteriaItems SET Stock = Stock + @Amount WHERE ItemID = @ItemID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@ItemID", itemId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadItems();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                UpdateStock(+1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                UpdateStock(-1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CafeteriaItems (ItemName, Price, Stock) VALUES (@ItemName, @Price, @Stock)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ItemName", lbl2ProductName.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(lbl2ProductPrice.Text));
                cmd.Parameters.AddWithValue("@Stock", (int)numericUpDown1.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadItems();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
