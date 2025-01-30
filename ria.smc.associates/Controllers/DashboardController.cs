using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.DataAccessLayer.Interfaces.Dashboard;
using ria.smc.associates.UI.Models;

namespace ria.smc.associates.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardItemsRepository _dashboardItemsRepository;

        public DashboardController(IDashboardItemsRepository dashboardItemsRepository)
        {
            _dashboardItemsRepository = dashboardItemsRepository;
        }
        [HttpGet]
        [Route("GetDashboardMenuItems")]
        public async Task<IActionResult> GetDashboardMenuItems()
        {
            List<DashboardMenuItems> dashboardItems = new List<DashboardMenuItems>();
            try
            {
                dashboardItems =await _dashboardItemsRepository.GetDashboardItems();
                if(dashboardItems != null)
                {
                    return Ok(dashboardItems);
                }
                else
                {
                    return StatusCode(404, "An unexpected error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
