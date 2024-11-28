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
    public partial class mainDashbboard : Form
    {
        public mainDashbboard()
        {
            InitializeComponent();
        }

        private void hoursLabel_Click(object sender, EventArgs e)
        {

        }

        private void memberButton_Click(object sender, EventArgs e)
        {
            addMemberForm member = new addMemberForm();
            member.Show();
            this.Hide();
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            reserveBook r = new reserveBook();
            r.Show();
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addBook D = new addBook();
            D.Show();
            this.Hide();
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            payment P = new payment();
            P.Show();
            this.Hide();
        }

        private void issueButton_Click(object sender, EventArgs e)
        {
            issueBook r = new issueBook();
            r.Show();
            this.Hide();
        }
    }
}
