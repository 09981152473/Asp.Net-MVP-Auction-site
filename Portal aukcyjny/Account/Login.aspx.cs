using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Portal_aukcyjny.Repositories;
using System.Globalization;
using System.Resources;
using System.Web.UI.WebControls;

namespace Portal_aukcyjny.Account
{
    public partial class Login : Page, View.ILoginView, View.IResManView
    {
        public ResourceManager ResMan { get; set; }
        public string Loginpath { get; set; }
        public string FailureMassage { get; set; }
        public bool ErrorMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)Master.FindControl("lang");
            if(!IsPostBack)
            {
                bool checkbox = (bool)Session["checkbox"];
                box.Checked = checkbox;
            }
            Presenter.ResManPresenter respresenter = new Presenter.ResManPresenter(this, new ResManModels());
            respresenter.language(box.Checked);
            LanguageChange(ResMan);
            Session["checkbox"] = box.Checked;
        }

        protected void LogIn(object sender, EventArgs e)
        {
           
            Presenter.LoginPresenter presenter = new Presenter.LoginPresenter(this, new UserRepository());
            presenter.LoginUser(Email.Text.Trim(), Password.Text.Trim(), RememberMe.Checked);
            Response.Redirect(Loginpath);
        }
        protected void LanguageChange(ResourceManager ResMan)
        {
            Pswd.Text = ResMan.GetString("Password");
            remember.Text = ResMan.GetString("RememberMe");
            log.Text = ResMan.GetString("Post");
        }
    }   
          
}
         

