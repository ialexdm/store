using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Order
    {
        public int Id { get; set; }

        public OrderItemCollection Items { get; }

        public string CellPhone { get; set; }

        public OrderDelivery Delivery { get; set; }

        public OrderPayment Payment { get; set; }

        public Order(int id, IEnumerable<OrderItem> items)
        {
            Id = id;

            Items = new OrderItemCollection(items);
        }

        public int TotalCount => Items.Sum(item => item.Count);


        public decimal TotalPrice => Items.Sum(item => item.Price * item.Count )
            + (Delivery?.Amount ?? 0m);

        private void ThrowBookException(string message, int bookId)
        {
            var exception = new InvalidOperationException(message);

            exception.Data["Id"] = bookId;

            throw exception;
        }
    }
}
