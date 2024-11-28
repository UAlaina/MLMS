using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLMS
{
    public partial class addMemberForm : Form
    {
        public addMemberForm()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainDashbboard B = new mainDashbboard();
            B.Show();
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Retrieve values from the form inputs
            string fullName = nameTextBox.Text;
            string address = addressRichTextBox.Text;
            DateTime? dob = DOBDateTimePicker.Value;
            string phoneNumber = phoneNoTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text; // New password field
            string confirmPassword = confirmPasswordTextBox.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Validate that email is not already in use
            if (CheckIfEmailExists(email))
            {
                MessageBox.Show("Email already exists. Please choose a different one.");
                return;
            }

            // Hash the password before saving (use SHA256 for demo, but bcrypt or other hashing algorithms should be used in real apps)
            string hashedPassword = HashPassword(password);

            // change it whenever you test it out in other laptops
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

            // SQL query to insert the member into the database
            string memberQuery = "INSERT INTO Member (FullName, Address, DOB, PhoneNumber, Email) VALUES (@FullName, @Address, @DOB, @PhoneNumber, @Email)";
            string userQuery = "INSERT INTO Users (Email, Password, Role) VALUES (@Email, @Password, 'User')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Create a command object with the query and connection
                    SqlCommand cmd = new SqlCommand(memberQuery, conn);

                    // Add parameters to the SQL command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@DOB", dob.HasValue ? dob.Value : (object)DBNull.Value);  // Handle nullable DateTime
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", email);
                    int memberResult = cmd.ExecuteNonQuery();

                    SqlCommand userCmd = new SqlCommand(userQuery, conn);
                    userCmd.Parameters.AddWithValue("@Email", email);
                    userCmd.Parameters.AddWithValue("@Password", hashedPassword);
                    int userResult = userCmd.ExecuteNonQuery();

                    if (memberResult > 0 && userResult > 0)
                    {
                        MessageBox.Show("Member and User account created successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Error adding the member or user.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        // Method to check if email already exists in the Users table
        private bool CheckIfEmailExists(string email)
        {
            bool exists = false;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int result = (int)cmd.ExecuteScalar();
                    if (result > 0)
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }

        // Simple password hashing method for demo purposes (use SHA-256 or bcrypt in real apps)
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
