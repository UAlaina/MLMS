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
            string username;
            string password;

            username = textBox1.Text;
            password = textBox2.Text;

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

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
