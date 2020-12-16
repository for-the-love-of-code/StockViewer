
namespace StockViewer.Domain.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}
