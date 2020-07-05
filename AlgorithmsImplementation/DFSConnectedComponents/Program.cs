using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSConnectedComponents
{
    class Program
    {
        public static int N { get; set; }
        public static bool[] Visited { get; set; } = new bool[18];
        public static Dictionary<int, List<int>> Graph { get; set; } = new Dictionary<int, List<int>>();
        public static Dictionary<int, List<int>> Result { get; set; } = new Dictionary<int, List<int>>();
        public static List<Node> AllNodes { get; set; } = new List<Node>();
        public static int Count { get; set; } = 0;
        public static int[] Components { get; set; } = new int[18];
        static void Main(string[] args)
        {
            N = 17;
            #region nodepop
            Node n0 = new Node(0);
            Node n1 = new Node(0);
            Node n2 = new Node(0);
            Node n3 = new Node(0);
            Node n4 = new Node(0);
            Node n5 = new Node(0);
            Node n6 = new Node(0);
            Node n7 = new Node(0);
            Node n8 = new Node(0);
            Node n9 = new Node(0);
            Node n10 = new Node(0);
            Node n11 = new Node(0);
            Node n12 = new Node(0);
            Node n13 = new Node(0);
            Node n14 = new Node(0);
            Node n15 = new Node(0);
            Node n16 = new Node(0);
            Node n17 = new Node(0);

            n0.Connections.Add(4);
            n0.Connections.Add(8);
            n0.Connections.Add(13);
            n0.Connections.Add(14);

            n1.Connections.Add(5);

            n2.Connections.Add(9);
            n2.Connections.Add(15);

            n3.Connections.Add(9);

            n4.Connections.Add(0);
            n4.Connections.Add(8);

            n5.Connections.Add(1);
            n5.Connections.Add(16);
            n5.Connections.Add(17);

            n6.Connections.Add(7);
            n6.Connections.Add(11);

            n7.Connections.Add(6);
            n7.Connections.Add(11);

            n8.Connections.Add(0);
            n8.Connections.Add(4);
            n8.Connections.Add(14);

            n9.Connections.Add(2);
            n9.Connections.Add(3);
            n9.Connections.Add(15);

            n10.Connections.Add(15);

            n11.Connections.Add(6);
            n11.Connections.Add(7);

            n13.Connections.Add(0);
            n13.Connections.Add(14);

            n14.Connections.Add(0);
            n14.Connections.Add(8);
            n14.Connections.Add(13);

            n15.Connections.Add(2);
            n15.Connections.Add(9);
            n15.Connections.Add(10);

            n16.Connections.Add(5);

            n17.Connections.Add(5);

            AllNodes.Add(n0);
            AllNodes.Add(n1);
            AllNodes.Add(n2);
            AllNodes.Add(n3);
            AllNodes.Add(n4);
            AllNodes.Add(n5);
            AllNodes.Add(n6);
            AllNodes.Add(n7);
            AllNodes.Add(n8);
            AllNodes.Add(n9);
            AllNodes.Add(n10);
            AllNodes.Add(n11);
            AllNodes.Add(n12);
            AllNodes.Add(n13);
            AllNodes.Add(n14);
            AllNodes.Add(n15);
            AllNodes.Add(n16);
            AllNodes.Add(n17);
            #endregion nodepop

            for (int i = 0; i < Visited.Length; i++)
            {
                Visited[i] = false;
                Console.Write($"{i} false ");
            }
            for (int i = 0; i < 18; i++)
            {
                Result.Add(i, new List<int>());
            }

            FindComponents();

        }

        public static void FindComponents()
        {
            for (int i = 0; i < N; i++)
            {
                if (Visited[i]==false)
                {
                    Console.WriteLine($"Entered new group => {Count}.");
                    Count++;
                    dfs(i);
                }
            }
            Console.WriteLine($"The Count - total number of Groups is {Count}");
            foreach (var item in Result.Keys)
            {
                if (Result[item].Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var nodeId in Result[item])
                    {
                        sb.Append($"{nodeId} ");
                    }
                    Console.WriteLine($"Group {item} has the following members: {sb.ToString().Trim()}.");
                }
                
            }
        }

        public static void dfs(int at)
        {
            Visited[at] = true;
            Components[at] = Count;
            Result[Count].Add(at);
            Node tempNode = AllNodes[at];
            for (int i=0; i < tempNode.Connections.Count(); i++)
            {
                if (Visited[tempNode.Connections[i]]==false)
                {
                    dfs(tempNode.Connections[i]);
                }
            }
        }
    }
}
