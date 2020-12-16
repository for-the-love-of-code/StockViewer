using StockViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Authentication
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> TickerSearchAsync(string searchText);

        Task<Stock> GetStockQuoteAsync(string symbol);
    }
}
