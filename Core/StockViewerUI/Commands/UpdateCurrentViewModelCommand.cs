using StockViewerUI.State;
using StockViewerUI.State.Navigators;
using StockViewerUI.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IBaseViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IBaseViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
