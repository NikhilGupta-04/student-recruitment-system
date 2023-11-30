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
    public partial class Tchprofile1 : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            label();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxName.Text = "";
            DropDownListGender.Text = "";            
            TextBoxContactno.Text = "";
        }

        public void label()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                String com = "select name, Gender, Phone, Email from Users where id = '" + Session["id"] + "'";
                SqlCommand Comm1 = new SqlCommand(com, Conn);
                Conn.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    TextBoxName.Text = DR1.GetValue(0).ToString();

                    if (DR1.GetValue(1).ToString().Equals(1))
                    {
                        DropDownListGender.Text = "Male";
                    }
                    else
                    {
                        DropDownListGender.Text = "Female";
                    }
                    TextBoxContactno.Text = DR1.GetValue(2).ToString();
                    TextBoxemail.Text = DR1.GetValue(3).ToString();
                }
                Conn.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
            }
        }
    }
}