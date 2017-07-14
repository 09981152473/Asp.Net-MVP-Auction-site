using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Portal_aukcyjny.Repositories
{
    public class SingleAuctionRepository :Page
    {
       public string txtname;
       public string txtemail;
       public string txtcomment;
       public void comment(string name, string email, string comment, string auctionId)
       {
            int Id = 0;
            string DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(DefaultConnection))
            {
                using (SqlCommand cmd2 = new SqlCommand("Insert_Comment"))
                {
                    using (SqlDataAdapter sda2 = new SqlDataAdapter())
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@name", name);
                        cmd2.Parameters.AddWithValue("@email", email);
                        cmd2.Parameters.AddWithValue("@comment", comment);
                        cmd2.Parameters.AddWithValue("@AuctionId", auctionId);
                        cmd2.Connection = con;
                        con.Open();
                        Id = Convert.ToInt32(cmd2.ExecuteScalar());
                        con.Close();

                    }

                }
            }
            txtname = "";
            txtemail = "";
            txtcomment = "";
       }
    }
}