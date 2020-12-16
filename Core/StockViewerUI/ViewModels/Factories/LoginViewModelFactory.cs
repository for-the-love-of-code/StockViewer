using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public class LoginViewModelFactory : IGenericViewModelFactory<LoginViewModel>
    {
        private readonly IUserManager userManager;
        private readonly ICurrentContext navigator;
        private readonly IGenericViewModelFactory<WatchListViewModel> viewModelFactory;
        private readonly IGenericViewModelFactory<RegisterViewModel> registerViewModelFactory;

        public LoginViewModelFactory(
            IUserManager userManager,
            ICurrentContext navigator,
            IGenericViewModelFactory<WatchListViewModel> viewModelFactory,
            IGenericViewModelFactory<RegisterViewModel> registerViewModelFactory)
        {
            this.userManager = userManager;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.registerViewModelFactory = registerViewModelFactory;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(userManager, navigator, viewModelFactory, registerViewModelFactory);
        }
    }
}
