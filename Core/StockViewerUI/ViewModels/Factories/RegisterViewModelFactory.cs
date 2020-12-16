using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public class RegisterViewModelFactory : IGenericViewModelFactory<RegisterViewModel>
    {
        private readonly IUserManager userManager;
        private readonly ICurrentContext currentContext;
        private readonly IGenericViewModelFactory<LoginViewModel> viewModelFactory;

        public RegisterViewModelFactory(
            IUserManager userManager,
            ICurrentContext currentContext,
            IGenericViewModelFactory<LoginViewModel> viewModelFactory)
        {
            this.userManager = userManager;
            this.currentContext = currentContext;
            this.viewModelFactory = viewModelFactory;
        }

        public RegisterViewModel CreateViewModel()
        {
            return new RegisterViewModel(userManager, currentContext, viewModelFactory);
        }
    }
}
