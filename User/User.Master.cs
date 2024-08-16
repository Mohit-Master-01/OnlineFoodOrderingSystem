using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FOS.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["s_userId"] != null)
            {
                lbLoginOrLogout.Text = "LogOut";
            }
            else 
            {
                lbLoginOrLogout.Text = "Login";

            }
        }
        protected void order_click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Working')</script>");

        }

        protected void lbLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (Session["s_userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

        }
    }
}