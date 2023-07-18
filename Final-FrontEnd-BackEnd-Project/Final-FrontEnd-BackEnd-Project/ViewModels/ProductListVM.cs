namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Raiting { get; set; }
        public string MainImage { get; set; }
        public string SecondImage { get; set; }
        public bool InStock { get; set; }
    }
}
