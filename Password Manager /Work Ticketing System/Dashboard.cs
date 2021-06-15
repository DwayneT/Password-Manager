using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Work_Ticketing_System
{
    public partial class Dashboard : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        // private string uname;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRgn")]

        private static extern IntPtr CreateRoundRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse


         );
        public Dashboard()
        {
            InitializeComponent();
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRgn(0,0,Width,Height,25,25));
            label2.Text = User.Username;
        }

       

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var conn = new MySqlConnection(myconnstrng);
            conn.Open();
            String userCount = "SELECT COUNT(Id) FROM users";
            var cmd = new MySqlCommand(userCount,conn);
            Int32 Ucount = Convert.ToInt32(cmd.ExecuteScalar());
            //MySqlDataReader rdr = cmd.ExecuteReader();
            if (Ucount > 0)
            {
                label12.Text = Convert.ToString(Ucount.ToString());
            }
            else
            {
                label12.Text = "";
            }
            String pending = "SELECT COUNT(Id) FROM passwords";
            var cmd1 = new MySqlCommand(pending,conn);
            Int32 pendingCount = Convert.ToInt32(cmd1.ExecuteScalar());
            if (pendingCount > 0)
            {
                label5.Text = Convert.ToString(pendingCount.ToString());
            }
            else
            {
                label5.Text = "0";
            }
            String resolved = "SELECT COUNT(Id) FROM passwords";
            var cmd2 = new MySqlCommand(resolved, conn);
            Int32 resolvedCount = Convert.ToInt32(cmd2.ExecuteScalar());
            if (resolvedCount > 0)
            {
                label7.Text = Convert.ToString(resolvedCount.ToString());
            }
            else
            {
                label7.Text = "0";
            }
            //label20.Text = Convert.ToString((resolvedCount / pendingCount) * 100);
            //Console.WriteLine(Convert.ToString((resolvedCount / pendingCount) * 100));

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersList list = new UsersList();
            list.Show();
            this.Hide();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            //Tickets tickets = new Tickets();
            //tickets.Show();
            //this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            UserInputHD tickets = new UserInputHD();
            tickets.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
