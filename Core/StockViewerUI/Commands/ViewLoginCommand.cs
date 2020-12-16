using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels;
using StockViewerUI.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class ViewLoginCommand : ICommand
    {
        private readonly ICurrentContext navigator;
        private readonly IGenericViewModelFactory<LoginViewModel> viewModelFactory;

        public ViewLoginCommand(ICurrentContext navigator, IGenericViewModelFactory<LoginViewModel> viewModelFactory)
        {
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            navigator.CurrentViewModel = viewModelFactory.CreateViewModel();
        }
    }
}
