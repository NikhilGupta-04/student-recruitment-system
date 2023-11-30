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
    public partial class Tchprofile : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            displaycollege();
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    label();
                    labelcollege();                    
                }
            }
        }

        protected void Buttonedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tchprofile1.aspx");
        }

        protected void Btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("TchCollege.aspx");
        }

        protected void Buttonupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("TchCollege1.aspx");
        }

        public void label()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select name, Gender, Phone, Email from Users where id = '" + Session["id"] + "'";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    Labelname1.Text = DR1.GetValue(0).ToString();

                    if (DR1.GetValue(1).ToString().Equals(1))
                    {
                        LabelGender1.Text = "Male";
                    }
                    else
                    {
                        LabelGender1.Text = "Female";
                    }
                    LabelContactNo1.Text = DR1.GetValue(2).ToString();
                    LabelEmail1.Text = DR1.GetValue(3).ToString();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void displaycollege()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select ID from Teacher_CurCollege where Tch_Id = '"+Session["id"]+"' ";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    if(DR1.HasRows)
                    {
                        Panelcollegebutton.Visible = false;
                        Panelcollegedisplay.Visible = true;
                    }
                }
                else
                {
                    Panelcollegebutton.Visible = true;
                    Panelcollegedisplay.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void labelcollege()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select cur_college_name, Naac_Rating, department, university from Teacher_CurCollege where Tch_Id = '" + Session["id"] + "' and status = 1";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    LabelCollegeName1.Text = DR1.GetValue(0).ToString();
                    LabelNAACRating1.Text = DR1.GetValue(1).ToString();
                    LabelDepartment1.Text = DR1.GetValue(2).ToString();
                    LabelUniversity1.Text = DR1.GetValue(3).ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string collID = ((Button)sender).CommandArgument;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "delete from Teacher_CurCollege  where Tch_Id = '" + Session["id"] + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();           
        }
    }
}