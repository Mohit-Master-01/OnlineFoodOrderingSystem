using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace FOS.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter sda;
        public static int id;
        public static string t_img;

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
                if (Session["s_admin"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
                else
                {
                    Session["breadCrum"] = "Category";
                    FNConnectionDB();
                    FNReapterBind();
                }
            }
            lblMsg.Visible = false;
        }

        protected void btnAddorUpdate_Click(object sender, EventArgs e)
        {
            string img = "~/uploads/" + fuCategoryImage.FileName;
            try
            {
                FNConnectionDB();
                string qry = "INSERT INTO Categories(Name,Date,Image) VALUES('" + txtName.Text + "',GETDATE(),'" + img + "')";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (fuCategoryImage.HasFile)
                {
                    if (res > 0)
                    {
                        fuCategoryImage.SaveAs(Server.MapPath(img));
                        FNReapterBind();
                        FNClear();
                        Response.Write("<script>alert('Inserted!')</script>");
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

        protected void FNClear()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            fuCategoryImage.Dispose();
            imgCategory.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            FNClear();
        }

        protected void FNReapterBind()
        {
            try
            {
                FNConnectionDB();
                string qry = "Select * from Categories";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rCategory.DataSource = ds;
                rCategory.DataBind();
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

        protected void rCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    FnDelete(id);
                }
                else if (e.CommandName == "edit")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    FnSelectUpdate(id);
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


        void FnSelectUpdate(int id)
        {
            try
            {
                FNConnectionDB();
                string qry = "select * from Categories where Id = " + id;
                cmd = new SqlCommand(qry, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    txtId.Text = dr["Id"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    imgCategory.ImageUrl = dr["Image"].ToString();
                    t_img = dr["Image"].ToString();
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

        protected void FnDelete(int id)
        {
            try
            {
                FNConnectionDB();
                string qry = "Delete from Categories where Id = '" + id + "'";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Response.Write("<script>alert('Deleted')</script>");
                    FNReapterBind();
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


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                FNConnectionDB();
                int u_id = Convert.ToInt32(txtId.Text);
                //id = u_id;
                string img = "~/uploads/" + fuCategoryImage.FileName;
                string qry = "Update Categories Set Name='" + txtName.Text + "',Date=GETDATE(),Image='" + img + "' where Id=" + u_id;
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (fuCategoryImage.HasFile)
                {
                    if (res > 0)
                    {
                        fuCategoryImage.SaveAs(Server.MapPath(img));
                        FNReapterBind();
                        FNClear();
                        Response.Write("<script>alert('Updated!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Process Failed!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No File')</script>");
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