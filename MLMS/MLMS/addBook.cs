﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MLMS
{
    public partial class addBook : Form
    {
        // Define the connection string (update with your connection string)
        //private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=App_Data\Library.mdf;Integrated Security=True;Connect Timeout=30;";
        //private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Library.mdf;Integrated Security=True;Connect Timeout=30;";
        //"C:\School_Projects\Git_Repositories\MLMS\MLMS\MLMS\App_Data\Library.mdf"
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\School_Projects\Git_Repositories\MLMS\MLMS\MLMS\App_Data\Library.mdf;Integrated Security=True;Connect Timeout=30;";
        //string connectionString = System.Configuration.ConfigurationManager.connectionStrings["LibraryEntities"].ConnectionString;
        //string connectionString;
        // BookName PublishDate Edition


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
            MessageBox.Show(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            MessageBox.Show(Directory.GetCurrentDirectory());
            
            // Retrieve values from the form inputs
            string bookName = bookTextBox.Text;
            string isbn = ISBNtextBox.Text;
            string author = authorTextBox.Text;
            DateTime publishedDate = publishDateTimePicker.Value;
            string edition = editionTextBox.Text;
            string description = descriptionRichTextBox.Text;

            
            // SQL query to insert the book into the database
            string query = "INSERT INTO Book (Title, ISBN, Author, YearPublished, Description) " +
                           "VALUES (@BookName, @ISBN, @Author, @PublishedDate, @Description)";

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
                    //cmd.Parameters.AddWithValue("@Edition", edition);
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
        private void validateBookFields()
        {
            // Check if the book name is empty
            if (string.IsNullOrWhiteSpace(bookTextBox.Text))
            {
                MessageBox.Show("Book name should be filled out.");
                return;
            }

            // Check if the ISBN is empty
            if (string.IsNullOrWhiteSpace(ISBNtextBox.Text))
            {
                MessageBox.Show("ISBN should be filled out.");
                return;
            }

            // Check if the author is empty
            if (string.IsNullOrWhiteSpace(authorTextBox.Text))
            {
                MessageBox.Show("Author should be filled out.");
                return;
            }

            // Check if the edition is empty
            if (string.IsNullOrWhiteSpace(editionTextBox.Text))
            {
                MessageBox.Show("Edition should be filled out.");
                return;
            }

            // Check if the description is empty
            if (string.IsNullOrWhiteSpace(descriptionRichTextBox.Text))
            {
                MessageBox.Show("Description should be filled out.");
                return;
            }

            // If all fields are valid, proceed to add the book
            AddBookToDatabase();
        }

        private void AddBookToDatabase()
        {
            // Logic to add the book to the database
            string bookName = bookTextBox.Text;
            string isbn = ISBNtextBox.Text;
            string author = authorTextBox.Text;
            DateTime publishedDate = publishDateTimePicker.Value;
            string edition = editionTextBox.Text;
            string description = descriptionRichTextBox.Text;

            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\School_Projects\Git_Repositories\MLMS\MLMS\MLMS\bin\Debug\App_Data\Library.mdf;Integrated Security=True;Connect Timeout=30;";
            string query = "INSERT INTO Book (BookName, ISBN, Author, PublishedDate, Edition, Description) VALUES (@BookName, @ISBN, @Author, @PublishedDate, @Edition, @Description)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookName", bookName);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@PublishedDate", publishedDate);
                    cmd.Parameters.AddWithValue("@Edition", edition);
                    cmd.Parameters.AddWithValue("@Description", description);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Book added successfully!");
                        ClearForm();
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
        private void ClearForm()
        {
            bookTextBox.Clear();
            ISBNtextBox.Clear();
            authorTextBox.Clear();
            editionTextBox.Clear();
            descriptionRichTextBox.Clear();
        }

        private void addBook_Load(object sender, EventArgs e)
        {

        }

        private void publishDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}