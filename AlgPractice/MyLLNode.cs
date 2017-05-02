using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgPractice
{
    public class MyLLNode
    {
        internal MyLLNode next;
        internal int Value { get; set; }
        internal MyLLNode(int val)
        {
            Value = val;
        }
        public static void Append(MyLLNode toAdd, ref MyLLNode endOfLL)
        {
            endOfLL.next = toAdd;
            endOfLL = toAdd;
        }
        internal static void printVals(MyLLNode first)
        {
            var next = first;
            while (next != null)
            {
                Console.WriteLine(next.Value);
                next = next.next;
            }
        }
        internal static void Test()
        {
            const int VALS_MAX = 1000;
            const int VALS_MIN = -VALS_MAX;
            var rnd = new Random();

            var first = new MyLLNode(rnd.Next(VALS_MIN, VALS_MAX));

            int N = rnd.Next(3, 20);
            Console.WriteLine($"Linked list of random ints size({N + 1})");

            MyLLNode next = first;
            for (int i = 0; i < N; i++)
            {
                //MyLLNode.Append(new MyLLNode(rnd.Next(VALS_MIN, VALS_MAX)), ref next);
                next.next = new MyLLNode(rnd.Next(VALS_MIN, VALS_MAX));
                next = next.next;
            }
            MyLLNode.printVals(first);
            Console.ReadLine();
        }
    }
}
