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
    public class RegisterViewModel : ViewModelBase
    {
		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
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

		private string confirmPassword;
		public string ConfirmPassword
		{
			get
			{
				return confirmPassword;
			}
			set
			{
				confirmPassword = value;
				OnPropertyChanged(nameof(ConfirmPassword));
			}
		}

		public ICommand RegisterCommand { get; }

		public ICommand ViewLoginCommand { get; }

		public RegisterViewModel(IUserManager userManager, IRenavigator loginNavigator)
		{
			RegisterCommand = new RegisterCommand(this, userManager, loginNavigator);
			ViewLoginCommand = new RedirectCommand(loginNavigator);
		}
	}
}
