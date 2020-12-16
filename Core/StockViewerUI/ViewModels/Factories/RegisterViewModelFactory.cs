using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public class RegisterViewModelFactory : IGenericViewModelFactory<RegisterViewModel>
    {
        public RegisterViewModel CreateViewModel()
        {
            return new RegisterViewModel();
        }
    }
}
