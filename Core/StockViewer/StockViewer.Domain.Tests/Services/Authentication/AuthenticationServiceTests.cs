using Microsoft.AspNet.Identity;
using StockViewer.Domain.Models;
using StockViewer.Domain.Services.Authentication;
using StockViewer.Domain.Services.Data;
using System;
using System.Threading.Tasks;
using Telerik.JustMock;
using Telerik.JustMock.AutoMock;
using Xunit;

namespace StockViewer.Domain.Tests.Services.Authentication
{
    public class AuthenticationServiceTests
    {
        [Fact]
        public async Task RegisterAsync_ForValidInput_RegisterSuccessfullyAsync()
        {
            using (var container = CreateContainer())
            {
                // Arrange.
                var name = Guid.NewGuid().ToString();
                var userName = Guid.NewGuid().ToString();
                var password = Guid.NewGuid().ToString();
                var confirmPassword = Guid.NewGuid().ToString();

                container.Arrange<IUserDataService>(
                    userDataService =>
                    userDataService.UserNameExistsAsync(Arg.Matches<string>(a => a.Equals(userName))))
                    .Returns(false)
                    .OccursOnce();

                string passwordHash = Guid.NewGuid().ToString();
                container.Arrange<IPasswordHasher>(x => x.HashPassword(Arg.Matches<string>(x => x.Equals(password))))
                    .Returns(passwordHash)
                    .OccursOnce();
                container.Arrange<IUserDataService>(
                    x => x.CreateAsync(
                        Arg.Matches<User>(u => u.Name == name && u.PasswordHash == passwordHash)))
                    .OccursOnce();

                // Act.
                var result = await container.Instance.RegisterAsync(name, userName, password, password);

                // Assert.
                Assert.True(result);
            }
        }

        [Fact]
        public async Task RegisterAsync_ForExistingUser_ThrowsExceptionAsync()
        {
            using (var container = CreateContainer())
            {
                // Arrange.
                var name = Guid.NewGuid().ToString();
                var userName = Guid.NewGuid().ToString();
                var password = Guid.NewGuid().ToString();
                var confirmPassword = Guid.NewGuid().ToString();
                
                container.Arrange<IUserDataService>(
                    userDataService =>
                    userDataService.UserNameExistsAsync(Arg.Matches<string>(a => a.Equals(userName))))
                    .Returns(true)
                    .OccursOnce();

                container.Arrange<IPasswordHasher>(x => x.HashPassword(Arg.AnyString))
                    .OccursNever();
                container.Arrange<IUserDataService>(x => x.CreateAsync(Arg.IsAny<User>()))
                    .OccursNever();

                // Act & Assert.
                var result =
                    await Assert.ThrowsAsync<Exception>(async () => await container.Instance.RegisterAsync(name, userName, password, password));
            }
        }

        [Fact]
        public async Task LoginAsync_ForCorrectCredentials_LoginSuccessfullyAsync()
        {
            return;
        }

        [Fact]
        public async Task LoginAsync_ForIncorrectPassword_ThrowsExceptionAsync()
        {
            return;
        }

        private MockingContainer<AuthenticationService> CreateContainer()
        {
            return new MockingContainer<AuthenticationService>(new AutoMockSettings { MockBehavior = Behavior.Strict });
        }

    }
}
