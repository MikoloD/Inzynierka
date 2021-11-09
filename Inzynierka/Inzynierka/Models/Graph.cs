using Database;
using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Models
{
    public class Graph : IGraph
    {
        private readonly DatabaseContext _context;
        public List<INode> Nodes { get; set; } = new List<INode>();
        public List<IEdge> Edges { get; set; } = new List<IEdge>();
        public Graph(DatabaseContext context)
        {
            _context = context;
           
            foreach (var item in _context.Cities.ToList())
            {
                Nodes.Add(item);
            }

            foreach (var item in _context.Roads.ToList())
            {
                Edges.Add(item);
            }             
        } 
    }
}
