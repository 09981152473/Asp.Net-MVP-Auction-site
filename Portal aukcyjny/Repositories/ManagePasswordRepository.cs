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
    public class ManagePasswordRepository :Page
    {
        public string path(string currentPassword, string newPassword)
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
    }
}