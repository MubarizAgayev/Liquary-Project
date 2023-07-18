using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Models;

namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class ShopVM
    {
        public Paginate<ProductListVM> Products { get; set; }
    }
}
