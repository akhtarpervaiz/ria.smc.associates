using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.Models.MasterData
{
    public static class RIA_MasterData
    {
        public static List<Genders> Genders = new List<Genders>();
        public static List<BloodGroups> BloodGroups = new List<BloodGroups>();
        public static List<MaritalStatuses> MaritalStatuses = new List<MaritalStatuses>();
    }
    
    public class Genders
    {
        public string GenderId { get; set; }
        public string Gender { get; set; }
    }
    public class BloodGroups
    {
        public string BloodGroupId { get; set; }
        public string BloodGroup { get; set; }
    }
    public class MaritalStatuses
    {
        public string MaritalStatusId { get; set; }
        public string MaritalStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class EmployeeTypes
    {
        public string EmployeeTypeId { get; set; }
        public string EmployeeType { get; set; }
    }
    public class EmployeeStatuses
    {
        public string EmployeeStatusId { get; set; }
        public string EmployeeStatus { get; set; }
    }
}
