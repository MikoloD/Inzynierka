using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class ParallelDijkstra : IDijkstra
    {
        public IGraph Graph { get; set ; }
        public DijkstraResult[] AlghoritmResult { get; set; }
        public int TargetNodeId { get; set; }
        public ConcurrentBag<INode> Nodes { get; set; }
        public ConcurrentBag<IEdge> Edges { get; set; }
        public ParallelDijkstra(IGraph graph)
        {
            Graph = graph;
            Nodes = new ConcurrentBag<INode>(Graph.Nodes);
            Edges = new ConcurrentBag<IEdge>(Graph.Edges);
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
