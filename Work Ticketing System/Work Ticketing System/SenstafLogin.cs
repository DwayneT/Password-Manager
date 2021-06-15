using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Ticketing_System
{
    public partial class SenstafLogin : Form
    {
        public SenstafLogin()
        {
            InitializeComponent();
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public void clear()
        {
            txtBoxStaffNames.Text = "";
            txtBoxSecurityCode.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //database connnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            String uname = txtBoxStaffNames.Text.Trim();
            String pass =txtBoxSecurityCode.Text.Trim();
            string sql = "select * from users where username ='"+uname+ "'and Passcode ='" +pass+"'";
           

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            try
            {
                if (dt.Rows.Count == 1)
                {
                    User.Username = uname;
                    MessageBox.Show(" Logged in Succesfully ", "Welcome :"+""+uname);
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    Hide();
                    clear();
                }
                else
                {
                    MessageBox.Show("Incorrect. Check your username and password", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Error!"+ ex.StackTrace);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                txtBoxSecurityCode.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxSecurityCode.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SenstafLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
