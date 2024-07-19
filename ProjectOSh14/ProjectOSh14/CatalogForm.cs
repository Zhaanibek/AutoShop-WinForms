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
    public partial class CatalogForm : Form
    {
        private ComboBox comboBoxProductTypes;
        private ListBox listBoxProducts;
        private TextBox nameTextBox;
        private TextBox priceTextBox;

        // Объявление списка товаров
        private List<Product> allProducts = new List<Product>();

        // Объявление списка типов товаров
        private List<string> allProductTypes = new List<string>();
        public CatalogForm()
        {
            InitializeComponent();
            InitializeProducts(); // Инициализация списка товаров
            DisplayAllProducts(); // Отображение всех товаров при загрузке формы
            InitializeProductTypes(); // Инициализация списка типов товаров
            DisplayProductTypes(); // Отображение всех типов товаров в ComboBox
        }

        // Инициализация списка товаров (заглушка)
        private void InitializeProducts()
        {
            // Здесь вы можете загрузить список товаров из базы данных или добавить их вручную
            // Пример добавления товаров:
            allProducts.Add(new Product("Товар 1", "Тип товара 1", 100));
            allProducts.Add(new Product("Товар 2", "Тип товара 1", 150));
            allProducts.Add(new Product("Товар 3", "Тип товара 2", 200));
            // и т.д.
        }

        // Отображение всех товаров
        private void DisplayAllProducts()
        {
            listBoxProducts.Items.Clear(); // Очищаем список товаров

            foreach (Product product in allProducts)
            {
                listBoxProducts.Items.Add(product.Name); // Добавляем название товара в список
            }
        }

        // Инициализация списка типов товаров
        private void InitializeProductTypes()
        {
            // Здесь вы можете загрузить список типов товаров из базы данных или добавить их вручную
            // Пример добавления типов товаров:
            allProductTypes.Add("Тип товара 1");
            allProductTypes.Add("Тип товара 2");
            // и т.д.
        }

        // Отображение всех типов товаров в ComboBox
        private void DisplayProductTypes()
        {
            comboBoxProductTypes.Items.Clear(); // Очищаем ComboBox

            foreach (string productType in allProductTypes)
            {
                comboBoxProductTypes.Items.Add(productType); // Добавляем тип товара в ComboBox
            }
        }

        // Обработчик нажатия на кнопку "Добавить товар"
        private void addButton_Click(object sender, EventArgs e)
        {
            // Получаем данные о новом товаре
            string name = nameTextBox.Text;
            string type = comboBoxProductTypes.SelectedItem as string;
            decimal price = Convert.ToDecimal(priceTextBox.Text);

            // Создаем новый объект товара
            Product newProduct = new Product(name, type, price);

            // Добавляем товар в базу данных
            AddProductToDatabase(newProduct);

            // Добавляем товар в список всех товаров и отображаем его
            allProducts.Add(newProduct);
            DisplayAllProducts();
        }

        // Метод для добавления товара в базу данных
        private void AddProductToDatabase(Product product)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand ("INSERT INTO products (name, type, price) VALUES (@name, @type, @price)");


            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@type", product.Type);
            command.Parameters.AddWithValue("@price", product.Price);

            command.ExecuteNonQuery();
            
        }

        // Пример класса Product
        public class Product
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public decimal Price { get; set; }

            public Product(string name, string type, decimal price)
            {
                Name = name;
                Type = type;
                Price = price;
            }
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

