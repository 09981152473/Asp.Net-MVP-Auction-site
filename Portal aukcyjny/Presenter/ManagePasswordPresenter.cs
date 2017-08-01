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

namespace Portal_aukcyjny.Presenter
{
    public class ManagePasswordPresenter : System.Web.UI.Page
    {
        View.IPathView _managePasswordView;
        Repositories.UserRepository _managePasswordModel;
        public ManagePasswordPresenter(View.IPathView view, Repositories.UserRepository model)
        {
            _managePasswordView = view;
            _managePasswordModel = model;
        }
        public void ChangePassword(string currentPassword, string newPassword)
        {
            _managePasswordView.path = _managePasswordModel.ManagePasswordPath(currentPassword, newPassword);
        }


    }
}