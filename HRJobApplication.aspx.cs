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
    public partial class HRJobApplication : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        private string cv;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                getname();
            }
        
        public void getname()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                string jobid = Request.QueryString["jobid"];
                String sqlQuery = "select Users.Id, Users.name,resume_path,Users.CollegeName from Applied_Students join Users on Users.Id = Applied_Students.student_ID " +
                    "where Applied_Students.job_ID = @jobid and Applied_Students.status = @status";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.Parameters.AddWithValue("@jobid", jobid);
                sqlCommand.Parameters.AddWithValue("@status", 1);

                SqlDataReader dr = sqlCommand.ExecuteReader();
                //string name = dr["name"].ToString();
                //string collegename = dr["CollegeName"].ToString();
                GridViewApplication.DataSource = dr;
                GridViewApplication.DataBind();
                conn.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(e);
            }
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    SqlConnection Conn = new SqlConnection(ConnectionString);
        //    Conn.Open();
        //    string sqlQuery = "select resume_path from Users join Applied_Students on student_ID = Users.Id ";
        //    SqlCommand Comm1 = new SqlCommand(sqlQuery, Conn);
        //    SqlDataReader DR1 = Comm1.ExecuteReader();            
        //    Conn.Close();            
        //}

        protected void GridViewApplication_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void GridViewApplication_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "resume")
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //    SqlConnection Conn = new SqlConnection(ConnectionString);
            //    Conn.Open();
              
            //    string sqlQuery = "select resume_path from Users where id = '"+rowIndex + "' ";
            //    SqlCommand Comm1 = new SqlCommand(sqlQuery, Conn);
            //    SqlDataReader DR1 = Comm1.ExecuteReader();
            //    if (DR1.Read())
            //    {
            //        cv = DR1.GetValue(0).ToString();
            //    }
            //    Conn.Close();
            //    var filePath = cv;
            //    Response.ContentType = "application/octet-stream";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + cv);
            //    Response.TransmitFile(filePath);
            //}
        }

        
    }
}