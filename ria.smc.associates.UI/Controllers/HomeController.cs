using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.UI.Utilities.Attributes;

namespace ria.smc.associates.UI.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizeAuth()]
        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeAuth()]
        public IActionResult Error()
        {
            return View();
        }

        [AuthorizeAuth()]
        public IActionResult NotFound()
        {
            return View();
        }

    }
}
