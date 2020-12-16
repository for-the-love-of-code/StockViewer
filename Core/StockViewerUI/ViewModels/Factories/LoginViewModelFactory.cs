using StockViewerUI.Orchastration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public class LoginViewModelFactory : IGenericViewModelFactory<LoginViewModel>
    {
        private readonly IUserManager userManager;

        public LoginViewModelFactory(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(userManager);
        }
    }
}
