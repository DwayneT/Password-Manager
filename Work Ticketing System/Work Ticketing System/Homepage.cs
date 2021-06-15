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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInputHD user = new UserInputHD();
            user.Show();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculator clt = new calculator();
            clt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calender cl = new calender();
            cl.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                //remain in the application
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stafflogin sl = new Stafflogin();
            sl.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffSignup fm4 = new StaffSignup();
            fm4.Show();
            Hide();
        }
    }
}
