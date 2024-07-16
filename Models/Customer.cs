namespace FashionHub.Models
{
    public class Customer : Person
    {
        public ICollection<Order> Orders { get; set; }

    }
}
