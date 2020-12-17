using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewerUI.Models;
using StockViewerUI.Orchastration;
using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private readonly WatchListViewModel watchListViewModel;
        private readonly IStockService stockService;
        private readonly IUserStockMappingDataService userStockMappingDataService;
        private readonly IUserManager userManager;

        public SearchSymbolCommand(
            WatchListViewModel watchListViewModel,
            IStockService stockService,
            IUserStockMappingDataService userStockMappingDataService,
            IUserManager userManager)
        {
            this.watchListViewModel = watchListViewModel;
            this.stockService = stockService;
            this.userStockMappingDataService = userStockMappingDataService;
            this.userManager = userManager;
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
                // Text search - getting the most relevant one for now. 
                var searchedStock = (await stockService.TickerSearchAsync(watchListViewModel.Symbol)).ToList().FirstOrDefault();

                // Update the newly searched record if not already exists.
                if (searchedStock != null)
                {
                    if (!watchListViewModel.WatchList.Any(x => x.Symbol == searchedStock.Symbol))
                    {

                        var stockDetails = await stockService.GetStockDataAsync(searchedStock.Symbol);
                        watchListViewModel.Stock = stockDetails;

                        var liveStockInfo = new LiveStockData
                        {
                            Name = stockDetails.Name,
                            PreviousClose = stockDetails.PreviousClose,
                            YearHigh = stockDetails.YearHigh,
                            Price = stockDetails.Price,
                            Symbol = stockDetails.Symbol,
                            YearLow = stockDetails.YearLow,
                            IsPositiveChange = (stockDetails.PreviousClose <= stockDetails.Price),
                            PercentageChange = Math.Round(((stockDetails.Price - stockDetails.PreviousClose) * 100 / stockDetails.PreviousClose), 2).ToString() + "%",
                    };

                        watchListViewModel.WatchList.Add(liveStockInfo);
                        await userStockMappingDataService.AddStockForUserAsync(
                            new UserStockMapping()
                            {
                                StockId = stockDetails.Id,
                                UserId = userManager.CurrentUser.UserId,
                                Stock = stockDetails,
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
