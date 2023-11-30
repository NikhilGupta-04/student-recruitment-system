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
    public partial class HRExperiences : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                experience();
            }
        }

        public void experience()
        {
            try
            {
                string ExpID = Request.QueryString["ID"];
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select Exp_ID, Company_Name, Position,Job_Description from HR_Experiences where Exp_ID = '" + ExpID + "'  ";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    TextBoxCompanyName.Text = DR1.GetString(1).ToString();
                    TextBoxPosition.Text = DR1.GetString(2).ToString();
                    TextBoxJobDescription.Text = DR1.GetString(3).ToString();
                }
                Conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string ExpID = Request.QueryString["ID"];
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String comm = "update HR_Experiences set Company_Name=@name, Position=@position, From_Year=@from, To_Year=@to, Job_Description=@description where Exp_ID = @Id and status = 1";
                SqlCommand Comm1 = new SqlCommand(comm, Conn);
                Conn.Open();
                Comm1.Parameters.AddWithValue("@name", TextBoxCompanyName.Text);
                Comm1.Parameters.AddWithValue("@position", TextBoxPosition.Text);
                Comm1.Parameters.AddWithValue("@from", TextBoxFrom.Text);
                Comm1.Parameters.AddWithValue("@to", TextBoxTo.Text);
                Comm1.Parameters.AddWithValue("@description", TextBoxJobDescription.Text);
                Comm1.Parameters.AddWithValue("@Id", ExpID);
                int i = Comm1.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("HRProfile.aspx");
                }
                Conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(ex.Message);
            }
        }
    }
}