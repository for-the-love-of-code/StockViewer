using StockViewerUI.State.CurrentContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
