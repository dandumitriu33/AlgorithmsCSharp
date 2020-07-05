using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSConnectedComponents
{ 
    class Node
    {
        public int Id { get; set; }
        public List<int> Connections { get; set; } = new List<int>();
        public int GroupId { get; set; }
        public Node(int id)
        {
            Id = id;
        }
    }
}
