using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal_aukcyjny.Presenter
{
    public class ManagePresenter
    {
        View.IPathView _manageView;
        Repositories.ManageRepository _manageModel;
        public ManagePresenter(View.IPathView view, Repositories.ManageRepository model)
        {
            _manageView = view;
            _manageModel = model;
        }
        public void Change()
        {
            _manageModel.PswdChange();
            _manageView.path = _manageModel.path;
        }
    }
}