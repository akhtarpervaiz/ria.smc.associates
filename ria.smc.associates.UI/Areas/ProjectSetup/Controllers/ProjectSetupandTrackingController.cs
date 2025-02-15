using Microsoft.AspNetCore.Mvc;

namespace ria.smc.associates.UI.Areas.ProjectSetup.Controllers
{
    [Area("ProjectSetup")]
    public class ProjectSetupandTrackingController : Controller
    {
        [HttpGet]
        public IActionResult AddNewProject()
        {
            return View();
        }
    }
}
