using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CoreBusiness.Models
{
    public class Order
    {
        public Order()
        {
            LineItems = new List<OrderLineItem>();
        }

        public int? OrderId { get; set; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateProcessing { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public string CustomerStateProvince { get; set; } = string.Empty;
        public string CustomerCountry { get; set; } = string.Empty;
        public string AdminUser { get; set; } = string.Empty;
        public List<OrderLineItem> LineItems { get; set; }
        public string UniqueId { get; set; } = string.Empty;

        public void AddProduct(int productId, int qty, double price)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
                item.Quantity += qty;
            else
                LineItems.Add(new OrderLineItem { ProductId = productId, Quantity = qty, Price = price, OrderId = OrderId });
        }

        public void RemoveProduct(int productId)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null) LineItems.Remove(item);
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null) item.Quantity = quantity;
        }
    }
}
