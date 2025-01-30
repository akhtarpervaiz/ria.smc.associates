using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.DL.UIDataLayers.Dashboard;
using ria.smc.associates.UI.Models;

namespace ria.smc.associates.UI.Components.Layout;
public class SidebarViewComponent : ViewComponent
{ 
    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<DashboardMenuItems> dashboardMenuItems = new List<DashboardMenuItems>();
        dashboardMenuItems = DashboardMenuItemsDL.GetDashboardMenuItems();
        
        return await Task.FromResult((IViewComponentResult)View("../Layout/Sidebar", dashboardMenuItems));
    }
}