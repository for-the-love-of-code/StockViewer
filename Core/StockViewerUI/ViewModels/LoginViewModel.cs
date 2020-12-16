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
			ICurrentContext navigator,
			IGenericViewModelFactory<WatchListViewModel> viewModelFactory,
			IGenericViewModelFactory<RegisterViewModel> registerViewModelFactory)
		{
			LoginCommand = new LoginCommand(userManager, this, navigator, viewModelFactory);
			ViewRegisterCommand = new ViewRegisterCommand(navigator, registerViewModelFactory);
		}
	}
}
