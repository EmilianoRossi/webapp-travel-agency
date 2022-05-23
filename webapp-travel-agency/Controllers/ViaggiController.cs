using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{
    public class ViaggiController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
