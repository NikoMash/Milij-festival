using Microsoft.AspNetCore.Mvc;

namespace Milijøfestival.Server.Controllers
{
    public class VagtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
