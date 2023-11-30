using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace student
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void chehcemail()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                String sqlQuery = "SELECT   Email from Users where EMAIL='" + TextBoxEmail.Text + "' ";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                SqlDataReader DR = sqlCommand.ExecuteReader();
                if (DR.Read())
                {
                    if (DR.HasRows)
                    {
                        updatepass();
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Invalid', 'Please Click OK for Relogin', 'info')", true);
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        public void updatepass()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                String sqlQuery = "update Users set Password='" + TextBox1.Text + "' where EMAIL='" + TextBoxEmail.Text + "' ";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Successfully', 'Your password is Updated', 'success')", true);
                    Response.Write("<script>alert('')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            chehcemail();
        }
    }
}