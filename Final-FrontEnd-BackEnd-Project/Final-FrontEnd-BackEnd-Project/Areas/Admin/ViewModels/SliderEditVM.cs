using Final_FrontEnd_BackEnd_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class SliderEditVM
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Offer { get; set; }
        [Required]
        public string Describtion { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
