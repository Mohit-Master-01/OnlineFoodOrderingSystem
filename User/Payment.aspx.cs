using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FOS.User
{
    public partial class Payment : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["s_userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
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


        protected void lbCardSubmit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "card")
                {
                    FnAddress();
                }
                else if (e.CommandName == "COD")
                {
                    FncodAddress();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void FnAddress()
        {
            try
            {
                FNConnectionDB();
                string qry = "INSERT INTO Payment(Name, CardNo, Type, Date) VALUES ('" + txtName.Text + "','" + txtCardNo.Text + "','Card',GETDATE() )";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {

                    Response.Write("<script>alert('Payment successfull!')</script>");

                }
                else
                {

                    Response.Write("<script>alert('Payment Failed!')</script>");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
        }
        protected void FncodAddress()
        {
            try
            {
                FNConnectionDB();
                string qry = "INSERT INTO Payment( Type, Date) VALUES ('COD',GETDATE() )";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {

                    Response.Write("<script>alert('Payment successfull')</script>");

                }
                else
                {

                    Response.Write("<script>alert('Payment Failed!')</script>");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }

        }

        protected void lbCardSubmit_Click(object sender, EventArgs e)
        {
            FnAddress();
            Response.Redirect("Home.aspx");
        }

        protected void lbCODSubmit_Click(object sender, EventArgs e)
        {
            FncodAddress();
            Response.Redirect("Home.aspx");
        }
    }
}