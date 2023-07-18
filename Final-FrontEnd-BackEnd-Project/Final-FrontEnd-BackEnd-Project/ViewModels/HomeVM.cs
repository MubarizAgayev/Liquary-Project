using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.ViewModels.Account;

namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Slider { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Offer> Offers { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
