using Microsoft.AspNetCore.Http;
using ria.smc.associates.Common.CommonLayerHelper;
using ria.smc.associates.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associatesDto.ProjectSetupandTracking
{
    public class ProjectSetupDTO
    {
        public ProjectSetupDTO()
        {
            ProjectSetupId = Guid.NewGuid().NewGuidId();
            RecordMode = RecordMode.Added;
        }
        public string ProjectSetupId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string ProjectTypeId { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public string ProjectStausId { get; set; }
        public string ProjectLocation { get; set; }
        public string ProjectDescription { get; set; }
        public decimal EstimatedBudget { get; set; }
        public decimal AllocatedBudget { get; set; }
        public string FundingSourceId { get; set; }
        public string CurrencyId { get; set; }
        public string ProjectManagerId { get; set; }
        public string SiteSupervisorId { get; set; }
        public string MainContractorId { get; set; }
        public string SubContractorId { get; set; }
        public string ApprovalStatusId { get; set; }
        public string Remarks { get; set; }
        public IFormFile ProjectAttachment { get; set; }
        public RecordMode RecordMode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
