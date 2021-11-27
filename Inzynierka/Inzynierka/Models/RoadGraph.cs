using Database;
using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Models
{
    public class RoadGraph : Graph
    {
        private readonly DatabaseContext _context;
        public RoadGraph(DatabaseContext context)
        {
            _context = context;
           
            foreach (var item in _context.Cities.ToList())
            {
                Nodes.Add(item);
            }

            foreach (var item in _context.Roads.ToList())
            {
                var edge = item;
                edge.Wage = item.Distance;
                Edges.Add(edge);
            }             
        } 
    }
}
