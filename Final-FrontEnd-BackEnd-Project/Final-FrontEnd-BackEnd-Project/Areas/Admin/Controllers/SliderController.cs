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
using System.Text.RegularExpressions;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
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
        public async Task<IActionResult> Create(SliderCreateVM model)
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

                if (!model.Photo.CheckFileSize(400))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 400kb");
                    return View();
                }


                string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/slider-img/", fileName);

                await FileHelper.SaveFileAsync(path, model.Photo);


                Slider newSlider = new()
                {
                    Tittle = model.Tittle,
                    Offer = model.Offer,
                    Describtion= model.Describtion,
                    Image = fileName
                };

                await _context.Sliders.AddAsync(newSlider);
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
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m=>m.Id == id);

            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/slider-img/", slider.Image);

            FileHelper.DeleteFile(path);

            _context.Sliders.Remove(slider);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m=>m.Id == id);

            if (slider is null) return NotFound();

            return View(slider);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return BadRequest();

            Slider slider = await _context.Sliders.FindAsync(id);

            if (slider is null) return NotFound();

            SliderEditVM sliderEditVM = new()
            {
                Tittle = slider.Tittle,
                Offer = slider.Offer,
                Describtion = slider.Describtion,
                Image = slider.Image,
            };
            return View(sliderEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id, SliderEditVM model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Slider dbSlider = await _context.Sliders.FindAsync(id);

                if (dbSlider is null) return NotFound();

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

                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/slider-img/", dbSlider.Image);

                    FileHelper.DeleteFile(oldPath);




                    string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/slider-img/", fileName);

                    await FileHelper.SaveFileAsync(path, model.Photo);

                    dbSlider.Image = fileName;
                }

                dbSlider.Tittle = model.Tittle;
                dbSlider.Offer = model.Offer;
                dbSlider.Describtion = model.Describtion;

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
