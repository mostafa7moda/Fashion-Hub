
using Microsoft.EntityFrameworkCore;

namespace FashionHub.Models
{
    [PrimaryKey(nameof(ProductId), nameof(OrderId))]
    public class Bill
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ItemPrice { get; set; }
        public int? TotalPrice { get; set; }
        public int? NUmItems { get; set; }
        public DateTime Date { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }



    }
}