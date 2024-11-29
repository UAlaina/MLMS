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
    public partial class ReserveBook : Form
    {
        public ReserveBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainDashbboard c = new MainDashbboard();
            c.Show();
            this.Hide();
        }
    }
}
