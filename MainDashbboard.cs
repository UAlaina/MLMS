using MLMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLMS2
{
    public partial class MainDashbboard : Form
    {
        public MainDashbboard()
        {
            InitializeComponent();
        }

        private void memberButton_Click(object sender, EventArgs e)
        {
            addMemberForm member = new addMemberForm();
            member.Show();
            this.Hide();
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            ReserveBook r = new ReserveBook();
            r.Show();
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddBook D = new AddBook();
            D.Show();
            this.Hide();
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            Payment P = new Payment();
            P.Show();
            this.Hide();
        }

        private void issueButton_Click(object sender, EventArgs e)
        {
            IssueBook r = new IssueBook();
            r.Show();
            this.Hide();
        }
    }
}
