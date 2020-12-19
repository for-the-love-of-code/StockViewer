using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using StockViewer.EntityFramework;
using StockViewer.EntityFramework.Services;
using StockViewer.StockApiService;
using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels;
using StockViewerUI.ViewModels.Factories;
using StockViewerUI.Views;
using System;
using static StockViewerUI.ViewModels.ViewModelBase;

namespace StockViewerUI
{
    public class 
        AppCatalog
    {
        public static IServiceProvider ServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Http
            services.AddHttpClient<StockServiceClient>(c => c.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/"));

            // Services
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
            services.AddSingleton<IStockDataService, StockDataService>();

            // Factories.
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            // Abstracting the implementation of creation of view models.
            services.AddSingleton<CreateViewModel<WatchListViewModel>>(
                s =>
                () => new WatchListViewModel(
                    s.GetRequiredService<IStockService>(),
                    s.GetRequiredService<IUserManager>(),
                    s.GetRequiredService<IUserStockMappingDataService>()));

            services.AddSingleton<CreateViewModel<LoginViewModel>>(
                s =>
                () => new LoginViewModel(
                    s.GetRequiredService<IUserManager>(),
                    new ViewModelNavigationController<WatchListViewModel>(
                        s.GetRequiredService<ICurrentContext>(),
                        s.GetRequiredService<CreateViewModel<WatchListViewModel>>()),
                    new ViewModelNavigationController<RegisterViewModel>(
                        s.GetRequiredService<ICurrentContext>(),
                        s.GetRequiredService<CreateViewModel<RegisterViewModel>>()))
                    );

            services.AddSingleton<CreateViewModel<RegisterViewModel>>(
                s =>
                () => new RegisterViewModel(
                    s.GetRequiredService<IUserManager>(),
                    new ViewModelNavigationController<LoginViewModel>(
                        s.GetRequiredService<ICurrentContext>(),
                        s.GetRequiredService<CreateViewModel<LoginViewModel>>())));

            // View models and associated components.
            services.AddScoped(
                s => new MainViewModel(
                    s.GetRequiredService<ICurrentContext>(),
                    s.GetRequiredService<IViewModelFactory>(),
                    s.GetRequiredService<IUserManager>(),
                    new ViewModelNavigationController<LoginViewModel>(
                        s.GetRequiredService<ICurrentContext>(),
                        s.GetRequiredService<CreateViewModel<LoginViewModel>>())));

            services.AddScoped<WatchListViewModel>();
            services.AddScoped<MainWindow>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ICurrentContext, CurrentContext>();

            // Main Window.
            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
