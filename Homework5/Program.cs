using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Commodity
    {
        public string no;
        public string name;
        public double price;
        public Commodity(string no, string name, double price)
        {
            this.no = no;
            this.name = name;
            this.price = price;
        }
        public override string ToString()
        {
            return $"{no} {name} {price}";
        }
    }
    class Customer
    {
        public string name, info;
        public Customer(string name, string info)
        {
            this.name = name;
            this.info = info;
        }
        public override string ToString()
        {
            return $"{name} {info}";
        }
    }
    class Order : IComparable<Order>
    {
        public int orderNo;
        public Customer customer;
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public double total
        {
            get
            {
                double total = 0;
                foreach (OrderDetails orderDetail in orderDetails)
                {
                    total += orderDetail.goods.price * orderDetail.quantity;
                }
                return total;
            }
        }
        public Order(int orderNo, Customer customer, params OrderDetails[] orderDetails)
        {
            this.orderNo = orderNo;
            this.customer = customer;
            foreach (OrderDetails orderDetail in orderDetails)
            {
                if (!this.orderDetails.Contains(orderDetail))
                {
                    this.orderDetails.Add(orderDetail);
                }
            }
        }
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && orderNo == order.orderNo;
        }

        public override int GetHashCode()
        {
            return orderNo;
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            foreach (OrderDetails orderDetail in orderDetails)
            {
                details.Append(orderDetail);
            }
            return $"订单号：{orderNo}\n客户：{customer}\n商品：\n{details.ToString()}金额: {total}\n";
        }
        public int CompareTo(Order order)
        {
            return orderNo.CompareTo(order.orderNo);
        }
    }
    class OrderDetails
    {
        public Commodity goods;
        public int quantity;
        public OrderDetails(Commodity goods, int quantity)
        {
            this.goods = goods;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return $"{goods}\n{quantity}件  共{goods.price * quantity}元\n";
        }
        public override bool Equals(object obj)
        {
            OrderDetails orderDetail = obj as OrderDetails;
            return orderDetail != null && goods.no == orderDetail.goods.no;
        }
        public override int GetHashCode()
        {
            return int.Parse(goods.no);
        }
    }
    class OrderService
    {
        public List<Order> orderList = new List<Order>();
        public void AddOrder(int orderNo, Customer customer, params OrderDetails[] orderDetails)
        {
            Order order = new Order(orderNo, customer, orderDetails);
            if (!orderList.Contains(order))
            {
                orderList.Add(order);
            }
        }
        public void DeleteOrder(int orderNo)
        {
            var orderQuery = from s in orderList where s.orderNo == orderNo select s;
            Order deleteOrder = null;
            foreach (Order order in orderQuery)
            {
                deleteOrder = order;
            }
            int index = orderList.IndexOf(deleteOrder);
            if (index == -1)
            {
                throw new Exception("错误：订单不存在");
            }
            else
            {
                orderList.RemoveAt(index);
            }
        }
        public void EditOrder(int orderNo, Order newOrder)
        {
            var orderQuery = from s in orderList where s.orderNo == orderNo select s;
            Order oldOrder = null;
            foreach (Order order in orderQuery)
            {
                oldOrder = order;
            }
            int index = orderList.IndexOf(oldOrder);
            if (index == -1)
            {
                throw new Exception("错误：订单不存在");
            }
            else
            {
                orderList[index] = newOrder;
            }
        }
        public void SelectOrder(int selectType, string selectParam)
        {
            switch (selectType)
            {
                case 1:
                    var orderQuery1 = from s in orderList where s.orderNo == int.Parse(selectParam) select s;
                    if (!orderQuery1.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery1)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 2:
                    var orderQuery2 = from s in orderList from n in s.orderDetails where n.goods.name == selectParam select s;
                    if (!orderQuery2.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery2)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 3:
                    var orderQuery3 = from s in orderList where s.customer.name == selectParam select s;
                    if (!orderQuery3.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery3)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 4:
                    var orderQuery4 = from s in orderList where s.total == double.Parse(selectParam) select s;
                    if (!orderQuery4.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery4)
                    {
                        Console.WriteLine(order);
                    }
                    break;
            }
        }
        public void Sort()
        {
            orderList.Sort();
        }
        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }
        public void ShowOrder()
        {
            foreach (Order order in orderList)
            {
                Console.WriteLine(order);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OrderService orderService = new OrderService();
                orderService.AddOrder(1, new Customer("客户1", "123"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
                orderService.AddOrder(2, new Customer("客户2", "456"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
                orderService.AddOrder(3, new Customer("客户3", "123"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
                orderService.AddOrder(4, new Customer("客户4", "789"), new OrderDetails(new Commodity("1002", "商品2", 20), 2), new OrderDetails(new Commodity("1006", "商品6", 60), 3));
                orderService.AddOrder(5, new Customer("客户5", "456"), new OrderDetails(new Commodity("1002", "商品2", 20), 1), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
                orderService.ShowOrder();
                orderService.Sort();
                orderService.ShowOrder();
                orderService.DeleteOrder(1);
                orderService.ShowOrder();
                orderService.SelectOrder(1, "1");
                orderService.SelectOrder(1, "3");
                orderService.SelectOrder(2, "商品2");
                orderService.SelectOrder(3, "客户3");
                orderService.SelectOrder(4, "50");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
