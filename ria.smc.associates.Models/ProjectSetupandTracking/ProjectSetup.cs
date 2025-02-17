using ria.smc.associates.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.Models.ProjectSetupandTracking
{
    public class ProjectSetup
    {
        public string ProjectCode { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ProjectType { get; set; } = string.Empty;
        public string ProjectTypeId { get; set; } = string.Empty;
        public DateTime ProjectStartDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public string ProjectStaus { get; set; } = string.Empty;
        public string ProjectStausId { get; set; } = string.Empty;
        public string ProjectLocation { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public decimal EstimatedBudget { get; set; } = 0;
        public decimal AllocatedBudget { get; set; } = 0;
        public string FundingSource { get; set; } = string.Empty;
        public string FundingSourceId { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string CurrencyId { get; set; } = string.Empty;
        public string ProjectManager { get; set; } = string.Empty;
        public string ProjectManagerId { get; set; } = string.Empty;
        public string SiteSupervisor { get; set; } = string.Empty;
        public string SiteSupervisorId { get; set; } = string.Empty;
        public string MainContractorId { get; set; } = string.Empty;
        public string SubContractor { get; set; } = string.Empty;
        public string SubContractorId { get; set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;
        public string ApprovalStatusId { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
    }
}
