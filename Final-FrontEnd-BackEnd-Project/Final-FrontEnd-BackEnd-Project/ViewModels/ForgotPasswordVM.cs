using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
