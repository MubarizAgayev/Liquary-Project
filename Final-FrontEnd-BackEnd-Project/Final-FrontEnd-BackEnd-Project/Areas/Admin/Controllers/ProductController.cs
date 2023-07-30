using Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels;
using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Final_FrontEnd_BackEnd_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProductController : Controller
    {
        
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IProductService _productService;
        public ProductController(AppDbContext context, IWebHostEnvironment env, IProductService productService)
        {
            _context = context;
            _env = env;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await GetCategoriesAsync();
            return View();
        }


        private async Task<SelectList> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _context.Category.ToListAsync();
            return new SelectList(categories, "Id", "CategoryName");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            try
            {
                ViewBag.categories = await GetCategoriesAsync();

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model.Photos.Count() < 2)
                {
                    ModelState.AddModelError("Name", "Image count must be min 2");
                    return View(model);
                }

                foreach (var photo in model.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "File type must be image");
                        return View();
                    }

                    if (!photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View();
                    }
                }


                List<ProductImage> productImages = new();

                foreach (var photo in model.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/products/", fileName);

                    await FileHelper.SaveFileAsync(path, photo);

                    ProductImage productImage = new()
                    {
                        Image = fileName
                    };

                    productImages.Add(productImage);
                }

                productImages.FirstOrDefault().IsMain = true;

                decimal convertedPrice = decimal.Parse(model.Price.Replace(".", ","));




                Product newProduct = new()
                {
                    Name = model.Name,
                    Describtion = model.Describtion,
                    Count = model.Count,
                    Price = convertedPrice,
                    Images = productImages,
                    CategoryId= model.CategoryId,

                };




                await _context.ProductImage.AddRangeAsync(productImages);
                await _context.Product.AddAsync(newProduct);
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
            Product product = await _productService.GetById((int)id);


            foreach (var item in product.Images)
            {
                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/products/", item.Image);

                FileHelper.DeleteFile(path);

                _context.ProductImage.Remove(item);
            }

            _context.Product.Remove(product);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _productService.GetById((int)id);

            if (product is null) return NotFound();

            ViewBag.desc = Regex.Replace(product.Describtion, "<.*?>", string.Empty);

            return View(product);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return BadRequest();

            Product product = await _productService.GetById((int)id);

            if (product is null) return NotFound();

            ViewBag.categories = await GetCategoriesAsync();

            ProductEditVM productEditVM = new()
            {
                Name = product.Name,
                Price = product.Price.ToString("0.#####").Replace(",", "."),
                Count = product.Count,
                Raiting = (int)product.Raiting,
                Describtion = product.Describtion,
                CategoryName = product.Category.CategoryName,
                CategoryId = product.CategoryId,
                Images = product.Images,

            };
            return View(productEditVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage(int id)
        {

            return Ok();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id, ProductEditVM model)
        {
            ViewBag.categories = await GetCategoriesAsync();


            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Product dbProduct = await _productService.GetById((int)id);

                if (dbProduct is null) return NotFound();

                if (model.Photos != null)
                {
                    foreach (var photo in model.Photos)
                    {
                        if (!photo.CheckFileType("image/"))
                        {
                            ModelState.AddModelError("Photo", "File type must be image");
                            return View();
                        }

                        if (!photo.CheckFileSize(400))
                        {
                            ModelState.AddModelError("Photo", "Image size must be max 400kb");
                            return View();
                        }
                    }



                    foreach (var item in dbProduct.Images)
                    {
                        string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/products/", item.Image);

                        FileHelper.DeleteFile(oldPath);
                    }



                    List<ProductImage> productImages = new();

                    foreach (var photo in model.Photos)
                    {


                        string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                        string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/products/", fileName);

                        await FileHelper.SaveFileAsync(path, photo);

                        ProductImage productImage = new()
                        {
                            Image = fileName
                        };

                        productImages.Add(productImage);


                    }

                    productImages.FirstOrDefault().IsMain = true;

                    dbProduct.Images = productImages;
                }


                decimal convertedPrice = decimal.Parse(model.Price.Replace(".", ","));


                dbProduct.Name = model.Name;
                dbProduct.Count = model.Count;
                dbProduct.Describtion= model.Describtion;
                dbProduct.CategoryId= model.CategoryId;
                dbProduct.Raiting = model.Raiting;
                dbProduct.Price = convertedPrice;


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
