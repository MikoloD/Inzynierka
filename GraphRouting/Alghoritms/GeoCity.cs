using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphRouting.Alghoritms
{
    public class GeoCity
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public  void GoogleGeoLocator(string address)
        {
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);

            this.Lat = point.Latitude;
            this.Lon = point.Longitude;

        }
    }
}
