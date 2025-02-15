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
        public static List<Genders> GetGenders()
        {
            string endPoint = $"MasterData/GetGenders";
            return HttpCaller.Get<List<Genders>>(endPoint);
        }
        public static List<BloodGroups> GetBloodGroups()
        {
            string endPoint = $"MasterData/GetBloodGroups";
            return HttpCaller.Get<List<BloodGroups>>(endPoint);
        }
        public static List<MaritalStatuses> GetMaritalStatus()
        {
            string endPoint = $"MasterData/GetMaritalStatuses";
            return HttpCaller.Get<List<MaritalStatuses>>(endPoint);
        }
        public static List<EmployeeTypes> GetEmployeeTypes()
        {
            string endPoint = $"MasterData/GetEmployeeTypes";
            return HttpCaller.Get<List<EmployeeTypes>>(endPoint);
        }
        public static List<EmployeeStatuses> GetEmployeeStatus()
        {
            string endPoint = $"MasterData/GetEmployeeStatus";
            return HttpCaller.Get<List<EmployeeStatuses>>(endPoint);
        }
        
    }
}
