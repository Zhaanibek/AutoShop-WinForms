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

namespace ProjectOSh14
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            FillComboBox();
            comboBox1.SelectedIndexChanged += FillDataGridView;
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

        private void FillDataGridView(object sender, EventArgs e)
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
                        string quantityString = reader["productQuantity"].ToString();
                        int quantity = Convert.ToInt32(quantityString);
                        if (quantity > 0)
                        {
                            dataGridView1.Rows.Add(productName, price, "Available");
                        }
                        else if (quantity == 0)
                        {
                            dataGridView1.Rows.Add(productName, price, "Not available");
                        }

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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.FromArgb(25, 25, 26);
        }


        private void UsersButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            employeesPass employeesPass = new employeesPass();
            employeesPass.Show();
        }

        private void Registration_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UsersButton_MouseEnter(object sender, EventArgs e)
        {
            UsersButton.BackColor = Color.FromArgb(45, 45, 46);
        }

        private void UsersButton_MouseLeave(object sender, EventArgs e)
        {
            UsersButton.BackColor = Color.FromArgb(25, 25, 26);
        }

        private void CatalogsButton_MouseEnter(object sender, EventArgs e)
        {

        }

        private void CatalogsButton_MouseLeave(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
