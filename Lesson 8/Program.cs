using System;

namespace BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] example = new int[] { 200, 25, -8, 456456, 5, 0, 9999 };
            var sort = new Sort();
           var result= sort.BucketSort(example);
           sort.Print(result);
          
        }
    }
}
