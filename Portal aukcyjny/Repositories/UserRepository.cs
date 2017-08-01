using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Portal_aukcyjny.Repositories
{
    public class UserRepository :Page
    {
        public string Loginpath;
        public string ManagePath;
        public string FailureMessage;
        public bool ErrorMessage;

        public string RegisterPath(string email, string password)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = email, Email = email };
            IdentityResult result = manager.Create(user, password);
            if (result.Succeeded)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                return "~/";
            }
            else
            {
                return "~/Error.aspx";
            }
        }
        public void Login(string email, string password, bool rememberMe)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var result = signinManager.PasswordSignIn(email, password, rememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    Loginpath = "~/";
                    break;
                case SignInStatus.LockedOut:
                    Loginpath = "~/Error.aspx";
                    break;
                case SignInStatus.Failure:
                default:
                    FailureMessage = "Podano błędne dane";
                    ErrorMessage = true;
                    break;
            }
        }
        public string ManagePasswordPath(string currentPassword, string newPassword)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            IdentityResult result = manager.ChangePassword(User.Identity.GetUserId(), currentPassword, newPassword);
            if (result.Succeeded)
            {
                var user = manager.FindById(User.Identity.GetUserId());
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                return "~/Account/Manage?m=ChangePwdSuccess";
            }
            else
            {
                return "~/Error.aspx";
            }
        }
        public void PswdChange()
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            if (!IsPostBack)
            {
                ManagePath = "~/Account/Manage";
            }
        }

}
}