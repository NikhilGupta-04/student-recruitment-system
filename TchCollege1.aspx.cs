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
    public partial class TchCollege1 : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                labelcollege();
            }
        }

        public void labelcollege()
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            String com = "select cur_college_name, Naac_Rating, department, university from Teacher_CurCompany  where Tch_Id = '" + Session["id"] + "' and status = 1";
            SqlCommand Comm1 = new SqlCommand(com, Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                TextBoxCurCollegeName.Text = DR1.GetValue(0).ToString();
                DropDownListNAACRating.Text = DR1.GetValue(1).ToString();
                TextBoxDepartment.Text = DR1.GetValue(2).ToString();
                TextBoxUniversityName.Text = DR1.GetValue(3).ToString();
            }
        }

        protected void Buttoncancel_Click(object sender, EventArgs e)
        {
            TextBoxCurCollegeName.Text = "";
            DropDownListNAACRating.Text = "";
            TextBoxDepartment.Text = "";
            TextBoxUniversityName.Text = "";

            Response.Redirect("Tchprofile.aspx");
        }

        protected void Btnupdate_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                String comm = "update Teacher_CurCompany set cur_college_name=@curname, Naac_Rating=@rating, department=@department, university=@university where Id=@ID and status = 1";
                SqlCommand Comm1 = new SqlCommand(comm, conn);
                conn.Open();
                Comm1.Parameters.AddWithValue("@curname", TextBoxCurCollegeName.Text);
                Comm1.Parameters.AddWithValue("@rating", DropDownListNAACRating.Text);
                Comm1.Parameters.AddWithValue("@department", TextBoxDepartment.Text);
                Comm1.Parameters.AddWithValue("@university", TextBoxUniversityName.Text);
                Comm1.Parameters.AddWithValue("@Id", Session["Id"]);
                int i = Comm1.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("Tchprofile.aspx");
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