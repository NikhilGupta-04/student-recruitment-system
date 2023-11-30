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
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Labelemail.Text = "";
        }

        public void SignUpButtonClick(object sender, EventArgs e)
        {
            String name = TextBoxName.Text;
            String dob = TextBoxDob.Text;
            String email = TextBoxEmail.Text;
            String phone = TextBoxPhoneNo.Text;
            int profession = 0;
            int gender = 0;
            String password = TextBoxPassword.Text;
            try
            {
               
                String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                String query = "select Email from Users where Email='" + email + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Labelemail.Text = "Email Already Exists ";
                }
                else
                {
                    insertdata();
                    clear();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public void insertdata()
        {
            String name = TextBoxName.Text;
            String dob = TextBoxDob.Text;
            String email = TextBoxEmail.Text;
            String phone = TextBoxPhoneNo.Text;
            int profession = 0;
            int gender = 0;
            String password = TextBoxPassword.Text;

            String ConnectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
            String sqlQuery = "INSERT INTO Users ([name],[Password],[Gender],[RoleType],[Email],[DateOfBirth],[Phone],[status]) VALUES (@name, @Password,@Gender,@Roletype,@Email,@DOB,@Phone,1)";
            SqlConnection conn = new SqlConnection(ConnectionString);
            if (DropDownListGender.Text.Equals("Male"))
            {
                gender = 1;
            }
            else if (DropDownListGender.Text.Equals("Female"))
            {
                gender = 2;
            }
            else
            {
                gender = 3;
            }


            if (DropDownListprofession.Text.Equals("HR"))
            {
                profession = 1;
            }
            else if (DropDownListprofession.Text.Equals("Teacher"))
            {
                profession = 2;
            }
            else
            {
                profession = 3;
            }
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            sqlCommand.Parameters.AddWithValue("@Gender", gender);
            sqlCommand.Parameters.AddWithValue("@Roletype", profession);
            sqlCommand.Parameters.AddWithValue("@Email", email);
            sqlCommand.Parameters.AddWithValue("@DOB", dob);
            sqlCommand.Parameters.AddWithValue("@Phone", phone);

            sqlCommand.ExecuteNonQuery();
            conn.Close();
            clear();
          

            Response.Redirect("login.aspx");
        }
        public void clear()
        {
            TextBoxName.Text = "";
            TextBoxDob.Text = "";
            TextBoxEmail.Text = "";
            TextBoxPhoneNo.Text = "";
            TextBoxPassword.Text = "";
        }
    }
}
 