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
    public partial class StudEducation : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            educationdropdown();
        }

        protected void Btsave_Click(object sender, EventArgs e)
        {
            try
            {
                String edlevel = DropDownListEducation.SelectedValue;
                String feildofstudy = "";
                if (edlevel == "HSC")
                {
                     feildofstudy = DropDownListStreamhsc.SelectedValue;
                }
                else if (edlevel == "SSC")
                {
                     feildofstudy = DropDownListStreamSSC.SelectedValue;
                }
                else if (edlevel == "Degree")
                {
                     feildofstudy = DropDownListStreamDegree.SelectedValue;
                }
                String percentage = TextBoxPercentage.Text;
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                String sqlQuery = "INSERT INTO Stud_education(Student_id, Education_level, Feild_of_study, percentage_aggregate, status) VALUES('" + Session["id"] + "', '" + edlevel + "', '" + feildofstudy + "', '" + percentage + "' , 1)";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                int i = sqlCommand.ExecuteNonQuery();
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

        public void educationdropdown()
        {
            if (DropDownListEducation.SelectedValue.Equals(""))
            {
                PanelStreamHSC.Visible = false;
                PanelStreamSSC.Visible = false;
                PanelStreamDegree.Visible = false;
            }
            else if (DropDownListEducation.SelectedValue.Equals("HSC"))
            {
                PanelStreamHSC.Visible = true;
                PanelStreamSSC.Visible = false;
                PanelStreamDegree.Visible = false;
            }
            else if (DropDownListEducation.SelectedValue.Equals("SSC"))
            {
                PanelStreamSSC.Visible = true;
                PanelStreamHSC.Visible = false;
                PanelStreamDegree.Visible = false;
            }
            else
            {
                PanelStreamDegree.Visible = true;
                PanelStreamHSC.Visible = false;
                PanelStreamSSC.Visible = false;
            }
        }
    }
}