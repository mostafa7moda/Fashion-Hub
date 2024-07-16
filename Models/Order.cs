namespace FashionHub.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int NumItem { get; set; }
        public string OrderDetail { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
