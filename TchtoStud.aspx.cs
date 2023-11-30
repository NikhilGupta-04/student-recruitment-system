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
    public partial class TchtoStud : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            studentname();
        }

        public string getteacherclgname(string jid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Users.CollegeName from send_job_student1 join Users on send_job_student1.teacher_id=Users.Id where job_id=@jid";
            string collegeteacher = "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@jid", jid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr.HasRows)
                {
                    collegeteacher = dr["CollegeName"].ToString();
                }
            }
            return collegeteacher;
        }

        public string getteacherclgname()
        {
            string teacherclgname = "";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Teacher_CurCollege.cur_college_name from Teacher_CurCollege where Teacher_CurCollege.Tch_Id=@tchid ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tchid", Session["id"]);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                teacherclgname = dr["cur_college_name"].ToString();
            }
            return teacherclgname;
        }
        public void senjobdata()
        {
            try
            {
                string tclg = getteacherclgname();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "insert into send_job_student1 (job_id,teacher_id,send_status,teacher_clg_name) values(@jid,@tid,@status,@clgname)";
                string jobid = Request.QueryString["jobid"];
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@jid", jobid);
                cmd.Parameters.AddWithValue("@tid", Session["id"]);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.Parameters.AddWithValue("@clgname", tclg);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Great!', 'Job is sent to all students!', 'info')", true);
                    //Response.Write("<script> alert('Job is sended to all students.')</script>");
                    //Response.Redirect("TchJobs.aspx");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(e);
            }
        }
        public void sendjob()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                string sqlQuery = " ";
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Great!', 'Job is sent to all students!', 'info')", true);
                    //Response.Write("<script> alert('Job is sended to all students.')</script>");
                    //Response.Redirect("TchJobs.aspx");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            senjobdata();
        }
            
        public void studentname()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                string sqlQuery = "select Users.name from Users where CollegeName ='" + getcollegename() + "' and RoleType = 3  and status = 1";
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                GridViewJobs.DataSource = sqlCommand.ExecuteReader();
                GridViewJobs.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public string getcollegename()
        {
            string college_name = "";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select CollegeName from Users where id= '" + Session["Id"] + "' and RoleType = 2 ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                college_name = dr["CollegeName"].ToString();
            }
            return college_name;
        }
    }
}


//public void studentname()
//{
//    try
//    {
//        SqlConnection Conn = new SqlConnection(ConnectionString);
//        string sqlQuery = "select Users.name from Users where CollegeName = (select cur_college_name  from Teacher_CurCompany where id = '" + Session["Id"] + "') and RoleType = 3  and status = 1";
//        SqlConnection conn = new SqlConnection(ConnectionString);
//        conn.Open();
//        SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
//        GridViewJobs.DataSource = sqlCommand.ExecuteReader();
//        GridViewJobs.DataBind();
//        conn.Close();
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex);
//    }
//}

//public void studeducation()
//{
//    try
//    { 
//        string college_name =  getcollegename();
//        SqlConnection Conn = new SqlConnection(ConnectionString);
//        string sqlQuery = "SELECT " +
//            "(SELECT Users.Id from Users where CollegeName = '" + college_name + "' and RoleType = 3) AS id,"+
//            "(SELECT Users.name from Users where CollegeName = '" + college_name + "' and RoleType = 3) AS NAME," +
//            "(SELECT SE.percentage_aggregate FROM Users U INNER JOIN Stud_education SE ON U.Id = SE.Student_id AND SE.status = 1 WHERE SE.Education_level = 'SSC') AS SSC_PER," +
//            "(SELECT SE.percentage_aggregate FROM Users U INNER JOIN Stud_education SE ON U.Id = SE.Student_id AND SE.status = 1 " +
//            "WHERE SE.Education_level = 'HSC') AS HSC_PER," +
//            "(SELECT SE.percentage_aggregate FROM Users U INNER JOIN Stud_education SE ON U.Id = SE.Student_id AND SE.status = 1 " +
//            "WHERE SE.Education_level = 'Degree') AS DEGREE_PER";
//        SqlConnection conn = new SqlConnection(ConnectionString);
//        conn.Open();
//        SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
//        GridViewJobs.DataSource = sqlCommand.ExecuteReader();
//        GridViewJobs.DataBind();
//        conn.Close();
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex);
//    }
//}

//public void studeducation()
//{
//    try
//    {
//        int id = insertjobpost();
//        string cn = getcollegename();
//        SqlConnection Conn = new SqlConnection(ConnectionString);
//        string sqlQuery = " SELECT Users.Id,(SELECT Users.name from Users where CollegeName = " + cn + ") AS NAME," +
//            "(SELECT SE.percentage_aggregate FROM Users U INNER JOIN Stud_education SE ON U.Id = SE.Student_id AND SE.status = 1 WHERE SE.Education_level = 'SSC') AS SSC_PER," +
//            "(SELECT SE.percentage_aggregate FROM Users U INNER JOIN Stud_education SE ON U.Id = SE.Student_id AND SE.status = 1 WHERE SE.Education_level = 'HSC') AS HSC_PER, " +
//            "(SELECT SE.percentage_aggregate FROM Users U INNER JOIN Stud_education SE ON U.Id = SE.Student_id AND SE.status = 1 WHERE SE.Education_level = 'Degree') AS DEGREE_PER FROM Users where RoleType = 3";
//        SqlConnection conn = new SqlConnection(ConnectionString);
//        conn.Open();
//        SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
//        GridViewJobs.DataSource = sqlCommand.ExecuteReader();
//        GridViewJobs.DataBind();
//        conn.Close();
//    }
//    catch (Exception ex)
//    {
//        Response.Write(ex);
//    }
//}