using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; 
using System.Data.SqlClient;

namespace MLMS2
{
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainDashbboard c = new MainDashbboard();
            c.Show();
            this.Hide();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Retrieve the connection string from app.config
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;

            try
            {
                // Validate form inputs
                if (string.IsNullOrWhiteSpace(issueBookNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(ISBNNoTextBox.Text) ||
                    string.IsNullOrWhiteSpace(authorTextBox.Text) ||
                    cmbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please fill out all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Capture form inputs
                string issuedBookName = issueBookNameTextBox.Text.Trim();
                string isbn = ISBNNoTextBox.Text.Trim();
                string author = authorTextBox.Text.Trim();
                DateTime issueDate = issueDateTimePicker.Value; // Assuming a DateTimePicker for IssueDate
                DateTime dueDate = DueDateDateTimePicker.Value; // Assuming a DateTimePicker for DueDate
                string status = cmbStatus.SelectedItem.ToString();

                // Check if due date is after the issue date
                if (dueDate <= issueDate)
                {
                    MessageBox.Show("Due date must be after the issue date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SQL Insert command
                string query = @"INSERT INTO IssueBooks 
                                (MemberID, BookID, IssueBookName, ISBN, Author, IssueDate, DueDate, Status)
                                VALUES (@MemberID, @BookID, @IssueBookName, @ISBN, @Author, @IssueDate, @DueDate, @Status)";

                // Execute the query
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        cmd.Parameters.AddWithValue("@BookID", bookId);
                        cmd.Parameters.AddWithValue("@IssueBookName", issuedBookName);
                        cmd.Parameters.AddWithValue("@ISBN", isbn);
                        cmd.Parameters.AddWithValue("@Author", author);
                        cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);
                        cmd.Parameters.AddWithValue("@Status", status);

                        // Open connection and execute query
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if insertion was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Book issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally clear fields after success
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Error while issuing the book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input for Member ID or Book ID. Please enter valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to clear the form fields
        private void ClearForm()
        {
            issueBookNameTextBox.Clear();
            ISBNNoTextBox.Clear();
            authorTextBox.Clear();
            cmbStatus.SelectedIndex = -1; // Reset ComboBox
            issueDateTimePicker.Value = DateTime.Now; // Reset DateTimePicker to today
            DueDateDateTimePicker.Value = DateTime.Now.AddDays(7); // Set default due date to one week later
        }
    }
}