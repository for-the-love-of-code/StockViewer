
namespace StockViewer.Domain.Models
{
    public class Stock : BaseModel
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double PreviousClose { get; set; }

        public double YearLow { get; set; }

        public double YearHigh { get; set; }
    }
}
