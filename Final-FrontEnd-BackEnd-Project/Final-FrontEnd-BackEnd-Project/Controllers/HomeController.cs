﻿using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
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
                ViewBag.BasketCount = basketCount;
            }
            else
            {
                ViewBag.BasketCount = 0;
            }
            if (basketCount > 0)
            {
                ViewBag.BasketCount = basketCount;
            }
            else
            {
                ViewBag.BasketCount = 0;
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

                int basketCount = baskets.Sum(m => m.Count);

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