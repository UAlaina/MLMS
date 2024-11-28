using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLMS
{
    public partial class userLogin : Form
    {
        public userLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = emailTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill out both username and password.");
                return;
            }

            // Check if either "Admin" or "User" is selected
            if (!adminRadioButton.Checked && !userRadioButton.Checked)
            {
                MessageBox.Show("Please select Admin or User.");
                return;
            }
            if (adminRadioButton.Checked)
            {
                if ("abc@gmail.com" == username && "abc123" == password)
                {
                    MessageBox.Show("Login Success!");
                    mainDashbboard DB = new mainDashbboard();
                    DB.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Login Denied :(");
                }
            }
            // User login logic
            else if (userRadioButton.Checked)
            {
                if ("user@example.com" == username && "user123" == password)
                {
                    MessageBox.Show("User Login Success!");
                    mainDashbboard userDashboard = new mainDashbboard();
                    userDashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Login Denied :(");
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            emailTextBox.Text = passwordTextBox.Text = "";
            adminRadioButton.Checked = false;
            userRadioButton.Checked = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            addMemberForm newUserForm = new addMemberForm();
            newUserForm.Show();
        }
    }
}
