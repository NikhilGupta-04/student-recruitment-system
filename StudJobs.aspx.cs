using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace student
{
    public partial class StudJobs : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showapply();
            }              
        }

        public string getstudcollegename()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select CollegeName from Users where Id=@id";
            string collegestudent = "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Session["id"]);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.HasRows)
                {
                    collegestudent = dr["CollegeName"].ToString();
                }
            }
            return collegestudent;
        }
       
        public void showapply()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "select  Jobs_Post.Job_ID, Jobs_Post.company_name, Jobs_Post.Job_Title, Jobs_Post.Skills_Required, Jobs_Post.Location, Jobs_Post.Job_Description,Jobs_Post.Department, Jobs_Post.Package, Job_Qualification.education, Job_Qualification.Level_Edu, Job_Qualification.percantage_aggregate from Jobs_Post join Job_Qualification on Jobs_Post.Job_ID = Job_Qualification.Job_ID join send_job_student1 on send_job_student1.job_id = Jobs_Post.Job_ID where Jobs_Post.status = 1 and send_job_student1.send_status =1 and send_job_student1.teacher_clg_name=@stud ";
                string clgname = getstudcollegename();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@stud", clgname );

                SqlDataReader Dr = cmd.ExecuteReader();
                if (Dr.Read())
                {
                    DataListstudaplly.DataSource = Dr;
                    DataListstudaplly.DataBind();
                }
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(e);
            }
        }

        public decimal getstudentpercentage()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select percentage_aggregate from Stud_education where Student_id = '" + Session["id"] + "' and Education_level = 'Degree'";
            SqlCommand cmd = new SqlCommand(query, con);
            decimal i = Convert.ToDecimal(cmd.ExecuteScalar().ToString());
            return i;
        }

        public decimal getjobpercentage(string jid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select percantage_aggregate from Job_Qualification where Job_ID = '" + jid + "' and education = 'Degree'";
            SqlCommand cmd = new SqlCommand(query, con);
            decimal i = Convert.ToDecimal(cmd.ExecuteScalar().ToString());
            return i;
        }
        
        public void applyjob(string jid)
        {
            try
            {
                decimal x = getstudentpercentage();
                decimal y = getjobpercentage(jid);
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                if (x >= y)
                {
                    SqlConnection con = new SqlConnection(ConnectionString);
                    con.Open();
                    string query = "insert into Applied_Students(job_ID, student_ID, applied_date, status) values(@jid,@studid,@date, @status)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@jid", jid);
                    cmd.Parameters.AddWithValue("@studid", Session["id"]);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@status", 1);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Successfully!', 'Job Applied!', 'success')", true);
                        //Response.Write("<script> alert('Job Applied Successfully.') </script>");
                        sendemail(jid);
                    }
                    con.Close();
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Sorry!', 'Your eligibility is revoked due to insufficient degree marks!', 'info')", true);
                    //Response.Write("<script> alert('Your eligibility is revoked due to insufficient degree marks.') </script>");                
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }
        
        public void sendemail(string jid)

        {
            string email = "";
            string comapnyname = "";
            string jobtitle = "";
            string applydate = "";
            string studname = "";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Users.Email, Jobs_Post.Job_Title,Users.name,Jobs_Post.company_name,Applied_Students.applied_date, Applied_Students.status from Applied_Students join Users on  Applied_Students.student_ID = Users.Id join Jobs_Post on Applied_Students.job_ID = Jobs_Post.Job_ID where Applied_Students.student_ID = @id and Applied_Students.job_ID =@jid ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Session["id"]);
            cmd.Parameters.AddWithValue("@jid", jid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                email = dr["Email"].ToString();
                jobtitle = dr["Job_Title"].ToString();
                comapnyname = dr["company_name"].ToString();
                applydate = dr["applied_date"].ToString();
                studname = dr["name"].ToString();
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("studentsrecruiitmentsystem@gmail.com", "qxvrvxcueicdmayb");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Applied Job_Details";
            msg.Body = "Dear " + studname + ",\n\nCongratulations!\n" +
                "Your Job Application for the Post of " + jobtitle + "  in" +
                " Company " + comapnyname + " has been received successfully.\n\n" +
                 "We value your interest in a career " + comapnyname + ", and" +
                " if you are chosen to move forward in the hiring process, " +
                "\nwe will get in touch with you.\n\nGratitude for applying!\n\nSRS";
            string toaddress = email;
            msg.To.Add(toaddress);
            string fromaddress = "SRS <studentsrecruiitmentsystem@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            con.Close();
            try
            {
                smtp.Send(msg);
            }
            catch
            {
                throw;
            }
        }

        protected void Buttonapply_Click(object sender, EventArgs e)
        {
            string jid = ((Button)sender).CommandArgument;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select ID from Applied_Students where student_ID = '" + Session["id"] + "' and job_ID = '" + jid + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Great!', 'You Have Already Applied for this Job!', 'info')", true);
                //Response.Write("<script> alert('You Have Already Applied for this Job') </script>");
            }
            else
            {
                applyjob(jid);
            }
        }
    }
}

//public string getmail()
//{
//	//SqlConnection con = new SqlConnection(ConnectionString);
//	//con.Open();
//	//string query = "select Email from Users where Id='" + Session["id"] + "' ";
//	//SqlCommand cmd = new SqlCommand(query, con);
//	//SqlDataReader dr = cmd.ExecuteReader();
//	//string email = dr.ToString();
//	//return email;
//}

//public void checkcollegename(string jid)
//{
//    string studcollege = getstudcollegename();
//    string teachercollege = getteacherclgname(jid);
//    if (studcollege == teachercollege)
//    {
//        showapply();
//    }
//    else
//    {
//        Response.Write();
//    }

//}


//string query = "select  Jobs_Post.Job_ID, Jobs_Post.company_name, Jobs_Post.Job_Title,Jobs_Post.Skills_Required, Jobs_Post.Location, Jobs_Post.Job_Description,Jobs_Post.Department, Jobs_Post.Package, Job_Qualification.education,Job_Qualification.Level_Edu, Job_Qualification.percantage_aggregate from Jobs_Post join Job_Qualification on Jobs_Post.Job_ID = Job_Qualification.Job_ID join send_job_student1 on send_job_student1.job_id = Jobs_Post.Job_ID where Jobs_Post.status = 1 and send_job_student1.send_status = 1 ";

//public string getteachercollegename()
//{
//	SqlConnection con = new SqlConnection(ConnectionString);
//	con.Open();
//	string query = "select CollegeName from User where Id=@id";

//	string collegestudent = "";
//	SqlCommand cmd = new SqlCommand(query, con);
//	cmd.Parameters.AddWithValue("@id", Session["id"]);
//	SqlDataReader dr = cmd.ExecuteReader();
//	if (dr.Read())
//	{
//		if (dr.HasRows)
//		{
//			collegestudent = dr["CollegeName"].ToString();
//		}
//	}
//	return collegestudent;
//}
//public string getteacherclgname(string jid)
//{
//    SqlConnection con = new SqlConnection(ConnectionString);
//    con.Open();
//    string query = "select Teacher_CurCollege.cur_college_name from send_job_student1 join Teacher_CurCollege on Teacher_CurCollege.Tch_Id=send_job_student1.teacher_id where job_id=@jid";

//    string collegeteacher = "";
//    SqlCommand cmd = new SqlCommand(query, con);
//    cmd.Parameters.AddWithValue("@jid", jid);
//    SqlDataReader dr = cmd.ExecuteReader();
//    if (dr.Read())
//    {
//        if (dr.HasRows)
//        {
//            collegeteacher = dr["CollegeName"].ToString();
//        }
//    }
//    return collegeteacher;
//}

//public void applyjob(object sender, EventArgs e)
//{
//    string jobid = ((Button)sender).CommandArgument;
//    decimal x = getstudentpercentage();
//    decimal y = getjobpercentage(jobid);
//    string date = DateTime.Now.ToString("yyyy-MM-dd");
//    if (x >= y)
//    {
//        SqlConnection con = new SqlConnection(ConnectionString);
//        con.Open();
//        string query = "insert into Applied_Students(job_ID, student_ID, applied_date, status) values('" + jobid + "', '" + Session["id"] + "','" + date + "', 1)";
//        SqlCommand cmd = new SqlCommand(query, con);
//        int i = cmd.ExecuteNonQuery();
//        if (i > 0)
//        {
//            Response.Write("<script> alert('Job Applied Successfully.') </script>");
//            Response.Redirect("StudProfile.aspx");
//        }
//        con.Close();
//    }
//    else
//    {
//        Response.Write("<script> alert('Your eligibility is revoked due to insufficient degree marks.') </script>");
//        Response.Redirect("StudProfile.aspx");
//    }
//}

//protected void Buttonapply_Click(object sender, EventArgs e)
//{
//    string jobid = ((Buttochehcn)sender).CommandArgument;
//    SqlConnection con = new SqlConnection(ConnectionString);
//    con.Open();
//    string query = "select ID from Applied_Students where student_ID = '" + Session["id"] + "' and job_ID = '" + jobid + "' ";
//    SqlCommand cmd = new SqlCommand(query, con);
//    SqlDataReader dr = cmd.ExecuteReader();
//    if (dr.HasRows)
//    {
//        applyjob();
//    }
//    else
//    {
//        Response.Write("<script> alert('You Have Already Applied for this Job') </script>");
//    }
//}
