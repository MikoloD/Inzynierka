using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model
{
    public class Road : Edge
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public float Price { get; set; }
    }
}
