using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1,2,3,4,5};
            StrangeSum(array);
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;//пренебрегаем
            int difficulty = 0;//пренебрегаем
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
 
                        int y = 0;//пренебрегаем

                        if (j != 0)
                        {
                            y = k / j;//пренебрегаем
                            difficulty++;
                        }

                        
                        sum += inputArray[i] + i + k + j + y;//пренебрегаем
                        difficulty++;
                    }
                    difficulty++;
                }

                difficulty++;
            }

            Console.WriteLine($"Асимптотическая сложность функции:{difficulty} шагов");
            return sum;
        }

    }
}
