using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockViewerUI.State.CurrentContext
{
    public interface ICurrentContext
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
