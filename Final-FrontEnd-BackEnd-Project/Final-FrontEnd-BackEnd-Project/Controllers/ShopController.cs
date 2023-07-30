using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShopController(AppDbContext context, IBasketService basketService, IProductService productService)
        {
            _context = context;
            _basketService = basketService;
            _productService = productService;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(string searchText = null,string filter = null,string category = null,int page = 1, int take = 6)
        {
            List<Category> categories = await _context.Category.ToListAsync();

            List<Product> products = await _productService.GetPaginatedDatas(page, take, searchText, filter,category);
            List<ProductListVM> mappedDatas = GetMappedDatas(products);
            int pageCount = await GetPageCountAsync(take,searchText,category,filter);

            Paginate<ProductListVM> paginatedDatas = new(mappedDatas, page, pageCount);

            int basketCount = 0;
            if (User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
                List<Basket> baskets = await _context.Baskets.Where(m => m.UserId == result.Id && m.SoftDelete == false).ToListAsync();
                basketCount = baskets.Sum(m => m.Count);
                List<Wishlist> wishlists = await _context.Wishlist.Where(m => m.UserId == result.Id).ToListAsync();

                int wishListCount = wishlists.Count;

                if (basketCount > 0)
                {
                    ViewBag.BasketCount = basketCount;
                }
                else
                {
                    ViewBag.BasketCount = 0;
                }

                if (wishListCount > 0)
                {
                    ViewBag.WishListCount = wishListCount;
                }
                else
                {
                    ViewBag.WishListCount = 0;
                }

            }
            else
            {
                ViewBag.BasketCount = 0;
                ViewBag.WishListCount = 0;
            }

            ShopVM model = new()
            {
                Products = paginatedDatas,
                Categories = categories
            };



            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Sort(string filter, int page = 1, int take = 6)
        {
            ViewBag.Text = filter;
            List<Product> products = await _productService.GetPaginatedDatas(page, take, null, filter,null);
            List<ProductListVM> mappedDatas = GetMappedDatas(products);
            int pageCount = await GetPageCountAsync(take,null,null,filter);

            Paginate<ProductListVM> paginatedDatas = new(mappedDatas, page, pageCount);

            return PartialView("_ProductSortPartial",paginatedDatas);
        }

        [HttpGet]
        public async Task<IActionResult> CategorySort(string category, int page = 1, int take = 6)
        {
            List<Product> products = await _productService.GetPaginatedDatas(page, take, null, null, category);
            List<ProductListVM> mappedDatas = GetMappedDatas(products);
            int pageCount = await GetPageCountAsync(take,null,category,null);

            Paginate<ProductListVM> paginatedDatas = new(mappedDatas, page, pageCount);

            ViewBag.Text = category;

            return PartialView("_ProductSortPartial", paginatedDatas);
        }

        private async Task<int> GetPageCountAsync(int take,string searchText,string category,string filter)
        {
            var productCount = await _productService.GetCountAsync(searchText,category,filter);
            return (int)Math.Ceiling((decimal)productCount / take);
        }

        private List<ProductListVM> GetMappedDatas(List<Product> products)
        {
            List<ProductListVM> mappedDatas = new();
            foreach (Product product in products)
            {
                ProductListVM productVM = new()
                {
                    Id = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Raiting = (int)product.Raiting,
                    MainImage = product.Images.Where(m => m.IsMain).FirstOrDefault().Image,
                    SecondImage = product.Images.Where(m => !m.IsMain).FirstOrDefault().Image,
                    InStock = product.InStock
                };

                mappedDatas.Add(productVM);
            }
            return mappedDatas;
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

                if (id is null) return BadRequest();

                Product dbProduct = await _productService.GetById((int)id);

                if (dbProduct == null) return NotFound();

                Basket existBasket = await _context.Baskets.Where(m => m.ProductId == id && m.UserId == result.Id).FirstOrDefaultAsync();

                if (existBasket != null)
                {
                    existBasket.Count += 1;
                }
                else
                {

                    Basket newBasket = new()
                    {
                        ProductId = (int)id,
                        UserId = result.Id,
                        Count = 1
                    };
                    await _context.Baskets.AddAsync(newBasket);
                }
                List<Basket> baskets = await _context.Baskets.Where(m => m.UserId == result.Id).ToListAsync();



                int basketCount = baskets.Sum(m => m.Count) + 1;

                if (basketCount > 0)
                {
                    ViewBag.BasketCount = basketCount;
                }
                else
                {
                    ViewBag.BasketCount = 0;
                }

                await _context.SaveChangesAsync();

                return Ok(basketCount);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
