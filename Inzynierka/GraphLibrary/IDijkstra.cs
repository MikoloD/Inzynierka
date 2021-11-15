using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public interface IDijkstra
    {
        public IGraph Graph { get; set; }
        public DijkstraResult[] AlghoritmResult { get; set; }
        public int TargetNodeId { get; set; }
        public void Run(int startVertex, List<float> WageList = null);
    }

}
