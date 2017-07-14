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
    public class RegisterPresenter
    {
        View.IPathView _registerView;
        Repositories.RegisterRepository _registerModels;
        public RegisterPresenter(View.IPathView rview, Repositories.RegisterRepository rmodel)
        {
            _registerView = rview;
            _registerModels = rmodel;
        }
        public void RegisterUser(string email, string password)
        {
            _registerView.path= _registerModels.path(email, password);
        }
    }
}