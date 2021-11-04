using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model
{
    public class City : Node
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
