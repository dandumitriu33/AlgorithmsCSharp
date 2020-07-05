using System.Collections.Generic;
using System.Text;

namespace AlgorithmsImplementation
{
    class Node
    {
        public int Id { get; set; }
        public List<int> Connections { get; set; } = new List<int>();
        public Node(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int item in this.Connections)
            {
                sb.Append($"{item.ToString()} ");
            }
            string result = sb.ToString().Trim();
            return result;
        }

    }
}
