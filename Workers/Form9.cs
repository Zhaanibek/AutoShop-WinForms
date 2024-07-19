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

namespace Workers
{
    public partial class Form9 : Form
    {
        public Form9()
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
        private void Form9_Load(object sender, EventArgs e) 
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productType = comboBox1.SelectedItem.ToString();
            string productName = comboBox2.SelectedItem.ToString();

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
                    string query = "DELETE FROM products WHERE productName = @productName";
                    MySqlCommand delete = new MySqlCommand(query, connection);
                    delete.Parameters.AddWithValue("@ProductName", productName);
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Product deleted successfully");
                    connection.Close();
                    this.Close();
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
