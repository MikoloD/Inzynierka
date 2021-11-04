using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphLibrary
{
    public class Edge
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public int Target { get; set; }
        public float Wage { get; set; }
    }
}
