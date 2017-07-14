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
using System.Resources;

namespace Portal_aukcyjny.Account
{
    public partial class Register : Page, View.IPathView, View.IResManView
    {
        public string path { get; set; }
        public ResourceManager ResMan { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)Master.FindControl("lang");
            Presenter.ResManPresenter respresenter = new Presenter.ResManPresenter(this, new Repositories.ResManModels());
            respresenter.language(box.Checked);
            LanguageChange(ResMan);
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Presenter.RegisterPresenter presenter = new Presenter.RegisterPresenter(this, new RegisterRepository());
            presenter.RegisterUser(Email.Text.Trim(), Password.Text.Trim());
            Response.Redirect(path);
        }
        protected void LanguageChange(ResourceManager ResMan)
        {
            PasswordLbl.Text = ResMan.GetString("Password");
            ConfirmLbl.Text = ResMan.GetString("NewPasswordConf");
            RegisterLbl.Text = ResMan.GetString("Register");
            RegisterBtn.Text = ResMan.GetString("Post");
        }
    }
            
}        
    
