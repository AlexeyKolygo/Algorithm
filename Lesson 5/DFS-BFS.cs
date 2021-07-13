using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace BFS_DFS
{
 
        class Program
        {
            static void Main(string[] args)
            {
                Tree tree = new Tree();
                int[] data = new[] { 52, 42, 32, 22, 11, 62, 72, 82 };//именно в данном случае решил сделать статичное дерево, потому что удобнее в отладке работать со статичными данными.
                tree.AddArrayToTree(data);
                tree.PrintTree();
                Console.WriteLine();
                tree.DFS(32);
                Console.WriteLine();
                tree.BFS(72);
                Console.WriteLine();
                Console.ReadKey();
            }
        }

}
