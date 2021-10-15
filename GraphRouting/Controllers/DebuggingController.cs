using Microsoft.AspNetCore.Mvc;
using RoadNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphRouting.Controllers
{
    public class DebuggingController : Controller
    {
        private readonly GraphDTO _graphDTO;
        public DebuggingController(GraphDTO graphDTO)
        {
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
    }
}
