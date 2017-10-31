using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryr.XrmToolBox.RecentItemsManager.AppCode
{
    public enum RecentlyViewedType
    {
        Record,
        View
    }

    public class RecentlyViewedItem
    {
        public RecentlyViewedType Type { get; set; }
        public Guid ObjectId { get; set; }
        public int EntityTypeCode { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string IconPath { get; set; }
        public string PinStatus { get; set; }
        public Guid? ProcessInstanceId { get; set; }
        public Guid? ProcessId { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
