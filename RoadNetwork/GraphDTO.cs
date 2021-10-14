using System;
using System.Collections.Generic;
using System.IO;

namespace RoadNetwork
{
    public class GraphDTO
    {
        public int[,] AdjacencyMatrix;
        public Dictionary<int, string> Vercites; 
        public int[,] LoadAdjacencyMatrix(string path)
        {
            string input = File.ReadAllText(path);
            int i = 0;
            int size = File.ReadAllLines(path).Length;
            int[,] result = new int[size, size];
            foreach (var row in input.Split('\n'))
            {
                int j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    var elem = col.Trim();
                    if (Int32.TryParse(elem, out int defaultInt))
                    {
                        result[i, j] = int.Parse(elem);
                        j++;
                    }
                    else if (j == 0 && !String.IsNullOrEmpty(elem))
                    {
                        Vercites.Add(i, elem);
                    }
                }
                i++;
            }
            return result;
        }
        public GraphDTO()
        {
            Vercites = new Dictionary<int, string>();
            AdjacencyMatrix = LoadAdjacencyMatrix(@"G:\Projekty\RoadNetwork\Data\Distances.txt");
        }
    }
}
