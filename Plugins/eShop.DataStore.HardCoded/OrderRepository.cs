using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            int nextId = orders.Keys.Any() ? orders.Keys.Max() + 1 : 1;
            order.OrderId = nextId;
            if (string.IsNullOrWhiteSpace(order.UniqueId))
            {
                order.UniqueId = Guid.NewGuid().ToString();
            }
            orders[order.OrderId.Value] = order;
            return order.OrderId.Value;
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue == false);
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            var allOrders = (IEnumerable<Order>)orders.Values;
            return allOrders.Where(x => x.DateProcessed.HasValue);
        }

        public Order? GetOrder(int id)
        {
            if (orders.TryGetValue(id, out var ord))
            {
                return ord;
            }
            return null;
        }

        public Order? GetOrderByUniqueId(string uniqueId)
        {
            if (string.IsNullOrWhiteSpace(uniqueId)) return null;

            foreach (var order in orders)
            {
                if (order.Value.UniqueId == uniqueId) return order.Value;
            }
            return null;
        }

        public void UpdateOrder(Order order)
        {
            if (order == null || !order.OrderId.HasValue) return;

            if (!orders.ContainsKey(order.OrderId.Value)) return;

            orders[order.OrderId.Value] = order;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var ord = GetOrder(orderId);
            return ord?.LineItems ?? Enumerable.Empty<OrderLineItem>();
        }
    }
}
