using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = await _context.Contact.ToListAsync();
            return View(contacts);
        }


        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            Contact contact = await _context.Contact.FindAsync(id);

            _context.Contact.Remove(contact);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Contact contact = await _context.Contact.FindAsync(id);

            if (contact is null) return NotFound();


            return View(contact);
        }

    }
}
