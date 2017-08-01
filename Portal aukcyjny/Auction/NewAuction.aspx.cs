using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using System.Resources;
using System.Data.Entity;

namespace Portal_aukcyjny
{
    public partial class NewAuction : Page, View.INewAuctionView, View.IResManView
    {
        public ResourceManager ResMan { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)Master.FindControl("lang");
            if (!IsPostBack)
            {
                bool checkbox = (bool)Session["checkbox"];
                box.Checked = checkbox;
            }
            Presenter.ResManPresenter respresenter = new Presenter.ResManPresenter(this, new Repositories.ResManModels());
            respresenter.language(box.Checked);
            LanguageChange(ResMan);
            Session["checkbox"] = box.Checked;
            ModelEntity.Where = "it.[Brand] = @brand";
            if(!IsPostBack)
            {
                ModelEntity.WhereParameters.Add(new Parameter("brand", TypeCode.String, ModelBrand.SelectedValue.ToString()));
                Model.DataSource = ModelEntity;
                Model.DataBind();
            }
        }

        protected void CreateAuction_Click(object sender, EventArgs e)
        {
            Presenter.NewAuctionPresenter presenter = new Presenter.NewAuctionPresenter(this,new Portal_aukcyjny.Repositories.AuctionsRepository());
            presenter.CreateAuction(ModelBrand.SelectedItem.Text.Trim(), Model.SelectedItem.Text.Trim(), Mileage.Text.Trim(), ProductionYear.Text.Trim(), Fuel.SelectedItem.Text.Trim(), Price.Text.Trim(), Picture.FileName);
            Picture.SaveAs(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\Portal aukcyjny\Portal aukcyjny\Content\" + Picture.FileName);
            string message = string.Empty;
            message = "Samochód został wystawiony na sprzedaż.";
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

        }
        protected void LanguageChange(ResourceManager ResMan)
        {
            BrandLbl.Text = ResMan.GetString("Brand");
            ModelLbl.Text = ResMan.GetString("Model");
            MileageLbl.Text = ResMan.GetString("Mileage");
            ProductionYearLbl.Text = ResMan.GetString("ProductionYear");
            FuelLbl.Text = ResMan.GetString("Fuel");
            Fuel.Items.FindByValue(0.ToString()).Text = ResMan.GetString("Gasoline");
            Fuel.Items.FindByValue(2.ToString()).Text = ResMan.GetString("Gas");
            PriceLbl.Text = ResMan.GetString("Price");
            PictureLbl.Text = ResMan.GetString("PictureLbl");
            PostBtn.Text = ResMan.GetString("Post");
            TitleLbl.Text = ResMan.GetString("NewAuction");
        }
        protected void Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Items.Clear();
            ModelEntity.WhereParameters.Clear();
            ModelEntity.WhereParameters.Add(new Parameter("brand", TypeCode.String, ModelBrand.SelectedValue.ToString()));
            Model.DataSource = ModelEntity;
            Model.DataBind();

        }
    }    
}
