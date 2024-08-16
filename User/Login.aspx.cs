using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FOS.User
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        protected void fnConnectDB()
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                conn = new SqlConnection(strcon);

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                    // Response.Write("<script>alert('Connected')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["s_userId"] !=null)
            {
                Response.Redirect("Home.aspx");
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "Admin" && txtPassword.Text.Trim() == "123")
            {
                Session["s_admin"] = txtUsername.Text.Trim();
                Response.Redirect("../Admin/dashboard.aspx");
            }
            else
            {
                fnConnectDB();
                string qry = "Select * from tblUser Where Username = '"+txtUsername.Text.Trim()+"' and Password = '"+txtPassword.Text.Trim()+"'";
                cmd = new SqlCommand(qry);
                cmd.Connection=conn;
                sda=new SqlDataAdapter(cmd);
                dt=new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    Session["s_username"] = txtUsername.Text.Trim();
                    Session["s_userId"] = dt.Rows[0]["Id"];
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Invalid Credentials..!";
                    lblmsg.CssClass = "alert alert-danger";
                    Response.Write("<script>alert('"+txtPassword.Text.Trim()+"')</script>");
                }
            }
        }
    }
}