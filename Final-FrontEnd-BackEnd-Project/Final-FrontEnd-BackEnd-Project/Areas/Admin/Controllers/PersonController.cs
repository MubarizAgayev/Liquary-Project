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
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PersonController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Person> people = await _context.Person.ToListAsync();
            return View(people);
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
        public async Task<IActionResult> Create(PersonCreateVM model)
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

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/peoples/", fileName);

                await FileHelper.SaveFileAsync(path, model.Photo);


                Person newPerson = new()
                {
                    Name= model.Name,
                    Position=model.Position,
                    Describtion = model.Describtion,
                    Facebook= model.Facebook,
                    TikTok= model.TikTok,
                    Twitter= model.Twitter,
                    Image = fileName
                };

                await _context.Person.AddAsync(newPerson);
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
            Person person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/peoples/", person.Image);

            FileHelper.DeleteFile(path);

            _context.Person.Remove(person);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Person person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (person is null) return NotFound();

            return View(person);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) return BadRequest();

            Person person = await _context.Person.FindAsync(id);

            if (person is null) return NotFound();

            PersonEditVM personEditVM = new()
            {
                Name= person.Name,
                Position= person.Position,
                Describtion= person.Describtion,
                Facebook= person.Facebook,
                Twitter= person.Twitter,
                TikTok= person.TikTok,  
                Image = person.Image,
            };


            return View(personEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(int? id, PersonEditVM model)
        {

            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                Person dbPerson = await _context.Person.FindAsync(id);

                if (dbPerson is null) return NotFound();

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

                    string oldPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/peoples/", dbPerson.Image);

                    FileHelper.DeleteFile(oldPath);


                    string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                    string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/peoples/", fileName);

                    await FileHelper.SaveFileAsync(path, model.Photo);

                    dbPerson.Image = fileName;
                }

                dbPerson.Name= model.Name;
                dbPerson.Position = model.Position;
                dbPerson.Describtion = model.Describtion;
                dbPerson.Facebook= model.Facebook;
                dbPerson.Twitter= model.Twitter;
                dbPerson.TikTok= model.TikTok;

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
