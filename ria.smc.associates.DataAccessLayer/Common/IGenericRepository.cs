using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Common
{
    public interface IGenericRepository
    {
        SqlCommand GetCommand();
        SqlCommand GetCommand(string cmdText);
        SqlCommand GetCommand(string cmdText, CommandType cmdType = CommandType.Text);
        SqlCommand GetCommand(string cmdText, CommandType cmdType, SqlTransaction transaction);
        void OpenConnection();
        void CloseConnection(SqlCommand command = null);
        object ExecuteScalar(string procedureName, params SqlParameter[] parameters);
        int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters);

        SqlParameter GetSqlParameter(string paramenterName,
            object value,
            SqlDbType Dbtype,
            int size = 0);

        SqlParameter GetSqlParameterNullValue(string paramenterName,
            object value,
            SqlDbType Dbtype,
            int size = 0);
    }
}
