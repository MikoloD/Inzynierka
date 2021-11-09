using Database.Model;
using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Models
{
    public class MapModel
    {
        public List<City> Cities { get; set; }
        public MapModel(List<City> cities)
        {
            Cities = cities;
        }
    }
}
