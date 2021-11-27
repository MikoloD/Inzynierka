using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
    }
}
