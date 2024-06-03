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
    public partial class CateriaPage : Form
    {

        private string connectionString = "Data Source=DESKTOP-G556UFM;Initial Catalog=EduConnect;Integrated Security=True;TrustServerCertificate=True;";

        public CateriaPage()
        {
            InitializeComponent();
            LoadStudentData();
            LoadCafeteriaProducts();
        }
        //dataGridView1NotAllowed    restrictedItemsGridView
        // dataGridView2   studentpurchasess..
        private void LoadStudentData()
        {
            var userSession = UserSession.Instance;
            if (userSession.Role == "Student")
            {
                int studentId = GetStudentIdByEmail(userSession.Email);
                if (studentId != 0)
                {
                    DataTable purchases = GetNotAllowedProducts(studentId);
                    //dataGridView2.DataSource = purchases;

                    DataTable restrictedItems = GetNotAllowedProducts(studentId);
                    dataGridView1NotAllowed.DataSource = restrictedItems;

                    textStudentName.Text = $"{userSession.FirstName} {userSession.LastName}";
                    textBalance.Text = userSession.Balance.ToString("C");
                }
                else
                {
                    MessageBox.Show("The student has not been found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataTable GetNotAllowedProducts(int studentId)
        {
            string query = @"
                SELECT ci.ItemName
                FROM ProductRestriction ir
                JOIN CafeteriaItems ci ON ir.ItemID = ci.ItemID
                JOIN Students s ON ir.StudentID = s.StudentID
                WHERE s.StudentID = @StudentID AND ir.IsRestricted = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void LoadCafeteriaProducts()
        {
            string query = "SELECT ItemID, ItemName, Price, Stock FROM CafeteriaItems";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ProductComboBox1.DisplayMember = "ItemName";
                ProductComboBox1.ValueMember = "ItemID";
                ProductComboBox1.DataSource = dataTable;

                // DataGridView'da seçilen ürün hakkında bilgi göster
                ProductComboBox1.SelectedIndexChanged += (sender, e) =>
                {
                    if (ProductComboBox1.SelectedItem != null)
                    {
                        DataRowView selectedRow = (DataRowView)ProductComboBox1.SelectedItem;
                        lblPrice.Text = $"Price: {selectedRow["Price"]:C}";
                        lblStock.Text = $"Stock: {selectedRow["Stock"]}";
                    }
                };
            }
        }


        public int GetStudentIdByEmail(string email)
        {
            string query = "SELECT StudentID FROM Students WHERE Email = @Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var result = command.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }

        public DataTable GetStudentPurchases(int studentId)
        {
            string query = @"
                SELECT p.PurchaseID, i.ItemName, p.Quantity, i.Price, p.PurchaseDate
                FROM CafeteriaPurchases p
                JOIN CafeteriaItems i ON p.ItemID = i.ItemID
                WHERE p.StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        private int GetItemStock(int itemId)
        {
            string query = "SELECT Stock FROM CafeteriaItems WHERE ItemID = @ItemID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemID", itemId);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
        private decimal GetItemPrice(int itemId)
        {
            string query = "SELECT Price FROM CafeteriaItems WHERE ItemID = @ItemID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemID", itemId);
                connection.Open();
                return (decimal)command.ExecuteScalar();
            }
        }

        public bool UpdateStockAndBalance(int studentId, int itemId, int quantity)
        {
            try
            {
                decimal itemPrice = GetItemPrice(itemId);
                decimal totalPrice = itemPrice * quantity;

                // Öğrencinin bakiyesini kontrol et
                var userSession = UserSession.Instance;
                if (userSession.Balance < totalPrice)
                {
                    MessageBox.Show("You do not have enough balance to purchase this item.", "Insufficient Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false; // Satın alma işlemi başarısız oldu
                }

                // Stoğu kontrol et
                int currentStock = GetItemStock(itemId);
                if (currentStock < quantity)
                {
                    MessageBox.Show("Sorry, this item is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false; // Satın alma işlemi başarısız oldu
                }

                string query = @"
                    BEGIN TRANSACTION;
                    UPDATE CafeteriaItems SET Stock = Stock - @Quantity WHERE ItemID = @ItemID;
                    UPDATE Students SET Balance = Balance - @TotalPrice WHERE StudentID = @StudentID;
                    INSERT INTO CafeteriaPurchases (StudentID, ItemID, Quantity, PurchaseDate) VALUES (@StudentID, @ItemID, @Quantity, GETDATE());
                    COMMIT TRANSACTION;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@ItemID", itemId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                // Kullanıcı bakiyesini güncelle
                userSession.Balance = userSession.Balance - totalPrice;
                //userSession.Balance -= totalPrice;
                UpdateItemStock(itemId, quantity);
                lblStock.Text = $"Stock: {currentStock - quantity}";
                MessageBox.Show("Purchase successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true; // Satın alma işlemi başarılı
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Satın alma işlemi başarısız oldu
            }
        }
        private void UpdateItemStock(int itemId, int quantity)
        {
            string query = "UPDATE CafeteriaItems SET Stock = Stock - @Quantity WHERE ItemID = @ItemID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemID", itemId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userSession = UserSession.Instance;
            if (userSession.Role == "Student")
            {
                int studentId = GetStudentIdByEmail(userSession.Email);
                if (studentId != 0)
                {
                    int itemId = (int)ProductComboBox1.SelectedValue;
                    int quantity = 1; // Örneğin 1 adet ürün alınıyor
                    if (IsItemRestrictedForStudent(studentId, itemId))
                    {
                        MessageBox.Show("You cannot buy this product. It is restricted by your parent..", "Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (UpdateStockAndBalance(studentId, itemId, quantity))
                    {
                        LoadStudentData(); // Güncellenmiş verileri tekrar yükle
                    }
                }
                else
                {
                    MessageBox.Show("The student has not been found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool IsItemRestrictedForStudent(int studentId, int itemId)
        {
            string query = @"
                SELECT COUNT(*)
                FROM ProductRestriction r
                JOIN Students s ON r.StudentID = s.StudentID
                WHERE s.StudentID = @StudentID AND r.ItemID = @ItemID AND r.IsRestricted = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentId);
                command.Parameters.AddWithValue("@ItemID", itemId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void lblPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
