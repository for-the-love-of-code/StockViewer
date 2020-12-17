using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockViewer.EntityFramework
{
    public class StockViewerDbContextFactory : IDesignTimeDbContextFactory<StockViewerDbContext>
    {
        public StockViewerDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockViewerDbContext>(); 
                optionsBuilder.UseSqlite(
                    "Data Source=StockViewer.db");

            return new StockViewerDbContext(optionsBuilder.Options);
        }
    }
}
