using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public interface IGraph
    {
        public List<INode> Nodes { get; set; }
        public List<IEdge> Edges { get; set; }
    }
}
