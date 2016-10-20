using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using IOLDOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace IOLDotNet.Controllers
{
    public class HomeController : Controller
    {
        DashboardElements  dbe = new DashboardElements();
        private DashboardElementsDBContext dbc;
        private GroceryStoreItemContext _GroceryContext ;

        public HomeController(GroceryStoreItemContext gdbc){
         _GroceryContext = gdbc;
        }

        public IActionResult Index()
        {
            var result = GetCommuteTime();
            ViewData["commuteDuration"] = result["duration"]["text"];
            ViewData["commuteVia"] = result["via"];
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

        public async Task<IActionResult> Groceries()
        {
            return View(await _GroceryContext.GroceryStoreItem.ToListAsync());
        }

        [HttpPostAttribute]
        public IActionResult SaveNewGroceryItem(GroceryStoreItem gsi){
            gsi.LastUpdated = DateTime.Now;
            _GroceryContext.GroceryStoreItem.Add(gsi);
            _GroceryContext.SaveChanges();
            return RedirectToAction("Groceries");
        }

        public IActionResult RemoveItem(int itemId){
            Console.WriteLine("The Grocery item being removed is " + itemId);
            var item = _GroceryContext.GroceryStoreItem.First(m => m.itemId.Equals(itemId));
            if (item ==null){
                Console.WriteLine("Given item is null!");
            }
            else{
                Console.WriteLine("Item is " + item.ToString());
            }
            if (item != null){
                _GroceryContext.GroceryStoreItem.Remove(item);
            }
            _GroceryContext.SaveChanges();
            return RedirectToAction("Groceries");
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