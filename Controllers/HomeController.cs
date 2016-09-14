using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOL.net.Controllers {
 public class HomeController: Controller {
  public IActionResult Index() {
      GetCommuteTime();
   return View();
  }

  public IActionResult About() {
   ViewData["Message"] = "Your application description page.";

   return View();
  }

  public IActionResult Contact() {
   ViewData["Message"] = "Your contact page.";

   return View();
  }

  public IActionResult Error() {
   return View();
  }

  private void GetCommuteTime() {
    string url = @"https://maps.googleapis.com/maps/api/directions/xml";
    string reqParams = "?origin=7302%20North%20New%20York%20Ave%20Portland%20OR&destination=2715%20Southwest%203rd%20Ave%20Portland%20OR&key=AIzaSyBOfz-0OGf1ns4RtF6VGXQDHVDy6YM09B4";
    HttpClient client = new HttpClient();
    client.BaseAddress = new System.Uri(url);
    HttpResponseMessage response = client.GetAsync(reqParams).Result;

    if (response.IsSuccessStatusCode){
        Console.WriteLine("Yay!");
    }
  
  }

 }
}