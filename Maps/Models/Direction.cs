using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.Models
{
    public class Direction
    {
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        //public string Location { get; set; }
        //public string Distination { get; set; }

        public List<string> Origins { get; set; }
        public List<string> Destinations { get; set; }
        public List<Row> Rows { get; set; }
        public string Status { get; set; }


        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public List<ResourceSet> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public List<Element> elements { get; set; }
    }


    // bing

    public class Point
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class ToPoint
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Resource
    {
        public string __type { get; set; }
        public Point point { get; set; }
        public string description { get; set; }
        public DateTime end { get; set; }
        public object incidentId { get; set; }
        public DateTime lastModified { get; set; }
        public bool roadClosed { get; set; }
        public int severity { get; set; }
        public int source { get; set; }
        public DateTime start { get; set; }
        public ToPoint toPoint { get; set; }
        public int type { get; set; }
        public bool verified { get; set; }
    }

    public class ResourceSet
    {
        public int estimatedTotal { get; set; }
        public List<Resource> resources { get; set; }
    }
}