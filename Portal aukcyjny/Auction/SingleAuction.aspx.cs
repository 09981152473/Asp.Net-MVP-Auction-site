using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal_aukcyjny
{
    public partial class SingleAuction : System.Web.UI.Page, View.ISingleAuctionView, View.IResManView
    {
        public ResourceManager ResMan { get; set; }
        public string txtname { get; set; }
        public string txtemail { get; set; }
        public string txtcomment { get; set; }   
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)Master.FindControl("lang");
            Presenter.ResManPresenter respresenter = new Presenter.ResManPresenter(this, new Repositories.ResManModels());
            respresenter.language(box.Checked);
            LanguageChange(ResMan);
            if (!IsPostBack)
            {
                AuctionEntity.WhereParameters.Add(new Parameter("auctionid", TypeCode.Int32, Request.QueryString["AuctionId"]));
                AuctionEntity.Where = "it.[Id] = @auctionid";
                CommentsEntity.WhereParameters.Add(new Parameter("auctionid", TypeCode.Int32, Request.QueryString["AuctionId"]));
                CommentsEntity.Where = "it.[AuctionId] = @auctionid";
            }
        }       
        protected void btn_Submit_Click(object sender, EventArgs e)    
        {
            Presenter.SingleAuctionPresenter presenter = new Presenter.SingleAuctionPresenter(this, new Repositories.SingleAuctionRepository());
            presenter.Submit(txtName.Text, txtEmail.Text, txtComment.Text, Request.QueryString["AuctionId"]);
            Response.Redirect(Request.RawUrl);

        }
        protected void LanguageChange(ResourceManager ResMan)
        {
            foreach (ListViewItem item in Auction.Items)
            {
                var BrandLbl = item.FindControl("BrandLbl") as Label;
                BrandLbl.Text = ResMan.GetString("Brand");
                var MileageLbl = item.FindControl("MileageLbl") as Label;
                MileageLbl.Text = ResMan.GetString("Mileage");
                var ProductionYearLbl = item.FindControl("ProductionYearLbl") as Label;
                ProductionYearLbl.Text = ResMan.GetString("ProductionYear");
                var FuelLbl = item.FindControl("FuelLbl") as Label;
                FuelLbl.Text = ResMan.GetString("Fuel");
                var PriceLbl = item.FindControl("PriceLbl") as Label;
                PriceLbl.Text = ResMan.GetString("Price");
                var SellerLbl = item.FindControl("SellerLbl") as Label;
                SellerLbl.Text = ResMan.GetString("ContactSeller");
                var EurLbl = item.FindControl("EurLbl") as Label;
                EurLbl.Text = ResMan.GetString("EurPrice");
                var PriceName = item.FindControl("PriceName") as Label;
            }
            NameLbl.Text = ResMan.GetString("Name");
            EmailLbl.Text = ResMan.GetString("Email");
            CommentLbl.Text = ResMan.GetString("Comment");
            PostBtn.Text = ResMan.GetString("Post");
            CommentsHeader.Text = ResMan.GetString("Comments");
        }
        protected void Auction_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem dataitem = (ListViewDataItem)e.Item;
            decimal pln = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "Price"));
            Repositories.ICurrencyRepository repo = new Repositories.ICurrencyRepository();
            decimal eur = Math.Ceiling(repo.CurrencyExchange(pln, "PLN", "EUR") * 100) / 100;
            var EurName = e.Item.FindControl("EurName") as Label;
            EurName.Text = eur.ToString();
        }
    }
}