using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }
        public Node(string NodeName)
        {
            Name = NodeName;
            Edges = new List<Edge>();
        }
        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
        public void AddEdge(Node nodeName, int edgeWeight)
        {
            AddEdge(new Edge(nodeName, edgeWeight));
        }
        public string ToString() => Name;
    }

    public class Edge
    {
        public Node ConnectedNode{ get; }
        public int EdgeWeight { get; }
        public Edge(Node ConnectedNode, int weight)
        {
            this.ConnectedNode = ConnectedNode;
            this.EdgeWeight = weight;
        }
    }

    public class Graph
    {
        public List<Node> Nodes { get; }
        public Graph()
        {
            Nodes = new List<Node>();
        }
        public void AddNode(string NodeName)
        {
            Nodes.Add(new Node(NodeName));
        }
        public Node FindNode(string NodeName)
        {
            foreach (var n in Nodes)
            {
                if (n.Name.Equals(NodeName))
                {
                    return n;
                }
            }

            return null;
        }
        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindNode(firstName);
            var v2 = FindNode(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }
    }

    public class NodeInfo
    {
        public Node Node { get; set; }
        public bool IsUnvisited { get; set; }
        public int EdgesWeightSum { get; set; }
        public Node PreviousNode { get; set; }
        public NodeInfo(Node node)
        {
            Node = node;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PreviousNode = null;
        }
    }

    public class ShortestPath
    {
        Graph graph;
        List<NodeInfo> nodes;
        public ShortestPath(Graph graph)
        {
            this.graph = graph;
        }
        void InitInfo()
        {
            nodes = new List<NodeInfo>();
            foreach (var n in graph.Nodes)
            {
                nodes.Add(new NodeInfo(n));
            }
        }
        NodeInfo GetNodeInfo(Node n)
        {
            foreach (var i in nodes)
            {
                if (i.Node.Equals(n))
                {
                    return i;
                }
            }

            return null;
        }

        public NodeInfo FindNodeMinimum()
        {
            var minValue = int.MaxValue;
            NodeInfo minNodeInfo = null;
            foreach (var n in nodes)
            {
                if (n.IsUnvisited && n.EdgesWeightSum < minValue)
                {
                    minNodeInfo = n;
                    minValue = n.EdgesWeightSum;
                }
            }

            return minNodeInfo;
        }
        public string FindShortestPath(string startName, string finishName)
        {
            return FindShortestPath(graph.FindNode(startName), graph.FindNode(finishName));
        }
        public string FindShortestPath(Node startNode, Node endNode)
        {
            InitInfo();
            var first = GetNodeInfo(startNode);
            first.EdgesWeightSum = 0;
            while (true)
            {
                var current = FindNodeMinimum();
                if (current == null) 
                {
                    break;
                }

                SetSum(current);
            }

            return GetPath(startNode, endNode);
        }
        void SetSum(NodeInfo info)
        {
            info.IsUnvisited = false;
            foreach (var e in info.Node.Edges)
            {
                var nextInfo = GetNodeInfo(e.ConnectedNode);
                var sum = info.EdgesWeightSum + e.EdgeWeight;
                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PreviousNode = info.Node;
                }
            }
        }
        string GetPath(Node startNode, Node endNode)
        {
            var path = endNode.ToString();
            while (startNode != endNode)
            {
                endNode = GetNodeInfo(endNode).PreviousNode;
                path = endNode.ToString() + path;
            }

            return path;
        }
    }
}
