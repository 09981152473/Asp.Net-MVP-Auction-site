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
using System.Resources;

namespace Portal_aukcyjny.Account
{
    public partial class Manage : System.Web.UI.Page, View.IPathView, View.IResManView
    {
        public string path { get; set; }
        public ResourceManager ResMan { get; set; }
        protected void Page_Load()
        {
            CheckBox box = (CheckBox)Master.FindControl("lang");
            if (!IsPostBack)
            {
                bool checkbox = (bool)Session["checkbox"];
                box.Checked = checkbox;
            }
            Presenter.ResManPresenter respresenter = new Presenter.ResManPresenter(this, new ResManModels());
            Presenter.ManagePresenter presenter = new Presenter.ManagePresenter(this, new UserRepository());
            respresenter.language(box.Checked);
            presenter.Change();
            Form.Action = ResolveUrl(path);
            LanguageChange(ResMan);
            Session["checkbox"] = box.Checked;
        }
        protected void LanguageChange(ResourceManager ResMan)
        {
            msg.Text = ResMan.GetString("AccountManagement");
            Pswd.Text = ResMan.GetString("Password") + ":   ";
            ChangePassword.Text = ResMan.GetString("Change");
        }
    }
}