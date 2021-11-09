using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class Dijkstra : IDijkstra
    {
        public IGraph Graph { get; set; }
        public Dijkstra(IGraph graph)
        {
            Graph = graph;
        }


    }
}
