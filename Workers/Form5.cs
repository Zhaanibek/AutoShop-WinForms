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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productType = textBox1.Text;

            if (string.IsNullOrEmpty(productType))
            {
                label1.Text = "Please fill in all fields";
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
                string checkQuery = "SELECT COUNT(*) FROM products WHERE productType = @productType";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@productType", productType);
                int productCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (productCount > 0)
                {
                    label1.Text = "This product type already exists.";
                }

                else
                {
                    string insertQuery = "INSERT INTO products (productType) VALUES (@Value1)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Value1", productType);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Product type added successfully");

                    this.Close();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

