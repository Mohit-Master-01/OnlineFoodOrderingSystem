using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FOS.User
{
    public partial class Cart : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        decimal grandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Response.Write(conn);
                if (Session["s_userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    getCartItems();
                }
            }

        }

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

        void getCartItems()
        {
            DataSet ds = new DataSet();
            try
            {
                fnConnectDB();
                string qry = "SELECT c.P_Id AS P_id, p.Name, p.Image, p.Price, c.Quantity AS Quantity, p.Quantity as PrdQty\r\nFROM Carts c\r\nINNER JOIN Product p ON p.Id=c.P_Id Where U_Id = '" + Convert.ToInt32(Session["s_userId"]) + "'";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                rCartItem.DataSource = ds;
                rCartItem.DataBind();
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

        protected void rCartItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "remove")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    fnDelete(id);
                }

                if (e.CommandName == "checkout")
                {
                    bool isTrue = false;
                    string pName = string.Empty;
                    //First will check item quantity
                    for (int item = 0; item < rCartItem.Items.Count; item++)
                    {
                        if (rCartItem.Items[item].ItemType == ListItemType.Item || rCartItem.Items[item].ItemType == ListItemType.AlternatingItem)
                        {
                            HiddenField _productId = rCartItem.Items[item].FindControl("hdnProductId") as HiddenField;
                            HiddenField _cartquantity = rCartItem.Items[item].FindControl("hdnQuantity") as HiddenField;
                            HiddenField _productQuantity = rCartItem.Items[item].FindControl("hdnPrdQuantity") as HiddenField;
                            Label productName = rCartItem.Items[item].FindControl("lblName") as Label;
                            int cartQuantity = Convert.ToInt32(_cartquantity.Value);
                            int ProductId = Convert.ToInt32(_productId.Value);
                            int productQuantity = Convert.ToInt32(_productQuantity.Value);

                            if (productQuantity > cartQuantity && productQuantity > 2)
                            {
                                isTrue = true;

                            }
                            else
                            {
                                isTrue = true;
                                pName = productName.Text.ToString();
                                break;
                            }

                        }

                    }

                    if (isTrue)
                    {
                        Response.Redirect("Payment.aspx");
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Item <b> '" + pName + "' </b> is out of stock :( ";
                        lblMsg.CssClass = "alert alert-warning";
                    }
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

        protected bool updateCart(int ProId, int qty, int UserId)
        {
            bool isUpdated = false;
            fnConnectDB();
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

        protected void rCartItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label totalPrice = e.Item.FindControl("lblTotalPrice") as Label;
                Label productPrice = e.Item.FindControl("lblPrice") as Label;
                TextBox quantity = e.Item.FindControl("txtQuantity") as TextBox;
                decimal calTotalPrice = Convert.ToDecimal(productPrice.Text) * Convert.ToDecimal(quantity.Text);
                totalPrice.Text = calTotalPrice.ToString();
                grandTotal += calTotalPrice;
            }
            Session["grandTotalPrice"] = grandTotal;

        }

        void fnSelectUpdate(int id)
        {
            try
            {
                fnConnectDB();
                string qry = "select * from Carts where P_Id= '" + id + "' and U_Id='" + Convert.ToInt32(Session["s_userId"]) + "'";
                cmd = new SqlCommand(qry, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        void fnDelete(int id)
        {
            try
            {
                fnConnectDB();
                string qry = "Delete from Carts where P_Id = '" + id + "'and U_Id='" + Convert.ToInt32(Session["s_userId"]) + "'";
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    Response.Write("<script>alert('Deleted')</script>");
                    getCartItems();

                }
                else
                {
                    Response.Write("<script>alert('Process failed')</script>");

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


