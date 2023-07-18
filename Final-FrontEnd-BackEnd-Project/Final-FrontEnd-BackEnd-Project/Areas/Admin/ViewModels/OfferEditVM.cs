using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class OfferEditVM
    {
        [Required]
        public string Describtion { get; set; }

        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
