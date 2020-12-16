using Prism.Commands;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewer.EntityFramework.Services;
using StockViewerUI.Commands;
using StockViewerUI.Orchastration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockViewerUI.ViewModels
{
    public class WatchListViewModel : ViewModelBase
    {
		private string symbol;
		private Stock stock;
		private readonly IUserManager userManager;
		private readonly ObservableCollection<Stock> watchList;
		private readonly IUserStockMappingDataService userStockMappingDataService;
		private DelegateCommand<Stock> removeSymbolCommand;

		public ICommand SearchSymbolCommand { get; set; }
		public ICommand RemoveStockCommand { get; set; }

		public DelegateCommand<Stock> RemoveSymbolCommand => removeSymbolCommand ?? (removeSymbolCommand = new DelegateCommand<Stock>(RemoveSymbol, _ => true));

		public WatchListViewModel(IStockService stockService, IUserManager userManager, IUserStockMappingDataService userStockMappingDataService)
		{
			this.userManager = userManager;
			this.userStockMappingDataService = userStockMappingDataService;

			// For testing 
			watchList = new ObservableCollection<Stock>();
			SearchSymbolCommand = new SearchSymbolCommand(this, stockService);
			RemoveStockCommand = new RemoveStockCommand(this, userManager, userStockMappingDataService);
			
		}

		public string Symbol
		{
			get
			{
				return symbol;
			}
			set
			{
				symbol = value;
				OnPropertyChanged(nameof(Symbol));
			}
		}

		public Stock Stock
		{
			get
			{
				return stock;
			}
			set
			{
				stock = value;
				OnPropertyChanged(nameof(Stock));
			}
		}

		public ObservableCollection<Stock> WatchList
		{
			get
			{
				return watchList;
			}
			set
			{
				WatchList = value;
			}
		}

		private void RemoveSymbol(Stock stock)
		{
			try
			{
				var currentUser = userManager.CurrentUser;
				WatchList.Remove(stock);
				// await userStockMappingDataService.DeleteStockForUserAsync(currentUser.UserId, stock.Id);
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}
	}
}