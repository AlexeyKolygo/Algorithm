using System;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph();

            g.AddNode("A");
            g.AddNode("B");
            g.AddNode("C");
            g.AddNode("D");
            g.AddNode("E");
            g.AddNode("F");
            g.AddNode("G");

            g.AddEdge("A", "B", 20);
            g.AddEdge("A", "G", 10);
            g.AddEdge("B", "C", 40);
            g.AddEdge("B", "E", 50);
            g.AddEdge("C", "D", 10);
            g.AddEdge("C", "E", 20);
            g.AddEdge("C", "F", 30);
            g.AddEdge("D", "F", 40);
            g.AddEdge("E", "F", 10);
            g.AddEdge("E", "G", 20);
            g.AddEdge("F", "G", 30);

            var ShortestPath = new ShortestPath(g);
            var path = ShortestPath.FindShortestPath("A", "D");
            Console.WriteLine(path);
            Console.ReadLine();
        }
    }
}
