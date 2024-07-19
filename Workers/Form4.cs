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
    public partial class Form4 : Form
    {
        private int WorkerID;
        public Form4(int workerID)
        {
            InitializeComponent();
            this.WorkerID = workerID;
            Form12 form12 = new Form12(WorkerID);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string getWorkerNameQuery = "SELECT WorkerName FROM workers WHERE WorkerID = @WorkerID";
                MySqlCommand getWorkerNameCommand = new MySqlCommand(getWorkerNameQuery, connection);
                getWorkerNameCommand.Parameters.AddWithValue("@WorkerID", WorkerID);

                string workerName = getWorkerNameCommand.ExecuteScalar()?.ToString();

                label1.Text = workerName;

                string getWorkerSurnameQuery = "SELECT WorkerSurname FROM workers WHERE WorkerID = @WorkerID";
                MySqlCommand getWorkerSurnameCommand = new MySqlCommand(getWorkerSurnameQuery, connection);
                getWorkerSurnameCommand.Parameters.AddWithValue("@WorkerID", WorkerID);

                string workerSurname = getWorkerSurnameCommand.ExecuteScalar()?.ToString();

                label2.Text = workerSurname;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close(); // Всегда закрывайте соединение после использования
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12(WorkerID);
            form12.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
        }
    }
}
