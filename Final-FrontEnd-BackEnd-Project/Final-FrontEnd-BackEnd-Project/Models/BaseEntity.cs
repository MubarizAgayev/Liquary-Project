namespace Final_FrontEnd_BackEnd_Project.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDelete { get; set; } = false;
    }
}
