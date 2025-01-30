using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ria.smc.associates.DataAccessLayer.Common;
using ria.smc.associates.DataAccessLayer.Constants.Users;
using ria.smc.associates.DataAccessLayer.Interfaces.Users;
using ria.smc.associates.UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IGenericRepository _genericRepository;

        public UsersRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<LoginResponse> GetUserInformation(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            SqlCommand command = null;
            try
            {
                
                command = _genericRepository.GetCommand(StoreProcedures.USERINFORMATION_GET.Name, CommandType.StoredProcedure);
                var pUserName = _genericRepository.GetSqlParameter(StoreProcedures.USERINFORMATION_GET.Params.USERNAME, loginRequest.UserName, SqlDbType.NVarChar);
                var pPassword = _genericRepository.GetSqlParameter(StoreProcedures.USERINFORMATION_GET.Params.PASSWORD, loginRequest.Password, SqlDbType.NVarChar);

                command.Parameters.AddRange
                    (new[]
                    { 
                        pUserName,
                        pPassword
                    });

                _genericRepository.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int USERID = reader.GetOrdinal("USERID");
                        int EMPLOYEEID = reader.GetOrdinal("EMPLOYEEID");
                        int USERNAME = reader.GetOrdinal("USERNAME");
                        int EMAIL = reader.GetOrdinal("EMAIL");
                        int MOBILENO = reader.GetOrdinal("MOBILENUMBER");
                        while (reader.Read())
                        {
                            loginResponse.UserId = reader.GetString(USERID);
                            loginResponse.UserName = reader.GetString(USERNAME);
                            loginResponse.Email = reader.GetString(EMAIL);
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
            return loginResponse;
        }
    }
}
