using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Workers
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT productType FROM products";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["productType"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productType = comboBox1.SelectedItem.ToString();
            string productName = textBox2.Text;
            string productPrice = textBox4.Text;
            string productQuantity = textBox5.Text;

            if (comboBox1.SelectedItem == null)
            {
                label6.Text = "Please select product type and product name.";
                return;
            }

            if (string.IsNullOrEmpty(productType) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productPrice) || string.IsNullOrEmpty(productQuantity))
            {
                label6.Text = "Please fill in all fields";
                return;
            }
            int price;
            if (!int.TryParse(productPrice, out price))
            {
                label6.Text = "Invalid price format";
                return;
            }

            int quantity;
            if (!int.TryParse(productQuantity, out quantity))
            {
                label6.Text = "Invalid quantity format";
                return;
            }

            if (quantity <= 0)
            {
                label6.Text = "Invalid quantity format";
                return;
            }

            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string checkproductQuery = "SELECT COUNT(*) FROM products WHERE productName = @productName";
                MySqlCommand checkproductCommand = new MySqlCommand(checkproductQuery, connection);
                checkproductCommand.Parameters.AddWithValue("@productName", productName);
                int productNameCount = Convert.ToInt32(checkproductCommand.ExecuteScalar());


                if (productNameCount > 0)
                {
                    label6.Text = "This product already exist";
                }
                else
                {
                    string insertQuery = "INSERT INTO products (productType, productName, productPrice, productQuantity) VALUES (@Value1, @Value2, @Value4, @Value5)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Value1", productType);
                    command.Parameters.AddWithValue("@Value2", productName);
                    command.Parameters.AddWithValue("@Value4", price);
                    command.Parameters.AddWithValue("@Value5", quantity);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully!");

                    this.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}