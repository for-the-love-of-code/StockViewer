using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using System;
using System.Collections.Generic;
using System.Text;
using static StockViewerUI.ViewModels.ViewModelBase;

namespace StockViewerUI.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<WatchListViewModel> createWatchListViewModel;
        private readonly CreateViewModel<LoginViewModel> createLoginViewModel;
        private readonly CreateViewModel<RegisterViewModel> createRegisterViewModel;
        private readonly IUserManager userManager;

        public ViewModelFactory(
            CreateViewModel<WatchListViewModel> createWatchListViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<RegisterViewModel> createRegisterViewModel,
            IUserManager userManager)
        {
            this.createWatchListViewModel = createWatchListViewModel;
            this.createLoginViewModel = createLoginViewModel;
            this.createRegisterViewModel = createRegisterViewModel;
            this.userManager = userManager;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return createLoginViewModel();
                case ViewType.Register:
                    return createRegisterViewModel();
                case ViewType.Home:
                    return createWatchListViewModel();
                default:
                    return createLoginViewModel();
            }
        }
    }
}