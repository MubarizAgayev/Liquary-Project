using Final_FrontEnd_BackEnd_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class ProductEditVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Describtion { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int Raiting { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<ProductImage> Images { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
