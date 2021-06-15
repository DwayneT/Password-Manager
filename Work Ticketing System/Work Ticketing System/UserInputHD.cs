using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Work_Ticketing_System.class_folder;

namespace Work_Ticketing_System
{
    public partial class UserInputHD : Form
    {
        public UserInputHD()
        {
            InitializeComponent();
            refreshData();

        }

        private void refreshData()
        {
            DataRow dr;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=passwordgenerator;password=");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from passwords",conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            
            conn.Close();
            //throw new NotImplementedException();
        }

        workticketclass c = new workticketclass();
        public void clear()
        {
            txtBoxSiteName.Text = "";
            txtBoxPassword.Text = "";

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            c.site_name = txtBoxSiteName.Text;
            c.generated_password = txtBoxPassword.Text;
            c.userId = User.UserId;

            if (txtBoxSiteName.Text == "")
            {
                MessageBox.Show("Site name cannot be blank!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clear();
            }

            else if (txtBoxPassword.Text == "")
            {
                MessageBox.Show("Create or Generate your password!!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }

            else
            {
                if (c.savePassword(c))
                {
                    MessageBox.Show("Your password has been saved successfully!!");
                    //call clear method here
                    clear();
                }
                else
                {
                    MessageBox.Show("An error occured while saving your password!!");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
            Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
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
            }
        }

        


        private void UserInputHD_Load(object sender, EventArgs e)
        {

        }

        private void lblOther_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void cmbBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbIssues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void UserInputHD_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            Hide();
        }

       public static string Random(int length)
        {
            try
            {
                byte[] result = new byte[length];
                for (int index=0; index < length; index++)
                {
                    result[index] = (byte)new Random().Next(33,126);
                }
                return System.Text.Encoding.ASCII.GetString(result);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            /* try
             {
                 int length = 8;
                 byte[] result = new byte[length];
                 for (int index = 0; index < length; index++)
                 {
                     result[index] = (byte)new Random().Next(33, 126);
                 }
                 txtBoxPassword.Text= System.Text.Encoding.ASCII.GetString(result);

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }*/
            int length = 16;
            const string alphanumericCharacters =
                "ABCDEF" +
                "abcdef" +
                "0123456789";
            txtBoxPassword.Text= ParseUnicodeHex(GetRandomString(length, alphanumericCharacters)); 

        }
        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
        string ParseUnicodeHex(string hex)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < hex.Length; i += 4)
            {
                string temp = hex.Substring(i, 4);
                char character = (char)Convert.ToInt16(temp, 16);
                sb.Append(character);
            }
            return sb.ToString();
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
