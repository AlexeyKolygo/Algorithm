using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Task_2
{
    class Task2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Tree tree = new Tree();
                var RandomList = new List<int>();
                for (int i = 1; i < 10; i++)
                {
                    var r = new Random().Next(1,100);
                    tree.AddItem(r);
                    RandomList.Add(r);
                }

                
                tree.PrintTree();
                Console.WriteLine();
                Console.WriteLine(tree.GetNodeByValue(Random(RandomList)).Value);
                Console.WriteLine(tree.GetNodeByValue(Random(RandomList)).Value);
                tree.RemoveItem(Random(RandomList));
                tree.PrintTree();
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        static int Random(List<int>List)
        {
            var rnd = new Random().Next(List.Count);
            return List[rnd];
        }
    }
}
