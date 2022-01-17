using Database;
using GraphLibrary;
using Inzynierka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IDijkstra _dijkstra;
        private readonly MapModel _model;

        public HomeController(DatabaseContext context, IDijkstra dijkstra)
        {
            _context = context;
            _dijkstra = dijkstra;
            _model = new MapModel(context);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_model);
        }
        [HttpPost]
        public IActionResult Index(int SourceCityId, int TargetCityId, int CriteriumId, FuelInfo fuelInfo)
        {
            _dijkstra.TargetNodeId = TargetCityId;
            List<float> Wages = null;
            switch (CriteriumId)
            {
                case 1:
                    _model.Unit = "Km";
                    break;
                case 2:
                    Wages = new List<float>();
                    foreach (var item in _context.Roads.ToList())
                    {
                        Wages.Add((float)item.Distance / item.Speed);
                    }
                    _model.Unit = "h";
                    break;
            }
            _dijkstra.Run(SourceCityId,Wages);
            _model.FillModel(_dijkstra, fuelInfo);
            return View(_model);
        }
    }
}
