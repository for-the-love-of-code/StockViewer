using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public class BaseViewModelFactory : IBaseViewModelFactory
    {
        private readonly IGenericViewModelFactory<WatchListViewModel> watchListViewModelFactory;
        private readonly IGenericViewModelFactory<LoginViewModel> loginViewModelFactory;
        private readonly IGenericViewModelFactory<RegisterViewModel> registerViewModelFactory;
        private readonly IUserManager userManager;

        public BaseViewModelFactory(
            IGenericViewModelFactory<WatchListViewModel> watchListViewModelFactory,
            IGenericViewModelFactory<LoginViewModel> loginViewModelFactory,
            IGenericViewModelFactory<RegisterViewModel> registerViewModelFactory)
        {
            this.watchListViewModelFactory = watchListViewModelFactory;
            this.loginViewModelFactory = loginViewModelFactory;
            this.registerViewModelFactory = registerViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return loginViewModelFactory.CreateViewModel();
                case ViewType.Register:
                    return registerViewModelFactory.CreateViewModel();
                case ViewType.Home:
                    return watchListViewModelFactory.CreateViewModel();
                default:
                    return loginViewModelFactory.CreateViewModel();
            }
        }
    }
}