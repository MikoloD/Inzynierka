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
        public List<Criterium> Criteria { get; set; }
        public List<City> Cities { get; set; }
        public int SourceCityId { get; set; }
        public int TargetCityId { get; set; }
        public int CriteriumId { get; set; }
        public DijkstraResult[] DijkstraResult { get; set; } = new DijkstraResult[0];
        public List<int> Path { get; set; } = new List<int>();
        public MapModel(List<City> cities)
        {
            Cities = cities;
            Criteria = new List<Criterium>
            {
                new Criterium { CriteriumId = 1, Name = "Dystans" },
                new Criterium { CriteriumId = 2, Name = "Czas" }
            };
        }
    }
}
