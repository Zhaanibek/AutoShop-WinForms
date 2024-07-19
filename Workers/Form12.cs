using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
    public partial class Form12 : Form
    {
        private int WorkerID;
        public Form12(int workerID)
        {
            InitializeComponent();
            this.WorkerID = workerID;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";

            // Создаем SQL запрос для извлечения информации о заказе
            string selectQuery = $"SELECT productType, productName, productQuantity, productPrice, orderDate, userName, userSurname, orderID FROM orders";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Извлекаем данные о заказе
                    string productType = reader.GetString("productType");
                    string productName = reader.GetString("productName");
                    int productOrderID = reader.GetInt32("orderID");
                    int productQuantity = reader.GetInt32("productQuantity");
                    decimal productPrice = reader.GetDecimal("productPrice");
                    DateTime orderDate = reader.GetDateTime("orderDate");
                    string userName = reader.GetString("userName");
                    string userSurname = reader.GetString("userSurname");

                    // Отображаем информацию о заказе в listbox1
                    listBox1.Items.Add($"Order ID: {productOrderID}, Product Type: {productType}, Product Name: {productName}, Quantity: {productQuantity}, Price: {productPrice}, Date: {orderDate}, User: {userName} {userSurname}");

                }

                reader.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string completedOrder = textBox1.Text;

            if (string.IsNullOrEmpty(completedOrder))
            {
                label3.Text = "Please fill in all fields";
                return;
            }

            int orderID;
            if (!int.TryParse(completedOrder, out orderID))
            {
                label3.Text = "Invalid order ID format";
                return;
            }

            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";

            // Создаем SQL запрос для извлечения информации о заказе
            string selectQuery = $"SELECT productType, productName, productQuantity, productPrice, orderDate, userName, userSurname, orderID, userID FROM orders WHERE orderID = {orderID}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Извлекаем данные о заказе
                    string productType = reader.GetString("productType");
                    string productName = reader.GetString("productName");
                    int productOrderID = reader.GetInt32("orderID");
                    int productQuantity = reader.GetInt32("productQuantity");
                    decimal productPrice = reader.GetDecimal("productPrice");
                    DateTime orderDate = reader.GetDateTime("orderDate");
                    string userName = reader.GetString("userName");
                    string userSurname = reader.GetString("userSurname");
                    int userID = reader.GetInt32("userID");

                    // Отображаем информацию о заказе в listbox1


                    CompleteOrder(orderID, productType, productName, productQuantity, productPrice, orderDate, userName, userSurname, userID);

                    int indexToRemove = -1;
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        string item = listBox1.Items[i].ToString();
                        if (item.Contains($"Order ID: {orderID}"))
                        {
                            indexToRemove = i;
                            break;
                        }
                    }

                    // Если элемент найден, удаляем его
                    if (indexToRemove != -1)
                    {
                        listBox1.Items.RemoveAt(indexToRemove);
                    }
                    label3.Text = "";
                }
                else
                {
                    label3.Text = "Order not found";
                }

                reader.Close();
            }
        }

        private void CompleteOrder(int orderID, string productType, string productName, int productQuantity, decimal productPrice, DateTime orderDate, string userName, string userSurname, int userID)
        {
            string server = "localhost";
            string database = "autoshop";
            string uid = "root";
            string password = "root";
            string connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Port=3306;";

            // Получаем информацию о сотруднике из таблицы workers по его ID
            string selectWorkerQuery = $"SELECT WorkerName, WorkerSurname FROM workers WHERE WorkerID = {WorkerID}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectWorkerQuery, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                string workerName = "";
                string workerSurname = "";

                if (reader.Read())
                {
                    workerName = reader.GetString("WorkerName");
                    workerSurname = reader.GetString("WorkerSurname");
                }

                reader.Close();

                // Записываем информацию о заказе в таблицу completed_orders
                string insertQuery = $"INSERT INTO completed_orders (productType, productName, productQuantity, productPrice, orderDate, userName, userSurname, orderID, userID, workerName, workerSurname, workerID) VALUES ('{productType}', '{productName}', {productQuantity}, {productPrice}, '{orderDate.ToString("yyyy-MM-dd")}', '{userName}', '{userSurname}', {orderID}, {userID}, '{workerName}', '{workerSurname}', '{WorkerID}')";

                command = new MySqlCommand(insertQuery, connection);
                command.ExecuteNonQuery();

                // Удаляем информацию о заказе из таблицы orders
                string deleteQuery = $"DELETE FROM orders WHERE orderID = {orderID}";
                command = new MySqlCommand(deleteQuery, connection);
                command.ExecuteNonQuery();
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
