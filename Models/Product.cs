using System.ComponentModel.DataAnnotations.Schema;

namespace FashionHub.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Details { get; set; }
        public string CategoryName { get; set; }
        [NotMapped]
        public IFormFile ProductImg { get; set; }
        public string ImagePath {  get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; } 

    }
}
