using ApiCaller.ServiceCaller;
using ria.smc.associates.Models.EmployeeManagement;
using ria.smc.associates.Models.MasterData;
using ria.smc.associatesDto.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DL.UIDataLayers.HumanResourceManagement
{
    public class HumanResourceDL
    {
        public static EmployeeInformation CreateEmployee(EmployeeInformationDTO employeeInformationDTO)
        {
            string endPoint = $"EmployeeManagement/EmployeeRegistration";
            return HttpCaller.Post<EmployeeInformation>(endPoint, employeeInformationDTO);
        }

        public static string GetMaxEmployeeCode()
        {
            string endPoint = $"EmployeeManagement/GetMaxEmployeeCode";
            return HttpCaller.Get<string>(endPoint);
        }
    }
}
