using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Resources;

namespace Portal_aukcyjny
{
    public partial class Auctions : System.Web.UI.Page, View.IResManView
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
            searchLbl.Text = ResMan.GetString("Search");
            SearchBtn.Text = ResMan.GetString("Search");


        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            AuctionsEntity.WhereParameters.Clear();
            AuctionsEntity.WhereParameters.Add(new Parameter("search", TypeCode.String, search.Text.Trim()));
            AuctionsEntity.Where = "it.[Brand] = @search";
        }
    }
}
