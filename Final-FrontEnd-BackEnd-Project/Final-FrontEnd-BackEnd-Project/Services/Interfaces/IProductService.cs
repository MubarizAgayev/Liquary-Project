using Final_FrontEnd_BackEnd_Project.Models;

namespace Final_FrontEnd_BackEnd_Project.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<List<Product>> GetPaginatedDatas(int page, int take,string searchText, string filter);
        Task<int> GetCountAsync();
    }
}
