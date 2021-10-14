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
            _logger = logger;
            _graphDTO = graphDTO;
        }

        public IActionResult Index()
        {
            Dijkstra dijkstra = new Dijkstra(_graphDTO);
            //for debug purposes 0
            int startingVertex = 0;
            dijkstra.Run(_graphDTO.AdjacencyMatrix, startingVertex);
            return View(dijkstra.DijkstraDTOs);
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
