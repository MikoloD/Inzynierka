using Database;
using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Models
{
    public class AddRoadModel
    {
        public List<City> Cities { get; set; }
        public Road AddedRoad { get; set; }
        public AddRoadModel(List<City> cities)
        {
            Cities = cities;
            AddedRoad = new Road();
        }
    }
}
