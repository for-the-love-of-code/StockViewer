using StockViewerUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StockViewerUI.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    }
}
