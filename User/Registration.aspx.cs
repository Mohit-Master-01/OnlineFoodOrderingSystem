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
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {/*
                if (Request.QueryString["Id"]!=null)
                {
                    get
                }
                else*/
                if (Session["s_userId"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
        protected void fnConnectDB()
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
                conn = new SqlConnection(strcon);

                if (conn.State != ConnectionState.Open)
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
        protected void fnclear()
        {
            txtName.Text = string.Empty;
            txtusername.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtmobile.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtpostcode.Text = string.Empty;
            fuuserimage.Dispose();
            txtPassword.Text = string.Empty;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string img = "~/assests/Images/" + fuuserimage.FileName;
            try
            {
                fnConnectDB();
                string qry = "INSERT INTO tblUser(Name,Password,Mobile,Email,Username,Address,image,PostCode,Date) Values('" + txtName.Text + "','" + txtPassword.Text + "','" + txtmobile.Text + "','" + txtemail.Text + "','" + txtusername.Text + "','" + txtaddress.Text + "','" + img + "','" + txtpostcode.Text + "',GETDATE())";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();

                if (fuuserimage.HasFile)
                {
                    if (res > 0)
                    {
                        fuuserimage.SaveAs(Server.MapPath(img));
                        Response.Write("<script>alert('Inserted!')</script>");
                        fnclear();
                    }
                    else
                    {

                        Response.Write("<script>alert('Insertion Failed!')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('No File')</script>");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}