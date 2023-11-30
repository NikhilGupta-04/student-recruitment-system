using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace student
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public Boolean isUserLoggedIn = false;
        public Boolean isHrLoggedIn = false;
        public Boolean isTeacherLoggedIn = false;
        public Boolean isStudentLoggedIn = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                isUserLoggedIn = false;
            } else
            {
                isUserLoggedIn = true;
                String roleType = Session["roleType"].ToString();
                //hr
                if (roleType.Equals("1"))
                {
                    isHrLoggedIn = true;
                }

                //Teacher
                if (roleType.Equals("2"))
                {
                    isTeacherLoggedIn = true;
                }

                //Student
                if (roleType.Equals("3"))
                {
                    isStudentLoggedIn = true;
                }

            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("login.aspx");
        }
    }
}