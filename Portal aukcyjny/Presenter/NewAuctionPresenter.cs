using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;

namespace Portal_aukcyjny.Presenter
{
    public class NewAuctionPresenter
    {
        View.INewAuctionView _newAuctionView;
        Repositories.NewAuctionRepository _newAuctionRepo;
        public NewAuctionPresenter(View.INewAuctionView view, Repositories.NewAuctionRepository repo)
        {
            _newAuctionView = view;
            _newAuctionRepo = repo;
        }
        public void CreateAuction(string brand,string model, string mileage, string productionyear, string fuel, string price, string picture)
        {
            _newAuctionRepo.create(brand,model, mileage, productionyear, fuel, price, picture);
        }
    }
}