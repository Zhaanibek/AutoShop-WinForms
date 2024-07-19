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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            FillComboBox();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
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
                    string productType = comboBox1.SelectedItem.ToString();
                    string query = "SELECT DISTINCT productName FROM products WHERE productType = @productType AND productName IS NOT NULL"; // Замените на ваш запрос
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["productName"].ToString());
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
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                label4.Text = "Please select product type and product name.";
                return;
            }

            string productType = comboBox1.SelectedItem.ToString();
            string productName = comboBox2.SelectedItem.ToString();
            string quantityToAdd = textBox1.Text;

            if (string.IsNullOrEmpty(quantityToAdd))
            {
                label4.Text = "Please fill in all fields";
                return;
            }

            int quantity;
            if (!int.TryParse(quantityToAdd, out quantity))
            {
                label4.Text = "Invalid quantity format";
                return;
            }

            if (quantity <= 0)
            {
                label4.Text = "Invalid quantity format";
                return;
            }

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
                    // Обновляем количество продукта
                    string updateQuery = "UPDATE products SET productQuantity = productQuantity + @QuantityToRemove WHERE productName = @ProductName";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@QuantityToRemove", quantity);
                    updateCommand.Parameters.AddWithValue("@ProductName", productName);
                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Product quantity successfully reduced.");
                    this.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
