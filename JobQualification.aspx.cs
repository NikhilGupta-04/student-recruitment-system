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
    public partial class JobQualification : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int insertjobpost()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select MAX(Job_ID) from Jobs_Post";
            SqlCommand cmd = new SqlCommand(query, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        public void educationjob()
        {
            try
            {
                int id = insertjobpost();
                string edu = DropDownListEducation.Text;
                int level = 0;
                if (DropDownListlevel.Text.Equals("Above"))
                {
                    level = 1;
                }
                else
                {
                    level = 2;
                }
                string marks = DropDownListPercentage.Text;

                String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                string sqlQuery = "insert into Job_Qualification (HR_ID, Job_ID, education, Level_Edu, percantage_aggregate, status) values(" + Session["id"] + ", " + id + ", '" + edu + "', '" + level + "', '" + marks + "', 1 )";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                int i = sqlCommand.ExecuteNonQuery();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DropDownListEducation.SelectedIndex = 0;
                DropDownListlevel.SelectedIndex = 0;
                DropDownListPercentage.SelectedIndex = 0;
            }
        }

        protected void BtPost_Click(object sender, EventArgs e)
        {
            educationjob();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Great!', 'Job Posted!', 'success')", true);
        }
    }
}