using AlgorithmsImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSTraverse
{
    class Program
    {
        public static bool[] Visited { get; set; } = new bool[12];
        public static Dictionary<int, List<int>> Graph { get; set; } = new Dictionary<int, List<int>>();
        public static List<Node> AllNodes { get; set; } = new List<Node>();

        static void Main(string[] args)
        {
            // n is the number of nodes
            int n = 12;

            // g is the Adjacency List representing the graph
            // 0 => 1, 9 // 1 => 0, 8  // 9 => 0, 8  // 8 => 7  // 7 => 10, 11, 6, 3  // 10 => 7, 11
            // 11 => 10, 7  // 6 => 7, 5  // 3 => 2, 4  // 5 => 6, 3  // 2 => 3  // 4 => 3  // 12 => None
            
            Node n0 = new Node(0);
            n0.Connections.Add(1);
            n0.Connections.Add(9);
            AllNodes.Add(n0);
            Node n1 = new Node(1);
            n1.Connections.Add(0);
            n1.Connections.Add(8);
            AllNodes.Add(n1);
            Node n2 = new Node(2);
            n2.Connections.Add(3);
            AllNodes.Add(n2);
            Node n3 = new Node(3);
            n3.Connections.Add(2);
            n3.Connections.Add(4);
            AllNodes.Add(n3);
            Node n4 = new Node(4);
            n4.Connections.Add(3);
            AllNodes.Add(n4);
            Node n5 = new Node(5);
            n5.Connections.Add(6);
            n5.Connections.Add(3);
            AllNodes.Add(n5);
            Node n6 = new Node(6);
            n6.Connections.Add(7);
            n6.Connections.Add(5);
            AllNodes.Add(n6);
            Node n7 = new Node(7);
            n7.Connections.Add(10);
            n7.Connections.Add(11);
            n7.Connections.Add(6);
            n7.Connections.Add(3);
            AllNodes.Add(n7);
            Node n8 = new Node(8);
            n8.Connections.Add(7);
            AllNodes.Add(n8);
            Node n9 = new Node(9);
            n9.Connections.Add(0);
            n9.Connections.Add(8);
            AllNodes.Add(n9);
            Node n10 = new Node(10);
            n10.Connections.Add(7);
            n10.Connections.Add(11);
            AllNodes.Add(n10);
            Node n11 = new Node(11);
            n11.Connections.Add(10);
            n11.Connections.Add(7);
            AllNodes.Add(n11);
            Node n12 = new Node(12);
            AllNodes.Add(n12);

            
            foreach (Node item in AllNodes)
            {
                List<int> temp = new List<int>();
                foreach (var connection in item.Connections)
                {
                    temp.Add(connection);
                }
                Graph.Add(item.Id, temp);      
            }

            // visited is the list that keeps track of the nodes we looked at
            // bool[] visited = new bool[n];
            for (int i=0; i < Visited.Length; i++)
            {
                Visited[i] = false;
            }
            
            // start_node is the node where we start the traversing
            int start_node = 0;
            dfs(start_node);

        }

        private static void dfs(int at)
        {
            if (Visited[at])
            {
                Console.WriteLine($"Already visited node {at}. Backtracking.");
                return;
            }
            else
            {
                Console.WriteLine($"Looking at node {at} with neightbors {AllNodes[at].ToString()}");
                Console.WriteLine($"******************************************* Node {at} actual work as it was reached during traversal.");
                Visited[at] = true;
            }
            List<int> neighbours = Graph[at];
            foreach (int node in neighbours)
            {
                dfs(node);
            }

        }
    }
}
