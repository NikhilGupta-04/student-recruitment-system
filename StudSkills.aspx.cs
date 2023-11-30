using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace student
{
    public partial class StudSkills : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                string sqlQuery = "select skill from stud_skills where skill = '"+ TextBoxSkills.Text +"' and status = 1 and stud_id = '"+Session["id"]+"' ";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                SqlDataReader DR1 =  sqlCommand.ExecuteReader();                                 
                    if (DR1.HasRows)
                    {
                        Label1.Text = "Already Exists*";
                    }
                    else
                    {
                        skills();
                    }
                
                conn.Close();               
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                TextBoxSkills.Text = "";
            }

        }

        public void skills()
        {
            try
            {
                String skill = TextBoxSkills.Text;
                String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                String sqlQuery = "INSERT INTO stud_skills(stud_id,skill,status) values('"+Session["id"]+"','"+skill+"', 1)";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                int i = sqlCommand.ExecuteNonQuery();
                if(i>0)
                {
                    Response.Redirect("StudProfile.aspx");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }        
    }
}