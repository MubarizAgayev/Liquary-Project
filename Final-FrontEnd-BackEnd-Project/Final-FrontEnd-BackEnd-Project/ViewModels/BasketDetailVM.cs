namespace Final_FrontEnd_BackEnd_Project.ViewModels
{
    public class BasketDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
