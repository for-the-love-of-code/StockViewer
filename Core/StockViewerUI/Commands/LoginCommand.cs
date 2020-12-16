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

namespace StockViewerUI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserManager userManager;
        private readonly LoginViewModel loginViewModel;
        private readonly ICurrentContext navigator;
        private readonly IGenericViewModelFactory<WatchListViewModel> viewModelFactory;

        public LoginCommand(IUserManager userManager, LoginViewModel loginViewModel, ICurrentContext navigator, IGenericViewModelFactory<WatchListViewModel> viewModelFactory)
        {
            this.userManager = userManager;
            this.loginViewModel = loginViewModel;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
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
                    navigator.CurrentViewModel = viewModelFactory.CreateViewModel();
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
