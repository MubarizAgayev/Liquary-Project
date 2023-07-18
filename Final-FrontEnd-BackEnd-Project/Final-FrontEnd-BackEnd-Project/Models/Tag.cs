namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public ICollection<BlogTag> BlogTags { get; set; }
    }
}
