using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public interface IGenericViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
