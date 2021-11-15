using Database;
using Database.Model;
using GraphLibrary;
using Inzynierka.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Controllers
{
    public class MapController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IDijkstra _dijkstra;
        private readonly MapModel _model;

        public MapController(DatabaseContext context,IDijkstra dijkstra)
        {
            _context = context;
            _dijkstra = dijkstra;
            List<City> Cities = _context.Cities.OrderBy(x => x.Name).ToList();
            _model = new MapModel(Cities);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_model);
        }
        [HttpPost]
        public IActionResult Index(int SourceCityId, int TargetCityId, int Criterium)
        {
            _dijkstra.TargetNodeId = TargetCityId;
            //switch (Criterium)
            //{
            //    case 0:
            //        _dijkstra.Run(SourceCityId);
            //        break;
            //    case 1:
            //        List<float> Times = new List<float>();
            //        foreach (var item in _context.Roads.ToList())
            //        {
            //            float time = (float)item.Distance / (float)item.Speed;
            //            Times.Add(time);
            //        }
            //        _dijkstra.Run(SourceCityId, Times);
            //        break;
            //    case 2:

            //        break;
            //}
            _dijkstra.Run(SourceCityId);
            _model.Path = _dijkstra.AlghoritmResult[_dijkstra.TargetNodeId].Path;
            _model.DijkstraResult = _dijkstra.AlghoritmResult;
            return View(_model);
        }
    }
}
