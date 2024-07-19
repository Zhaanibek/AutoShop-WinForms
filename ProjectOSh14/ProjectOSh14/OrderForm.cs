using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectOSh14
{
    public partial class OrderForm : Form
    {
        private string connectionString = "Server=localhost;Database=autoshop;Uid=root;Pwd=root;Port=3306;";

        private int UserID;
        private int orderID;

        private decimal totalCost = 0;

        public OrderForm(int UserID)
        {
            InitializeComponent();

            FillComboBox();
            AddForType.SelectedIndexChanged += AddForType_SelectedIndexChanged;
            this.UserID = UserID;
        }

        private void FillComboBox()
        {
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
                        AddForType.Items.Add(reader["productType"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddForType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddForName.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string productType = AddForType.SelectedItem.ToString();
                    string query = "SELECT DISTINCT productName FROM products WHERE productType = @productType AND productName IS NOT NULL";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AddForName.Items.Add(reader["productName"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today; // Устанавливаем текущую дату
            dateTimePicker1.Format = DateTimePickerFormat.Short; // Устанавливаем формат отображения
            dateTimePicker1.Enabled = false; // Отключаем возможность изменения пользователем

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(orderID) FROM orders";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    object result = cmd.ExecuteScalar();

                    // Проверяем, что результат запроса не равен DBNull.Value
                    if (result != null && result != DBNull.Value)
                    {
                        orderID = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        orderID = 1; // Если результат запроса равен DBNull.Value, присваиваем 0
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddForOrderButton_Click(object sender, EventArgs e)
        {
            AddLabel.Text = "";
            DeleteLabel.Text = "";
            if (AddForType.SelectedItem == null || AddForName.SelectedItem == null)
            {
                AddLabel.Text = "Please select product type and product name.";
                return;
            }

            string productType = AddForType.SelectedItem.ToString();
            string productName = AddForName.SelectedItem.ToString();
            string quantityString = textBoxQuantity.Text;
            string orderDate = dateTimePicker1.Text;

            int quantity;
            if (!int.TryParse(quantityString, out quantity) || quantity <= 0)
            {
                AddLabel.Text = "Invalid quantity format";
                return;
            }

            // Проверяем, есть ли товар с таким же типом и именем уже в заказе
            bool duplicateItem = IsDuplicateOrder(productType, productName, UserID, orderID);

            if (duplicateItem)
            {
                // Если товар уже присутствует в заказе, обновляем количество товара в заказе
                UpdateOrderQuantity(productType, productName, quantity);
            }
            else
            {
                // Если товара нет в заказе, добавляем новый товар в заказ
                AddItemToOrder(productType, productName, quantity);
            }

            UpdateListBox();
        }

        private bool IsDuplicateOrder(string productType, string productName, int userID, int orderID)
        {
            bool isDuplicate = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM orders WHERE productType = @productType AND productName = @productName AND userID = @userID AND orderID = @orderID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        isDuplicate = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

            return isDuplicate;
        }

        private void UpdateOrderQuantity(string productType, string productName, int quantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE orders SET productQuantity = productQuantity + @quantity WHERE productType = @productType AND productName = @productName AND userID = @userID AND orderID = @orderID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    cmd.Parameters.AddWithValue("@userID", UserID);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                    int productPrice = GetProductPrice(productType, productName);
                    totalCost += quantity * productPrice;
                    TotalCostLabel.Text = "Total cost: " + totalCost;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddItemToOrder(string productType, string productName, int quantity)
        {
            string userName = "";
            string userSurname = "";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryInfo = "SELECT UserName, UserSurname FROM users WHERE UserID = @userID";
                    MySqlCommand cmdInfo = new MySqlCommand(queryInfo, connection);
                    cmdInfo.Parameters.AddWithValue("@userID", UserID);
                    MySqlDataReader reader = cmdInfo.ExecuteReader();
                    if (reader.Read())
                    {
                        userName = reader["UserName"].ToString();
                        userSurname = reader["UserSurname"].ToString();
                    }
                    reader.Close();

                    // Если не удалось получить имя пользователя и фамилию, выводим сообщение об ошибке
                    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userSurname))
                    {
                        MessageBox.Show("Error: Unable to retrieve user information.");
                        return;
                    }

                    // Добавляем товар в заказ
                    int productPrice = GetProductPrice(productType, productName);

                    string query = "INSERT INTO orders (userID, orderID ,productType, productName, productPrice, productQuantity, orderDate, userName, userSurname) " +
                        "VALUES (@userID, @orderID, @productType, @productName, @productPrice, @quantity, @orderDate, @userName, @userSurname);";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@userID", UserID);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@productPrice", productPrice);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@orderDate", DateTime.Today);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@userSurname", userSurname);
                    int lastInsertedId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Обновляем общую цену
                    totalCost += productPrice * quantity;

                    if (!DeleteOrder.Items.Contains(productName))
                    {
                        DeleteOrder.Items.Add(productName);
                    }

                    TotalCostLabel.Text = "Total cost: " + totalCost;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UpdateListBox()
        {
            string productType = AddForType.SelectedItem.ToString();
            string productName = AddForName.SelectedItem.ToString();
            int quantity = int.Parse(textBoxQuantity.Text);
            decimal productPrice = GetProductPrice(productType, productName);

            // Проверяем, есть ли уже такой товар в списке
            bool itemExists = false;
            foreach (var item in listBox1.Items)
            {
                string itemProductName = item.ToString().Split(',')[0].Split(':')[1].Trim(); // Получаем название товара из строки в listBox1
                if (itemProductName == productName)
                {
                    itemExists = true;
                    break;
                }
            }

            if (itemExists)
            {
                // Если товар уже есть в списке, обновляем только его количество
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string itemProductName = listBox1.Items[i].ToString().Split(',')[0].Split(':')[1].Trim(); // Получаем название товара из строки в listBox1
                    if (itemProductName == productName)
                    {
                        int oldQuantity = int.Parse(listBox1.Items[i].ToString().Split(',')[1].Split(':')[1].Trim());
                        listBox1.Items[i] = $"Product: {productName}, Quantity: {oldQuantity + quantity}, Price per Item: {productPrice}";
                        break;
                    }
                }
            }
            else
            {
                // Если товара нет в списке, добавляем новый элемент
                listBox1.Items.Add($"Product: {productName}, Quantity: {quantity}, Price per Item: {productPrice}");
            }
        }

        private void DeleteFromOrderButton_Click(object sender, EventArgs e)
        {
            AddLabel.Text = "";
            DeleteLabel.Text = "";
            if (DeleteOrder.SelectedItem == null)
            {
                DeleteLabel.Text = "Please select product to delete.";
                return;
            }

            string productName = DeleteOrder.SelectedItem.ToString();

            // Удаление товара из базы данных
            DeleteProductFromDatabase(productName, orderID, UserID);

            // Удаление товара из listBox1
            RemoveProductFromListBox(productName);

            DeleteOrder.Items.Remove(productName);
        }

        private void DeleteProductFromDatabase(string productName, int orderID, int userID)
        {
            string connectionString = "Server=localhost;Database=autoshop;Uid=root;Pwd=root;Port=3306;"; // Замените на ваше подключение к базе данных

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    int quantity = 0;
                    string queryQuantity = "SELECT productQuantity FROM orders WHERE productName = @productName AND orderID = @orderID";
                    MySqlCommand cmdQuantity = new MySqlCommand(queryQuantity, connection);
                    cmdQuantity.Parameters.AddWithValue("@productName", productName);
                    cmdQuantity.Parameters.AddWithValue("@orderID", orderID);

                    using (MySqlDataReader readerQuantity = cmdQuantity.ExecuteReader())
                    {
                        if (readerQuantity.Read())
                        {
                            quantity = Convert.ToInt32(readerQuantity["productQuantity"]);
                        }
                    }

                    double productPrice = 0.0;

                    // Получаем цену продукта из базы данных
                    string queryPrice = "SELECT productPrice FROM products WHERE productName = @productName";
                    MySqlCommand cmdPrice = new MySqlCommand(queryPrice, connection);
                    cmdPrice.Parameters.AddWithValue("@productName", productName);

                    using (MySqlDataReader readerPrice = cmdPrice.ExecuteReader())
                    {
                        if (readerPrice.Read())
                        {
                            productPrice = Convert.ToDouble(readerPrice["productPrice"]);
                        }
                    }

                    // Вычисляем итоговую стоимость и обновляем интерфейс
                    totalCost -= Convert.ToDecimal(quantity * productPrice);
                    TotalCostLabel.Text = "Total cost: " + totalCost;

                    // Удаляем продукт из базы данных
                    string query = "DELETE FROM orders WHERE productName = @productName AND orderID = @orderID AND userID = @userID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.ExecuteNonQuery();

                    DeleteLabel.Text = "Product deleted from order successfully.";
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void RemoveProductFromListBox(string productName)
        {
            // Находим индекс товара в listBox1
            int index = -1;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString();
                if (item.Contains(productName))
                {
                    index = i;
                    break;
                }
            }

            // Если товар найден, удаляем его из listBox1
            if (index != -1)
            {
                listBox1.Items.RemoveAt(index);
            }
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM orders WHERE orderID = @orderID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.ExecuteNonQuery();
                    listBox1.Items.Clear();
                    totalCost = 0;

                    TotalCostLabel.Text = "Total cost: 0";
                    AddLabel.Text = "";
                    DeleteLabel.Text = "";
                    DeleteOrder.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                AddLabel.Text = "Please add items to the order.";
                return;
            }

            ReduceProductQuantity();

            orderID++;

            // Очистка элементов управления и вывод сообщения об успешном завершении
            listBox1.Items.Clear();
            totalCost = 0;
            label1.Text = "Total cost: 0";
            DeleteOrder.Items.Clear(); // Очищаем combobox с выбранными товарами
            MessageBox.Show("Order placed successfully!");
            this.Close();
        }

        private void ReduceProductQuantity()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    foreach (var item in listBox1.Items)
                    {
                        string productName = item.ToString().Split(',')[0].Split(':')[1].Trim(); // Получаем название товара из строки в listBox1
                        int quantity = int.Parse(item.ToString().Split(',')[1].Split(':')[1].Trim()); // Получаем количество товара из строки в listBox1

                        // Обновляем количество доступных товаров в таблице products
                        string updateQuery = "UPDATE products SET productQuantity = productQuantity - @quantity WHERE productName = @productName";
                        MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, connection);
                        cmdUpdate.Parameters.AddWithValue("@quantity", quantity);
                        cmdUpdate.Parameters.AddWithValue("@productName", productName);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private int GetProductPrice(string productType, string productName)
        {
            int productPrice = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT productPrice FROM products WHERE productType = @productType AND productName = @productName";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@productType", productType);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        productPrice = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return productPrice;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM orders WHERE orderID = @orderID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@orderID", orderID);
                    cmd.ExecuteNonQuery();
                    listBox1.Items.Clear();
                    totalCost = 0;

                    TotalCostLabel.Text = "Total cost: 0";
                    AddLabel.Text = "";
                    DeleteLabel.Text = "";
                    DeleteOrder.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            this.Close();
        }
    }
}
