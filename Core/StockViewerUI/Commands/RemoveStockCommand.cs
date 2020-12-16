using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Data;
using StockViewerUI.Orchastration;
using StockViewerUI.ViewModels;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace StockViewerUI.Commands
{
    public class RemoveStockCommand : ICommand
    {
        private readonly WatchListViewModel watchListViewModel;
        private readonly IUserManager userManager;
        private readonly IUserStockMappingDataService userStockMappingDataService;


        public RemoveStockCommand(WatchListViewModel watchListViewModel, IUserManager userManager, IUserStockMappingDataService userStockMappingDataService)
        {
            this.watchListViewModel = watchListViewModel;
            this.userManager = userManager;
            this.userStockMappingDataService = userStockMappingDataService;
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
                var stock = (Stock)parameter;
                var currentUser = userManager.CurrentUser;
                watchListViewModel.WatchList.Remove(stock);
                await userStockMappingDataService.DeleteStockForUserAsync(currentUser.UserId, stock.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
