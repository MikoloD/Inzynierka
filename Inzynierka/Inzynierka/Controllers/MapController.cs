using Database;
using Database.Model;
using GraphLibrary;
using Inzynierka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Concurrent;
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
        public IActionResult Index(int SourceCityId, int TargetCityId, int CriteriumId)
        {
            _dijkstra.TargetNodeId = TargetCityId;
            List<float> Wages = null;
            switch (CriteriumId)
            {
                case 1:
                    break;
                case 2:
                    Wages = new List<float>();
                    foreach (var item in _context.Roads.ToList())
                    {                    
                        Wages.Add((float)item.Distance / item.Speed);
                    }
                    break;
                default:
                    break;
            }
            _dijkstra.Run(SourceCityId,Wages);
            _model.Path = _dijkstra.AlghoritmResult[_dijkstra.TargetNodeId].Path;
            _model.DijkstraResult = _dijkstra.AlghoritmResult;
            return View(_model);
        }
    }
}
