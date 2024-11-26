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
    public partial class issueBook : Form
    {
        public issueBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainDashbboard c = new mainDashbboard();
            c.Show();
            this.Hide();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }
}
