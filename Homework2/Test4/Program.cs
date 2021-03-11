using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the number of rows: ");
            String s1 = Console.ReadLine();
            int r = Int32.Parse(s1);
            Console.WriteLine("Please input the number of columns: ");
            String s2 = Console.ReadLine();
            int c = Int32.Parse(s2);
            int[,] a;
            a = new int[r, c];
            String s3 = " ";
            for(int i=0;i<r;i++)
            {
                for(int j = 0; j < c; j++)
                {
                    Console.WriteLine("Please input a number: ");
                    s3 = Console.ReadLine();
                    a[i,j]= Int32.Parse(s3);
                }
            }
            bool b = true;
            for(int i = 0; i < r-1; i++)
            {
                for(int j = 0; j < c-1; j++)
                {
                    if (a[i, j] != a[i + 1, j + 1])
                    {
                        b = false;
                    }
                }
            }
            if (b == true)
            {
                Console.WriteLine("True");
            }
        }
    }
}
