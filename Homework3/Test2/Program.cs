using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Test2
{
    class Program
    {
        public interface Shape
        {
            double getArea();
            bool IsValid();
        }
        public class Rectangle : Shape
        {
            public double Length { set; get; }
            public double Width { set; get; }
            public Rectangle(double Length, double Width)
            {
                this.Length = Length;
                this.Width = Width;
            }
            public bool IsValid()
            {
                if (Length > 0 && Width > 0)
                { return true; }
                else
                { return false; }
            }
            public double getArea()
            {
                if (IsValid())
                {
                    return Length * Width;
                }
                else
                {
                    Console.WriteLine("输入不合法！");
                    return 0;
                }
            }
        }

        public class Square : Shape
        {
            public double Side { set; get; }
            public Square(double Side)
            {
                this.Side = Side;
            }
            public bool IsValid()
            {
                if (Side > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public double getArea()
            {
                if (IsValid())
                {
                    return Side * Side;
                }
                else
                {
                    Console.WriteLine("输入不合法！");
                    return 0;
                }
            }
        }

        public class Triangle : Shape
        {
            public double Side1 { set; get; }
            public double Side2 { set; get; }
            public double Side3 { set; get; }
            public Triangle(double Side1, double Side2, double Side3)
            {
                this.Side1 = Side1;
                this.Side2 = Side2;
                this.Side3 = Side3;
            }
            public bool IsValid()
            {
                if (Side1 > 0 && Side2 > 0 && Side3 > 0 && (Side1 + Side2 > Side3) && (Side1 + Side3 > Side2) && (Side2 + Side3 > Side1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public double getArea()
            {
                if (IsValid())
                {
                    double p = (Side1 + Side2 + Side3) / 2;
                    double area = Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
                    return area;
                }
                else
                {
                    Console.WriteLine("输入不合法！");
                    return 0;
                }
            }
        }

        public class ShapeFactory
        {
            public static Shape CreateShape(int num)
            {
                Random random = new Random();
                switch (num)
                {
                    case 1:
                        double x = random.Next(1, 20);
                        double y = random.Next(1, 20);
                        return new Rectangle(x, y);
                    case 2:
                        double z = random.Next(1, 20);
                        return new Square(z);
                    case 3:
                        double a = random.Next(1, 20);
                        double b = random.Next(1, 20);
                        double c = random.Next(1, 20);
                        return new Triangle(a, b,c);
                    default:
                        return null;
                }
            }
        }
        static void Main(string[] args)
        {
            double sum = 0;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                sum += ShapeFactory.CreateShape(random.Next(1, 3)).getArea();
            }
            Console.WriteLine($"总面积:{sum}");
        }
    }
}
