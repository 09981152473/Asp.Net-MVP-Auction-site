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

namespace Portal_aukcyjny.Repositories
{
    public class LoginRepository
    {
        public string path;
        public string FailureMessage;
        public bool ErrorMessage;
        public void login(string email, string password, bool rememberMe)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var result = signinManager.PasswordSignIn(email, password, rememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    path = "~/";
                    break;
                case SignInStatus.LockedOut:
                    path= "~/Error.aspx";
                    break;
                case SignInStatus.Failure:
                default:
                    FailureMessage= "Podano błędne dane";
                    ErrorMessage = true;
                    break;
            }
        }

    }
}