using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node()
        {
            Next = null;
            Data = default(T);
        }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    class List<T>
    {
        public Node<T> Head;
        public Node<T> Tail;

        public List()
        {
            Head = new Node<T>();
            Tail = new Node<T>();
            Head.Next = Tail;
        }
        public void Add(T t)
        {
            Node<T> node = new Node<T>(t);
            node.Next = Head.Next;
            Head.Next = node;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> node_p = this.Head.Next;

            while (node_p != Tail)
            {
                action(node_p.Data);
                node_p = node_p.Next;
            }
        }
    }


    class Program
    {
        public static void DoThis<T>(T t)
        {
            Console.Write(t);
            Console.Write("   ");
        }

        delegate int Fun(int n);

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Action<int> action = DoThis;
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.ForEach(action);

            Fun fun = delegate (int k) {
                return k;
            };

            Node<int> p = list.Head;

            int max = p.Data;
            int min = p.Data;
            int total = 0;
            while (p != list.Tail)
            {
                if ((p.Data) >= max)
                {
                    max = (p.Data);
                }
                else
                {
                    min = (p.Data);
                }
                total += (p.Data);
                p = p.Next;
            }
            Console.WriteLine();
            Console.WriteLine("最大值:" + max);
            Console.WriteLine("最小值:" + min);
            Console.WriteLine("和:" + total);
            Console.ReadLine();
        }
    }
}
