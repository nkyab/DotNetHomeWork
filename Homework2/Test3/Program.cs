using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            a= new int[99];
            for(int i = 2; i <= 100; i++)
            {
                a[i - 2] = i;
            }
            for(int k = 2; k <=10; k++)
            {
                for(int j = 0; j < 99; j++)
                {
                    if (a[j] != 0 && a[j] % k == 0 && a[j] != k)
                    {
                        a[j] = 0;
                    }
                }
            }
            for(int j=0;j<99;j++)
            {
                if (a[j] != 0)
                {
                    Console.Write($"{a[j]} ");
                }
            }
        }
    }
}
