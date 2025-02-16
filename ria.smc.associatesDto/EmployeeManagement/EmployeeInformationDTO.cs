using Microsoft.AspNetCore.Http;
using ria.smc.associates.Common.CommonLayerHelper;
using ria.smc.associates.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associatesDto.EmployeeManagement
{
    public class EmployeeInformationDTO
    {
        public EmployeeInformationDTO()
        {
            EmployeeId =  Guid.NewGuid().NewGuidId();
            EmployeeRegId =  Guid.NewGuid().NewGuidId();
            RecordMode = RecordMode.Added;
        }
        public string EmployeeRegId { get; set; } 
        public string EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Cnic { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string? ProfilePicPath { get; set; }
        public string? FolderName { get; set; }
        public string GenderId { get; set; }
        public string MaritalStatusId { get; set; }
        public string BloodGroupId { get; set; }
        public string Nationality { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string EmergencyContactNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string EmployeeTypeId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string EmployeeStatusId { get; set; }
        public string EmployeeCategoryId { get; set; }
        public string HighestQualification { get; set; }
        public string Specialization { get; set; }
        public string Certification { get; set; }
        public string Experience { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal GrossSalary { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public RecordMode RecordMode { get; set; }
    }
}
