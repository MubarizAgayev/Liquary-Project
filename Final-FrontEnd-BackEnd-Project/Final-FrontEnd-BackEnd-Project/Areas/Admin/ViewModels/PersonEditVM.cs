using Final_FrontEnd_BackEnd_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class PersonEditVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Describtion { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string TikTok { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
