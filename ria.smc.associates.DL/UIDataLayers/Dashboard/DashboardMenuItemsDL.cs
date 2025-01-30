using ApiCaller.ServiceCaller;
using ria.smc.associates.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DL.UIDataLayers.Dashboard
{
    public static class DashboardMenuItemsDL
    {
        public static List<DashboardMenuItems> GetDashboardMenuItems()
        {
            string endPoint = $"Dashboard/GetDashboardMenuItems";
            return HttpCaller.Get<List<DashboardMenuItems>>(endPoint);
        }
    }
}
