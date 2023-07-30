using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CommentController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Review> reviews = await _context.Reviews.ToListAsync();
            return View(reviews);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Review review = await _context.Reviews.FindAsync(id);

            if (review is null) return NotFound();


            return View(review);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            Review review = await _context.Reviews.FindAsync(id);

            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
