using System;
using System.Collections.Generic;
using System.Text;

namespace StockViewer.Domain.Models
{
    public class UserAccount
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public List<Stock> WatchList { get; set; }
    }
}
