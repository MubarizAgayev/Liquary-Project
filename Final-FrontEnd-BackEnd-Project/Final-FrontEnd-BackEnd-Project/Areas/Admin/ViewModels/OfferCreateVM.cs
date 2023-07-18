using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class OfferCreateVM
    {
        [Required]
        public string Describtion { get; set; }

        [Required]
        public IFormFile Photo { get; set; }
    }
}
