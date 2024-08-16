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
    public partial class User_Profile : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter sda;

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
                if (Session["s_userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    getUserDetails();
                }
            }
        }

        protected void getUserDetails()
        {
            try
            {
                FNConnectionDB();
                string qry = "Select * from tblUser where Id = '" + Session["s_userId"] +"'";
                cmd= new SqlCommand(qry);
                cmd.Connection= conn;
                sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                rUserProfile.DataSource = dataTable;
                rUserProfile.DataBind();
                if(dataTable.Rows.Count == 1)
                {
                    Session["name"] = dataTable.Rows[0]["Name"].ToString();
                    Session["image"] = dataTable.Rows[0]["image"].ToString();
                    Session["username"] = dataTable.Rows[0]["Username"].ToString();
                    Session["Id"] = dataTable.Rows[0]["Id"].ToString();
                    Session["email"] = dataTable.Rows[0]["Email"].ToString();
                    Session["date"] = dataTable.Rows[0]["Date"].ToString();
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}