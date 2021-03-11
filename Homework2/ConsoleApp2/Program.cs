using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            String s = " ";
            int i = 0;
            int n = 0;
            Console.WriteLine("Please input the length of array: ");
            s=Console.ReadLine();
            i = Int32.Parse(s);
            a = new int[i];
            for(int j = 0; j < i; j++)
            {
                Console.WriteLine("Please input an integer number:");
                s = Console.ReadLine();
                n = Int32.Parse(s);
                a[j] = n;
            }
            int max = a[0];
            for(int k = 1; k < i; k++)
            {
                if (max<a[k])
                {
                    max = a[k];
                }
            }
            Console.WriteLine($"The maximum of the array :{max}");
            int min = a[0];
            for (int k = 1; k < i; k++)
            {
                if (min>a[k])
                {
                    min = a[k];
                }
            }
            Console.WriteLine($"The minimum of the array :{min}");
            int sum = 0;
            for (int k = 0; k < i; k++)
            {
                sum += a[k];
            }
            double average = sum/i;
            Console.WriteLine($"Sum of all array elements:{sum}");
            Console.WriteLine($"Average of all array elements:{average}");
        }
    }
}
