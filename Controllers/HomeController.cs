using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using IOL.net.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IOL.net.Controllers
{
    public class HomeController : Controller
    {
        DashboardElements  dbe = new DashboardElements();
        public IActionResult Index()
        {
            var result = GetCommuteTime();
            dbe.commute = result; 
            return View(dbe);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private JObject GetCommuteTime()
        {
            string url = @"https://maps.googleapis.com/maps/api/directions/json";
            string reqParams = "?origin=7302%20North%20New%20York%20Ave%20Portland%20OR&destination=2715%20Southwest%203rd%20Ave%20Portland%20OR&key=AIzaSyBOfz-0OGf1ns4RtF6VGXQDHVDy6YM09B4";
            Task<string> responseBody = SendGetRequest(url, reqParams);
            Console.WriteLine("response is " + responseBody.Result);
            JObject o = JObject.Parse(responseBody.Result);
            Console.WriteLine("Geocoder status is " + o["geocoded_waypoints"][0]["geocoder_status"]);
            JObject trip = new JObject();
            trip["duration"] = o["routes"][0]["legs"][0]["duration"];
            trip["via"] = o["routes"][0]["summary"];
            return trip;
            }


        private async Task<string> SendGetRequest(string requestBase, string requestParams)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestBase + requestParams);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}