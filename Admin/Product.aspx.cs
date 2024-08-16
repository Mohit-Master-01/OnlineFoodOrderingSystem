using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace FOS.Admin
{
    public partial class Product : System.Web.UI.Page
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
                    Session["breadCrum"] = "Product";
                    FNConnectionDB();
                    FNCategoryBind();
                    FNReapterBind();
                }
            }

        }


        protected void btnAddorUpdate_Click(object sender, EventArgs e)
        {
            string img = "~/uploads/" + fuProductImage.FileName;
            try
            {
                FNConnectionDB();
                string qry = "INSERT INTO Product(Name,Price,Quantity,C_id,Image,Date) Values('" + txtName.Text + "','" + txtPrice.Text + "','" + txtQuantity.Text + "','" + ddlCategories.SelectedValue + "','" + img + "',GETDATE())";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (fuProductImage.HasFile)
                {
                    if (res > 0)
                    {
                        fuProductImage.SaveAs(Server.MapPath(img));
                        Response.Write("<script>alert('Inserted!')</script>");
                        FNReapterBind();
                        FNClear();
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

        protected void FNCategoryBind()
        {
            DataSet ds = new DataSet();
            try
            {
                FNConnectionDB();
                string qry = "Select * from categories";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                ddlCategories.DataSource = ds;
                ddlCategories.DataTextField = "Name";
                ddlCategories.DataValueField = "Id";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("Select Category"));
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
            txtName.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            ddlCategories.SelectedIndex = 0;
            fuProductImage.Dispose();
            FNReapterBind();
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
                string qry = "Select p.Id as Id,p.Name as Name,p.price as Price,p.Quantity as Quantity,p.Image as Image,p.Date as Date,c.Name as C_Name  from Product p, Categories c  where p.C_id = c.Id";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rProduct.DataSource = ds;
                rProduct.DataBind();
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

        protected void rProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                   // Response.Write(id);
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
                string qry = "select * from Product where Id = " + id;
                cmd = new SqlCommand(qry, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    txtID.Text = dr["Id"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQuantity.Text = dr["Quantity"].ToString();
                    ddlCategories.SelectedValue = dr["C_id"].ToString();
                    imgProduct.ImageUrl = dr["Image"].ToString();
                    
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
                string qry = "Delete from Product where Id = '" + id + "'";
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
                int u_id = Convert.ToInt32(txtID.Text);
               // id = u_id;
                string img = "~/uploads/" + fuProductImage.FileName;
                string qry = "Update Product Set Name='" + txtName.Text + "',Price='"+txtPrice.Text+"',Quantity='"+txtQuantity.Text+"',C_id='"+ddlCategories.SelectedValue+"',Image='" + img + "',Date=GETDATE() where Id=" + u_id;
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (fuProductImage.HasFile)
                {
                    if (res > 0)
                    {
                        fuProductImage.SaveAs(Server.MapPath(img));
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

