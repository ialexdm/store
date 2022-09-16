using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderItemCollectionTests
    {
        [Fact]
        public void Get_WithExistingItem_ReturnsItem()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1,3,10m),
                new OrderItem(1,5,100m),
            });

            var orderItem = order.Items.Get(1);

            Assert.Equal(3, orderItem.Count);
        }
        [Fact]
        public void Get_WithNotExistingItem_ReturnsItem()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1,3,10m),
                new OrderItem(1,5,100m),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Get(100);
            });

        }
        [Fact]
        public void Add_WithExistingItem_ThrowInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,3,10m),
                new OrderItem(1,5,100m),
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Add(1, 10, 10m);
            });
        }
        [Fact]
        public void Add_WithNewItem_SetsCount()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1,3,10m),
                new OrderItem(1,5,100m),
            });
            order.Items.Add(4, 10, 30m);

            Assert.Equal(10, order.Items.Get(4).Count);
        }
        [Fact]
        public void Remove_WithExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });
            order.Items.Remove(1);

            Assert.Collection(order.Items,
                item => Assert.Equal(2, item.BookId));
        }
        [Fact]
        public void Remove_WithNotExistingItem_ReturnsItem()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1,3,10m),
                new OrderItem(2,5,100m),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.Items.Remove(100);
            });

        }
    }
}
