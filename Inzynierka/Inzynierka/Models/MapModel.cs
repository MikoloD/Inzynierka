using Database;
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
        private readonly DatabaseContext _context;
        public List<Criterium> Criteria { get; set; }
        public List<City> Cities { get; set; }
        public int SourceCityId { get; set; }
        public int TargetCityId { get; set; }
        public int CriteriumId { get; set; }
        public DijkstraResult[] DijkstraResult { get; set; } = new DijkstraResult[0];
        public List<int> Path { get; set; } = new List<int>();
        public float Result { get; set; }
        public string Unit { get; set; }
        public FuelInfo FuelInfo { get; set; }
        public float Cost { get; set; }
        public MapModel(DatabaseContext context)
        {
            _context = context;
            Cities = _context.Cities.OrderBy(x => x.Name).ToList();
            Criteria = new List<Criterium>
            {
                new Criterium { CriteriumId = 1, Name = "Dystans" },
                new Criterium { CriteriumId = 2, Name = "Czas" }
            };
        }
        public void FillModel(IDijkstra dijkstra,FuelInfo fuelInfo)
        {
            int targetNodeId = dijkstra.TargetNodeId;
            Path = dijkstra.AlghoritmResult[targetNodeId].Path;
            DijkstraResult = dijkstra.AlghoritmResult;
            Result = dijkstra.AlghoritmResult[targetNodeId].Value;
            FuelInfo = fuelInfo;
            if (FuelInfo.Usage > 0)
            {
                ComputeCost();
            }
        }
        private void ComputeCost()
        {
            for(int i=1;i<Path.Count;i++)
            {
                Road road = _context.Roads.FirstOrDefault(x => (x.SourceNodeId == Path[i-1] || x.SourceNodeId == Path[i]) && (x.TargetNodeId == Path[i] || x.TargetNodeId == Path[i - 1]));
                float singleRoadCost = (FuelInfo.Usage / 100) * road.Distance * FuelInfo.Price + road.Price;
                Cost += singleRoadCost;
            }
            Cost = (float)Math.Round(Cost, 2);
        }
    }
}
