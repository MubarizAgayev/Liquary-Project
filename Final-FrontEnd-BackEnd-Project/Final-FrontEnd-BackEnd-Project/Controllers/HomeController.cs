using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(AppDbContext context, IProductService productService, IBasketService basketService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _productService = productService;
            _basketService = basketService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            

            List<Slider> slider = await _context.Sliders.ToListAsync();
            List<Category> categories = await _context.Category.ToListAsync();
            List<Product> products = await _context.Product.Include(m => m.Category).Include(m => m.Images).ToListAsync();
            List<Offer> offers = await _context.Offer.ToListAsync();
            List<Blog> blogs = await _context.Blog.Include(m => m.BlogTags).ThenInclude(m => m.Tag).ToListAsync();
            


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


            HomeVM model = new()
            {
                Offers= offers,
                Categories = categories,
                Products= products,
                Slider = slider,
                Blogs= blogs
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AddBasket(int? id)
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

                int basketCount = baskets.Sum(m => m.Count)+1;

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





        public async Task<IActionResult> AddWishList(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

                if (id is null) return BadRequest();

                Product dbProduct = await _productService.GetById((int)id);

                if (dbProduct == null) return NotFound();

                Wishlist existWishlist = await _context.Wishlist.Where(m => m.ProductId == id && m.UserId == result.Id).FirstOrDefaultAsync();

                if (existWishlist != null)
                {
                    _context.Wishlist.Remove(existWishlist);
                }
                else
                {

                    Wishlist newWishlist = new()
                    {
                        ProductId = (int)id,
                        UserId = result.Id,
                    };
                    await _context.Wishlist.AddAsync(newWishlist);
                }


                List<Wishlist> wishlists = await _context.Wishlist.Where(m => m.UserId == result.Id).ToListAsync();

                int wishListCount = wishlists.Count+1;

                if (wishListCount > 0)
                {
                    ViewBag.WishListCount = wishListCount;
                }
                else
                {
                    ViewBag.WishListCount = 0;
                }

                await _context.SaveChangesAsync();

                return Ok(wishListCount);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

    }
}