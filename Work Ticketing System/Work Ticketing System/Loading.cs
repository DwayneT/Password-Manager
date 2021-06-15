using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Ticketing_System
{
    public partial class startuporm : Form
    {
        public startuporm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 588)
            {
                timer1.Stop();
                Homepage homepage = new Homepage();
                homepage.Show();
                this.Hide();

            }
        }
    }
}
    

