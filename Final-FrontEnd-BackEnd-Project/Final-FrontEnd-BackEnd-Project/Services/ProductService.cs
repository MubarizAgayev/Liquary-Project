using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Product> GetById(int id) => await _context.Product.Include(m => m.Category).Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);
        public async Task<IEnumerable<Product>> GetAll() => await _context.Product.Include(m => m.Category).Include(m => m.Images).ToListAsync();
        public async Task<int> GetCountAsync()
        {
            return await _context.Product.CountAsync();
        }
        public async Task<List<Product>> GetPaginatedDatas(int page, int take, string searchText, string filter)
        {
            if (searchText == null || searchText == "")
            {
                if (filter == "All")
                {
                    return await _context.Product.Include(m => m.Images).OrderByDescending(m => m.Name).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Alphabetically,Z-A")
                {
                    return await _context.Product.Include(m => m.Images).OrderBy(m => m.Name).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Alphabetically,A-Z")
                {
                    return await _context.Product.Include(m => m.Images).OrderBy(m => m.Name).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Price,Low to High")
                {
                    return await _context.Product.Include(m => m.Images).OrderBy(m => m.Price).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Price,High to Low")
                {
                    return await _context.Product.Include(m => m.Images).OrderByDescending(m => m.Price).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Date,Old to New")
                {
                    return await _context.Product.Include(m => m.Images).OrderBy(m => m.CreateDate).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Date,New to Old")
                {
                    return await _context.Product.Include(m => m.Images).OrderByDescending(m => m.CreateDate).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Best Selling")
                {
                    return await _context.Product.Include(m => m.Images).OrderByDescending(m => m.Raiting).Skip((page * take) - take).Take(take).ToListAsync();
                }
                return await _context.Product.Include(m => m.Images).Skip((page * take) - take).Take(take).ToListAsync(); ;
            }
            else
            {
                if (filter == "All")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Alphabetically,Z-A")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Alphabetically,A-Z")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Price,Low to High")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Price,High to Low")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Date,Old to New")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Date,New to Old")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                else if (filter == "Best Selling")
                {
                    return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
                }
                return await _context.Product.Include(m => m.Images).Where(m => m.Name.Trim().ToLower().StartsWith(searchText.Trim().ToLower())).Skip((page * take) - take).Take(take).ToListAsync();
            }

        }
    }
}
