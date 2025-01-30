using ria.smc.associates.UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Interfaces.Users
{
    public interface IUsersRepository
    {
        Task<LoginResponse> GetUserInformation(LoginRequest loginRequest);
    }
}
