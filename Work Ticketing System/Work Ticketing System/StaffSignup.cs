using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Work_Ticketing_System.class_folder;

namespace Work_Ticketing_System
{
    public partial class StaffSignup : Form
    {
        public StaffSignup()
        {
            InitializeComponent();
        }
        workticketclass c = new workticketclass();
        public void clear()
        {
            txtEmail.Text = "";
            txtContact.Text = "";
            txtUsername.Text = "";
            //cmbRole
            txtBoxNames.Text = "";
            textBox1.Text = "";
            txtBoxPasscode.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
             c.FullName = txtBoxNames.Text;
             c.Email = txtEmail.Text;
             c.Contact = txtContact.Text;
             c.username = txtUsername.Text;
             c.Passcode =txtBoxPasscode.Text;

            
                 if (txtBoxNames.Text == "")
                 {
                     MessageBox.Show("Please input Two Names", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 }
                 
                 else if (txtBoxPasscode.Text == "")
                 {
                     MessageBox.Show("Password cannot be left blank!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 }

                 else
                 {

                //load data to database
                // DataTable dt = c.select();
                if (c.addStaff(c))
                {
                    MessageBox.Show("Your account has been created successfully!!");
                    //call clear method here
                    clear();
                }
                else
                {
                    MessageBox.Show("An error occured while creating your account!!");
                }

                    
                 }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stafflogin list = new Stafflogin();
            list.Show();
            this.Hide();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void StaffSignup_Load(object sender, EventArgs e)
        {

        }
    }
}
