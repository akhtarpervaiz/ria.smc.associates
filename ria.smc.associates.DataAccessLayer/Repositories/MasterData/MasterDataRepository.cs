using Microsoft.Data.SqlClient;
using ria.smc.associates.DataAccessLayer.Common;
using ria.smc.associates.DataAccessLayer.Constants.MasterData;
using ria.smc.associates.DataAccessLayer.Interfaces.MasterData;
using ria.smc.associates.Models.MasterData;
using ria.smc.associates.UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Repositories.MasterData
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly IGenericRepository _genericRepository;

        public MasterDataRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<BloodGroups>> GetBloodGroups()
        {
            List<BloodGroups> bloodGroups = new List<BloodGroups>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.BLOODGROUP_GET.Name, CommandType.StoredProcedure);
                _genericRepository.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int BLOODGROUPID = reader.GetOrdinal("BLOODGROUPID");
                        int BLOODGROUP = reader.GetOrdinal("BLOODGROUP");
                        
                        while (reader.Read())
                        {
                            BloodGroups bloodGroup = new BloodGroups();
                            bloodGroup.BloodGroupId = reader.GetString(BLOODGROUPID);
                            bloodGroup.BloodGroup = reader.GetString(BLOODGROUP);
                            bloodGroups.Add(bloodGroup);
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
            return bloodGroups;
        }

        public async Task<List<Genders>> GetGenders()
        {
            List<Genders> genders = new List<Genders>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.GENDER_GET.Name, CommandType.StoredProcedure);
                _genericRepository.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int GENDERID = reader.GetOrdinal("GENDERID");
                        int GENDER = reader.GetOrdinal("GENDER");

                        while (reader.Read())
                        {
                            Genders gender = new Genders();
                            gender.GenderId = reader.GetString(GENDERID);
                            gender.Gender = reader.GetString(GENDER);
                            genders.Add(gender);
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
            return genders;
        }

        public async Task<List<MaritalStatuses>> GetMaritalStatus()
        {
            List<MaritalStatuses> maritalStatuses = new List<MaritalStatuses>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.MARITALSTATUS_GET.Name, CommandType.StoredProcedure);
                _genericRepository.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int MARITALSTATUSID = reader.GetOrdinal("MARITALSTATUSID");
                        int MARITALSTATUS = reader.GetOrdinal("MARITALSTATUS");

                        while (reader.Read())
                        {
                            MaritalStatuses maritalStatus = new MaritalStatuses();
                            maritalStatus.MaritalStatusId = reader.GetString(MARITALSTATUSID);
                            maritalStatus.MaritalStatus = reader.GetString(MARITALSTATUS);
                            maritalStatuses.Add(maritalStatus);
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
            return maritalStatuses;
        }

        public async Task<List<EmployeeStatuses>> GetEmployeeStatuses()
        {
            List<EmployeeStatuses> employeeStatuses = new List<EmployeeStatuses>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.EMPLOYEESTATUES_GET.Name, CommandType.StoredProcedure);
                _genericRepository.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int EMPLOYEESTATUSID = reader.GetOrdinal("EMPLOYEESTATUSID");
                        int EMPLOYEESTATUS = reader.GetOrdinal("EMPLOYEESTATUS");

                        while (reader.Read())
                        {
                            EmployeeStatuses employeeStatus = new EmployeeStatuses();
                            employeeStatus.EmployeeStatusId = reader.GetString(EMPLOYEESTATUSID);
                            employeeStatus.EmployeeStatus = reader.GetString(EMPLOYEESTATUS);
                            employeeStatuses.Add(employeeStatus);
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
            return employeeStatuses;
        }

        public async Task<List<EmployeeTypes>> GetEmployeeTypes()
        {
            List<EmployeeTypes> employeeTypes = new List<EmployeeTypes>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.EMPLOYEETYPES_GET.Name, CommandType.StoredProcedure);
                _genericRepository.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader?.HasRows == true)
                    {
                        int EMPLOYEETYPEID = reader.GetOrdinal("EMPLOYEETYPEID");
                        int EMPLOYEETYPE = reader.GetOrdinal("EMPLOYEETYPE");

                        while (reader.Read())
                        {
                            EmployeeTypes employeeType = new EmployeeTypes();
                            employeeType.EmployeeTypeId = reader.GetString(EMPLOYEETYPEID);
                            employeeType.EmployeeType = reader.GetString(EMPLOYEETYPE);
                            employeeTypes.Add(employeeType);
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
            return employeeTypes;
        }
    }
}
