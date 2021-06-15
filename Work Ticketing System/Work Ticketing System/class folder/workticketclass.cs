using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_Ticketing_System.class_folder
{
    class workticketclass
    {

        //getter and setter properties
        //Acts as data carriers in our application
        public int id { get; set; }
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Passcode { get; set; }

        public string site_name { get; set; }
        public string generated_password { get; set; }
        
        public string username { get; set; }

        public int userId { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;        
        public DataTable selectUserPasswords()
        {
            //database connnection
                MySqlConnection conn = new MySqlConnection(myconnstrng);
                DataTable dtHD = new DataTable();
                try
                {
                    //writing sql query
                    string sql = "SELECT * FROM passwords";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dtHD);
                }
                catch (Exception )
                {

                }
                finally
                {
                    conn.Close();
                }
                return dtHD;
            }
        
       
       public bool addStaff(workticketclass c)
       {
           bool isSuccess = false;
           MySqlConnection conn = new MySqlConnection(myconnstrng);
           try
           {        
                   //sql query to add data
                   string sql = "INSERT INTO users(name,email,contact,username,password) VALUES(@name,@email,@contact,@username,@password)";
                   MySqlCommand cmd = new MySqlCommand(sql, conn);
                   //create parameters to add data
                   cmd.Parameters.AddWithValue("@name", c.FullName);
                   cmd.Parameters.AddWithValue("@email", c.Email);
                   cmd.Parameters.AddWithValue("@contact", c.Contact);
                  
                   cmd.Parameters.AddWithValue("@username", c.username);
                   cmd.Parameters.AddWithValue("@password", c.Passcode);

                   //open connection
                   conn.Open();
                   int rows = cmd.ExecuteNonQuery();
                   if (rows > 0)
                   {
                       isSuccess = true;
                   }
                   else
                   {
                       isSuccess = false;
                   }
               }
           catch (Exception e)
           {
                Console.WriteLine(e.ToString());
           }
           finally
           {
               conn.Close();
           }
           return isSuccess;
       }


        public bool savePassword(workticketclass c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                //sql query to add data
                string sql = "INSERT INTO passwords(user_id,site_name,generated_password) VALUES(@user_id,@site_name,@generated_password)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //create parameters to add data
                cmd.Parameters.AddWithValue("@user_id", c.userId);
                cmd.Parameters.AddWithValue("@site_name", c.site_name);
                cmd.Parameters.AddWithValue("@generated_password", c.generated_password);
                //open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }



        public bool Delete(workticketclass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //sql to delete data
                string sql = "DELETE FROM passwords WHERE id = @id";

                //sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add value
               // cmd.Parameters.AddWithValue("@Ticket_No", c.ticket_id);

                //open database connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }

}

