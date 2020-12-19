using StockViewerUI.Orchastration;
using StockViewerUI.State;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels;
using StockViewerUI.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using static StockViewerUI.ViewModels.ViewModelBase;

namespace StockViewerUI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserManager userManager;
        private readonly LoginViewModel loginViewModel;
        private readonly IRenavigator watchListNavigator;

        public LoginCommand(IUserManager userManager, LoginViewModel loginViewModel, IRenavigator watchListNavigator)
        {
            this.userManager = userManager;
            this.loginViewModel = loginViewModel;
            this.watchListNavigator = watchListNavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                bool success = await userManager.LoginAsync(loginViewModel.UserName, loginViewModel.Password);
                
                if (success)
                {
                    watchListNavigator.Renavigate();
                }

            }
            catch(Exception ex)
            {
                loginViewModel.Error = ex.Message;
                Debug.WriteLine(ex);

            }
        }
    }
}
