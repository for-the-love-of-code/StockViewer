using StockViewer.Domain.Services.Authentication;
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

        public SearchSymbolCommand(WatchListViewModel watchListViewModel, IStockService stockService)
        {
            this.watchListViewModel = watchListViewModel;
            this.stockService = stockService;
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
                var matchingDetails = (await stockService.TickerSearchAsync(watchListViewModel.Symbol)).ToList().FirstOrDefault();
                if (matchingDetails != null)
                {
                    var stockDetails = await stockService.GetStockQuoteAsync(matchingDetails.Symbol);
                    watchListViewModel.Stock = stockDetails;
                    watchListViewModel.WatchList.Add(stockDetails);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
