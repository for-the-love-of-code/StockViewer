using Microsoft.EntityFrameworkCore;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StockViewer.EntityFramework.Services
{
    public class UserDataService : DataService<User>, IUserDataService
    {
        public UserDataService(StockViewerDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return await dbContext.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync().ConfigureAwait(false);
            }
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                return (await dbContext.Users.Where(x => x.UserName == userName).CountAsync().ConfigureAwait(false)) > 0;
            }
        }
    }
}
