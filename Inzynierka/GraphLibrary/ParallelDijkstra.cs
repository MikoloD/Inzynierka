using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class ParallelDijkstra : IDijkstra
    {
        public Graph Graph { get; set ; }
        public DijkstraResult[] AlghoritmResult { get; set; }
        public int TargetNodeId { get; set; }
        public ConcurrentBag<Node> Nodes { get; set; }
        public ConcurrentBag<Edge> Edges { get; set; }
        public ParallelDijkstra(Graph graph)
        {
            Graph = graph;
            Nodes = new ConcurrentBag<Node>(Graph.Nodes);
            Edges = new ConcurrentBag<Edge>(Graph.Edges);
            int size = Graph.Nodes.Count;
            AlghoritmResult = new DijkstraResult[size];
            for (int i = 0; i < size; i++)
            {
                AlghoritmResult[i] = new DijkstraResult();
            }
        }
        public void Run(int startVertex, List<float> WageList = null)
        {
            throw new NotImplementedException();
        }
    }
}
