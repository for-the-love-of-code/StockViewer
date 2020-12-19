using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockViewerUI.Commands;
using StockViewerUI.Orchastration;
using StockViewerUI.State.CurrentContext;
using StockViewerUI.ViewModels.Factories;
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

		private string password;

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public ICommand LoginCommand { get; }
		public ICommand ViewRegisterCommand { get; }

		public LoginViewModel(
			IUserManager userManager,
			IRenavigator watchListNavigator,
			IRenavigator registerRenavigator)
		{
			LoginCommand = new LoginCommand(userManager, this, watchListNavigator);
			ViewRegisterCommand = new RedirectCommand(registerRenavigator);
		}

		private string error;
		public string Error
		{
			get
			{
				return error;
			}
			set
			{
				error = value;
				if (!string.IsNullOrEmpty(value))
					hasErrorOccurred = true;
				OnPropertyChanged(nameof(Error));
				OnPropertyChanged(nameof(HasErrorOccurred));
			}
		}

		private bool hasErrorOccurred;
		public bool HasErrorOccurred
		{
			get
			{
				return hasErrorOccurred;
			}
			set
			{
				hasErrorOccurred = value;
				OnPropertyChanged(nameof(HasErrorOccurred));
			}
		}
	}
}
