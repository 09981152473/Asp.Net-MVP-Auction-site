using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Resources;

namespace Portal_aukcyjny.Account
{
    public partial class ManagePassword : System.Web.UI.Page, View.IPathView, View.IResManView
    {
        public string path { get; set; }
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
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            Presenter.ManagePasswordPresenter presenter = new Presenter.ManagePasswordPresenter(this, new Repositories.UserRepository());
            presenter.ChangePassword(CurrentPassword.Text.Trim(), NewPassword.Text.Trim());
            Response.Redirect(path);
        }
        protected void LanguageChange(ResourceManager ResMan)
        {
            CurrentPasswordLabel.Text = ResMan.GetString("CurrentPassword");
            NewPasswordLabel.Text = ResMan.GetString("NewPassword");
            ConfirmNewPasswordLabel.Text = ResMan.GetString("NewPasswordConf");
            ChangeBtn.Text = ResMan.GetString("Change");
            TitleLbl.Text = ResMan.GetString("ChangePassword");
        }
    }
}