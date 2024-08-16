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
    public partial class Report : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public static int id;
        public static string t_img;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(conn);
            if (!IsPostBack)
            {
                fnConnectDB();
                Session["breadCrum"] = "Selling Report";
                if (Session["s_admin"] == null)
                {
                    Response.Redirect("../User/Login.aspx");
                }
                //FNRepeaterBind();
            }
            lblTotal.Visible = false;
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            if (toDate > DateTime.Now)
            {
                Response.Write("<script>alert('ToDate cannot be greater than current date')</script>");
            }
            else if (fromDate > toDate)
            {
                Response.Write("<script>alert('ToDate cannot be greater than ToDate')</script>");

            }
            else
            {
                FnFetchDate(fromDate, toDate);
            }
        }


        protected void FnFetchDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                fnConnectDB();
                double grandTotal = 0;
                string qry = "Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [SrNo], u.[First name], u.Email,\r\nSum(o.Quantity) as TotalOrders, Sum(o.Quantity * p.Price) as TotalPrice\r\nfrom Orders o\r\nINNER JOIN Product p ON p.Id = o.P_Id\r\nINNER JOIN tblUser u ON u.Id = o.U_Id\r\nWHERE CAST(o.OrderDate as Date) Between @FromDate AND @ToDate\r\nGROUP BY u.[First name], u.Email";
                cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        grandTotal += Convert.ToDouble(dr["TotalPrice"]);

                    }
                    lblTotal.Text = "Solid Cost : ₹" + grandTotal;
                    lblTotal.CssClass = "badge badge-primary";
                }
                rReport.DataSource = dt;
                rReport.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}