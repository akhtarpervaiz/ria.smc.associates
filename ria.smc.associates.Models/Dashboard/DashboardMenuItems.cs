using ria.smc.associates.Common.CommonLayerHelper;

namespace ria.smc.associates.UI.Models
{
    public class DashboardMenuItems
    {
        public string MenuItemId { get; set; } = Guid.NewGuid().NewGuidId();
        public string ParentId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public string IsActiveItem { get; set; } = "";
        public string CreatedBy { get; set; }
        public decimal CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public decimal? ModifiedDate { get; set; }
    }
}
