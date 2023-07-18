using Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels;
using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _context.Tag.ToListAsync();

            return View(tags);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(TagCreateVM model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var existData = await _context.Tag.FirstOrDefaultAsync(m => m.TagName.Trim().ToLower() == model.TagName.Trim().ToLower());

                if (existData is not null)
                {
                    ModelState.AddModelError("Name", "This data already exist");
                    return View();
                }


                Tag newTag = new()
                {
                    TagName = model.TagName,

                };


                await _context.Tag.AddAsync(newTag);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", new { msj = ex.Message }); ;
            }
        }



        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            Tag tag = await _context.Tag.FindAsync(id);

            List<Blog> blog = await _context.Blog.Include(m=>m.BlogTags).ToListAsync();
            List<BlogTag> blogTag = await _context.BlogTag.Where(m=>m.TagId == id).ToListAsync();

            if(blogTag != null)
            {
                foreach (var item in blogTag)
                {
                    _context.Remove(item);
                }
            }

            _context.Tag.Remove(tag);



            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return BadRequest();

            Tag tag = await _context.Tag.FindAsync(id);

            if (tag is null) return NotFound();

            TagEditVM tagEditVM = new()
            {
                TagName = tag.TagName,
            };
            return View(tagEditVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id, TagEditVM model)
        {


            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Tag dbTag = await _context.Tag.FindAsync(id);

                if (dbTag is null) return NotFound();

                dbTag.TagName = model.TagName;

                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
