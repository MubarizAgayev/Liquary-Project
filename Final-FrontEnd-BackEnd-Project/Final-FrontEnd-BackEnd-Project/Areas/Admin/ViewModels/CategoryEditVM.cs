using Final_FrontEnd_BackEnd_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class CategoryEditVM
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string BackgroundColor { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Color { get; set; }
    }
}
