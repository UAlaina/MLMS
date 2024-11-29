﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLMS2
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainDashbboard B = new MainDashbboard();
            B.Show();
            this.Hide();
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve values from the form
                string email = emailTextBox.Text;
                string name = cardNameTextBox.Text;
                string cardNumber = cardNoTextBox.Text;
                string expiryDateStr = expireTextBox.Text;
                string cvv = securityCodeTextBox.Text;
                decimal amount = decimal.Parse(amountTextBox.Text);

                // Validate inputs
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) ||
                    string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(expiryDateStr) ||
                    string.IsNullOrEmpty(cvv) || amount <= 0)
                {
                    throw new Exception("All fields must be filled in correctly.");
                }

                // Validate card number (simple check for 16 digits)
                if (cardNumber.Length != 16)
                {
                    throw new Exception("Card number must be 16 digits.");
                }

                // Validate Expiry Date
                DateTime expiryDate = DateTime.ParseExact(expiryDateStr, "MM/yy", CultureInfo.InvariantCulture);
                if (expiryDate <= DateTime.Now)
                {
                    throw new Exception("Card has expired.");
                }

                // Validate CVV (3 digits for most cards)
                if (cvv.Length != 3)
                {
                    throw new Exception("CVV must be 3 digits.");
                }

                // Process Payment (mocked here, but you would integrate with a payment gateway)
                // Assuming the payment is processed successfully:
                SavePaymentToDatabase(email, name, cardNumber, expiryDate, cvv, amount);

                // Show success message
                MessageBox.Show($"Payment of {amount:C} successful for {name}!");
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SavePaymentToDatabase(string email, string name, string cardNumber, DateTime expiryDate, string cvv, decimal amount)
        {
            string connectionString = "your_connection_string_here"; // Replace with your actual connection string
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Payment (Email, Name, PaymentMethod, CardNumber, ExpireDate, SecurityCode, Amount) " +
                               "VALUES (@Email, @Name, @PaymentMethod, @CardNumber, @ExpireDate, @SecurityCode, @Amount)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@PaymentMethod", "Credit Card");  // Assuming it's a credit card payment
                    cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                    cmd.Parameters.AddWithValue("@ExpireDate", expiryDate);
                    cmd.Parameters.AddWithValue("@SecurityCode", cvv);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ClearPaymentForm()
        {
            emailTextBox.Clear();
            cardNameTextBox.Clear();
            cardNoTextBox.Clear();
            expireTextBox.Clear();
            securityCodeTextBox.Clear();
            amountTextBox.Clear();
            creditCardRadioButton.Checked = true;
        }
    }
}