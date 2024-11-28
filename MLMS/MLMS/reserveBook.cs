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
using System.Xml.Linq;

namespace MLMS
{
    public partial class reserveBook : Form
    {
        public reserveBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainDashbboard c = new mainDashbboard();
            c.Show();
            this.Hide();
        }

        private void SearchBooks(string searchBy, string searchInput, string statusFilter)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query for reservations with dynamic filtering
                string query = $@"SELECT 
                            rb.ReserveID AS 'Reservation ID',
                            m.MemberName AS 'Member Name',
                            b.BookName AS 'Book Title',
                            rb.ReserveDate AS 'Reservation Date',
                            rb.Status AS 'Status'
                         FROM ReserveBooks rb
                         JOIN Member m ON rb.MemberID = m.MemberID
                         JOIN Book b ON rb.BookID = b.BookID
                         WHERE (rb.Status = @StatusFilter OR @StatusFilter = 'All')
                         AND (@SearchBy = 'All' OR
                              (@SearchBy = 'Book Name' AND b.BookName LIKE '%' + @SearchInput + '%') OR
                              (@SearchBy = 'Author' AND b.Author LIKE '%' + @SearchInput + '%') OR
                              (@SearchBy = 'ISBN' AND b.ISBN LIKE '%' + @SearchInput + '%') OR
                              (@SearchBy = 'Published Date' AND b.PublishedDate LIKE '%' + @SearchInput + '%'));";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StatusFilter", statusFilter);
                    command.Parameters.AddWithValue("@SearchBy", searchBy);
                    command.Parameters.AddWithValue("@SearchInput", searchInput);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Assign the results to the DataGridView
                    dataGridViewBooks.DataSource = dataTable;
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchType = searchByComboBox.SelectedItem?.ToString() ?? "All";
            string searchTerm = searchTextBox.Text.Trim();
            string statusFilter = statusComboBox.SelectedItem?.ToString() ?? "All";

            // Call the search method
            if (searchType != "All" && string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please provide a search term for the selected search type.");
                return; // Exit the method if the search term is empty
            }

            // Call the search method with valid input
            SearchBooks(searchType, searchTerm, statusFilter);
        }

        private void reserveBook_Load(object sender, EventArgs e)
        {
            // Initialize statusComboBox
            statusComboBox.Items.AddRange(new string[] { "All", "Reserved", "Cancelled", "Not in This Library" });
            statusComboBox.SelectedIndex = 0; // Default to "All"

            // Initialize searchByComboBox
            searchByComboBox.Items.AddRange(new string[] { "All", "Book Name", "Author", "ISBN", "Published Date" });
            searchByComboBox.SelectedIndex = 0; // Default to "All"

            // Load all reservations initially
            SearchBooks("All", "", "All");
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the "Cancel" button was clicked
            if (e.ColumnIndex == dataGridViewBooks.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                int reserveId = Convert.ToInt32(dataGridViewBooks.Rows[e.RowIndex].Cells["Reservation ID"].Value);

                var confirmResult = MessageBox.Show(
                    "Are you sure you want to cancel this reservation?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    CancelReservation(reserveId);
                    MessageBox.Show("Reservation canceled successfully.");
                    SearchBooks("All", "", statusComboBox.SelectedItem?.ToString() ?? "All"); // Refresh the grid
                }
            }
        }

        private void CancelReservation(int reserveId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE ReserveBooks SET Status = 'Cancelled' WHERE ReserveID = @ReserveID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReserveID", reserveId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddCancelButtonColumn()
        {
            DataGridViewButtonColumn cancelColumn = new DataGridViewButtonColumn();
            cancelColumn.HeaderText = "Actions";
            cancelColumn.Text = "Cancel";
            cancelColumn.UseColumnTextForButtonValue = true;
            dataGridViewBooks.Columns.Add(cancelColumn);
        }
    }
}
