using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.ViewModels
{
    public class DirectionViewModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public string Address { get; set; }
    }
}