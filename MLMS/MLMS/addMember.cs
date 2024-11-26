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
    public partial class addMember : Form
    {
        public addMember()
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

            // change it whenever you test it out in other laptops
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

            // SQL query to insert the member into the database
            string query = "INSERT INTO Member (FullName, Address, DOB, PhoneNumber, Email) " +
                           "VALUES (@FullName, @Address, @DOB, @PhoneNumber, @Email)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Create a command object with the query and connection
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters to the SQL command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@DOB", dob.HasValue ? dob.Value : (object)DBNull.Value);  // Handle nullable DateTime
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", email);

                    // Execute the command
                    int result = cmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (result > 0)
                    {
                        MessageBox.Show("Member added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Error adding the member.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
