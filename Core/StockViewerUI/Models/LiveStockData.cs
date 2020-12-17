using StockViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewerUI.Models
{
    public class LiveStockData : Stock
    {
        public bool IsPositiveChange { get; set; }
        public string PercentageChange { get; set; }
    }
}
