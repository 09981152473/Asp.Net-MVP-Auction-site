using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Portal_aukcyjny.Presenter
{
    public class SingleAuctionPresenter
    {
        View.ISingleAuctionView _singleAuctionView;
        Repositories.AuctionsRepository _singleAuctionModels;
        public SingleAuctionPresenter(View.ISingleAuctionView view, Repositories.AuctionsRepository model)
        {
            _singleAuctionView = view;
            _singleAuctionModels = model;
        }
        
        public void Submit(string name, string email, string comment, string auctionid)
        {
            _singleAuctionModels.CreateComment(name, email, comment, auctionid);
            _singleAuctionView.txtname = _singleAuctionModels.txtname;
            _singleAuctionView.txtemail = _singleAuctionModels.txtemail;
            _singleAuctionView.txtcomment = _singleAuctionModels.txtcomment;
        }
    }
}