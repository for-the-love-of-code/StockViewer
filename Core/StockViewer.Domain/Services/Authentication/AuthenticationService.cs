using Microsoft.AspNet.Identity;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockViewer.Domain.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDataService userDataService;
        private readonly IUserStockMappingDataService userStockMappingDataService;
        private readonly IPasswordHasher hasher;

        public AuthenticationService(IUserDataService userDataService, IUserStockMappingDataService userStockMappingDataService, IPasswordHasher passwordHasher)
        {
            this.userDataService = userDataService;
            this.userStockMappingDataService = userStockMappingDataService;
            this.hasher = passwordHasher;
        }

        public async Task<UserAccount> LoginAsync(string userName, string password)
        {
            var user = await userDataService.GetByUserNameAsync(userName);
            if (user == null)
            {
                // Define cutom exception.
                throw new Exception("User does not exist.");
            }

            var verificationResult = hasher.VerifyHashedPassword(user.PasswordHash, password);

            if(verificationResult == PasswordVerificationResult.Success)
            {
                var stocks = (await userStockMappingDataService.GetStocksForUserAsync(user.Id)).Select(x => x.Stock).ToList();

                return new UserAccount()
                {
                    Name = user.Name,
                    UserId = user.Id,
                    WatchList = stocks,
                };
            }

            throw new Exception("Incorrect Password.");
        }

        public async Task<bool> RegisterAsync(string name, string userName, string password, string confirmPassword)
        {
            var success = false;

            if (await userDataService.UserNameExistsAsync(userName))
                throw new Exception("User exists.");

            IPasswordHasher hasher = new PasswordHasher();
            var passwordhash = hasher.HashPassword(password);

            if (password == confirmPassword)
            {
                var user = new User()
                {
                    Name = name,
                    UserName = userName,
                    PasswordHash = passwordhash,
                };
                var createdUser = await userDataService.CreateAsync(user);
                success = createdUser != null;
            }

            return success;
        }
    }
}
