using Database;
using Database.Model;
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
        public MapController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<City> Cities = _context.Cities.OrderBy(x => x.Name).ToList();
            ViewBag.Cities = Cities;
            List <RoadDTO> Roads= new List<RoadDTO>();
            foreach (var item in _context.Roads.ToList())
            {
                float[] points = new float[4];
                var source = Cities.First(x => x.Id == item.Source);
                var target = Cities.First(x => x.Id == item.Target);
                points[0] = source.Latitude;
                points[1] = source.Longitude;
                points[2] = target.Latitude;
                points[3] = target.Longitude;
                RoadDTO road = new RoadDTO(
                    item.Id,
                    points);
                Roads.Add(road);
            }
            ViewBag.Roads = Roads;
            return View();
        }
    }
}
