using System;
using Microsoft.VisualBasic.FileIO;

namespace Lesson_2_algorhitms
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var root = new NodeItem();

            InitializeNode(root, 100);
            PrintThisShit(root);
            FuncTest(root);
            Console.WriteLine("===");
            PrintThisShit(root);
        }

        static void FuncTest(NodeItem root)
        {
            root.AddNode(110);
            var nodeAdd = new Node() { Value = 101 };
            root.AddNodeAfter(nodeAdd, 2);
            var nodeRem = new Node() { Value = 8 };
            root.RemoveNode(nodeRem);
            root.RemoveNode(7);
        }
        static void InitializeNode(NodeItem root, int i)
        {
            
            for (i = 1; i <= 10; i++) root.AddNode(i);
            
        }

        static void PrintThisShit(NodeItem root)
        {
            Console.WriteLine($"This node has {root.GetCount()} elements");
            foreach (var elem in root)
            {
                Console.WriteLine(elem);
            }

            
        }
    }
}
