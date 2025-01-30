using ApiCaller.ServiceCaller;
using ria.smc.associates.Models.MasterData;
using ria.smc.associates.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DL.UIDataLayers.MasterDate
{
    public static class MasterDL
    {
        public static Genders GetGenders()
        {
            string endPoint = $"Dashboard/GetDashboardMenuItems";
            return HttpCaller.Get<Genders>(endPoint);
        }
        public static BloodGroups GetBloodGroups()
        {
            string endPoint = $"Dashboard/GetDashboardMenuItems";
            return HttpCaller.Get<BloodGroups>(endPoint);
        }
        public static MaritalStatuses GetMaritalStatus()
        {
            string endPoint = $"Dashboard/GetDashboardMenuItems";
            return HttpCaller.Get<MaritalStatuses>(endPoint);
        }
    }
}
