using System;
using System.Threading.Channels;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute(30);// с UI не заморачивался 🤣
        }

        private static void Execute(int n)
        {

            Console.WriteLine( "1 - recursion Fib, 2- nonrec Fib");
            var input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    for (int i = 0; i < n; i++) Console.WriteLine(RecurFib(i));
                    break;
                case 2:
                    NonRecurFib(n);
                    break;
                default:
                    Console.WriteLine(value: "Error");
                    break;
            }
        }

        private static void NonRecurFib(int n)
        {
            if (n == 0) Console.WriteLine(0);

            int prev=0;
            int next=1;
           
            for (int i = 1; i < n; i++)
            {
                var sum = prev + next;
                prev = next;
                next = sum;
                Console.WriteLine(next);
            }
        }

        private static int RecurFib(int n)
        {
            return n <= 1 ? 1 : RecurFib(n - 2) + RecurFib(n - 1);
        }
    }
}
