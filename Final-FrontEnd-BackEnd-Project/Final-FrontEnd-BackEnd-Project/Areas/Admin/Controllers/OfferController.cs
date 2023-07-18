using Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels;
using Final_FrontEnd_BackEnd_Project.Data;
using Final_FrontEnd_BackEnd_Project.Helpers;
using Final_FrontEnd_BackEnd_Project.Helpers.Enums;
using Final_FrontEnd_BackEnd_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class OfferController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public OfferController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Offer> offers = await _context.Offer.ToListAsync();
            return View(offers);
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
        public async Task<IActionResult> Create(OfferCreateVM model)
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

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/offers/", fileName);

                await FileHelper.SaveFileAsync(path, model.Photo);


                Offer newOffer = new()
                {
                    Describtion = model.Describtion,
                    Image = fileName
                };

                await _context.Offer.AddAsync(newOffer);
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
            Offer offer = await _context.Offer.FirstOrDefaultAsync(m => m.Id == id);

            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/offers/", offer.Image);

            FileHelper.DeleteFile(path);

            _context.Offer.Remove(offer);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Offer offer = await _context.Offer.FirstOrDefaultAsync(m => m.Id == id);

            if (offer is null) return NotFound();

            ViewBag.desc = Regex.Replace(offer.Describtion, "<.*?>", string.Empty);

            return View(offer);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return BadRequest();

            Offer offer = await _context.Offer.FindAsync(id);

            if (offer is null) return NotFound();

            OfferEditVM offerEditVM = new()
            {
                Describtion= offer.Describtion,
                Image = offer.Image,
            };

            ViewBag.desc = offer.Describtion;


            return View(offerEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id, OfferEditVM model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Offer dbOffer = await _context.Offer.FindAsync(id);

                if (dbOffer is null) return NotFound();

                if (model.Photo != null)
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

                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/offers/", dbOffer.Image);

                    FileHelper.DeleteFile(oldPath);




                    string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/offers/", fileName);

                    await FileHelper.SaveFileAsync(path, model.Photo);

                    dbOffer.Image = fileName;
                }

                dbOffer.Describtion = model.Describtion;

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
