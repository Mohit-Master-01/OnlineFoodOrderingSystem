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

namespace FOS.Admin
{
    public partial class UserFeedBack : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter sda;
        public static int id;

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
            if(!IsPostBack)
            {
                if (Session["s_admin"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
                else
                {
                    Session["breadCrum"] = "Feedback";
                    FNConnectionDB();
                    FNRepeaterBind();
                }
            }
        }

        protected void FNRepeaterBind()
        {
            try
            {
                FNConnectionDB();
                string qry = "Select * from tblUser";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rFeedback.DataSource = ds;
                rFeedback.DataBind();
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

        protected void rFeedback_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                FNDelete(id);
            }
        }
        protected void FNDelete(int id)
        {
            try
            {
                FNConnectionDB();
                string qry = "Delete from tblUser where Id = '" + id + "'";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Response.Write("<script>alert('Deleted')</script>");
                    FNRepeaterBind();
                }
                else
                {

                    Response.Write("<script>alert('Process Failed')</script>");
                }
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
    }
}