

using StockViewerUI.Commands;
using StockViewerUI.Orchastration;
using StockViewerUI.State;
using StockViewerUI.State.Navigators;
using StockViewerUI.ViewModels.Factories;
using System.Windows.Input;

namespace StockViewerUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IBaseViewModelFactory viewModelFactory, IUserManager userManager)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
