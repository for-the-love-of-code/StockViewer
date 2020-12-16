using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using static StockViewerUI.ViewModels.ViewModelBase;

namespace StockViewerUI.State.CurrentContext
{
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly ICurrentContext currentContext;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelDelegateRenavigator(ICurrentContext currentContext, CreateViewModel<TViewModel> createViewModel)
        {
            this.currentContext = currentContext;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            currentContext.CurrentViewModel = _createViewModel();
        }
    }
}
