using StockViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockViewerUI.Orchastration
{
    public interface IUserManager
    {
        UserAccount CurrentUser { get; }

        bool IsLoggedIn { get; }

        Task<bool> RegisterAsync(string name, string userName, string password, string confirmPassword);

        Task<bool> LoginAsync(string userName, string password);

        void Logout();
    }
}
