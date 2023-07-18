using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.ViewModels;

namespace Final_FrontEnd_BackEnd_Project.Services.Interfaces
{
    public interface IBasketService
    {
        List<BasketVM> GetBasketDatas();
        void AddProductToBasket(BasketVM? existProduct, Product product, List<BasketVM> basket,string UserId);
        void DeleteProductFromBasket(int id);
    }
}
