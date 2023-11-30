using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace student
{
    public partial class homepage : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ContactUs()
        {
            try
            {
                String name = txtname.Text;
                String email = txtEmail.Text;
                String message = txtmsg.Text;
              
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                String sqlQuery = "INSERT INTO Contact_Us ([Name],[Email],[Message]) VALUES (@name, @email, @msg)";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@msg", message);
                sqlCommand.ExecuteNonQuery();
                conn.Close();                
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(e);
            }
            finally
            {
                txtname.Text = "";
                txtEmail.Text = "";
                txtmsg.Text = "";
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            ContactUs();
        }
    }
}