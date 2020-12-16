using Microsoft.EntityFrameworkCore;
using StockViewer.Domain.Models;

namespace StockViewer.EntityFramework
{
    public class StockViewerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserStockMapping> UserStockMappings { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public StockViewerDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
