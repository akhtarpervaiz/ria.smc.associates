using ria.smc.associates.Models.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Interfaces.MasterData
{
    public interface IMasterDataRepository
    {
        Task<List<Genders>> GetGenders();
        Task<List<BloodGroups>> GetBloodGroups();
        Task<List<MaritalStatuses>> GetMaritalStatus();
        Task<List<EmployeeTypes>> GetEmployeeTypes();
        Task<List<EmployeeStatuses>> GetEmployeeStatuses();
    }
}
