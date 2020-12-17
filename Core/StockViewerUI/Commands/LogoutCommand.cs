using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class LogoutCommand : ICommand
    {
        private readonly IUserManager userManager;
        private readonly IRenavigator loginNavigator;

        public LogoutCommand(IUserManager userManager, IRenavigator loginNavigator)
        {
            this.userManager = userManager;
            this.loginNavigator = loginNavigator;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            userManager.Logout();
            loginNavigator.Renavigate();
        }
    }
}
