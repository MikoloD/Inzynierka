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
        [Display(Name = "Początek")]
        public int SourceNodeId { get; set; }
        [Display(Name = "Koniec")]
        public int TargetNodeId { get; set; }
        [Display(Name = "Waga")]
        public float Wage { get; set; }
    }
}
