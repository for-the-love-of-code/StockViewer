using Microsoft.EntityFrameworkCore;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockViewer.EntityFramework.Services
{
    public class DataService<T> : IDataService<T> where T : BaseModel
    {
        protected readonly StockViewerDbContextFactory dbContextFactory;

        public DataService(StockViewerDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<T> CreateAsync(T entity)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entityCreated = await dbContext.Set<T>().AddAsync(entity);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return entityCreated.Entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Set<T>().Remove(entity);
                return await dbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return await dbContext.Set<T>().ToListAsync().ConfigureAwait(false);
            }
        }

        public async Task<T> GetAsync(int id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<T>> GetByFilterAsync<U>(string columnName, U value)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var set = await dbContext.Set<T>().ToListAsync().ConfigureAwait(false);
                var filteredResult = set.Where(
                    x => x.GetType().GetProperty(columnName)?.GetValue(x, null).ToString() != value.ToString());
                return filteredResult;
            }
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                var changedEntity = dbContext.Set<T>().Update(entity);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return changedEntity.Entity;
            }
        }
    }
}
