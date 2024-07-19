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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            LogField.Text = "Enter username...";
            LogField.ForeColor = Color.Gray;

            PassField.UseSystemPasswordChar = false;
            PassField.Text = "Enter password...";
            PassField.ForeColor = Color.Gray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor= Color.White;
        }

        Point lastPoint;
        private void loginPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void loginPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Authorization_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void Authorization_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string Userlogin = LogField.Text;
            string Userpassword = PassField.Text;

            if (string.IsNullOrEmpty(Userlogin) || string.IsNullOrEmpty(Userpassword))
            {
                label1.Text = "Please fill in all fields.";
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
                string checkQuery = "SELECT COUNT(*) FROM users WHERE UserLogin = @UserLogin";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@UserLogin", Userlogin);
                int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (userCount == 1)
                {
                    // Пользователь найден, проверяем пароль
                    string getPasswordQuery = "SELECT UserPassword FROM users WHERE UserLogin = @UserLogin";
                    MySqlCommand getPasswordCommand = new MySqlCommand(getPasswordQuery, connection);
                    getPasswordCommand.Parameters.AddWithValue("@UserLogin", Userlogin);
                    string storedPassword = getPasswordCommand.ExecuteScalar().ToString();

                    if (storedPassword == Userpassword)
                    {
                        // Получаем UserID
                        string getUserIDQuery = "SELECT UserID FROM users WHERE UserLogin = @UserLogin";
                        MySqlCommand getUserIDCommand = new MySqlCommand(getUserIDQuery, connection);
                        getUserIDCommand.Parameters.AddWithValue("@UserLogin", Userlogin);
                        object userIDObject = getUserIDCommand.ExecuteScalar();

                        if (userIDObject != null)
                        {
                            int userID = Convert.ToInt32(userIDObject);

                            // Пароль совпадает, открываем 4-ю форму
                            LoggedForm form4 = new LoggedForm(userID);
                            MainForm mainForm = new MainForm();
                            mainForm.Hide();
                            form4.Show();
                            this.Hide(); // Скрыть текущую форму, если необходимо
                        }
                        else
                        {
                            // Пользователь не найден
                            MessageBox.Show("User is not found");
                        }

                    }
                    else
                    {
                        // Пароль не совпадает
                        label1.Text = "Wrong password";
                    }
                }
                else
                {
                    // Пользователь не найден
                    label1.Text = "User is not found";
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LogField_Enter(object sender, EventArgs e)
        {
            if (LogField.Text == "Enter username...")
            {
                LogField.Text = "";
                LogField.ForeColor = Color.Black;
            }
        }

        private void LogField_Leave(object sender, EventArgs e)
        {
            if (LogField.Text == "")
            {
                LogField.Text = "Enter username...";
                LogField.ForeColor = Color.Gray;
            }
        }

        private void PassField_Enter(object sender, EventArgs e)
        {
            if (PassField.Text == "Enter password...")
            {
                PassField.UseSystemPasswordChar = true;
                PassField.Text = "";
                PassField.ForeColor = Color.Black;
            }
        }


        private void PassField_Leave(object sender, EventArgs e)
        {
            if (PassField.Text == "")
            {
                PassField.UseSystemPasswordChar = false;
                PassField.Text = "Enter password...";
                PassField.ForeColor = Color.Gray;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {

        }

        private void LogField_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
