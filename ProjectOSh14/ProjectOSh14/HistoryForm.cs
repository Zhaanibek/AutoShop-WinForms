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
    public partial class HistoryForm : Form
    {
        private string connectionString = "Server=localhost;Database=autoshop;Uid=root;Pwd=root;Port=3306;";

        private int UserID;

        public HistoryForm(int userID)
        {
            InitializeComponent();
            FillDataGridView1();
            FillDataGridView2();
            this.UserID = userID;
        }

        private void FillDataGridView1()
        {
            try
            {
                // Создаем соединение с базой данных
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Открываем соединение
                    connection.Open();

                    // Запрос к базе данных с параметром @userID
                    string query = "SELECT orderID, productType, productName, productQuantity, productPrice, orderDate FROM orders WHERE userID = @userID";

                    // Создаем команду для выполнения запроса
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Привязываем значение параметра
                        command.Parameters.AddWithValue("@userID", UserID);

                        // Выполняем запрос и получаем результаты
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Проверяем, есть ли данные
                            if (reader.HasRows)
                            {
                                // Проходимся по каждой строке результата
                                while (reader.Read())
                                {
                                    // Формируем строку для добавления в ListBox
                                    string orderInfo = $"{reader["orderID"]} | {reader["productType"]} | {reader["productName"]} | {"Quantity:"}{reader["productQuantity"]} | {reader["productPrice"]} | {reader["orderDate"]}";

                                    // Добавляем строку в ListBox
                                    dataGridView1.Rows.Add(reader["orderID"], reader["productType"], reader["productName"], reader["productQuantity"], reader["productPrice"], reader["orderDate"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void FillDataGridView2()
        {
            try
            {
                // Создаем соединение с базой данных
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Открываем соединение
                    connection.Open();

                    // Запрос к базе данных с параметром @userID
                    string query = "SELECT orderID, productType, productName, productQuantity, productPrice, orderDate FROM completed_orders WHERE userID = @userID";

                    // Создаем команду для выполнения запроса
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Привязываем значение параметра
                        command.Parameters.AddWithValue("@userID", UserID);

                        // Выполняем запрос и получаем результаты
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Проверяем, есть ли данные
                            if (reader.HasRows)
                            {
                                // Проходимся по каждой строке результата
                                while (reader.Read())
                                {
                                    // Формируем строку для добавления в ListBox
                                    string orderInfo = $"{reader["orderID"]} | {reader["productType"]} | {reader["productName"]} | {"Quantity:"}{reader["productQuantity"]} | {reader["productPrice"]} | {reader["orderDate"]}";

                                    // Добавляем строку в ListBox
                                    dataGridView2.Rows.Add(reader["orderID"], reader["productType"], reader["productName"], reader["productQuantity"], reader["productPrice"], reader["orderDate"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            FillDataGridView1();
            FillDataGridView2();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
