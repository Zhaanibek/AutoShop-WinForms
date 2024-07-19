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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Enter name...";
            userNameField.ForeColor = Color.Gray;

            userSurnameField.Text = "Enter surname...";
            userSurnameField.ForeColor = Color.Gray;

            LogField.Text = "Enter username...";
            LogField.ForeColor = Color.Gray;

            PassField.UseSystemPasswordChar = false;
            PassField.Text = "Enter password...";
            PassField.ForeColor = Color.Gray;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(101, 99, 255);
        }

        Point lastPoint;
        private void MainPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Enter name...")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;

            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Enter name...";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void userSurnameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Enter surname...")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;
            }
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Enter surname...";
                userSurnameField.ForeColor = Color.Gray;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (LogField.Text == "Enter login...")
            {
                MessageBox.Show("Enter login!");
                return;
            }

            if (PassField.Text == "Enter password...")
            {
                MessageBox.Show("Enter password!");
                return;
            }

            if (userNameField.Text == "Enter password...")
            {
                MessageBox.Show("Enter name!");
                return; 
            }


            if (userSurnameField.Text == "Enter surname...")
            {
                MessageBox.Show("Enter surname!");
                return;
            }

            string Username = userNameField.Text;
            string Usersurname = userSurnameField.Text;
            string Userlogin = LogField.Text;
            string Userpassword = PassField.Text;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Usersurname) || string.IsNullOrEmpty(Userlogin) || string.IsNullOrEmpty(Userpassword))
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
                if (userCount > 0)
                {
                    RegisterErrorLabel.Text = "This login is already in use.";
                    return;
                }

                else
                {
                    // Если пользователь с таким логином не найден, выполняем вставку
                    string insertQuery = "INSERT INTO users (UserName, UserSurname, UserLogin, UserPassword) VALUES (@Value1, @Value2, @Value3, @Value4)";
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Value1", Username);
                    command.Parameters.AddWithValue("@Value2", Usersurname);
                    command.Parameters.AddWithValue("@Value3", Userlogin);
                    command.Parameters.AddWithValue("@Value4", Userpassword);

                    command.ExecuteNonQuery();

                    MessageBox.Show("User added successfully!");

                    string getUserIDQuery = "SELECT UserID FROM users WHERE UserLogin = @UserLogin";
                    MySqlCommand getUserIDCommand = new MySqlCommand(getUserIDQuery, connection);
                    getUserIDCommand.Parameters.AddWithValue("@UserLogin", Userlogin);
                    object userIDObject = getUserIDCommand.ExecuteScalar();
                    if (userIDObject != null)
                    {
                        int userID = Convert.ToInt32(userIDObject);

                        // Пароль совпадает, открываем 4-ю форму
                        LoggedForm form4 = new LoggedForm(userID);
                        form4.Show();
                        this.Hide(); // Скрыть текущую форму, если необходимо
                    }
                    else
                    {
                        // Пользователь не найден
                        MessageBox.Show("User is not found");
                    }

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            MainForm mainForm = new MainForm();
            mainForm.Hide();
        }

        private void AuthorizationLabel_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm loginForm = new MainForm();
            loginForm.Show();
        }

        private void LogField_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Registration_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterErrorLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(45, 45, 46); 
        }

        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(25, 25, 26); 
        }
    }
}


