using GraphRouting.Alghoritms;
using GraphRouting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoadNetwork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GraphRouting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GraphDTO _graphDTO;
        public HomeController(ILogger<HomeController> logger,GraphDTO graphDTO)
        {
            _graphDTO = graphDTO;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Cities = _graphDTO.Vercites;
            return View();
        }
        [HttpPost]
        public IActionResult Index(DijkstraDTO dijkstraDTO)
        {
            Dijkstra dijkstra = new Dijkstra(_graphDTO);
            ViewBag.Cities = _graphDTO.Vercites;
            dijkstra.Run(_graphDTO.AdjacencyMatrix,dijkstraDTO.StartVertex);
            var model = dijkstra.DijkstraDTOs.First(x => x.VertexIndex == dijkstraDTO.VertexIndex);
            //List<GeoCity> Coordinates = new List<GeoCity>();
            //foreach (var item in model.Path)
            //{
            //    GeoCity city = new GeoCity();
            //    city.Name = item;
            //    city.GoogleGeoLocator(item);
            //    Coordinates.Add(city);
            //}
            //ViewBag.Coordinates = Coordinates;
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
