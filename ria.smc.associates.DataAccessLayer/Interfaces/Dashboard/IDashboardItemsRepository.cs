using ria.smc.associates.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Interfaces.Dashboard
{
    public interface IDashboardItemsRepository
    {
        Task<List<DashboardMenuItems>> GetDashboardItems();
    }
}
