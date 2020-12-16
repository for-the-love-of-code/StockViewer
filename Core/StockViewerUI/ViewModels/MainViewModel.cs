

using StockViewerUI.Commands;
using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels.Factories;
using System.Windows.Input;

namespace StockViewerUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICurrentContext Navigator { get; set; }

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(ICurrentContext navigator, IBaseViewModelFactory viewModelFactory, IUserManager userManager)
        {
            Navigator = navigator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);

            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
