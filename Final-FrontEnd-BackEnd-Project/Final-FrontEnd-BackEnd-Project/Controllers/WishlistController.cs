using Microsoft.AspNetCore.Mvc;

namespace Final_FrontEnd_BackEnd_Project.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
