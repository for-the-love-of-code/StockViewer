using StockViewerUI.Orchastration;
using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserManager userManager;
        private readonly LoginViewModel loginViewModel;

        public LoginCommand(IUserManager userManager, LoginViewModel loginViewModel)
        {
            this.userManager = userManager;
            this.loginViewModel = loginViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool success = await userManager.LoginAsync(loginViewModel.UserName, string.Empty);
        }
    }
}
