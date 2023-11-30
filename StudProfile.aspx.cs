using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace student
{
    public partial class StudProfile : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        private string cv;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("login.aspx");

            }
            else
            {
                if (!Page.IsPostBack)
                {
                    label();
                    education();
                    studskill();
                    showjobsstudent();
                    showresume();
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudEducation.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudSkills.aspx");
        }

        protected void Buttonedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudProfile2.aspx");
        }

        public void showjobsstudent()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "select  Jobs_Post.Job_ID, Jobs_Post.company_name,Jobs_Post.Job_Title, " +
                    "Jobs_Post.Skills_Required, Jobs_Post.Location,Jobs_Post.Job_Description, Jobs_Post.Department," +
                      " Jobs_Post.Package, Job_Qualification.education, Job_Qualification.Level_Edu," +
                " Job_Qualification.percantage_aggregate from Jobs_Post join Job_Qualification on Jobs_Post.Job_ID = Job_Qualification.Job_ID join Applied_Students " +
                  "on Applied_Students.job_ID = Jobs_Post.Job_ID where Applied_Students.status = 1 and student_ID =' " + Session["id"] + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                SqlDataReader Dr = cmd.ExecuteReader();
                DataListstudjobdisplay.DataSource = Dr;
                DataListstudjobdisplay.DataBind();
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(e);
            }
        }

        public void label()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select name,Gender, DateOfBirth, Phone, University, CollegeName from Users where id = '" + Session["id"] + "'";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    Labelname1.Text = DR1.GetValue(0).ToString();
                    if (DR1.GetValue(1).ToString().Equals("1"))
                    {
                        LabelGender1.Text = "Male";
                    }
                    else
                    {
                        LabelGender1.Text = "Female";
                    }
                    string dob = DR1.GetValue(2).ToString();
                    LabelDateofbirth1.Text = DateTime.Parse(dob).ToString("yyyy-MM-dd");
                    LabelContactNo1.Text = DR1.GetValue(3).ToString();
                    LabelUniversity1.Text = DR1.GetValue(4).ToString();
                    LabelCollegeName1.Text = DR1.GetValue(5).ToString();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(ex.Message);
            }
        }

        public void education()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select ID, Education_level , Feild_of_study, percentage_aggregate from Stud_education where Student_id = '" + Session["id"] + "' and status = 1";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    DataListstudeducation.DataSource = DR1;
                    DataListstudeducation.DataBind();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(ex.Message);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string studID = ((Button)sender).CommandArgument;
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = "UPDATE Stud_education SET status= 0 where ID =" + studID + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Paneleducation.Visible = true;
                education();
            }
        }

        protected void Btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudEducation.aspx");
        }

        public void studskill()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                string query = "select skill from stud_skills where stud_id = '" + Session["id"] + "' and status = 1";
                SqlCommand Comm1 = new SqlCommand(query, Conn);
                Conn.Open();
                GridViewSkills.DataSource = Comm1.ExecuteReader();
                GridViewSkills.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(ex.Message);
            }
        }

        protected void GridViewSkills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                string skills = GridViewSkills.Rows[rowIndex].Cells[0].Text;
                SqlConnection Conn = new SqlConnection(ConnectionString);
                string query = "update stud_skills set status=0 where stud_id = '" + Session["id"] + "' and skill='" + skills + "' ";
                SqlCommand Comm1 = new SqlCommand(query, Conn);
                Conn.Open();
                int i = Comm1.ExecuteNonQuery();
                if (i > 0)
                {
                    studskill();
                }
            }
        }

        protected void buttonupdateeducation_Click(object sender, EventArgs e)
        {
            string studID = ((Button)sender).CommandArgument;
            Response.Redirect("StudEducation1.aspx?ID=" + studID + " ");
        }

        protected void GridViewSkills_RowDeleted(object sender, GridViewDeletedEventArgs e)

        {

        }

        protected void Buttoncvsave_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("./cv_upload/" + Session["id"].ToString() + "/");
            // Retrieve the name of the file that is posted.
            strFileName = FileUpload1.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (FileUpload1.FileName != "")
            {
                // Create the folder if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    //lblUploadResult.Text = strFileName + " already exists on the server!";
                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(strFilePath);
                    SqlConnection Conn = new SqlConnection(ConnectionString);
                    Conn.Open();
                    string newFilePath = "cv_upload/" + Session["id"].ToString() + "/" + strFileName;
                    string sqlQuery = "update Users set resume_path = '" + newFilePath + "' where Id='" + Session["id"] + "' ";
                    SqlCommand Comm1 = new SqlCommand(sqlQuery, Conn);
                    Comm1.ExecuteNonQuery();
                    Conn.Close();
                }
            }
            else
            {

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                string sqlQuery = "select resume_path from Users where id = '" + Session["id"] + "' ";
                SqlCommand Comm1 = new SqlCommand(sqlQuery, Conn);
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    cv = DR1.GetValue(0).ToString();
                }
                Conn.Close();
                var filePath = cv;
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + cv);
                Response.TransmitFile(filePath);
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        public void showresume()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                string sqlQuery = "select resume_path from Users where id = " + Session["id"] + " ";
                SqlCommand cmd = new SqlCommand(sqlQuery, Conn);
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                Conn.Open();
                string sqlQuery = "update Users set resume_path=NULL from Users where Id='" + Session["id"] + "' ";
                SqlCommand cmd = new SqlCommand(sqlQuery, Conn);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    //Response.Write("<script>alert('Cv is deleted')</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('warning', 'CV is deleted', 'warning')", true);
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }
    }
}