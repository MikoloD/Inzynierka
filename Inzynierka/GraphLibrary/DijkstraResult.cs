using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class DijkstraResult
    {
        public int SourceNodeId { get; set; }
        public int TargetSorceId { get; set; }
        public float Value { get; set; }
        public List<int> Path { get; set; } = new List<int>();
    }
}
