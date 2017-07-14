using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_aukcyjny.Presenter
{
    public class ResManPresenter
    {
        View.IResManView _resManView;
        Repositories.ResManModels _resManModels;
        
        public ResManPresenter(View.IResManView view, Repositories.ResManModels model)
        {
            _resManView = view;
            _resManModels = model;
        }
        public void language(bool Language)
        {
            _resManView.ResMan = _resManModels.switch_language(Language);
        }
    }
}