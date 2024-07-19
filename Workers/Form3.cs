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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Workerlogin = textBox1.Text;
            string Workerpassword = textBox2.Text;

            if (string.IsNullOrEmpty(Workerlogin) || string.IsNullOrEmpty(Workerpassword))
            {
                label3.Text = "Please fill in all fields";
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

                if (workerCount == 1)
                {
                    // Пользователь найден, проверяем пароль
                    string getPasswordQuery = "SELECT WorkerPassword FROM workers WHERE WorkerLogin = @WorkerLogin";
                    MySqlCommand getPasswordCommand = new MySqlCommand(getPasswordQuery, connection);
                    getPasswordCommand.Parameters.AddWithValue("@WorkerLogin", Workerlogin);
                    string storedPassword = getPasswordCommand.ExecuteScalar().ToString();

                    if (storedPassword == Workerpassword)
                    {
                        // Получаем UserID
                        string getWorkerIDQuery = "SELECT WorkerID FROM workers WHERE WorkerLogin = @WorkerLogin";
                        MySqlCommand getWorkerIDCommand = new MySqlCommand(getWorkerIDQuery, connection);
                        getWorkerIDCommand.Parameters.AddWithValue("@WorkerLogin", Workerlogin);
                        object workerIDObject = getWorkerIDCommand.ExecuteScalar();

                        if (workerIDObject != null)
                        {
                            int workerID = Convert.ToInt32(workerIDObject);

                            // Пароль совпадает, открываем 4-ю форму
                            Form4 form4 = new Form4(workerID);
                            form4.Show();
                            this.Hide(); // Скрыть текущую форму, если необходимо
                        }
                        else
                        {
                            // Пользователь не найден
                            MessageBox.Show("Worker is not found");
                        }
                    }
                    else
                    {
                        // Пароль не совпадает
                        label3.Text = "Wrong password";
                    }
                }
                else
                {
                    // Пользователь не найден
                    label3.Text = "Worker is not found";
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
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
