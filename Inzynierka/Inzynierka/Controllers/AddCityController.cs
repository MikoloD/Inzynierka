using Database;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Controllers
{
    public class AddCityController : Controller
    {
        private readonly DatabaseContext _context;
        public AddCityController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
