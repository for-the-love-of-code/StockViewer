using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockViewer.EntityFramework
{
    public class StockViewerDbContextFactory : IDesignTimeDbContextFactory<StockViewerDbContext>
    {
        public StockViewerDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockViewerDbContext>(); 
                optionsBuilder.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=StockViewerDB;Integrated Security=True;" +
                    "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                    "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new StockViewerDbContext(optionsBuilder.Options);
        }
    }
}
