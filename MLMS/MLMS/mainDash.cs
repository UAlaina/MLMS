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
    public partial class mainDash : Form
    {
        public mainDash()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            addMemberForm m = new addMemberForm();
            m.Show();
            this.Hide();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            addBook B = new addBook();
            B.Show();
            this.Hide();
        }

        private void issueButton_Click(object sender, EventArgs e)
        {
            issueBook issueBook = new issueBook();
            issueBook.Show();
            this.Hide();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {

        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            payment payment = new payment();
            payment.Show();
            this.Hide();
        }
    }
}
