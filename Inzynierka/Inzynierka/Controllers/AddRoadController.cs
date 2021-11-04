using Database;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
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
            _cities = _context.Cities.OrderBy(x=>x.Name).ToList();
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Cities = _cities;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Road road)
        {
            _context.Roads.Add(road);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
