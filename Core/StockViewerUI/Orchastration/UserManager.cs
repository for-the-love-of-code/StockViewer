using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewerUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace StockViewerUI.Orchastration
{
    public class UserManager : IUserManager
    {
        private IAuthenticationService authenticantionService;

        public UserManager(IAuthenticationService authenticantionService)
        {
            this.authenticantionService = authenticantionService;
        }

        public UserAccount CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> LoginAsync(string userName, string password)
        {
            try
            {
                CurrentUser = await authenticantionService.LoginAsync(userName, password);
                return IsLoggedIn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<bool> RegisterAsync(string name, string userName, string password, string confirmPassword)
        {
            return await authenticantionService.RegisterAsync(name, userName, password, confirmPassword);
        }
    }
}
