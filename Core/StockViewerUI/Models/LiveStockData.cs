using StockViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StockViewerUI.Models
{
    public class LiveStockData : Stock, INotifyPropertyChanged
    {
		private bool isPositiveChange;
		public bool IsPositiveChange
		{
			get
			{
				return isPositiveChange;
			}
			set
			{
				isPositiveChange = value;
				OnPropertyChanged(nameof(IsPositiveChange));
			}
		}
		public string PercentageChange { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
