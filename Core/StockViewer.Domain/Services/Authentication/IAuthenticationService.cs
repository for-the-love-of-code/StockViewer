using StockViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterAsync(string displayName, string userName, string password, string confirmPassword);

        Task<UserAccount> LoginAsync(string userName, string password);
    }
}
