

using StockViewer.Domain.Models;
using StockViewerUI.Commands;
using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels.Factories;
using System.Windows.Input;

namespace StockViewerUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string welcomeMessage;
        private readonly IUserManager userManager;

        public ICurrentContext Navigator { get; set; }

        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand LogoutCommand { get; }
        

        public MainViewModel(ICurrentContext navigator, IViewModelFactory viewModelFactory, IUserManager userManager, IRenavigator loginNavigator)
        {
            Navigator = navigator;
            this.userManager = userManager;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
            LogoutCommand = new LogoutCommand(userManager, loginNavigator);
        }
    }
}
