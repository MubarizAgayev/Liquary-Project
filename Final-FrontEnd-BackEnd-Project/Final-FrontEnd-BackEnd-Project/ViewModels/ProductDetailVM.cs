using Final_FrontEnd_BackEnd_Project.Models;

namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public bool InWish { get; set; }
        public ReviewVM Review { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
