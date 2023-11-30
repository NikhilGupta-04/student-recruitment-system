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
    public partial class HRProfile : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                label();
                companylevel();
                experience();
                job();
                showcompany();
            }
           
        }

        protected void Buttonexperiencesupdate_Click(object sender, EventArgs e)
        {
            string expID = ((Button)sender).CommandArgument;
            Response.Redirect("HRExperience1.aspx?ID="+ expID + " ");
        }

        protected void Buttoncomapnyupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRProfileCompany1.aspx");
        }

        protected void Buttoncompanyadd_Click1(object sender, EventArgs e)
        {
            Response.Redirect("HRProfilecompany.aspx");
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRExperience.aspx");
        }

        protected void Buttonedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRProfile1.aspx");

        }

        public void label()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select name, DateOfBirth, Phone, Email, Gender from Users where id = '" + Session["id"] + "'";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    Labelname1.Text = DR1.GetValue(0).ToString();
                    string dob = DR1.GetValue(1).ToString();
                    LabelDob1.Text = DateTime.Parse(dob).ToString("dd-MM-yyyy");
                    LabelContactNo1.Text = DR1.GetValue(2).ToString();
                    LabelEmail1.Text = DR1.GetValue(3).ToString();
                    if (DR1.GetValue(4).ToString().Equals("1"))
                    {
                        LabelGender2.Text = "Male";
                    }
                    else
                    {
                        LabelGender2.Text = "Female";
                    }
                }
                Conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        public void showcompany()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "select Company_ID from HR_Company where HR_ID='" + Session["id"] + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Panelcomapntbutton.Visible = false;
                    Panelcompany.Visible = true;
                }
                else
                {
                    Panelcomapntbutton.Visible = true;
                    Panelcompany.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }                

        public void companylevel()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select Company_Name,CMMI_Level,BIo from HR_Company where HR_ID = '" + Session["id"] + "' and status = 1";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    Label1CompanyName1.Text = DR1.GetValue(0).ToString();
                    LabelCMMIlevel1.Text = DR1.GetValue(1).ToString();
                    LabelBio1.Text = DR1.GetValue(2).ToString();
                }
                Conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        public void experience()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select Company_Name,Exp_ID,Position,From_Year,To_Year,Job_Description from HR_Experiences where HR_ID = '" + Session["id"] + "' and status = 1 ";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    DataListWorkExperiences.DataSource = DR1;
                    DataListWorkExperiences.DataBind();

                    PanelWorkExperiences.Visible = true;
                }
                Conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string expID = ((Button)sender).CommandArgument;
                SqlConnection con = new SqlConnection(ConnectionString);
                string query = "UPDATE HR_Experiences SET status= 0 where Exp_ID =" + expID + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    PanelWorkExperiences.Visible = false;
                    experience();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        protected void Buttondetelet_Click(object sender, EventArgs e)
        {
            try
            {
                string compID = ((Button)sender).CommandArgument;
                SqlConnection con = new SqlConnection(ConnectionString);
                string query = "UPDATE HR_Company SET status = 0 where HR_ID = " + Session["id"] + " ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Panelcompany.Visible = false;
                    Panelcomapntbutton.Visible = true;

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }
        
        protected void Buttondeletequalification_Click(object sender, EventArgs e)
        {
            try
            {
                string jobid = ((Button)sender).CommandArgument;
                SqlConnection con = new SqlConnection(ConnectionString);
                string query = "UPDATE Jobs_Post SET status = 0 where Job_ID = '" + jobid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("HRProfile.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        public void showjob()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "select Job_ID from Jobs_Post where HR_ID='" + Session["id"] + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        public void job()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select  Jobs_Post.Job_ID, Jobs_Post.Job_Title, Jobs_Post.Skills_Required, Jobs_Post.Location, Jobs_Post.Job_Description, Jobs_Post.Department, Jobs_Post.Package, Job_Qualification.education, Job_Qualification.Level_Edu, Job_Qualification.percantage_aggregate from Jobs_Post  join Job_Qualification on Jobs_Post.Job_ID = Job_Qualification.Job_ID where Jobs_Post.HR_ID = '" + Session["id"] + "' and Jobs_Post.status=1";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    DataListjobpost.DataSource = DR1;
                    DataListjobpost.DataBind();
                }
                Conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        protected void ButtonApplication_Click(object sender, EventArgs e)
        {
            string jobid = ((Button)sender).CommandArgument;
            Response.Redirect("HRJobApplication.aspx?jobid="+ jobid +"");
        }
    } 
}