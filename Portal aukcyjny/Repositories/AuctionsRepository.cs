using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Portal_aukcyjny.Repositories
{
    public class AuctionsRepository
    {
        public string txtname;
        public string txtemail;
        public string txtcomment;
        public void CreateAuction(string brand, string model, string mileage, string productionyear, string fuel, string price, string picture)
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
        public void CreateComment(string name, string email, string comment, string auctionId)
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