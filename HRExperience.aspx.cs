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
    public partial class HRExperience : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            TextBoxCompanyName.Text = "";
            TextBoxPosition.Text = "";
            TextBoxFrom.Text = "";
            TextBoxTo.Text = "";
            TextBoxJobDescription.Text = "";
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            insertnewdata();
        }
        
        public void insertnewdata()
        {
            try
            {
                String companyname = TextBoxCompanyName.Text;
                String position = TextBoxPosition.Text;
                String from = TextBoxFrom.Text;
                String to = TextBoxTo.Text;
                String jobdescription = TextBoxJobDescription.Text;


                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                String sqlQuery = "INSERT INTO HR_Experiences ([HR_ID],[Company_Name],[Position],[From_Year],[To_Year],[Job_Description],[status]) VALUES (@HRID, @companyname, @position, @from, @to, @jobdescription, 1)";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.Parameters.AddWithValue("@companyname", companyname);
                sqlCommand.Parameters.AddWithValue("@position", position);
                sqlCommand.Parameters.AddWithValue("@jobdescription", jobdescription);
                sqlCommand.Parameters.AddWithValue("@from", from);
                sqlCommand.Parameters.AddWithValue("@to", to);
                sqlCommand.Parameters.AddWithValue("@HRID", Session["id"]);

                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("HRProfile.aspx");
                }
                conn.Close();               
                clear();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(e);
            }
        }
    }
}