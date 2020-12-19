using Prism.Commands;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewer.EntityFramework.Services;
using StockViewerUI.Commands;
using StockViewerUI.Models;
using StockViewerUI.Orchastration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace StockViewerUI.ViewModels
{
	public class WatchListViewModel : ViewModelBase, IDisposable
    {
		private const int DueTime = 5 * 1000;
		private const int RefreshRate = 1 * 5 * 1000;

		private string symbol;
		private Stock stock;
		private BindingList<LiveStockData> watchList;
		private readonly IUserManager userManager;
		private readonly IUserStockMappingDataService userStockMappingDataService;
		private readonly IStockService stockService;
		Timer timer;

		public ICommand SearchSymbolCommand { get; set; }
		public ICommand RemoveStockCommand { get; set; }

		public WatchListViewModel(
			IStockService stockService,
			IUserManager userManager,
			IUserStockMappingDataService userStockMappingDataService)
		{
			SearchSymbolCommand = new SearchSymbolCommand(this, stockService, userStockMappingDataService, userManager);
			RemoveStockCommand = new RemoveStockCommand(this, userManager, userStockMappingDataService);
			this.userManager = userManager;
			this.userStockMappingDataService = userStockMappingDataService;
			this.stockService = stockService;
			InitializeAsync();
		}

		private async void InitializeAsync()
		{
			try
			{
				var stocks =
					(await userStockMappingDataService.GetStocksForUserAsync(
						userManager.CurrentUser.UserId))
					.Select(
						x =>
						{
							var liveStockData = new LiveStockData
							{
								Name = x.Stock.Name,
								PreviousClose = x.Stock.PreviousClose,
								YearHigh = x.Stock.YearHigh,
								Price = x.Stock.Price,
								Symbol = x.Stock.Symbol,
								YearLow = x.Stock.YearLow,
								IsPositiveChange = x.Stock.PreviousClose <= x.Stock.Price,
								PercentageChange = Math.Round(((x.Stock.Price - x.Stock.PreviousClose) * 100 / x.Stock.PreviousClose), 2).ToString() + "%",
							};							
							return liveStockData;
						})
					.ToList();

				WatchList = new BindingList<LiveStockData>(stocks);
				RealTimePriceJob();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}

		private void RealTimePriceJob()
		{
			var currentContext = SynchronizationContext.Current;
			timer  = new Timer(OnElapsed, currentContext, DueTime, RefreshRate);
		}

		private async void OnElapsed(object state)
		{
			try
			{
				var context = (SynchronizationContext)state;
				Dictionary<string, Task<Stock>> symbolPriceTaskMapping = new Dictionary<string, Task<Stock>>();

				foreach (var stock in WatchList)
				{
					// symbolPriceTaskMapping[stock.Symbol] = stockService.GetLivePriceAsync(stock.Symbol);
				}

				await Task.WhenAll(symbolPriceTaskMapping.Select(x => x.Value));

				SynchronizationContext.SetSynchronizationContext(context);

				WatchList = new BindingList<LiveStockData>(
					WatchList.Select(
						x => 
						{
							if (symbolPriceTaskMapping.ContainsKey(x.Symbol))
							{
								x.Price = new Random().NextDouble();
								// x.Price = symbolPriceTaskMapping[x.Symbol].Result.Price;
								x.IsPositiveChange = x.Price > x.PreviousClose;
								x.PercentageChange = Math.Round(((x.Price - x.PreviousClose) * 100 / x.PreviousClose), 2).ToString() + "%";
							}
							return x; 
						})
					.ToList());
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}

		public void Dispose()
		{
			timer.Dispose();
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
				OnPropertyChanged(nameof(WatchList));
			}
		}

		public BindingList<LiveStockData> WatchList
		{
			get
			{
				return watchList;
			}
			set
			{
				watchList = value;
				OnPropertyChanged(nameof(WatchList));
			}
		}

		private bool isPositive;
		public bool IsPositive
		{
			get
			{
				return isPositive;
			}
			set
			{
				isPositive = value;
				OnPropertyChanged(nameof(IsPositive));
			}
		}
	}
}