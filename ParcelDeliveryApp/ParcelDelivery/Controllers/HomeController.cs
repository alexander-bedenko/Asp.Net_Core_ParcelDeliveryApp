using Microsoft.AspNetCore.Mvc;

namespace ParcelDelivery.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}