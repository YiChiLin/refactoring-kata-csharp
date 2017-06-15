using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class Orders
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public int GetOrdersCount()
        {
            return _orders.Count;
        }

        public Order GetOrder(int i)
        {
            return _orders[i];
        }

        public List<Order> GetOrders{ get { return _orders; } }

        public string GetOrdersJson()
        {
            var result = string.Join(", ", _orders.Select(order => order.GetOrderJson()).ToArray());
            return "{\"orders\": [" +result + "]}";
        }
    }
}
