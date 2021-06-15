using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Work_Ticketing_System
{
    
    public partial class UsersList : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public UsersList()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInputHD staff = new UserInputHD();
            staff.Show();
            this.Hide();

        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            displayToGrid();
        }

         void displayToGrid()
        {
            using (MySqlConnection conn = new MySqlConnection(myconnstrng))
            {
                // int userId = User.UserId;
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM passwords WHERE user_id='" + User.UserId + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridUsers.DataSource = dt;
            }
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
