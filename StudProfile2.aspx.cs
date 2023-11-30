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
    public partial class StudProfile2 : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               label();
            }
        }

        public void clear()
        {
            TextBoxName.Text = "";
            DropDownListGender.Text = "";
            TextBoxDOB.Text = "";
            TextBoxContactNo.Text = "";
            TextBoxUniversityName.Text = "";
            TextBoxCollegeName.Text = "";
        }

        public void label()
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            String com = "select name, DateOfBirth, Phone, Gender, University, CollegeName from Users where id = '" + Session["id"] + "'";
            SqlCommand Comm1 = new SqlCommand(com, Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                TextBoxName.Text = DR1.GetValue(0).ToString();
                string dob = DR1.GetValue(1).ToString();
                TextBoxDOB.Text = DateTime.Parse(dob).ToString("dd-mm-yyyy");
                TextBoxContactNo.Text = DR1.GetValue(2).ToString();
                DropDownListGender.Text = DR1.GetValue(3).ToString();
                TextBoxUniversityName.Text = DR1.GetValue(4).ToString();
                TextBoxCollegeName.Text = DR1.GetValue(5).ToString();
            }
            Conn.Close();
        }

        protected void Buttonupdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                String comm = "update Users set Users.name=@name, Users.phone=@phone, Users.University=@university, Users.CollegeName=@collegeName where Id=@ID";
                SqlCommand Comm1 = new SqlCommand(comm, conn);
                conn.Open();
                Comm1.Parameters.AddWithValue("@name", TextBoxName.Text);
                Comm1.Parameters.AddWithValue("@phone", TextBoxContactNo.Text);
                Comm1.Parameters.AddWithValue("@university", TextBoxUniversityName.Text);
                Comm1.Parameters.AddWithValue("@collegeName", TextBoxCollegeName.Text.ToLower());
                Comm1.Parameters.AddWithValue("@Id", Session["Id"]);
                int i = Comm1.ExecuteNonQuery();
                if (i > 0)
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

        protected void Buttonreset_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}