using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input number");
                var input = Int32.TryParse(Console.ReadLine(), out var number);
                if (input)

                    IsPrimeNumber(number);
                else
                    Console.WriteLine("Wrong!");
            }
        }

        private static void IsPrimeNumber(int number)
        {
            Console.Clear();
            var d = 0;
            var i = 2;
            while (i < number)
            {
                if (number % i == 0) d++;

                i++;
            }

            Console.WriteLine(d == 0 ? $"{number} is Prime" : $"{number} is not Prime");
        }
    }
}
