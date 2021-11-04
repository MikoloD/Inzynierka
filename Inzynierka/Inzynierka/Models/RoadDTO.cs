using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inzynierka.Models
{
    public class RoadDTO
    {
        public int Id { get; set; }
        public float[,] LatLong { get; set; } = new float[2,2];
        public RoadDTO()
        {

        }
        public RoadDTO(int id,float[] Point)
        {
            Id = id;
            int size = LatLong.GetLength(0);
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                for(int j=0;j<size;j++)
                {
                    LatLong[i, j] = Point[counter];
                    counter++;
                }
            }
        }
    }
}
