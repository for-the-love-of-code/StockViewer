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

        public async Task DeleteStockForUserAsync(int userId, int stockId)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var matchingEntity = await dbContext.UserStockMappings
                    .Where(x => x.UserId == userId && x.StockId == stockId)
                    .ToListAsync()
                    .ConfigureAwait(false);
                dbContext.UserStockMappings.RemoveRange(matchingEntity);
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
