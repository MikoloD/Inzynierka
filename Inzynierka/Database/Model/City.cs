using GraphLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Model
{
    public class City : Node
    {
        [Display(Name = "Nazwa Miasta")]
        public string Name { get; set; }
        [Display(Name = "Szerokość geograficzna")]
        public float Latitude { get; set; }
        [Display(Name = "Długośc geograficzna")]
        public float Longitude { get; set; }
        public List<Road> SourceRoads { get; set; }
        public List<Road> TargetRoads { get; set; }
    }
}
