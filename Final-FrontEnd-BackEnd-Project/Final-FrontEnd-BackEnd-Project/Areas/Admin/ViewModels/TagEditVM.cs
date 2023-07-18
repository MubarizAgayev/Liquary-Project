using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.Areas.Admin.ViewModels
{
    public class TagEditVM
    {
        [Required]
        public string TagName { get; set; }
    }
}
