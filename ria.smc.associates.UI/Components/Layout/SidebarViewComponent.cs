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

        for (int i = 0; i < dashboardMenuItems.Count; i++)
        {
            var path = HttpContext.Request.Path;
            if (getActiveNavItemName(dashboardMenuItems[i].Url) == getActiveNavItemName(path))
            {
                dashboardMenuItems[i].IsActiveItem = "active";
            }
        }

        return await Task.FromResult((IViewComponentResult)View("../Layout/Sidebar", dashboardMenuItems));
    }


    public string getActiveNavItemName(string item)
    {
        var items = item.Split('/');

        if(items.Length == 2)
        {
            return items[0];
        }
        else if(items.Length == 3)
        {
            return items[1];
        }
        else if (items.Length == 4)
        {
            return items[2];
        }

        return "";
    }


}