using FOS.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FOS.User
{
    public partial class _default : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter sda;
        public static int Cid;

        protected void FNConnectionDB()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                conn = new SqlConnection(conStr);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FNRptBind();
            }
        }
        protected void order_click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Working')</script>");

        }

        protected void FNRptBind()
        {
            try
            {
                FNConnectionDB();
                string qry = "Select * from Categories";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rorderItem.DataSource = ds;
                rorderItem.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }


        protected void rorderItem_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Session["s_userId"] != null)
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("product.aspx?id="+id);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

    }
}