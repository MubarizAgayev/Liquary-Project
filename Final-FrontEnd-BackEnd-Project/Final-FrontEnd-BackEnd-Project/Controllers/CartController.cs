using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(AppDbContext context, IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            int basketCount = 0;

            if(User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

                List<Basket> baskets = await _context.Baskets.Where(m=>m.UserId == result.Id).ToListAsync();
                List<BasketDetailVM> basketDetails = new();


            

                foreach (var product in baskets)
                {
                    //Product dbProduct = await _productService.GetById(product.Id);
                    Product dbProduct = await _context.Product.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == product.ProductId);
                    basketDetails.Add(new BasketDetailVM
                    {
                        Id = dbProduct.Id,
                        Name = dbProduct.Name,
                        Price = dbProduct.Price,
                        Image = dbProduct.Images.Where(m => m.IsMain).FirstOrDefault().Image,
                        Count = product.Count,
                        Total = dbProduct.Price * product.Count,
                    });
                }

                basketCount = baskets.Sum(m => m.Count);
                if (basketCount > 0)
                {
                    ViewBag.BasketCount = basketCount;
                }
                else
                {
                    ViewBag.BasketCount = 0;
                }

               

                return View(basketDetails);
            }
            else
            {
                ViewBag.BasketCount = basketCount;
                return View();
            }
        }

        public async Task<IActionResult> IncreaseProductCount(int? id)
        {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

                if (id is null) return BadRequest();


               Basket dbBasket = await _context.Baskets.Where(m=>m.ProductId == id && m.UserId == result.Id).FirstOrDefaultAsync();

                dbBasket.Count += 1;
                List<Basket> dbBaskets = await _context.Baskets.Where(m => m.UserId == result.Id).ToListAsync();

                int basketCount = dbBaskets.Sum(m => m.Count) + 1;

                if (basketCount > 0)
                {
                    ViewBag.BasketCount = basketCount;
                }
                else
                {
                    ViewBag.BasketCount = 0;
                }

                await _context.SaveChangesAsync();

                return Ok();

        }



        public async Task<IActionResult> DecreaseProductCount(int? id)
        {
            AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

            if (id is null) return BadRequest();

            Basket dbBasket = await _context.Baskets.Where(m => m.ProductId == id && m.UserId == result.Id).FirstOrDefaultAsync();

            dbBasket.Count -= 1;
            List<Basket> dbBaskets = await _context.Baskets.Where(m => m.UserId == result.Id).ToListAsync();

            int basketCount = dbBaskets.Sum(m => m.Count) - 1;

            if (basketCount > 0)
            {
                ViewBag.BasketCount = basketCount;
            }
            else
            {
                ViewBag.BasketCount = 0;
            }

            await _context.SaveChangesAsync();

            return Ok();

        }



        public async Task<IActionResult> DeleteProductFromBasket(int? id)
        {
            if (id is null) return BadRequest();
            AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

            int basketCount = 0;
            List<Basket> deletedBasket = await _context.Baskets.Where(m => m.ProductId == id && m.UserId == result.Id).ToListAsync();

            List<Basket> dbBaskets = await _context.Baskets.Where(m => m.UserId == result.Id).ToListAsync();

            basketCount = dbBaskets.Sum(m => m.Count) - deletedBasket.Sum(m=>m.Count);

            if (basketCount > 0)
            {
                ViewBag.BasketCount = basketCount;
            }
            else
            {
                ViewBag.BasketCount = 0;
            }

            foreach (var item in deletedBasket)
            {
                _context.Baskets.Remove(item);
            }
             
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
