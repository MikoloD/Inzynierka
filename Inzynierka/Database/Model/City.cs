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
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<Road> SourceRoads { get; set; }
        public List<Road> TargetRoads { get; set; }
    }
}
