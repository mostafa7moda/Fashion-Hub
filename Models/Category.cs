namespace FashionHub.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }

    }
}
