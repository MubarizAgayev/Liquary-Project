namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class Person : BaseEntity
    {
        public string Image { get; set; }
        public string Position { get; set; }
        public string Describtion { get; set; }
        public string Facebook { get; set; } = null;
        public string Twitter { get; set; } = null;
        public string TikTok { get; set; } = null;
        public string Name { get; set; }
    }
}
