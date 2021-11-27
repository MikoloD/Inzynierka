using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphLibrary
{
    public class Edge
    {
        [Key]
        public int EdgeId { get; set; }
        public int SourceNodeId { get; set; }
        public int TargetNodeId { get; set; }
        public float Wage { get; set; }
    }
}
