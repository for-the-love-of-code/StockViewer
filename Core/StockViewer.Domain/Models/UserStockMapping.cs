
namespace StockViewer.Domain.Models
{
    public class UserStockMapping : BaseModel
    {
        public int UserId { get; set; }

        public int StockId { get; set; }

        public User User { get; set; }

        public Stock Stock { get; set; }
    }
}
