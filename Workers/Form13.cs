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
    public partial class Form13 : Form
    {
        private string connectionString = "Server=localhost;Database=autoshop;Uid=root;Pwd=root;Port=3306;";

        public Form13()
        {
            InitializeComponent();
            FillListBox1();
        }

        private void FillListBox1()
        {
            try
            {
                // Создаем соединение с базой данных
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Открываем соединение
                    connection.Open();

                    // Запрос к базе данных с параметром @userID
                    string query = "SELECT orderID, productType, productName, productQuantity, productPrice, orderDate, userName, userSurname, workerName, workerSurname FROM completed_orders";

                    // Создаем команду для выполнения запроса
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Привязываем значение параметра

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
                                    string orderInfo = $"{reader["orderID"]} | {reader["productType"]} | {reader["productName"]} | {"Quantity:"}{reader["productQuantity"]} | {reader["productPrice"]} | {reader["orderDate"]} | {reader["userName"]} | {reader["userSurname"]} | Who completed:{reader["workerName"]} | {reader["workerSurname"]}";

                                    // Добавляем строку в ListBox
                                    listBox1.Items.Add(orderInfo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
