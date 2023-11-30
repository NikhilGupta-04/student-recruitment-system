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
    public partial class StudEducation1 : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            educationdropdown();
            if (!IsPostBack)
            {
                selectdata();
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

        //protected void Btupdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string studID = Request.QueryString["ID"];
        //        SqlConnection conn = new SqlConnection(ConnectionString);
        //        String comm = "update Stud_education set Education_level=@level, Feild_of_study=@study, percentage_aggregate=@percentage where ID = @Id";
        //        SqlCommand Comm1 = new SqlCommand(comm, conn);
        //        conn.Open();

        //        Comm1.Parameters.AddWithValue("@level", TextBoxEducationLevel.Text);
        //        Comm1.Parameters.AddWithValue("@study", TextBoxFeildOfStudy.Text);
        //        Comm1.Parameters.AddWithValue("@percentage", TextBoxPercentage.Text);
        //        Comm1.Parameters.AddWithValue("@Id", studID);
        //        int i = Comm1.ExecuteNonQuery();
        //        if (i > 0)
        //        {
        //            Response.Redirect("StudProfile.aspx");
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //} 

        public void selectdata()
        {
            try
            {
                string studID = Request.QueryString["ID"];
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select Education_level,Feild_of_study,percentage from Stud_education where ID='" + studID + "' ";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    DropDownListEducation.Text = DR1.GetValue(0).ToString();
                    DropDownListStreamhsc.Text = DR1.GetValue(1).ToString();
                    DropDownListStreamSSC.Text = DR1.GetValue(1).ToString();
                    DropDownListStreamDegree.Text = DR1.GetValue(1).ToString();
                    TextBoxPercentage.Text = DR1.GetValue(2).ToString();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}