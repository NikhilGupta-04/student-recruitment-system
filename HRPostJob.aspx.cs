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
    public partial class HRPostJob : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyname();
        }

        public void job()
        {
            try
            {
                String jobtittle = TextBoxJobTittle.Text;
                String department = TextBoxDepartment.Text;
                String skillsreq = TextBoxSkillsRequired.Text;
                String package = TextBoxPackage.Text;
                String location = TextBoxLocation.Text;
                String worktype = DropDownListWorkType.Text;
                String jobdescription = TextBoxJobRole.Text;

                String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                String sqlQuery = "INSERT INTO Jobs_Post (Job_Title, Skills_Required, Location, Job_Description, Department, Package, status, HR_ID, company_name) Values ('" + jobtittle + "', '" + skillsreq + "', '" + location + "', '" + jobdescription + "','" + department + "', '" + package + "', '" + 1 + "', '" + Session["id"] + "', '"+TextBoxCompanyName.Text+"')";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                TextBoxJobTittle.Text = "";
                TextBoxDepartment.Text = "";
                TextBoxSkillsRequired.Text = "";
                TextBoxPackage.Text = "";
                TextBoxLocation.Text = "";
                DropDownListWorkType.Text = "";
                TextBoxJobRole.Text = "";
            }
        } 
  
        public void companyname()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select Company_Name from HR_Company where HR_ID= '" + Session["id"] + "'";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    TextBoxCompanyName.Text = DR1["Company_Name"].ToString();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(ex);
            }
        }

        protected void Buttonnext_Click1(object sender, EventArgs e)
        {
            job();
            Response.Redirect("JobQualification.aspx");            
        }
    }
}