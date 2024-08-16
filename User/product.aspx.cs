using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FOS.Admin;
using System.Security.Cryptography;

namespace FOS.User
{
    public partial class product : System.Web.UI.Page
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
                if (Session["s_userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    FNReapterBind();
                }
            }
        }
        protected void FNReapterBind()
        {
            try
            {
                FNConnectionDB();
                int Cid = Convert.ToInt32(Request.QueryString[id]);
                string qry = "Select p.Id as Id,p.Name as Name,p.price as Price,p.Quantity as Quantity,p.Image as Image,p.Date as Date,c.Name as C_Name  from Product p Inner JOin Categories c ON c.Id = p.C_Id where p.C_Id = '" + Cid + "'";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rProduct.DataSource = ds;
                rProduct.DataBind();
                Response.Write(Cid);
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

        protected void rProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "addToCart")
            {
                if (Session["s_userId"] != null)
                {
                    bool isCartItemUpdated = false;
                    int id = Convert.ToInt32(e.CommandArgument);
                    int i = isItemExistInCart(id);
                    if (i == 0)
                    {
                        FNConnectionDB();
                        string qry = "Insert Into Carts(P_Id,Quantity,U_Id) values('" + e.CommandArgument + "','" + 1 + "','" + Convert.ToInt32(Session["s_userId"]) + "')";
                        cmd = new SqlCommand(qry, conn);
                        sda = new SqlDataAdapter(cmd);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('Error~" + ex.Message + "')</script>");
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        isCartItemUpdated = updateCart(id, i + 1, Convert.ToInt32(Session["s_userId"]));
                        lblmsg.Visible = true;
                        lblmsg.Text = "Item added successful";
                        lblmsg.CssClass = "alert alert-success";
                        Response.AddHeader("REFRESH", "1;URL=Cart.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected int isItemExistInCart(int ProId)
        {
            FNConnectionDB();
            string qry = "Select * from Carts Where P_Id = '" + ProId + "' and U_Id = '" + Session["s_userId"].ToString() + "'";
            cmd = new SqlCommand(qry, conn);
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int qty = 0;
            if (dt.Rows.Count > 0)
            {
                qty = Convert.ToInt32(dt.Rows[0]["Quantity"]);
            }
            return qty;
        }
        protected bool updateCart(int ProId, int qty, int UserId)
        {
            bool isUpdated = false;
            FNConnectionDB();
            string qry = "Update Carts Set Quantity = '" + qty + "' where P_Id = '" + ProId + "' and U_Id = '" + UserId + "'";
            cmd = new SqlCommand(qry, conn);
            sda = new SqlDataAdapter(cmd);
            try
            {
                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                Response.Write("<script>alert('Error~" + ex.Message + "')</script>");
            }
            finally
            {
                conn.Close();
            }
            return isUpdated;
        }
    }
}