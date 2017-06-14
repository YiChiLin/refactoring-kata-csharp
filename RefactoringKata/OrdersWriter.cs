using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                sb.Append("{");
                sb.Append("\"id\": ");
                sb.Append(order.GetOrderId());
                sb.Append(", ");
                sb.Append("\"products\": [");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    var product = order.GetProduct(j);
                    var productDetail = new Dictionary<string,object>()
                    {
                        {"code",product.Code},
                        {"color",product.getColorFor()},
                    };

                    if (product.Size != Product.SIZE_NOT_APPLICABLE)
                    {
                        productDetail.Add("size",product.getSizeFor());
                    }

                    productDetail.Add("price",product.Price);
                    productDetail.Add("currency",product.Currency);

                    sb.Append("{"+string.Join(", ",productDetail.Select(prop =>
                    {
                        if (prop.Value is string)
                            return string.Format("\"{0}\": \"{1}\"", prop.Key, prop.Value);
                        return string.Format("\"{0}\": {1}", prop.Key, prop.Value);
                    }).ToArray()) + "}, ");
                }

                if (order.GetProductsCount() > 0)
                {
                    sb.Remove(sb.Length - 2, 2);
                }

                sb.Append("]}, ");
            }

            if (_orders.GetOrdersCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.Append("]}").ToString();
        }
    }
}