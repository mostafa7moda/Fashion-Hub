namespace FashionHub.Models
{
    public class Admin : Person
    {
        public bool IsOwner { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
