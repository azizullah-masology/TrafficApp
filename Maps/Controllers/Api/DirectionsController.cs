using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using Google.Maps.Direction;
using Maps.ViewModels;
using Maps.Models;

namespace Maps.Controllers.Api
{
    public class DirectionsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetDirection(string location, string destination, string locationLatitude, string locationLongitude, string destinationLatitude, string destinationLongitude)
        {
            string urlGoogle = @"maps/api/distancematrix/json?origins=" + location + "&destinations=" + destination + "&key=AIzaSyBSLbjjLbyH9txKHGdhi_XW9kziuCrviaI";
            IRestRequest requestGoogle = new RestRequest(urlGoogle, Method.GET);
            requestGoogle.AddHeader("Accept", "application/json");
            requestGoogle.AddHeader("Content-Type", "application/json");

            IRestClient clientGoogle = new RestClient("https://maps.googleapis.com/");
            IRestResponse responseGoogle = clientGoogle.Execute(requestGoogle);

            string responseContent = responseGoogle.Content.Remove(responseGoogle.Content.LastIndexOf('}'));

            string urlBing = @"REST/v1/Traffic/Incidents/" + locationLatitude + "," + locationLongitude + "," + destinationLatitude + "," + destinationLongitude + "?key=ArkHrr2dyl5BuWKFXHxKyarXKmp9uz1u2JIvwLq1PBT8HUaZmo-MJW-CvfYZtOyb";
            IRestRequest requestBing = new RestRequest(urlBing, Method.GET);
            requestBing.AddHeader("Accept", "application/json");
            requestBing.AddHeader("Content-Type", "application/json");

            IRestClient clientBing = new RestClient("http://dev.virtualearth.net/");
            IRestResponse responseBing = clientBing.Execute(requestBing);

            string responseContentBing = responseBing.Content.Remove(0, 1);

            responseContent += "," + responseContentBing;

            return Ok(responseContent);
        }

        [HttpGet]
        public IHttpActionResult GetPlaces(string search)
        {
            string url = @"maps/api/place/autocomplete/json?input=" + search + "&types=geocode&language=en&key=AIzaSyBSLbjjLbyH9txKHGdhi_XW9kziuCrviaI";
            IRestRequest request = new RestRequest(url, Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            IRestClient client = new RestClient("https://maps.googleapis.com/");
            IRestResponse response = client.Execute(request);

            string responseContent = response.Content;
            Place directions = (Place)Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent, typeof(Place));

            List<Prediction> list = directions.predictions;

            return Ok(list);
        }
    }
}
