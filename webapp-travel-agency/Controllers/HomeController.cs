using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult DettagliUtente()
        {
            return View("DettagliUtente");
        }
    }
}