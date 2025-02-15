using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Constants.EmployeeManagement
{
    public static class StoreProcedures
    {
        public static class EMPLOYEEINFORMATION_INSERT
        {
            public const string Name = "EMPLOYEEINFORMATION_INSERT";
            public static class Params
            {
                public const string EMPLOYEEREGID = "@EMPLOYEEREGID";
                public const string EMPLOYEEID = "@EMPLOYEEID";
                public const string EMPLOYEECODE = "@EMPLOYEECODE";
                public const string EMPLOYEENAME = "@EMPLOYEENAME";
                public const string FATHERNAME = "@FATHERNAME";
                public const string DATEOFBIRTH = "@DATEOFBIRTH";
                public const string CNIC = "@CNIC";
                public const string PROFILEPICPATH = "@PROFILEPICPATH";
                public const string FOLDERNAME = "@FOLDERNAME";
                public const string GENDERID = "@GENDERID";
                public const string MARITALSTATUSID = "@MARITALSTATUSID";
                public const string BLOODGROUPID = "@BLOODGROUPID";
                public const string NATIONALITY = "@NATIONALITY";
                public const string MOBILENO = "@MOBILENO";
                public const string EMAIL = "@EMAIL";
                public const string PERMANENTADDRESS = "@PERMANENTADDRESS";
                public const string CURRENTADDRESS = "@CURRENTADDRESS";
                public const string EMERGENCYCONTACTNAME = "@EMERGENCYCONTACTNAME";
                public const string EMERGENCYCONTACTRELATION = "@EMERGENCYCONTACTRELATION";
                public const string EMERGENCYCONTACTNUMBER = "@EMERGENCYCONTACTNUMBER";
                public const string DATEOFJOINING = "@DATEOFJOINING";
                public const string EMPLOYEETYPEID = "@EMPLOYEETYPEID";
                public const string EMPLOYEECATEGORYID = "@EMPLOYEECATEGORYID";
                public const string DESIGNATION = "@DESIGNATION";
                public const string DEPARTMENT = "@DEPARTMENT";
                public const string EMPLOYEESTATUSID = "@EMPLOYEESTATUSID";
                public const string HIGHESTQUALIFICATION = "@HIGHESTQUALIFICATION";
                public const string SPECIALIZATION = "@SPECIALIZATION"; 
                public const string CERTIFICATION = "@CERTIFICATION";
                public const string EXPERIENCE = "@EXPERIENCE";
                public const string BASICSALARY = "@BASICSALARY";
                public const string GROSSSALARY = "@GROSSSALARY";
                public const string BANKNAME = "@BANKNAME";
                public const string BRANCH = "@BRANCH";
                public const string ACCOUNTNUMBER = "@ACCOUNTNUMBER";
                public const string CREATEDBY = "@CREATEDBY";
                public const string CREATEDDATE = "@CREATEDDATE";
            }

        }

        public static class EMPLOYEEINFORMATION_UPDATE
        {
            public const string Name = "EMPLOYEEINFORMATION_UPDATE";
            public static class Params
            {
                public const string EMPLOYEEID = "@EMPLOYEEID";
                public const string EMPLOYEECODE = "@EMPLOYEECODE";
                public const string EMPLOYEENAME = "@EMPLOYEENAME";
                public const string FATHERNAME = "@FATHERNAME";
                public const string DATEOFBIRTH = "@DATEOFBIRTH";
                public const string CNIC = "@CNIC";
                public const string PROFILEPICPATH = "@PROFILEPICPATH";
                public const string FOLDERNAME = "@FOLDERNAME";
                public const string GENDERID = "@GENDERID";
                public const string MARITALSTATUSID = "@MARITALSTATUSID";
                public const string BLOODGROUPID = "@BLOODGROUPID";
                public const string NATIONALITY = "@NATIONALITY";
                public const string MOBILENO = "@MOBILENO";
                public const string EMAIL = "@EMAIL";
                public const string PERMANENTADDRESS = "@PERMANENTADDRESS";
                public const string CURRENTADDRESS = "@CURRENTADDRESS";
                public const string EMERGENCYCONTACTNAME = "@EMERGENCYCONTACTNAME";
                public const string EMERGENCYCONTACTRELATION = "@EMERGENCYCONTACTRELATION";
                public const string EMERGENCYCONTACTNUMBER = "@EMERGENCYCONTACTNUMBER";
                public const string DATEOFJOINING = "@DATEOFJOINING";
                public const string EMPLOYEETYPEID = "@EMPLOYEETYPEID";
                public const string EMPLOYEECATEGORYID = "@EMPLOYEECATEGORYID";
                public const string DESIGNATION = "@DESIGNATION";
                public const string DEPARTMENT = "@DEPARTMENT";
                public const string EMPLOYEESTATUSID = "@EMPLOYEESTATUSID";
                public const string HIGHESTQUALIFICATION = "@HIGHESTQUALIFICATION";
                public const string SPECIALIZATION = "@SPECIALIZATION";
                public const string CERTIFICATION = "@CERTIFICATION";
                public const string EXPERIENCE = "@EXPERIENCE";
                public const string BASICSALARY = "@BASICSALARY";
                public const string GROSSSALARY = "@GROSSSALARY";
                public const string BANKNAME = "@BANKNAME";
                public const string BRANCH = "@BRANCH";
                public const string ACCOUNTNUMBER = "@ACCOUNTNUMBER";
                public const string MODIFIEDBY = "@MODIFIEDBY";
                public const string MODIFIEDDATE = "@MODIFIEDDATE";
            }
        }

        public static class EMPLOYEEINFORMATION_GET
        {
            public const string Name = "EMPLOYEEINFORMATION_GET";
            public static class Params
            {
                public const string EMPLOYEECODE = "@EMPLOYEECODE";
                public const string CNIC = "@CNIC";
                public const string MOBILENUMBER = "@MOBILENUMBER";
                public const string DEPARTMENT = "@DEPARTMENT";
            }

        }
        public static class EMPLOYEEINFORMATION_DELETE
        {
            public const string Name = "EMPLOYEEINFORMATION_DELETE";
            public static class Params
            {
                public const string EMPLOYEEID = "@EMPLOYEEID";
            }
        }
        public static class MAXEMPLOYEECODE_GET
        {
            public const string Name = "MAXEMPLOYEECODE_GET";
        }
    }
}
