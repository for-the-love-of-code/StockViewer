using StockViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Data
{
    public interface IStockDataService
    {
        Task<Stock> CreateIfNotExistsAsync(Stock stock);
    }
}
