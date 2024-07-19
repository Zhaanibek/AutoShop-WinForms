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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            FillComboBox();
            comboBox1.SelectedIndexChanged += FillListBox;
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

        private void FillListBox(object sender, EventArgs e) 
        {
            dataGridView1.Rows.Clear();
            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";
            string productType = comboBox1.SelectedItem.ToString();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT productName, productPrice, ProductQuantity FROM products Where productType = @productType AND productName IS NOT NULL";
                    MySqlCommand checkName = new MySqlCommand(query, connection);
                    checkName.Parameters.AddWithValue("@productType", productType);
                    MySqlDataReader reader = checkName.ExecuteReader();
                    while (reader.Read())
                    {
                        string productName = reader["productName"].ToString();
                        string price = reader["productPrice"].ToString();
                        string quantity = reader["productQuantity"].ToString();

                        dataGridView1.Rows.Add(productName, price, quantity);
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
