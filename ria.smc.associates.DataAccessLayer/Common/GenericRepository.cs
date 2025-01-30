using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Common
{
    public class GenericRepository : IGenericRepository
    {
        private string _connectionString;
        private SqlConnection _sqlConnectionPrivate;
        public GenericRepository(IConfiguration configuration)
        {
            var connectionString = new SqlConnection(configuration.GetConnectionString("dbConnection"));
            _connectionString = connectionString.ConnectionString;
            _sqlConnectionPrivate = new SqlConnection(connectionString.ConnectionString);
        }
        public SqlConnection _dbConnection => _sqlConnectionPrivate ?? new SqlConnection(_connectionString);
        public void CloseConnection(SqlCommand command = null)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command?.Dispose();
            }
        }

        public int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(procedureName))
            {
                using (SqlConnection connection = new SqlConnection(_connectionString.ToString()))
                {
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (parameters != null)
                        {
                            foreach (var t in parameters)
                            {
                                command.Parameters.Add(t);
                            }
                        }

                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }

                        command.Dispose();
                    }
                }
            }

            return 0;
        }

        public object ExecuteScalar(string procedureName, params SqlParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(procedureName) && parameters?.Length > 0)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString.ToString()))
                {
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        foreach (var t in parameters)
                        {
                            command.Parameters.Add(t);
                        }

                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        return command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }

                        command.Dispose();
                    }
                }
            }

            return null;
        }

        public SqlCommand GetCommand()
        {
            var cmd = new SqlCommand();
            cmd.Connection = _dbConnection;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        public SqlCommand GetCommand(string cmdText)
        {
            var cmd = GetCommand();
            cmd.CommandText = cmdText;
            return cmd;
        }

        public SqlCommand GetCommand(string cmdText, CommandType cmdType)
        {
            var cmd = GetCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            return cmd;
        }

        public SqlCommand GetCommand(string cmdText, CommandType cmdType, SqlTransaction transaction)
        {
            var cmd = GetCommand(cmdText, cmdType);
            cmd.Transaction = transaction;
            return cmd;
        }

        public SqlParameter GetSqlParameter(string paramenterName, object value, SqlDbType Dbtype, int size = 0)
        {
            if (!string.IsNullOrEmpty(paramenterName))
            {
                SqlParameter sqlParameter = new SqlParameter(paramenterName, value);
                if (size > 0)
                {
                    sqlParameter.Size = size;
                }

                return sqlParameter;
            }

            return new SqlParameter();
        }

        public SqlParameter GetSqlParameterNullValue(string paramenterName, object value, SqlDbType Dbtype, int size = 0)
        {
            SqlParameter sqlParameter = new SqlParameter(paramenterName, value);

            sqlParameter.Value = DBNull.Value;
            if (!string.IsNullOrEmpty(paramenterName) && !string.IsNullOrEmpty(value?.ToString()))
            {
                sqlParameter.Value = value;
                if (size > 0)
                {
                    sqlParameter.Size = size;
                }

                return sqlParameter;
            }

            return sqlParameter;
        }

        public void OpenConnection()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                {
                    _dbConnection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
