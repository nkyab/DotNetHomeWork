using System;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = " ";
            double a = 0;
            double b = 0;
            char c = '#';
            Console.Write("Please input a number: ");
            s = Console.ReadLine();
            a = double.Parse(s);
            Console.Write("Please input a number: ");
            s = Console.ReadLine();
            b = double.Parse(s);
            Console.Write("Please input an operator: ");
            s = Console.ReadLine();
            c = char.Parse(s);
            switch (c)
            {
                case '+':
                    Console.WriteLine($"a+b={a+b}");
                    break;
                case '-':
                    Console.WriteLine($"a-b={a-b}");
                    break;
                case '*':
                    Console.WriteLine($"a*b={a*b}");
                    break;
                case '/':
                    Console.WriteLine($"a/b={a/b}");
                    break;
                default:
                    Console.WriteLine("input error");
                    break;
            }

        }
    }
}
