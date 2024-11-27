﻿using System;
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
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainDashbboard B = new mainDashbboard();
            B.Show();
            this.Hide();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect values from the form fields
                string name = nameTextBox.Text;
                string email = emailTextBox.Text;
                string cardNumber = cardNoTextBox.Text;
                DateTime expireDate = dateTimeDateTimePicker.Value;
                string securityCode = securityCodeTextBox.Text;
                decimal amount = decimal.Parse(amountTextBox.Text);

                // Assuming you have a MemberID that is selected or known, for this example let's use a hardcoded value
                int memberId = 1;  // Replace with the actual MemberID value

                string paymentMethod = creditCardRadioButton.Checked ? "Credit card" : "PayPal";  // Check which payment method is selected

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\santh\Documents\GitHub\MLMS\MLMS\MLMS\bin\Debug\Library.mdf;Integrated Security=True;Connect Timeout=30;";

                // Create the SQL query to insert payment details
                string query = "INSERT INTO Payment (MemberID, PaymentMethod, Name, Email, CardNumber, ExpireDate, SecurityCode, Amount) " +
                               "VALUES (@MemberID, @PaymentMethod, @Name, @Email, @CardNumber, @ExpireDate, @SecurityCode, @Amount)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Prepare the SQL command
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberId);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                    cmd.Parameters.AddWithValue("@ExpireDate", expireDate);
                    cmd.Parameters.AddWithValue("@SecurityCode", securityCode);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if the payment was successfully inserted
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment processed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error processing payment.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
