using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;

namespace student
{
    public partial class TchJobs : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tchshowjob();
            }
        }

        public int selectjobid()
        {
             
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Job_ID from Jobs_Post where status =1";
            SqlCommand cmd = new SqlCommand(query, con);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }

        public void tchshowjob()
        {
                int id = selectjobid();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "select  Jobs_Post.Job_ID, Jobs_Post.company_name, Jobs_Post.Job_Title, Jobs_Post.Skills_Required, Jobs_Post.Location, Jobs_Post.Job_Description, Jobs_Post.Department, Jobs_Post.Package, Job_Qualification.education, Job_Qualification.Level_Edu, Job_Qualification.percantage_aggregate from Jobs_Post  join Job_Qualification on Jobs_Post.Job_ID = Job_Qualification.Job_ID where Jobs_Post.status=1";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                SqlDataReader Dr = cmd.ExecuteReader();
                DataListtchjobdisplay.DataSource = Dr;
                DataListtchjobdisplay.DataBind();
                con.Close();
            
        }

        protected void ButtonSendtoStudents_Click(object sender, EventArgs e)
        {
            string jobid = ((Button)sender).CommandArgument;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select send_id from send_job_student1  where Job_Id = '" + jobid + "' and send_status=@status and teacher_id = @id ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Session["id"]);
            cmd.Parameters.AddWithValue("@status", 1);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            SqlDataReader Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Great','Job Already sent to students!', 'info')", true);
            }
            else
            {
                Response.Redirect("TchtoStud.aspx?jobid=" + jobid + "");
            }
            con.Close();
        }
    }
}

//int id = selectjobid();
//SqlConnection con = new SqlConnection(ConnectionString);
//con.Open();
//            string query = "select send_student from Jobs_Post where Job_Id = '" + id + "' and status = 1 ";
//SqlCommand cmd = new SqlCommand(query, con);
//SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
//SqlDataReader Dr = cmd.ExecuteReader();
//            if (Dr.Read())
//            {
//                if (Convert.ToInt32((Dr["send_student"].ToString())) == 1)
//                {
//                    Response.Write("<script> alert('Job Already sended to students.') </script>");
//                }
//                else
//                {
//                    string jobid = ((Button)sender).CommandArgument;
//Response.Redirect("TchtoStud.aspx?jobid=" + jobid + "");
//                }
//            }
//            con.Close();