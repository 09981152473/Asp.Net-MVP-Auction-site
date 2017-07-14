using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Portal_aukcyjny.Repositories;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Portal_aukcyjny.Repositories
{
    public class NewAuctionRepository :Page
    {
        public void create(string brand, string model, string mileage, string productionyear, string fuel, string price, string picture)
        {
            int id = 0;
            string DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(DefaultConnection))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_Auction"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@mileage", Int32.Parse(mileage));
                        cmd.Parameters.AddWithValue("@productionYear", Int32.Parse(productionyear));
                        cmd.Parameters.AddWithValue("@fuel", fuel);
                        cmd.Parameters.AddWithValue("@price", Int32.Parse(price));
                        cmd.Parameters.AddWithValue("@photoPath", @"~\Content\" + picture);
                        cmd.Parameters.AddWithValue("@user", HttpContext.Current.User.Identity.GetUserId());
                        cmd.Connection = con;
                        con.Open();
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
        }
    }
}