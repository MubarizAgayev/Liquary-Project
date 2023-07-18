using Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels;
using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Category.ToListAsync();
            return View(categories);
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
        public async Task<IActionResult> Create(CategoryCreateVM model)
        {
            try
            { 

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (!model.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View();
                }

                if (!model.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 200kb");
                    return View();
                }

                if (!model.Color.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View();
                }

                if (!model.Color.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 200kb");
                    return View();
                }

                string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/", fileName);

                await FileHelper.SaveFileAsync(path, model.Photo);


                string fileName2 = Guid.NewGuid().ToString() + "_" + model.Color.FileName;

                string path2 = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/category-background/", fileName);

                await FileHelper.SaveFileAsync(path2, model.Color);

                Category newCategory = new()
                {
                    CategoryName = model.Name,
                    CategoryImage = fileName,
                    BackgroundColor = fileName2

                };


                await _context.Category.AddAsync(newCategory);
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
            Category category = await _context.Category.FindAsync(id);

            List<Product> product = await _context.Product.Where(m=>m.CategoryId == id).ToListAsync();

            if(product != null)
            {
                foreach (var item in product)
                {
                    foreach (var image in item.Images)
                    {
                        string pathImage = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/products/", image.Image);
                        FileHelper.DeleteFile(pathImage);

                        _context.ProductImage.Remove(image);
                    }
                    _context.Product.Remove(item);
                }
            }

            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/", category.CategoryImage);
            FileHelper.DeleteFile(path);

            string path1 = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/category-background/", category.BackgroundColor);
            FileHelper.DeleteFile(path1);

            _context.Category.Remove(category);

            

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Category.FindAsync(id);

            if (category is null) return NotFound();


            return View(category);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return BadRequest();

            Category category = await _context.Category.FindAsync(id);

            if (category is null) return NotFound();

            CategoryEditVM categoryEditVM = new()
            {
                Name = category.CategoryName,
                Image = category.CategoryImage,
                BackgroundColor = category.BackgroundColor,
            };
            return View(categoryEditVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM model)
        {


            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Category dbCategory = await _context.Category.FindAsync(id);

                if (dbCategory is null) return NotFound();



                if(model.Photo != null)
                {
                    if (!model.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View();
                    }

                    if (!model.Photo.CheckFileSize(400))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 400kb");
                        return View();
                    }


                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/", dbCategory.CategoryImage);

                    FileHelper.DeleteFile(oldPath);



                    string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/", fileName);

                    await FileHelper.SaveFileAsync(path, model.Photo);

                    dbCategory.CategoryImage = fileName;
                }



                if (model.Color != null)
                {
                    if (!model.Color.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View();
                    }

                    if (!model.Color.CheckFileSize(400))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 400kb");
                        return View();
                    }


                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/category-background/", dbCategory.BackgroundColor);

                    FileHelper.DeleteFile(oldPath);



                    string fileName = Guid.NewGuid().ToString() + "_" + model.Color.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/category-image/category-background/", fileName);

                    await FileHelper.SaveFileAsync(path, model.Color);

                    dbCategory.BackgroundColor = fileName;
                }






                dbCategory.CategoryName = model.Name;

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
