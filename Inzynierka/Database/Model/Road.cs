using GraphLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Model
{
    public class Road : Edge
    {
        public int Distance { get; set; }
        public int Speed { get; set; }
        public float Price { get; set; }
        public City SourceNode { get; set; }
        public City TargetNode { get; set; }

    }
}
