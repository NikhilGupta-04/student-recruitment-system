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
    public partial class TchCollege : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            string name = TextBoxCurCollegeName.Text;
            string rate = DropDownListNAACRating.Text;
            string department = TextBoxDepartment.Text;
            string university = TextBoxUniversityName.Text;

            SqlConnection Conn = new SqlConnection(ConnectionString);
            String sqlQuery = "insert into Teacher_CurCollege([Tch_Id],[cur_college_name],[Naac_Rating],[status],[department],[university]) values(@tchId, @name, @rate, 1, @department, @university)";
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
            sqlCommand.Parameters.AddWithValue("@name", name.ToLower());
            sqlCommand.Parameters.AddWithValue("@rate", rate);
            sqlCommand.Parameters.AddWithValue("@department", department);
            sqlCommand.Parameters.AddWithValue("@university", university);
            sqlCommand.Parameters.AddWithValue("@tchId", Session["Id"]);

            int i = sqlCommand.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Redirect("Tchprofile.aspx");
            }
            conn.Close();
        }
    }
}