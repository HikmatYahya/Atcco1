using Microsoft.AspNetCore.Mvc;

namespace Atcco.Controllers
{
    public class _404 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
