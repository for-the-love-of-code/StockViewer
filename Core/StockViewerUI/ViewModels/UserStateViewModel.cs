using StockViewerUI.Orchastration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.ViewModels
{
    public class UserStateViewModel : ViewModelBase
    {
        private readonly IUserManager userManager;
        private bool isLoggedIn;
        private string welcomeMessage;

        public UserStateViewModel(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }
            set
            {
                isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public string WelcomeMessage
        {
            get => welcomeMessage;
            set => welcomeMessage = value;
        }
    }
}
