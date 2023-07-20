using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WishlistController(AppDbContext context, IProductService productService, IBasketService basketService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _productService = productService;
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            int basketCount = 0;
            List<Wishlist> wishlists = new List<Wishlist>();
            if (User.Identity.IsAuthenticated)
            {
                List<WishListDetailVM> wishListDetailVMs = new();
                AppUser user = _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault();
                wishlists = await _context.Wishlist.Where(m => m.UserId == user.Id).ToListAsync();

                List<Basket> baskets = await _context.Baskets.Where(m => m.UserId == user.Id && m.SoftDelete == false).ToListAsync();
                basketCount = baskets.Sum(m => m.Count);
                if (basketCount > 0)
                {
                    ViewBag.BasketCount = basketCount;
                }
                else
                {
                    ViewBag.BasketCount = 0;
                }
                int wishListCount = wishlists.Count;

                if (wishListCount > 0)
                {
                    ViewBag.WishListCount = wishListCount;
                }
                else
                {
                    ViewBag.WishListCount = 0;
                }

                foreach (var item in wishlists)
                {
                    Product dbProduct = await _context.Product.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == item.ProductId);
                        wishListDetailVMs.Add(new WishListDetailVM
                        {
                            Id = dbProduct.Id,
                            Name = dbProduct.Name,
                            Price = dbProduct.Price,
                            MainImage = dbProduct.Images.Where(m => m.IsMain).FirstOrDefault().Image,
                            SecondImage = dbProduct.Images.Where(m=>!m.IsMain).FirstOrDefault().Image,
                            Raiting = dbProduct.Raiting,
                            InStock = dbProduct.InStock
                        });
                }
                
                return View(wishListDetailVMs);

            }
            else
            {
                ViewBag.WishListCount = 0;
                ViewBag.BasketCount = 0;
                return View(wishlists);
            }
            

        }



        public async Task<IActionResult> RemoveWish(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser result = await _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);

                if (id is null) return BadRequest();

                Product dbProduct = await _productService.GetById((int)id);

                if (dbProduct == null) return NotFound();

                Wishlist existWishlist = await _context.Wishlist.Where(m => m.ProductId == id && m.UserId == result.Id).FirstOrDefaultAsync();

                _context.Wishlist.Remove(existWishlist);


                List<Wishlist> wishlists = await _context.Wishlist.Where(m => m.UserId == result.Id).ToListAsync();

                int wishListCount = wishlists.Count - 1;

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
