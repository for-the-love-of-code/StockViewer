using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels;
using StockViewerUI.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel registerViewModel;
        private readonly IUserManager userManager;
        private readonly ICurrentContext currentContext;
        private readonly IGenericViewModelFactory<LoginViewModel> loginFactory;

        public RegisterCommand(RegisterViewModel registerViewModel,
            IUserManager userManager,
            ICurrentContext currentContext,
            IGenericViewModelFactory<LoginViewModel> loginFactory)
        {
            this.registerViewModel = registerViewModel;
            this.userManager = userManager;
            this.currentContext = currentContext;
            this.loginFactory = loginFactory;
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
                var success = await userManager.RegisterAsync(
                       registerViewModel.Name,
                       registerViewModel.UserName,
                       registerViewModel.Password,
                       registerViewModel.ConfirmPassword);

                if (success)
                {
                    currentContext.CurrentViewModel = loginFactory.CreateViewModel();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
