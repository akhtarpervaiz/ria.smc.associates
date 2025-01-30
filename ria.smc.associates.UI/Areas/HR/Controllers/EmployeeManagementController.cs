using Microsoft.AspNetCore.Mvc;

namespace ria.smc.associates.UI.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeRegistrationController : Controller
    {
        [HttpGet]
        public IActionResult EmployeeRegistration()
        {
            return View();
        }
    }
}
