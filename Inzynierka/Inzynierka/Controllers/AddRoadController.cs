using Database;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Inzynierka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Controllers
{
    public class AddRoadController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly List<City> _cities;
        public AddRoadController(DatabaseContext context)
        {
            _context = context;
            _cities = _context.Cities
                .OrderBy(x=>x)
                .ToList();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AddRoadModel(_cities));
        }
        [HttpPost]
        public IActionResult Index(AddRoadModel road)
        {
            _context.Roads.Add(road.AddedRoad);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
