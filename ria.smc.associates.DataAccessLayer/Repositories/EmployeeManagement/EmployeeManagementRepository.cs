using Microsoft.Data.SqlClient;
using ria.smc.associates.Common.CommonLayerHelper;
using ria.smc.associates.Common.Constants;
using ria.smc.associates.DataAccessLayer.Common;
using ria.smc.associates.DataAccessLayer.Constants.EmployeeManagement;
using ria.smc.associates.DataAccessLayer.Interfaces.EmployeeManagement;
using ria.smc.associates.Models.EmployeeManagement;
using ria.smc.associatesDto.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Repositories.EmployeeManagement
{
    public class EmployeeManagementRepository : IEmployeeManagementRepository
    {
        private readonly IGenericRepository _genericRepository;

        public EmployeeManagementRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<int> InsertEmployeeInformation(EmployeeInformationDTO employeeInformationDTO)
        {
            int result = 0;
            SqlCommand command = null;

            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.EMPLOYEEINFORMATION_INSERT.Name, CommandType.StoredProcedure);
                var pEmployeeRegId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEEREGID, employeeInformationDTO.EmployeeRegId, SqlDbType.VarChar);
                var pEmployeeId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEEID, employeeInformationDTO.EmployeeId, SqlDbType.VarChar);
                var pEmployeeCode = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEECODE, employeeInformationDTO.EmployeeCode, SqlDbType.VarChar);
                var pEmployeeName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEENAME, employeeInformationDTO.EmployeeName, SqlDbType.VarChar);
                var pFatherName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.FATHERNAME, employeeInformationDTO.FatherName, SqlDbType.VarChar);
                var pDateOfBirth = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.DATEOFBIRTH, employeeInformationDTO.DateOfBirth.ToDecimalFromDate(), SqlDbType.Decimal);
                var pCnic = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.CNIC, employeeInformationDTO.Cnic, SqlDbType.VarChar);
                var pProfilePicPath = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.PROFILEPICPATH, employeeInformationDTO.ProfilePicPath, SqlDbType.VarChar);
                var pFolderName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.FOLDERNAME, employeeInformationDTO.FolderName, SqlDbType.VarChar);
                var pGenderId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.GENDERID, employeeInformationDTO.GenderId, SqlDbType.VarChar);
                var pMaritalStatusId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.MARITALSTATUSID, employeeInformationDTO.MaritalStatusId, SqlDbType.VarChar);
                var pBloodGroupId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.BLOODGROUPID, employeeInformationDTO.BloodGroupId, SqlDbType.VarChar);
                var pNationality = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.NATIONALITY, employeeInformationDTO.Nationality, SqlDbType.VarChar);
                var pMobileNo = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.MOBILENO, employeeInformationDTO.MobileNo, SqlDbType.VarChar);
                var pEmail = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMAIL, employeeInformationDTO.Email, SqlDbType.VarChar);
                var pPermanentAddress = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.PERMANENTADDRESS, employeeInformationDTO.PermanentAddress, SqlDbType.VarChar);
                var pCurrentAddress = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.CURRENTADDRESS, employeeInformationDTO.CurrentAddress, SqlDbType.VarChar);
                var pEmergencyContactName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMERGENCYCONTACTNAME, employeeInformationDTO.EmergencyContactName, SqlDbType.VarChar);
                var pEmergencyContactRelation = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMERGENCYCONTACTRELATION, employeeInformationDTO.EmergencyContactRelation, SqlDbType.VarChar);
                var pEmergencyContactNumber = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMERGENCYCONTACTNUMBER, employeeInformationDTO.EmergencyContactNumber, SqlDbType.VarChar);
                var pDateOfJoining = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.DATEOFJOINING, employeeInformationDTO.DateOfJoining.ToDecimalFromDate(), SqlDbType.Decimal);
                var pEmployeeTypeId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEETYPEID, employeeInformationDTO.EmployeeTypeId, SqlDbType.VarChar);
                var pEmployeeCategoryId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEECATEGORYID, employeeInformationDTO.EmployeeCategoryId, SqlDbType.VarChar);
                var pDesignation = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.DESIGNATION, employeeInformationDTO.Designation, SqlDbType.VarChar);
                var pDepartment = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.DEPARTMENT, employeeInformationDTO.Department, SqlDbType.VarChar);
                var pEmployeeStatusId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EMPLOYEESTATUSID, employeeInformationDTO.EmployeeStatusId, SqlDbType.VarChar);
                var pHighestQualification = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.HIGHESTQUALIFICATION, employeeInformationDTO.HighestQualification, SqlDbType.VarChar);
                var pSpecialization = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.SPECIALIZATION, employeeInformationDTO.Specialization, SqlDbType.VarChar);
                var pCertification = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.CERTIFICATION, employeeInformationDTO.Certification, SqlDbType.VarChar);
                var pExperience = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.EXPERIENCE, employeeInformationDTO.Experience, SqlDbType.VarChar);
                var pBasicSalary = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.BASICSALARY, employeeInformationDTO.BasicSalary, SqlDbType.Decimal);
                var pGrossSalary = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.GROSSSALARY, employeeInformationDTO.GrossSalary, SqlDbType.Decimal);
                var pBankName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.BANKNAME, employeeInformationDTO.BankName, SqlDbType.VarChar);
                var pBranch = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.BRANCH, employeeInformationDTO.Branch, SqlDbType.VarChar);
                var pAccountNumber = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.ACCOUNTNUMBER, employeeInformationDTO.AccountNumber, SqlDbType.VarChar);
                var pCreatedby = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.CREATEDBY, employeeInformationDTO.Createdby, SqlDbType.VarChar);
                var pCreatedDate = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_INSERT.Params.CREATEDDATE, employeeInformationDTO.CreatedDate.ToDecimalFromDate(), SqlDbType.Decimal);

                command.Parameters.AddRange(new[]
                {
                    pEmployeeRegId,
                    pEmployeeId,
                    pEmployeeCode,
                    pEmployeeName,
                    pFatherName,
                    pDateOfBirth,
                    pCnic,
                    pProfilePicPath,
                    pFolderName,
                    pGenderId,
                    pMaritalStatusId,
                    pBloodGroupId,
                    pNationality,
                    pMobileNo,
                    pEmail,
                    pPermanentAddress,
                    pCurrentAddress,
                    pEmergencyContactName,
                    pEmergencyContactRelation,
                    pEmergencyContactNumber,
                    pDateOfJoining,
                    pEmployeeTypeId,
                    pEmployeeCategoryId,
                    pDesignation,
                    pDepartment,
                    pEmployeeStatusId,
                    pHighestQualification,
                    pSpecialization,
                    pCertification,
                    pExperience,
                    pBasicSalary,
                    pGrossSalary,
                    pBankName,
                    pBranch,
                    pAccountNumber,
                    pCreatedby,
                    pCreatedDate

                });
                _genericRepository.OpenConnection();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _genericRepository.CloseConnection();
            }
            return result;
        }
        public async Task<List<EmployeeInformation>> GetEmployeeInformation(string? employeeCode, string? cnic, string? mobileNumber, string? department)
        {
            List<EmployeeInformation> employees = new List<EmployeeInformation>();
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.EMPLOYEEINFORMATION_GET.Name, CommandType.StoredProcedure);

                var pEmployeeCode = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_GET.Params.EMPLOYEECODE, employeeCode, SqlDbType.VarChar);
                var pCnic = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_GET.Params.CNIC, cnic, SqlDbType.VarChar);
                var pMobileNumber = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_GET.Params.MOBILENUMBER, mobileNumber, SqlDbType.VarChar);
                var pDepartment = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_GET.Params.DEPARTMENT, department, SqlDbType.VarChar);

                command.Parameters.AddRange
                    (new SqlParameter[]
                {
                    pEmployeeCode,
                    pCnic,
                    pMobileNumber,
                    pDepartment
                });
                _genericRepository.OpenConnection();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        int EMPLOYEEID = reader.GetOrdinal("EMPLOYEEID");
                        int EMPLOYEECODE = reader.GetOrdinal("EMPLOYEECODE");
                        int EMPLOYEENAME = reader.GetOrdinal("EMPLOYEENAME");
                        int FATHERNAME = reader.GetOrdinal("FATHERNAME");
                        int DATEOFBIRTH = reader.GetOrdinal("DATEOFBIRTH");
                        int CNIC = reader.GetOrdinal("CNIC");
                        int PROFILEPICPATH = reader.GetOrdinal("PROFILEPICPATH");
                        int FOLDERNAME = reader.GetOrdinal("FOLDERNAME");
                        int GENDER = reader.GetOrdinal("GENDER");
                        int GENDERID = reader.GetOrdinal("GENDERID");
                        int MARITALSTATUS = reader.GetOrdinal("MARITALSTATUS");
                        int MARITALSTATUSID = reader.GetOrdinal("MARITALSTATUSID");
                        int BLOODGROUP = reader.GetOrdinal("BLOODGROUP");
                        int BLOODGROUPID = reader.GetOrdinal("BLOODGROUPID");
                        int NATIONALITY = reader.GetOrdinal("NATIONALITY");
                        int MOBILENO = reader.GetOrdinal("MOBILENO");
                        int EMAIL = reader.GetOrdinal("EMAIL");
                        int PERMANENTADDRESS = reader.GetOrdinal("PERMANENTADDRESS");
                        int CURRENTADDRESS = reader.GetOrdinal("CURRENTADDRESS");
                        int EMERGENCYCONTACTNAME = reader.GetOrdinal("EMERGENCYCONTACTNAME");
                        int EMERGENCYCONTACTRELATION = reader.GetOrdinal("EMERGENCYCONTACTRELATION");
                        int EMERGENCYCONTACTNUMBER = reader.GetOrdinal("EMERGENCYCONTACTNUMBER");
                        int DATEOFJOINING = reader.GetOrdinal("DATEOFJOINING");
                        int EMPLOYEETYPE = reader.GetOrdinal("EMPLOYEETYPE");
                        int EMPLOYEETYPEID = reader.GetOrdinal("EMPLOYEETYPEID");

                        int DESIGNATION = reader.GetOrdinal("DESIGNATION");
                        int DEPARTMENT = reader.GetOrdinal("DEPARTMENT");
                        int EMPLOYEESTATUS = reader.GetOrdinal("EMPLOYEESTATUS");
                        int EMPLOYEESTATUSID = reader.GetOrdinal("EMPLOYEESTATUSID");
                        int HIGHESTQUALIFICATION = reader.GetOrdinal("HIGHESTQUALIFICATION");
                        int SPECIALIZATION = reader.GetOrdinal("SPECIALIZATION");
                        int CERTIFICATION = reader.GetOrdinal("CERTIFICATION");
                        int EXPERIENCE = reader.GetOrdinal("EXPERIENCE");
                        int BASICSALARY = reader.GetOrdinal("BASICSALARY");
                        int GROSSSALARY = reader.GetOrdinal("GROSSSALARY");
                        int BANKNAME = reader.GetOrdinal("BANKNAME");
                        int BRANCH = reader.GetOrdinal("BRANCH");
                        int ACCOUNTNUMBER = reader.GetOrdinal("ACCOUNTNUMBER");

                        while (reader.Read())
                        {
                            EmployeeInformation employeeInformation = new EmployeeInformation();
                            employeeInformation.EmployeeId = reader.GetString(EMPLOYEEID);
                            employeeInformation.EmployeeCode = reader.GetString(EMPLOYEECODE);
                            employeeInformation.EmployeeName = reader.GetString(EMPLOYEENAME);
                            employeeInformation.FatherName = reader.GetString(FATHERNAME);

                            employeeInformation.DateOfBirth = DateTime.ParseExact
                                    (
                                        reader.GetDecimal(DATEOFBIRTH).ToString(CultureInfo.InvariantCulture), "yyyyMMddHHmmss", CultureInfo.InvariantCulture
                                    );

                            employeeInformation.Cnic = reader.GetString(CNIC);
                            employeeInformation.ProfilePicPath = reader.GetString(PROFILEPICPATH);
                            employeeInformation.FolderName = reader.GetString(FOLDERNAME);
                            employeeInformation.Gender = reader.GetString(GENDER);
                            employeeInformation.GenderId = reader.GetString(GENDERID);
                            employeeInformation.MaritalStatus = reader.GetString(MARITALSTATUS);
                            employeeInformation.MaritalStatusId = reader.GetString(MARITALSTATUSID);
                            employeeInformation.BloodGroup = !reader.IsDBNull(BLOODGROUP) ? reader.GetString(BLOODGROUP) : string.Empty;
                            employeeInformation.BloodGroupId = !reader.IsDBNull(BLOODGROUPID) ? reader.GetString(BLOODGROUPID) : string.Empty;
                            employeeInformation.Nationality = reader.GetString(NATIONALITY);
                            employeeInformation.MobileNo = reader.GetString(MOBILENO);
                            employeeInformation.Email = !reader.IsDBNull(EMAIL) ? reader.GetString(EMAIL) : string.Empty;
                            employeeInformation.PermanentAddress = reader.GetString(PERMANENTADDRESS);
                            employeeInformation.CurrentAddress = reader.GetString(CURRENTADDRESS);
                            employeeInformation.EmergencyContactName = reader.GetString(EMERGENCYCONTACTNAME);
                            employeeInformation.EmergencyContactRelation = reader.GetString(EMERGENCYCONTACTRELATION);
                            employeeInformation.EmergencyContactNumber = reader.GetString(EMERGENCYCONTACTNUMBER);
                            employeeInformation.DateOfJoining = DateTime.ParseExact
                                    (
                                        reader.GetDecimal(DATEOFJOINING).ToString(CultureInfo.InvariantCulture), "yyyyMMddHHmmss", CultureInfo.InvariantCulture
                                    );
                            employeeInformation.EmployeeType = reader.GetString(EMPLOYEETYPE);
                            employeeInformation.EmployeeTypeId = reader.GetString(EMPLOYEETYPEID);

                            employeeInformation.Designation = reader.GetString(DESIGNATION);
                            employeeInformation.Department = reader.GetString(DEPARTMENT);
                            employeeInformation.EmployeeStatus = reader.GetString(EMPLOYEESTATUS);
                            employeeInformation.EmployeeStatusId = reader.GetString(EMPLOYEESTATUSID);
                            employeeInformation.HighestQualification = reader.GetString(HIGHESTQUALIFICATION);
                            employeeInformation.Specialization = !reader.IsDBNull(SPECIALIZATION) ? reader.GetString(SPECIALIZATION) : string.Empty;
                            employeeInformation.Certification = !reader.IsDBNull(CERTIFICATION) ? reader.GetString(CERTIFICATION) : string.Empty;
                            employeeInformation.Experience = !reader.IsDBNull(EXPERIENCE) ? reader.GetString(EXPERIENCE) : string.Empty;
                            employeeInformation.BasicSalary = reader.GetDecimal(BASICSALARY);
                            employeeInformation.GrossSalary = reader.GetDecimal(GROSSSALARY);
                            employeeInformation.BankName = reader.GetString(BANKNAME);
                            employeeInformation.Branch = reader.GetString(BRANCH);
                            employeeInformation.AccountNumber = reader.GetString(ACCOUNTNUMBER);
                            employeeInformation.RecordMode = RecordMode.Old;
                            employees.Add(employeeInformation);
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
            return employees;
        }
        public async Task<int> UpdateEmployeeInformation(EmployeeInformationDTO employeeInformationDTO)
        {
            int result = 0;
            SqlCommand command = null;

            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Name, CommandType.StoredProcedure);
                var pEmployeeId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMPLOYEEID, employeeInformationDTO.EmployeeId, SqlDbType.VarChar);
                var pEmployeeCode = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMPLOYEECODE, employeeInformationDTO.EmployeeCode, SqlDbType.VarChar);
                var pEmployeeName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMPLOYEENAME, employeeInformationDTO.EmployeeName, SqlDbType.VarChar);
                var pFatherName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.FATHERNAME, employeeInformationDTO.FatherName, SqlDbType.VarChar);
                var pDateOfBirth = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.DATEOFBIRTH, employeeInformationDTO.DateOfBirth.ToDecimalFromDate(), SqlDbType.Decimal);
                var pCnic = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.CNIC, employeeInformationDTO.Cnic, SqlDbType.VarChar);
                var pProfilePicPath = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.PROFILEPICPATH, employeeInformationDTO.ProfilePicPath, SqlDbType.VarChar);
                var pFolderName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.FOLDERNAME, employeeInformationDTO.FolderName, SqlDbType.VarChar);
                var pGenderId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.GENDERID, employeeInformationDTO.GenderId, SqlDbType.VarChar);
                var pMaritalStatusId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.MARITALSTATUSID, employeeInformationDTO.MaritalStatusId, SqlDbType.VarChar);
                var pBloodGroupId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.BLOODGROUPID, employeeInformationDTO.BloodGroupId, SqlDbType.VarChar);
                var pNationality = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.NATIONALITY, employeeInformationDTO.Nationality, SqlDbType.VarChar);
                var pMobileNo = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.MOBILENO, employeeInformationDTO.MobileNo, SqlDbType.VarChar);
                var pEmail = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMAIL, employeeInformationDTO.Email, SqlDbType.VarChar);
                var pPermanentAddress = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.PERMANENTADDRESS, employeeInformationDTO.PermanentAddress, SqlDbType.VarChar);
                var pCurrentAddress = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.CURRENTADDRESS, employeeInformationDTO.CurrentAddress, SqlDbType.VarChar);
                var pEmergencyContactName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMERGENCYCONTACTNAME, employeeInformationDTO.EmergencyContactName, SqlDbType.VarChar);
                var pEmergencyContactRelation = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMERGENCYCONTACTRELATION, employeeInformationDTO.EmergencyContactRelation, SqlDbType.VarChar);
                var pEmergencyContactNumber = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMERGENCYCONTACTNUMBER, employeeInformationDTO.EmergencyContactNumber, SqlDbType.VarChar);
                var pDateOfJoining = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.DATEOFJOINING, employeeInformationDTO.DateOfJoining.ToDecimalFromDate(), SqlDbType.Decimal);
                var pEmployeeTypeId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMPLOYEETYPEID, employeeInformationDTO.EmployeeTypeId, SqlDbType.VarChar);
                var pEmployeeCategoryId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMPLOYEECATEGORYID, employeeInformationDTO.EmployeeCategoryId, SqlDbType.VarChar);
                var pDesignation = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.DESIGNATION, employeeInformationDTO.Designation, SqlDbType.VarChar);
                var pDepartment = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.DEPARTMENT, employeeInformationDTO.Department, SqlDbType.VarChar);
                var pEmployeeStatusId = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EMPLOYEESTATUSID, employeeInformationDTO.EmployeeStatusId, SqlDbType.VarChar);
                var pHighestQualification = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.HIGHESTQUALIFICATION, employeeInformationDTO.HighestQualification, SqlDbType.VarChar);
                var pSpecialization = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.SPECIALIZATION, employeeInformationDTO.Specialization, SqlDbType.VarChar);
                var pCertification = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.CERTIFICATION, employeeInformationDTO.Certification, SqlDbType.VarChar);
                var pExperience = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.EXPERIENCE, employeeInformationDTO.Experience, SqlDbType.VarChar);
                var pBasicSalary = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.BASICSALARY, employeeInformationDTO.BasicSalary, SqlDbType.Decimal);
                var pGrossSalary = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.GROSSSALARY, employeeInformationDTO.GrossSalary, SqlDbType.Decimal);
                var pBankName = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.BANKNAME, employeeInformationDTO.BankName, SqlDbType.VarChar);
                var pBranch = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.BRANCH, employeeInformationDTO.Branch, SqlDbType.VarChar);
                var pAccountNumber = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.ACCOUNTNUMBER, employeeInformationDTO.AccountNumber, SqlDbType.VarChar);
                var pModifiedBy = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.MODIFIEDBY, employeeInformationDTO.ModifiedBy, SqlDbType.VarChar);
                var pModifiedDate = _genericRepository.GetSqlParameter
                    (StoreProcedures.EMPLOYEEINFORMATION_UPDATE.Params.MODIFIEDDATE, employeeInformationDTO.ModifiedDate?.ToDecimalFromDate(), SqlDbType.Decimal);

                command.Parameters.AddRange(new[]
                {
                    pEmployeeId,
                    pEmployeeCode,
                    pEmployeeName,
                    pFatherName,
                    pDateOfBirth,
                    pCnic,
                    pProfilePicPath,
                    pFolderName,
                    pGenderId,
                    pMaritalStatusId,
                    pBloodGroupId,
                    pNationality,
                    pMobileNo,
                    pEmail,
                    pPermanentAddress,
                    pCurrentAddress,
                    pEmergencyContactName,
                    pEmergencyContactRelation,
                    pEmergencyContactNumber,
                    pDateOfJoining,
                    pEmployeeTypeId,
                    pEmployeeCategoryId,
                    pDesignation,
                    pDepartment,
                    pEmployeeStatusId,
                    pHighestQualification,
                    pSpecialization,
                    pCertification,
                    pExperience,
                    pBasicSalary,
                    pGrossSalary,
                    pBankName,
                    pBranch,
                    pAccountNumber,
                    pModifiedBy,
                    pModifiedDate

                });
                _genericRepository.OpenConnection();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _genericRepository.CloseConnection();
            }
            return result;
        }
        public async Task<int> DeleteEmployeeInformation(string employeeId)
        {
            int result = 0;
            SqlCommand command = null;
            try
            {
                command = _genericRepository.GetCommand(StoreProcedures.EMPLOYEEINFORMATION_DELETE.Name, CommandType.StoredProcedure);
                var pEmployeeId = _genericRepository.GetSqlParameter(StoreProcedures.EMPLOYEEINFORMATION_DELETE.Params.EMPLOYEEID, employeeId, SqlDbType.VarChar);
                command.Parameters.Add(pEmployeeId);
                _genericRepository.OpenConnection();
                result = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _genericRepository.CloseConnection();
            }

            return result;
        }
        public string ValidateEmployeeInformation(EmployeeInformationDTO employeeInformationDTO)
        {
            if (employeeInformationDTO == null)
            {
                return "Employee information cannot be null.";
            }

            var requiredFields = new Dictionary<string, string>
    {
        { nameof(employeeInformationDTO.EmployeeName), "Employee name is required" },
        { nameof(employeeInformationDTO.FatherName), "Father name is required" },
        { nameof(employeeInformationDTO.Cnic), "CNIC is required" },
        { nameof(employeeInformationDTO.DateOfBirth), "Date of birth is required" },
        { nameof(employeeInformationDTO.GenderId), "Gender is required" },
        { nameof(employeeInformationDTO.MaritalStatusId), "Marital Status is required" },
        { nameof(employeeInformationDTO.Nationality), "Nationality is required" },
        { nameof(employeeInformationDTO.MobileNo), "Mobile Number is required" },
        { nameof(employeeInformationDTO.PermanentAddress), "Permanent address is required" },
        { nameof(employeeInformationDTO.CurrentAddress), "Current address is required" },
        { nameof(employeeInformationDTO.EmergencyContactName), "Emergency contact person name is required" },
        { nameof(employeeInformationDTO.EmergencyContactRelation), "Emergency contact person relation is required" },
        { nameof(employeeInformationDTO.EmergencyContactNumber), "Emergency contact person mobile number is required" },
        { nameof(employeeInformationDTO.DateOfJoining), "Date of joining is required" },
        { nameof(employeeInformationDTO.EmployeeTypeId), "Employee type is required" },
        { nameof(employeeInformationDTO.EmployeeCategoryId), "Employee category is required" },
        { nameof(employeeInformationDTO.Designation), "Designation is required" },
        { nameof(employeeInformationDTO.EmployeeStatusId), "Employee status is required" },
        { nameof(employeeInformationDTO.HighestQualification), "Highest qualification is required" },
        { nameof(employeeInformationDTO.BankName), "Bank name is required" },
        { nameof(employeeInformationDTO.Branch), "Branch is required" },
        { nameof(employeeInformationDTO.AccountNumber), "Account number is required" }
    };

            foreach (var field in requiredFields)
            {
                var property = typeof(EmployeeInformationDTO).GetProperty(field.Key);
                var value = property?.GetValue(employeeInformationDTO);

                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return field.Value;
                }
            }

            return string.Empty;
        }


    }
}
