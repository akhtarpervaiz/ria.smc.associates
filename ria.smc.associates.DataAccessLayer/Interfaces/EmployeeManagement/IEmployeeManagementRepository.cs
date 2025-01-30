using ria.smc.associates.Models.EmployeeManagement;
using ria.smc.associatesDto.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Interfaces.EmployeeManagement
{
    public interface IEmployeeManagementRepository
    {
        string ValidateEmployeeInformation(EmployeeInformationDTO employeeInformationDTO);
        Task<int> InsertEmployeeInformation(EmployeeInformationDTO employeeInformationDTO);
        Task<int> UpdateEmployeeInformation(EmployeeInformationDTO employeeInformationDTO);
        Task<int> DeleteEmployeeInformation(string employeeId);
        Task<List<EmployeeInformation>> GetEmployeeInformation(string? employeeCode, string? cnic, string? mobileNumber, string? department);
    }
}
