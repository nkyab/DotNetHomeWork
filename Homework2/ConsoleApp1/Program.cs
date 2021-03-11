using System;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = " ";
            int i = 0;
            Console.Write("Please input a integer number: ");
            s = Console.ReadLine();
            i = int.Parse(s);
            void getPrimeNumber(ref int x)
            {
                if (x == 1)
                {
                    return ;
                }
                for(int j=2;j<=x; )
                {
                    if (x % j == 0)
                    {
                        Console.Write($"{j} ");
                        x /= j;
                        getPrimeNumber(ref x);
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            getPrimeNumber(ref i);

        }
    }
}
