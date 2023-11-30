using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace student
{
    public partial class login : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
                String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                String sqlQuery = "Select * from Users where Email='"+TextBoxEmail.Text+"' and Password='"+ TextBoxPassword.Text+"' ";
                cmd = new SqlCommand(sqlQuery, conn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["id"] = dr.GetInt32(0);
                        Session["roleType"] = dr.GetByte(4);
                    }
                    Response.Redirect("homepage.aspx");
                }

                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Invalid', 'Please Click OK for Relogin', 'info')", true);
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}