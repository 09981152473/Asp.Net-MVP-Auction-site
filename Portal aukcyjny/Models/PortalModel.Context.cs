﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal_aukcyjny.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PortalAukcyjnyCZEntities : DbContext
    {
        public PortalAukcyjnyCZEntities()
            : base("name=PortalAukcyjnyCZEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetAuctions> AspNetAuctions { get; set; }
        public virtual DbSet<AspNetComments> AspNetComments { get; set; }
        public virtual DbSet<AspNetModels> AspNetModels { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    
        public virtual int Insert_Auction(string brand, string model, Nullable<int> mileage, Nullable<int> productionYear, string fuel, Nullable<int> price, string photoPath, string user)
        {
            var brandParameter = brand != null ?
                new ObjectParameter("brand", brand) :
                new ObjectParameter("brand", typeof(string));
    
            var modelParameter = model != null ?
                new ObjectParameter("model", model) :
                new ObjectParameter("model", typeof(string));
    
            var mileageParameter = mileage.HasValue ?
                new ObjectParameter("mileage", mileage) :
                new ObjectParameter("mileage", typeof(int));
    
            var productionYearParameter = productionYear.HasValue ?
                new ObjectParameter("productionYear", productionYear) :
                new ObjectParameter("productionYear", typeof(int));
    
            var fuelParameter = fuel != null ?
                new ObjectParameter("fuel", fuel) :
                new ObjectParameter("fuel", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(int));
    
            var photoPathParameter = photoPath != null ?
                new ObjectParameter("photoPath", photoPath) :
                new ObjectParameter("photoPath", typeof(string));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Auction", brandParameter, modelParameter, mileageParameter, productionYearParameter, fuelParameter, priceParameter, photoPathParameter, userParameter);
        }
    
        public virtual int Insert_Comment(string name, string email, string comment, Nullable<int> auctionId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var commentParameter = comment != null ?
                new ObjectParameter("comment", comment) :
                new ObjectParameter("comment", typeof(string));
    
            var auctionIdParameter = auctionId.HasValue ?
                new ObjectParameter("AuctionId", auctionId) :
                new ObjectParameter("AuctionId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Comment", nameParameter, emailParameter, commentParameter, auctionIdParameter);
        }
    
        public virtual ObjectResult<string> Insert_Model(string brand)
        {
            var brandParameter = brand != null ?
                new ObjectParameter("brand", brand) :
                new ObjectParameter("brand", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Insert_Model", brandParameter);
        }
    
        public virtual ObjectResult<Retrieve_Auction_Result> Retrieve_Auction(string path)
        {
            var pathParameter = path != null ?
                new ObjectParameter("path", path) :
                new ObjectParameter("path", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Retrieve_Auction_Result>("Retrieve_Auction", pathParameter);
        }
    
        public virtual ObjectResult<Retrieve_Auctions_Result> Retrieve_Auctions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Retrieve_Auctions_Result>("Retrieve_Auctions");
        }
    
        public virtual ObjectResult<Retrieve_Comments_Result> Retrieve_Comments(string auctionId)
        {
            var auctionIdParameter = auctionId != null ?
                new ObjectParameter("AuctionId", auctionId) :
                new ObjectParameter("AuctionId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Retrieve_Comments_Result>("Retrieve_Comments", auctionIdParameter);
        }
    }
}
