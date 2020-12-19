using Microsoft.EntityFrameworkCore;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services;
using StockViewer.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.EntityFramework.Services
{
    public class UserStockMappingDataService : DataService<UserStockMapping>, IUserStockMappingDataService
    {
        public UserStockMappingDataService(StockViewerDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<UserStockMapping> AddStockForUserAsync(UserStockMapping userStockMapping, string symbol)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var existingEntity = await dbContext.Stocks.Where(x => x.Symbol == symbol).FirstOrDefaultAsync();
                if (existingEntity == null)
                {
                    await dbContext.Set<Stock>().AddAsync(userStockMapping.Stock).ConfigureAwait(false);
                }
                else
                {
                    userStockMapping.StockId = existingEntity.Id;
                }
                
                var entityCreated = await dbContext.Set<UserStockMapping>().AddAsync(userStockMapping);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return entityCreated.Entity;
            }
        }

        public async Task DeleteStockForUserAsync(int userId, string symbol)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var stockId = dbContext.Stocks.Where(x => x.Symbol == symbol).First().Id;
                var matchingEntity = await dbContext.UserStockMappings
                    .Where(x => x.UserId == userId && x.StockId == stockId)
                    .ToListAsync()
                    .ConfigureAwait(false);
                dbContext.UserStockMappings.RemoveRange(matchingEntity);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<UserStockMapping>> GetStocksForUserAsync(int userId)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return await dbContext.UserStockMappings
                    .Where(x => x.UserId == userId)
                    .Include(x => x.User)
                    .Include(x => x.Stock)
                    .ToListAsync()
                    .ConfigureAwait(false);
            }   
        }
    }
}
