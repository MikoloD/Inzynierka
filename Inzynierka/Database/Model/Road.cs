using GraphLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Model
{
    public class Road : IEdge
    {
        [Key]
        public int EdgeId { get;set; }
        public int SourceNodeId { get; set; }
        public int TargetNodeId { get; set; }
        public float Wage { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public float Price { get; set; }
        public City SourceNode { get; set; }
        public City TargetNode { get; set; }
    }
}
