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
    public partial class addBook : Form
    {
        public addBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainDashbboard M = new mainDashbboard();
            M.Show();
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Retrieve values from the form inputs
            string bookName = bookTextBox.Text;
            string isbn = ISBNtextBox.Text;
            string author = authorTextBox.Text;
            DateTime publishedDate = publishDateTimePicker.Value;
            string edition = editionTextBox.Text;
            string description = descriptionRichTextBox.Text;

            // Define the connection string (update with your connection string)
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

            // SQL query to insert the book into the database
            string query = "INSERT INTO Book (BookName, ISBN, Author, PublishedDate, Edition, Description) " +
                           "VALUES (@BookName, @ISBN, @Author, @PublishedDate, @Edition, @Description)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Create a command object with the query and connection
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters to the SQL command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@BookName", bookName);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@PublishedDate", publishedDate);
                    cmd.Parameters.AddWithValue("@Edition", edition);
                    cmd.Parameters.AddWithValue("@Description", description);

                    // Execute the command
                    int result = cmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    if (result > 0)
                    {
                        MessageBox.Show("Book added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Error adding the book.");
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
