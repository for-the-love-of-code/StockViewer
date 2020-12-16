using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewerUI.Orchastration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels.Factories
{
    public class WatchListViewModelFactory : IGenericViewModelFactory<WatchListViewModel>
    {
        IStockService stockService;
        IUserManager userManager;
        IUserStockMappingDataService userStockMappingDataService;


        public WatchListViewModelFactory(IStockService stockService, IUserManager userManager, IUserStockMappingDataService userStockMappingDataService)
        {
            this.stockService = stockService;
            this.userManager = userManager;
            this.userStockMappingDataService = userStockMappingDataService;
        }

        public WatchListViewModel CreateViewModel()
        {
            return new WatchListViewModel(stockService, userManager, userStockMappingDataService);
        }
    }
}
