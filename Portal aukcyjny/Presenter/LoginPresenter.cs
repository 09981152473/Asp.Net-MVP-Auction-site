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
    public class LoginPresenter
    {
        View.ILoginView _loginView;
        Repositories.LoginRepository _loginModel;
        public LoginPresenter(View.ILoginView view, Repositories.LoginRepository model)
        {
            _loginView = view;
            _loginModel = model;
        }
        public void LoginUser(string email, string password, bool rememberMe)
        {

            _loginModel.login(email, password, rememberMe);
            _loginView.path = _loginModel.path;
            _loginView.failureText = _loginModel.FailureMessage;
            _loginView.errorMessage = _loginModel.ErrorMessage;

            
        }
    }
}