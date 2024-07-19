using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Workers
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Workername = textBox1.Text;
            string Workersurname = textBox2.Text;
            string Workerlogin = textBox3.Text;
            string Workerpassword = textBox4.Text;

            if (string.IsNullOrEmpty(Workername) || string.IsNullOrEmpty(Workersurname) || string.IsNullOrEmpty(Workerlogin) || string.IsNullOrEmpty(Workerpassword))
            {
                label5.Text = "Please fill in all fields";
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
                // Проверяем, существует ли уже пользователь с таким логином
                string checkQuery = "SELECT COUNT(*) FROM workers WHERE WorkerLogin = @WorkerLogin";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@WorkerLogin", Workerlogin);
                int workerCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (workerCount > 0)
                {
                    label5.Text = "This login is already in use.";
                }

                else
                {
                    // Если пользователь с таким логином не найден, выполняем вставку
                    string insertQuery = "INSERT INTO workers (WorkerName, WorkerSurname, WorkerLogin, WorkerPassword) VALUES (@Value1, @Value2, @Value3, @Value4)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Value1", Workername);
                    command.Parameters.AddWithValue("@Value2", Workersurname);
                    command.Parameters.AddWithValue("@Value3", Workerlogin);
                    command.Parameters.AddWithValue("@Value4", Workerpassword);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Worker added successfully!");

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
            Form1 form = new Form1();
            form.Show();
        }
    }
}
