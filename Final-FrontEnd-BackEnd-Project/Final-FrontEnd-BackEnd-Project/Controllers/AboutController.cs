using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Final_FrontEnd_BackEnd_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBasketService _basketService;
        public AboutController(AppDbContext context, IBasketService basketService)
        {
            _context = context;
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            List<Person> people = await _context.Person.ToListAsync();

            AboutVM model = new()
            {
                People = people,
            };


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

            

            return View(model);
        }
    }
}
