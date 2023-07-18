using Microsoft.AspNetCore.Identity;

namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Basket> Baskets { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Wishlist> Wishlist { get; set; }
    }
}
