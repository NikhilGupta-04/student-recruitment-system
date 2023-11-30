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
    public partial class HRProfilecompany : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        public void insertnew()
        {
            try
            {
                String cmp = TextBoxCurComanyName.Text;
                int level = Convert.ToInt32(DropDownListCmmilevel.Text);
                String bio = TextBoxbio.Text;

                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();

                String sqlQuery = "INSERT INTO HR_Company([HR_ID],[Company_Name],[CMMI_Level],[Bio],[status]) VALUES(@HRID, @cmp, @level,@bio, 1)";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);

                sqlCommand.Parameters.AddWithValue("@cmp", cmp);
                sqlCommand.Parameters.AddWithValue("@level", level);
                sqlCommand.Parameters.AddWithValue("@bio", bio);
                sqlCommand.Parameters.AddWithValue("@HRID", Session["id"]);

                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        protected void BtnUpdate_Click1(object sender, EventArgs e)
        {
            insertnew();
        }
    }
}