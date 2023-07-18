namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public string BackgroundColor { get; set; } = null;
    }
}
