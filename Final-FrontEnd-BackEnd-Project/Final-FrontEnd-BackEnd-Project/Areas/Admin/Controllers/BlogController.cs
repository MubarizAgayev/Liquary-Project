using Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels;
using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> blogs = await _context.Blog.Include(m=>m.BlogTags).ThenInclude(m=>m.Tag).ToListAsync();
            return View(blogs);
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.tags = await GetTagsAsync();
            return View();
        }

        private async Task<SelectList> GetTagsAsync()
        {
            IEnumerable<Tag> tags = await _context.Tag.ToListAsync();
            return new SelectList(tags, "Id", "TagName");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(BlogCreateVM model)
        {
            try
            {
                ViewBag.tags = await GetTagsAsync();

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (!model.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View();
                }

                if (!model.Photo.CheckFileSize(400))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 200kb");
                    return View();
                }


                string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/blogs/", fileName);

                await FileHelper.SaveFileAsync(path, model.Photo);

                List<BlogTag> tags = new();


                Blog newBlog = new()
                {
                    Tittle = model.Tittle,
                    Owner = model.Owner,
                    Describtion = model.Describtion,
                    Image = fileName,
                    BlogTags = tags,
                };


                

                foreach (var item in model.TagId)
                {
                    BlogTag blogTag = new()
                    {
                        BlogId = newBlog.Id,
                        TagId = item,
                    };
                    tags.Add(blogTag);
                }


             
                await _context.BlogTag.AddRangeAsync(tags);
                await _context.Blog.AddAsync(newBlog);
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
            Blog blog = await _context.Blog.FindAsync(id);
            List<BlogTag> blogTags = await _context.BlogTag.Where(m => m.BlogId == id).ToListAsync();


            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/blogs/", blog.Image);

            FileHelper.DeleteFile(path);

            foreach (var item in blogTags)
            {
                _context.BlogTag.Remove(item);
            }

            _context.Blog.Remove(blog);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Blog blog = await _context.Blog.Include(m=>m.BlogTags).ThenInclude(m=>m.Tag).FirstOrDefaultAsync(m=>m.Id == id);

            if (blog is null) return NotFound();

            return View(blog);
        }
    }
}
