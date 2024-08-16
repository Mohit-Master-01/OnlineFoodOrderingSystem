using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FOS.Admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader sda;
        public static int cnt = 0;

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
                    Session["bread"] = "Dashboard";
                    Session["breadCrum"] = "";
    
                        Session["Category"] = FNcategory(cnt);
                        Session["Product"] = FNproduct(cnt);
                    Session["TotalOrders"] = FNTotalorder(cnt);
                    Session["Delivered"] = FNdeliveryItem(cnt);
                    Session["Pending"] = FNPendingItem(cnt);
                    Session["User"] = FNUsers(cnt);
                    Session["Amount"] = FNSoldAmount(cnt);
                    Session["Feedback"] = FNFeedbacks(cnt);


                }
                    /*
                                            // Create a new command to execute the second query
                                            using (SqlCommand command2 = new SqlCommand("SELECT ProductID, ProductName, UnitPrice FROM Production.Product", connection))
                                            {
                                                // Execute the command and store the results in a DataTable
                                                using (SqlDataReader reader2 = command2.ExecuteReader())
                                                {
                                                    DataTable table2 = new DataTable();
                                                    table2.Load(reader2);
                                                    Session["Table2"] = table2;*/
                }
            }

        protected int FNcategory(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                 cmd = new SqlCommand("SELECT count(*) from Categories", conn);
                // Execute the command and store the results in a DataTable
                 sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }


        protected int FNproduct(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT count(*) from Product", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }

        protected int FNTotalorder(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT count(*) from Orders", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }

        protected int FNdeliveryItem(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT count(*) from Orders where Status='Delivered'", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }

        protected int FNPendingItem(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT count(*) from Orders where Status='Ongoing'", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }

        protected int FNUsers(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT count(*) from tblUser", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }

        protected int FNSoldAmount(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT sum(o.Quantity*p.Price) from Orders o,Product p where o.P_Id=p.Id", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }

        protected int FNFeedbacks(int cnt)
        {

            FNConnectionDB();
            {
                // Create a new command to execute the first query
                cmd = new SqlCommand("SELECT count(*) from tblUser", conn);
                // Execute the command and store the results in a DataTable
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    if (sda[0] == DBNull.Value)
                    {
                        cnt = 0;
                    }
                    else
                    {
                        cnt = Convert.ToInt32(sda[0]);
                    }
                }
                return cnt;
            }
        }
    }
}
