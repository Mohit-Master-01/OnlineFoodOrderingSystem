using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FOS.Admin
{
    public partial class OrderStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["s_admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            else
            {
                Session["BreadCrum"] = "Order Status";
            }
        }
    }
}