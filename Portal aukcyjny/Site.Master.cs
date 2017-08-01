using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Resources;
namespace Portal_aukcyjny
{
    public partial class SiteMaster : MasterPage, View.IResManView
    {
        public ResourceManager ResMan { get; set; }
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        bool logged = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        protected void Page_Init(object sender, EventArgs e)
        {
            ;            
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
            
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (logged)
            {
                NewAuctionBtn.Visible = true;
                LoginBtn.Visible = false;
                RegisterBtn.Visible = false;
            }
            else
            {
                ManageBtn.Visible = false;
                LoginStatus.Visible = false;
            }

            Presenter.ResManPresenter presenter = new Presenter.ResManPresenter(this, new Repositories.ResManModels());
            presenter.language(lang.Checked);
            HomeBtn.InnerText = ResMan.GetString("CarExchange");
            NewAuctionBtn.InnerText = ResMan.GetString("NewAuction");
            CheckAuctionsBtn.InnerText = ResMan.GetString("CheckAuctions");
            RegisterBtn.InnerText = ResMan.GetString("Register");
            LoginBtn.InnerText = ResMan.GetString("Login");
            ManageBtn.InnerText = ResMan.GetString("WelcomeLabel") + " " + Context.User.Identity.GetUserName();
            LoginStatus.LogoutText = ResMan.GetString("Logout");
            ManageBtn.Title = ResMan.GetString("AccountManagement");
            Session["checkbox"] = lang.Checked;
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}