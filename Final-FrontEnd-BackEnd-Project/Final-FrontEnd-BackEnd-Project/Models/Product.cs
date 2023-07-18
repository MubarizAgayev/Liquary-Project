namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Describtion { get; set; }
        public int Count { get; set; }
        public decimal Raiting { get; set; } = 0;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool InStock { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
