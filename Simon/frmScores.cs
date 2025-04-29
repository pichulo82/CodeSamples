using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon
{
    public partial class frmScores : Form
    {
        public frmScores()
        {
            InitializeComponent();
        }

        private void frmScores_Load(object sender, EventArgs e)
        {
            txtHighScores.BackColor = Color.Black;
            txtHighScores.ForeColor = Color.White;
            txtHighScores.Text = "sir farts a lot";

            txtHighScores.Top = 600;
        }

        private void tmrScroller_Tick(object sender, EventArgs e)
        {
            // txtHighScores.Top = txtHighScores.Top - 1;
            // txtHighScores.Location.Y = txtHighScores.Location.Y - 1;
        }
    }
}
