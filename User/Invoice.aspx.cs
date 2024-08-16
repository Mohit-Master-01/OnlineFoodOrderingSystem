/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FOS.Admin;

namespace FOS.User
{
    public partial class Invoice : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter sda;
        DataTable dt;
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
                if (Request.QueryString["id"] != null)
                {
                    rOrderItem.DataSource = GetOrderDetails();
                    rOrderItem.DataBind();
                }
                else
                {
                    Response.Redirect("../User/Home.aspx");
                }
            }
        }
        protected void  GetOrderDetails() 
        {
            try
            {
                double grandtotal = 0;
                FNConnectionDB();
                string qry = "Select ROW_NUMBER() OVER(ORDER BY (SELECT1)) as [SrNo],o.OrderNo,p.Name,p.Price,o.Quantity,(p.Price*o.Quantity) as TotalPrice,o.OrderDate,o.Status From Order o INNER JOIN Product p ON p.Id = o.P_Id Where o.Pay_Id = @pay and o.U_Id = '" +Convert.ToInt32(Session["s_userId"]) +"'" ;
                cmd.Parameters.AddWithValue("pay", Convert.ToInt32(Request.QueryString["id"]));
                cmd = new SqlCommand(qry, conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        grandtotal += Convert.ToDouble(dr["TotalPrice"]);
                    }
                }
                DataRow row = dt.NewRow();
                row["TotalPrice"] = grandtotal;
                dt.Rows.Add(row);
                return dt;
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

       *//* protected void lbDownloadInvoice_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=MyFile.pdf");
            Response.TransmitFile(Server.MapPath("~/Files/MyFile.pdf"));
            Response.End();
        }*//*
    }
}*/