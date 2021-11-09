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
        public IActionResult Index(int Source, int Target)
        {
            return View(_model);
        }
    }
}
