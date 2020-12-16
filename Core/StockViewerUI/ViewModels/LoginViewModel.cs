using StockViewerUI.Commands;
using StockViewerUI.Orchastration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockViewerUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
		private string userName;
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				userName = value;
				OnPropertyChanged(nameof(UserName));
			}
		}

		public ICommand LoginCommand { get; }

		public LoginViewModel(IUserManager userManager)
		{
			LoginCommand = new LoginCommand(userManager, this);
		}
	}
}
