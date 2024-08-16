using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FOS.Admin
{
    public partial class UserList : System.Web.UI.Page
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
                    Session["breadCrum"] = "User List";
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
                rList.DataSource = ds;
                rList.DataBind();
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
        protected void rList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                FNDelete(id);
            }
        }
    }
}