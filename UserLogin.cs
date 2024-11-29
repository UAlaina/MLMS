using MLMS2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLMS
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = emailTextBox.Text;
            string password = passwordTextBox.Text;

            // Validate user inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill out both username and password.");
                return;
            }

            // Validate login credentials from the database
            if (ValidateUserLogin(username, password))
            {
                MessageBox.Show("Login Success!");
                MainDashbboard dashboard = new MainDashbboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Denied :(");
            }
        }

        private bool ValidateUserLogin(string username, string password)
        {
            bool isValid = false;

            // Get the connection string from the App.config file
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Password FROM Member WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", username);
                    string storedPassword = (string)cmd.ExecuteScalar();

                    if (storedPassword == password)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }



        private void clearButton_Click(object sender, EventArgs e)
        {
            emailTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            addMemberForm newUserForm = new addMemberForm();
            newUserForm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainDashbboard B = new MainDashbboard();
            B.Show();
            this.Hide();
        }
    }
}