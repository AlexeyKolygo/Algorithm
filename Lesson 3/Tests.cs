using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Tests
    {
        public  void Test(Action obj, int i)
        {
            for (int k = 0; k <= i; k++)
            {
                var sw = new Stopwatch();
                sw.Start();
                obj();
                sw.Stop();
                Console.WriteLine($"Test {k+1}. Elapsed Time = {sw.ElapsedMilliseconds} ms ");
            }

            


        }
    }
}
