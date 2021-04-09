using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Order order = new Order(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            OrderService orderService = new OrderService();
            orderService.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            Assert.AreEqual(orderService.orderList[0], order);
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            orderService.AddOrder(3, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            orderService.DeleteOrder(3);
            OrderService orderService1 = new OrderService();
            orderService1.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            orderService1.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            CollectionAssert.AreEqual(orderService.orderList, orderService1.orderList);
        }

        [TestMethod()]
        public void EditOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            orderService.AddOrder(3, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            Order order3 = new Order(3, new Customer("new order3 test", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService.EditOrder(3, order3);
            OrderService orderService1 = new OrderService();
            orderService1.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            orderService1.AddOrder(3, new Customer("new order3 test", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService1.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            CollectionAssert.AreEqual(orderService.orderList, orderService1.orderList);
        }

        [TestMethod()]
        public void SelectOrderTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            orderService.AddOrder(3, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            List<Order> selectedOrders = orderService.SelectOrder(1, "1").ToList();
            List<Order> orders = new List<Order>();
            orders.Add(new Order(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4)));
            CollectionAssert.AreEqual(selectedOrders, orders);
        }

        [TestMethod()]
        public void SortTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            orderService.AddOrder(3, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            orderService.Sort();
            OrderService orderService1 = new OrderService();
            orderService1.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
            orderService1.AddOrder(3, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
            orderService1.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
            CollectionAssert.AreEqual(orderService.orderList, orderService1.orderList);
        }
    }
}