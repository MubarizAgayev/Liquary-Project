using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductDetailController(AppDbContext context, IProductService productService, IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _productService = productService;
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index(int id)
        {
            Product product = await _productService.GetById(id);
            List<Review> review = await _context.Reviews.Where(m=>m.ProductId == id).ToListAsync();

            int basketCount = 0;
            if (User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
                List<Basket> baskets = await _context.Baskets.Where(m => m.UserId == result.Id && m.SoftDelete == false).ToListAsync();
                basketCount = baskets.Sum(m => m.Count);
            }
            if (basketCount > 0)
            {
                ViewBag.BasketCount = basketCount;
            }
            else
            {
                ViewBag.BasketCount = 0;
            }
            AppUser user1 = await _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefaultAsync();


            ProductDetailVM model = new()
            {
                Product = product,
                Reviews = review,
            };

            ViewBag.UserName = User.Identity.Name;
            ViewBag.Email = user1.Email;

            TempData["Id"] = id;

            return View(model);
        }

        public async Task<IActionResult> AddBasket(int? id,int count)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

                if (id is null) return BadRequest();

                Product dbProduct = await _productService.GetById((int)id);

                if (dbProduct == null) return NotFound();

                

                Basket existBasket = await _context.Baskets.Where(m => m.ProductId == id && m.UserId == result.Id).FirstOrDefaultAsync();
                List<Basket> baskets = await _context.Baskets.Where(m => m.UserId == result.Id).ToListAsync();

                int basketCount = 0;

                if (existBasket != null)
                {
                    existBasket.Count += count;
                    basketCount = baskets.Sum(m => m.Count) +count;
                }
                else
                {

                    Basket newBasket = new()
                    {
                        ProductId = (int)id,
                        UserId = result.Id,
                        Count = count
                    };
                    await _context.Baskets.AddAsync(newBasket);
                    basketCount = baskets.Sum(m => m.Count) + 1;
                }


                 

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


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(ReviewVM review)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser User = await _context.Users.Where(m => m.UserName == review.UserName && m.Email == review.Email).FirstOrDefaultAsync();
                if (User == null) { return NotFound(); }



                int id = Convert.ToInt32(TempData["Id"]);

                Product product = await _context.Product.Include(m => m.Reviews).FirstOrDefaultAsync(m => m.Id == id);

                decimal sum = product.Reviews.Sum(m => m.Raiting) + review.Raiting;
                decimal count = product.Reviews.Count + 1;

                product.Raiting = sum / count;


                Review newReview = new()
                {
                    ProductId = id,
                    UserId = User.Id,
                    Raiting = review.Raiting,
                    Tittle = review.Tittle,
                    Describtion = review.Describtion,
                    Username = User.UserName,
                    Email = User.Email,
                };

                await _context.Reviews.AddAsync(newReview);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }


}
