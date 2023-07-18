using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class SliderCreateVM
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Offer { get; set; }
        [Required]
        public string Describtion { get; set; }

        [Required]
        public IFormFile Photo { get; set; }
    }
}
