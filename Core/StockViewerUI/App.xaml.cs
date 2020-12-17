using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockViewer.EntityFramework;
using System;
using System.Windows;

namespace StockViewerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = AppCatalog.ServiceProvider();

            var dbContextFactory = serviceProvider.GetRequiredService<StockViewerDbContextFactory>();
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            var window = serviceProvider.GetRequiredService<MainWindow>();

            window.Show();
            base.OnStartup(e);
        }
    }
}
