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
using System.Diagnostics;
using System.Xml.Linq;
using System.EnterpriseServices;

namespace FOS.Admin
{
    public partial class OrderHistory : System.Web.UI.Page
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
            if (Session["s_admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            else
            {
                Session["breadCrum"] = "Order History";
                FNReapterBind();
            }
            lblMsg.Visible = false;
            pUpdateOrderStatus.Visible = false;
        }
        /*
                protected void FNReapterBind()
                {
                    try
                    {
                        FNConnectionDB();
                        string qry = "Select pay.Type as Type,pay.CardNo as CardNo,o.Id as Id from Orders o,Payment pay where o.Pay_Id=pay.Id";
                        cmd = new SqlCommand(qry, conn);
                        sda = new SqlDataAdapter(cmd);
                        DataTable ds = new DataTable();
                        sda.Fill(ds);
                        rOrderStatus.DataSource = ds;
                        rOrderStatus.DataBind();
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

                protected void rOrderStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
                {

                }
                *//*

               protected void r(object sender, RepeaterItemEventArgs e)
               {
                   try
                   {
                       FNConnectionDB();
                       HiddenField payid = e.Item.FindControl("hiddenpaymentid") as HiddenField;
                       Repeater rorders = e.Item.FindControl("rOrder") as Repeater;
                       string qry = "Select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) AS Id,P.Name as Name,P.Price as Price,o.Quantity as Quantity,o.Quantity*p.Price as Total_Price,o.Id as O_Id,o.Status as Status,pay.Id as Pay_Id from Orders o left join Product P on o.P_Id=P.Id left join Payment pay on o.Pay_Id=pay.Id left join tblUser u on o.U_Id=u.Id where o.Pay_Id = @pay";
                       cmd = new SqlCommand(qry, conn);
                       cmd.Parameters.AddWithValue("@pay", Convert.ToInt32(payid.Value));
                       sda = new SqlDataAdapter(cmd);
                       DataSet ds = new DataSet();
                       sda.Fill(ds);
                       rorders.DataSource = ds;
                       rorders.DataBind();
                   }
                   catch (Exception ex)
                   {
                       Response.Write(ex.ToString());
                   }
                   finally
                   {
                       conn.Close();
                   }
               }*/

        protected void FNReapterBind()
        {
            try
            {
                FNConnectionDB();
                string qry = "Select o.Id as Id,(pr.Price*o.Quantity) as TotalPrice,o.Status as Status,o.OrderDate as OrderDate,p.Type as Type,Pr.Name as Name from Orders o Inner Join Payment p on p.Id = o.Pay_Id Inner join Product pr on pr.Id=o.P_Id\r\n";
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rOrderStatus.DataSource = ds;
                rOrderStatus.DataBind();
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

        protected void rOrderStatus_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edit")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    FNConnectionDB();
                    string qry = "select Id,Status from Orders where Id = " + id;
                    cmd = new SqlCommand(qry, conn);
                    sda = new SqlDataAdapter(cmd);
                    DataTable dr = new DataTable();
                    sda.Fill(dr);
                    ddlOrderStatus.SelectedValue = dr.Rows[0]["Status"].ToString();
                    hdhId.Value = dr.Rows[0]["Id"].ToString();
                    pUpdateOrderStatus.Visible = true;
                    LinkButton btn = e.Item.FindControl("lnkEdit") as LinkButton;
                    btn.CssClass = "badge badge-warning";
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
                int u_id = Convert.ToInt32(hdhId.Value);
                //id = u_id;
                string qry = "Update Orders Set Status='" + ddlOrderStatus.SelectedValue+ "',OrderDate=GETDATE() where Id=" + u_id;
                cmd = new SqlCommand(qry, conn);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    FNReapterBind();
                    Response.Write("<script>alert('Updated!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Process Failed!')</script>");
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pUpdateOrderStatus.Visible = false;
        }
    }
}
