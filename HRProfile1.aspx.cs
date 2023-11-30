using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace student
{
    public partial class HRProfile1 : System.Web.UI.Page
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(! IsPostBack)
            {
                label();
            }
        }
        public void label()
        {
            SqlConnection Conn = new SqlConnection(ConnectionString);
            String com = "select name, DateOfBirth, Phone, Email, Gender from Users where id = '" + Session["id"] + "'";
            SqlCommand Comm1 = new SqlCommand(com, Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                TextBoxName.Text = DR1.GetValue(0).ToString();
                TextBoxDob.Text = DR1.GetValue(1).ToString();
                TextBoxContactNo.Text = DR1.GetValue(2).ToString();
                TextBoxEmail.Text = DR1.GetValue(3).ToString();
                DropDownListGender.Text = DR1.GetValue(4).ToString();
                
            }
            Conn.Close();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            TextBoxName.Text = "";
            DropDownListGender.Text = "";
            TextBoxEmail.Text = "";
            TextBoxContactNo.Text = "";
            TextBoxDob.Text = "";
        }
        public void updatedetails()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);

                String comm = "update Users set Users.name=@name ,Users.Phone=@phone where Id=@Id";
                SqlCommand Comm1 = new SqlCommand(comm, Conn);
                Conn.Open();
                Comm1.Parameters.AddWithValue("@name", TextBoxName.Text);
                Comm1.Parameters.AddWithValue("@phone", TextBoxContactNo.Text);
                Comm1.Parameters.AddWithValue("@Id", Session["Id"]);
                int i = Comm1.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("HRProfile.aspx");
                    label();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went wrong')</script>");
                //Response.Write(ex.Message);
            }
        }

       
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            updatedetails();
        }

        protected void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            String name = ((TextBox)sender).Text;
            TextBoxName.Text = name;
        }
    }
}