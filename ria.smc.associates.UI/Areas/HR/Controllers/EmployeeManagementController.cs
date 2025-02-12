using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.Models.EmployeeManagement;

namespace ria.smc.associates.UI.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeManagementController : Controller
    {
        [HttpGet]
        public IActionResult EmployeeRegistration()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EmployeeRegistration(EmployeeInformation employeeInformation)
        {
            return View();
        }
    }
}
