using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string cstrShoppingCart = "eShop.ShoppingCart";
        private readonly IJSRuntime jsRuntime;
        private readonly IProductRepository productRepository;

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository productRepository)
        {
            this.jsRuntime = jsRuntime;
            this.productRepository = productRepository;
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);
            return order;
        }

        public async Task EmptyAsync()
        {
            await this.SetOrder(null);
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await GetOrder();
            if (quantity <= 0)
                order.RemoveProduct(productId);
            else
                order.UpdateQuantity(productId, quantity);
            await SetOrder(order);
            return order;
        }

        private async Task<Order> GetOrder()
        {
            Order? order = null;

            var strOrder = await jsRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
            if (!string.IsNullOrEmpty(strOrder) && strOrder.ToLower() != "null")
            {
                order = JsonConvert.DeserializeObject<Order>(strOrder);
            }
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            if (order != null && order.LineItems != null)
            {
                foreach (var item in order.LineItems)
                {
                    item.Product = productRepository.GetProduct(item.ProductId);
                }
            }

            return order ?? new Order();
        }

        private async Task SetOrder(Order? order)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, JsonConvert.SerializeObject(order));
        }
    }
}
