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
    public partial class HRProfileCompany1 : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                label();
            }            
        }

        public void label()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select Company_Name,CMMI_Level,bio from HR_Company where HR_ID= '" + Session["id"] + "'";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    TextBoxCurComanyName.Text = DR1["Company_Name"].ToString();

                    DropDownListCmmilevel.Text = DR1["CMMI_Level"].ToString();
                    TextBoxbio.Text = DR1["bio"].ToString();
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        public void updatedatacompany()
        {
            try
            {
                String cmp = TextBoxCurComanyName.Text;
                int level = Convert.ToInt32(DropDownListCmmilevel.Text);
                String bio = TextBoxbio.Text;
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "update HR_Company set  Company_Name='" + cmp + "',CMMI_Level=" + level + ",bio='" + bio + "' where HR_ID=" + Session["id"] + "";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                int t = Comm1.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Redirect("HRProfile.aspx");
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            updatedatacompany();
        }
    }
}