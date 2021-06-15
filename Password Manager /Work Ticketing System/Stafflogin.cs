using MySql.Data.MySqlClient;
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
    public partial class Stafflogin : Form
    {
        public Stafflogin()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtBoxNames.Text = "";
          //  cmbExpertise.Text = "";
            txtBoxPasscode.Text = "";
        }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {

            //database connnection
                MySqlConnection conn = new MySqlConnection(myconnstrng);
                conn.Open();
                string sql = "select * from users where username ='" + txtBoxNames.Text.Trim() +  "' and password ='" + txtBoxPasscode.Text.Trim() + "'";

                 var cmd = new MySqlCommand(sql,conn);
                 MySqlDataReader mdr =cmd.ExecuteReader();
            /*SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);//for executing data reader
            DataTable dt = new DataTable();

            adapter.Fill(dt);*/
            // SqlCommand cmd = conn.CreateCommand();
            //  cmd.CommandText = sql;
            //int result = ((int)cmd.ExecuteScalar());
           
            try
            {
                    if (mdr.Read())
                    {
                        User.UserId = mdr.GetInt32(0);
                        User.Username = mdr.GetString(1);
                        MessageBox.Show(" Logged in Succesfully ", "Welcome");
                        Dashboard hd = new Dashboard();
                        hd.Show();
                        Hide();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect. Check your username and password", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!");
                }
            }
           
        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow.Checked)
            {

                txtBoxPasscode.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxPasscode.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
        }

        private void Stafflogin_Load(object sender, EventArgs e)
        {

        }
    }
}
