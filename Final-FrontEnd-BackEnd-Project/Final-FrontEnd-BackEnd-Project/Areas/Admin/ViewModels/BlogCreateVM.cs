using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class BlogCreateVM
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Describtion { get; set; }
        [Required]
        public string Owner { get; set; }
        public IEnumerable<int> TagId { get; set; }

        [Required]
        public IFormFile Photo { get; set; }
    }
}
