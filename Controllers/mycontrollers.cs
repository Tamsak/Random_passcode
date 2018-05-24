using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace RanWords.Controllers
{
    public class mycontrollers : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            int? Counter = HttpContext.Session.GetInt32("Counter");
            string Passcode = HttpContext.Session.GetString("Passcode");
            if (Counter == null)
            {
                Counter = 0;
                HttpContext.Session.SetInt32("Counter", 0);
            }
            if (Passcode == null)
                Passcode = "";
            
            HttpContext.Session.SetInt32("Counter",(int)Counter);
            HttpContext.Session.GetString("Passcode");
            ViewBag.Counter = Counter;
            ViewBag.Passcode = Passcode;
            return View();
        }
        [HttpPost("random_word")]
        public IActionResult RandomCode()
        {
            string Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string Passcode = "";
            Random Rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                Passcode = Passcode + Char[Rand.Next(0, Char.Length)];
            }
            int? Counter = HttpContext.Session.GetInt32("Counter");           
            Counter +=1;
            HttpContext.Session.SetInt32("Counter",(int)Counter);
            HttpContext.Session.SetString("Passcode",(string)Passcode);
            ViewBag.Counter = Counter;
            return RedirectToAction("index");
        }
        [HttpPost("random_word/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}