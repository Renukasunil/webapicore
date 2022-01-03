using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WelcomePage.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        { 
         
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Clients()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
