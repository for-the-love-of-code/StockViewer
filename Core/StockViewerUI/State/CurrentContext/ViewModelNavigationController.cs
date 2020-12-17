using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using static StockViewerUI.ViewModels.ViewModelBase;

namespace StockViewerUI.State.CurrentContext
{
    public class ViewModelNavigationController<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly ICurrentContext currentContext;
        private readonly CreateViewModel<TViewModel> createViewModel;

        public ViewModelNavigationController(ICurrentContext currentContext, CreateViewModel<TViewModel> createViewModel)
        {
            this.currentContext = currentContext;
            this.createViewModel = createViewModel;
        }

        public bool IsLoggedIn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Renavigate()
        {
            currentContext.CurrentViewModel = createViewModel();
        }
    }
}
