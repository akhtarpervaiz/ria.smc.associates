using Microsoft.Data.SqlClient;
using ria.smc.associates.DataAccessLayer.Common;
using ria.smc.associates.DataAccessLayer.Constants.Dashboard;
using ria.smc.associates.DataAccessLayer.Interfaces.Dashboard;
using ria.smc.associates.UI.Models;
using ria.smc.associates.UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Repositories.Dashboard
{
    public class DashboardItemsRepository : IDashboardItemsRepository
    {
        private readonly IGenericRepository _genericRepository;

        public DashboardItemsRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<DashboardMenuItems>> GetDashboardItems()
        {
            List<DashboardMenuItems> dashboardMenuItems = new List<DashboardMenuItems>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.DASHBOARDMENUITEMS_GET.Name, CommandType.StoredProcedure);
                _genericRepository.OpenConnection();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int MENUITEMID = reader.GetOrdinal("MENUITEMID");
                        int PARENTID = reader.GetOrdinal("PARENTID");
                        int TITLE = reader.GetOrdinal("TITLE");
                        int URL = reader.GetOrdinal("URL");
                        int ICON = reader.GetOrdinal("ICON");
                        int SORTORDER = reader.GetOrdinal("SORTORDER");

                        while (reader.Read())
                        {
                            DashboardMenuItems result = new DashboardMenuItems();
                            result.MenuItemId = reader.GetString(MENUITEMID);
                            result.ParentId = !reader.IsDBNull(PARENTID) ? reader.GetString(PARENTID) : string.Empty;
                            result.Title = reader.GetString(TITLE);
                            result.Url =!reader.IsDBNull(URL) ? reader.GetString(URL) : string.Empty;
                            result.Icon =!reader.IsDBNull(ICON) ? reader.GetString(ICON) : string.Empty;
                            result.SortOrder = reader.GetInt32(SORTORDER);
                            dashboardMenuItems.Add(result);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _genericRepository.CloseConnection();
            }
            return dashboardMenuItems;
        }

    }
}
