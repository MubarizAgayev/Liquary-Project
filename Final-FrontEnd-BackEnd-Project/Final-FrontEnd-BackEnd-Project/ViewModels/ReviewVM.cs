using System.ComponentModel.DataAnnotations;

namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class ReviewVM
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        public int Raiting { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Describtion { get; set; }

    }
}
