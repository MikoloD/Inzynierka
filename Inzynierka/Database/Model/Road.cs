using GraphLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Model
{
    public class Road : Edge
    {
        [Display(Name = "Oznaczenie")]
        public string Name { get; set; }
        [Display(Name = "Długość")]
        public int Distance { get; set; }
        [Display(Name = "Prędkość")]
        public int Speed { get; set; }
        [Display(Name = "Opłata")]
        public float Price { get; set; }
        public City SourceNode { get; set; }
        public City TargetNode { get; set; }
    }
}
