using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class Order
    {
        private readonly int id;
        private readonly List<Product> _products = new List<Product>();

        public Order(int id)
        {
            this.id = id;
        }

        public int OrderId
        {
            get { return id; }
        }

        public List<Product> Products { get { return _products; } }

        public string GetProductJson()
        {
            return "["+ string.Join(",",Products.Select(prodcut => prodcut.SerializeProduct()).ToArray())+"]";
        }

        public string GetOrderJson()
        {
            var orderDetail = new Dictionary<string, object>()
            {
                {"id", OrderId},
                {"products", GetProductJson()}
            };

            return JsonHelper.SerializeArray(orderDetail);
        }
    }
}