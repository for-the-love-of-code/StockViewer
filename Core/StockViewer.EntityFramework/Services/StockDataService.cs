using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.EntityFramework.Services
{
    public class StockDataService : DataService<Stock>, IStockDataService
    {
        public StockDataService(StockViewerDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<Stock> CreateIfNotExistsAsync(Stock stock)
        {            
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var existingEntity = dbContext.Stocks.Where(x => x.Symbol == stock.Symbol).First();
                if (existingEntity != null)
                {
                    return existingEntity;
                }
                var entityCreated = await dbContext.Set<Stock>().AddAsync(stock);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return entityCreated.Entity;
            }
        }
    }
}
