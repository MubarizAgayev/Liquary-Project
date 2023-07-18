namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class Blog : BaseEntity
    {
        public string Tittle { get; set; }
        public string Describtion { get; set; }
        public string Image { get; set; }
        public string Owner { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
