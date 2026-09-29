namespace eShop.CoreBusiness.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageLink { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
