using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class ContactVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public string Number { get; set; }
        [Required]
        public string Context { get; set; }
    }
}
