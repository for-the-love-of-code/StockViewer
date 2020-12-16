using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewer.EntityFramework;
using StockViewer.EntityFramework.Services;
using StockViewer.StockApiService;
using StockViewerUI.Orchastration;
using StockViewerUI.State.Navigators;
using StockViewerUI.ViewModels;
using StockViewerUI.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI
{
    public class AppCatalog
    {
        public static IServiceProvider ServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDataService<User>, DataService<User>>();
            services.AddSingleton<IDataService<Stock>, DataService<Stock>>();
            services.AddSingleton<IDataService<UserStockMapping>, UserStockMappingDataService>();
            services.AddSingleton<IUserStockMappingDataService, UserStockMappingDataService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IUserDataService, UserDataService>();
            services.AddSingleton<IDataService<User>, UserDataService>();
            services.AddSingleton<IStockService, StockService>();
            services.AddSingleton<StockViewerDbContextFactory>();

            // Factories - wrappers over ViewModels.
            services.AddSingleton<IBaseViewModelFactory, BaseViewModelFactory>();
            services.AddSingleton<IGenericViewModelFactory<WatchListViewModel>, WatchListViewModelFactory>();
            services.AddSingleton<IGenericViewModelFactory<LoginViewModel>, LoginViewModelFactory>();
            services.AddSingleton<IGenericViewModelFactory<RegisterViewModel>, RegisterViewModelFactory>();

            services.AddScoped<MainViewModel>();
            services.AddScoped<WatchListViewModel>();
            services.AddScoped<MainWindow>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<INavigator, Navigator>();

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
