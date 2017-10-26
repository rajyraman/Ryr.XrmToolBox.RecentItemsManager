using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ryr.XrmToolBox.RecentItemsManager.AppCode;

namespace Ryr.XrmToolBox.RecentItemsManager
{
    public partial class MRUStats : Form
    {
        private List<RecentlyViewedItem> _allRecentItems;
        private DateTime _startDate = DateTime.Today.AddMonths(-3);
        private DateTime _endDate = DateTime.Today;

        public MRUStats(List<RecentlyViewedItem> allRecentItems)
        {
            InitializeComponent();
            this._allRecentItems = allRecentItems;
            PopulateAllMRUList();
            PopulateRecentViewList();
            PopulateRecentDashboardList();
        }

        private void PopulateAllMRUList()
        {
            var items = (from a in _allRecentItems
                     where ((_startDate <= a.LastAccessed 
                     && a.LastAccessed <= _endDate) || 
                     a.PinStatus == "Yes") 
                     && string.IsNullOrEmpty(a.Action)
                group a by a.DisplayName into g
                orderby g.Count() descending
                select new
                {
                    g.Key,
                    Count = g.Count(),
                    LastAccessed = g.Max(x => x.LastAccessed)
                }
            ).Take(20);
            foreach (var item in items)
            {
                var row = new ListViewItem {Text = item.Key};
                row.SubItems.Add(item.Count.ToString());
                row.SubItems.Add(item.LastAccessed.ToString());
                recentItems.Items.Add(row);
            }
            recentItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void PopulateRecentViewList()
        {
            var items = (from a in _allRecentItems
                         where a.Type == RecentlyViewedType.View 
                         && ((_startDate <= a.LastAccessed 
                         && a.LastAccessed <= _endDate) 
                         || a.PinStatus == "Yes")
                    group a by new { a.ObjectId, a.Title } into g
                    orderby g.Count() descending
                    select new {
                        g.Key,
                        Count = g.Count(),
                        LastAccessed = g.Max(x => x.LastAccessed),
                        PinnedCount = g.Count(x => x.PinStatus == "Yes"),
                        NotPinnedCount = g.Count(x => x.PinStatus == "No") }
                ).Take(20);
            foreach (var item in items)
            {
                var row = new ListViewItem { Text = item.Key.Title };
                row.SubItems.Add(item.Count.ToString());
                row.SubItems.Add(item.LastAccessed.ToString());
                row.SubItems.Add(item.PinnedCount.ToString());
                row.SubItems.Add(item.NotPinnedCount.ToString());
                recentViews.Items.Add(row);
            }
            recentViews.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void PopulateRecentDashboardList()
        {
            var items = (from a in _allRecentItems
                where a.DisplayName == "Dashboard"
                      && ((_startDate <= a.LastAccessed
                           && a.LastAccessed <= _endDate)
                          || a.PinStatus == "Yes")
                group a by new { a.ObjectId, a.Title } into g
                orderby g.Count() descending
                select new
                {
                    g.Key,
                    Count = g.Count(),
                    LastAccessed = g.Max(x => x.LastAccessed),
                    PinnedCount = g.Count(x => x.PinStatus == "Yes"),
                    NotPinnedCount = g.Count(x => x.PinStatus == "No")
                }
            ).Take(20);
            foreach (var item in items)
            {
                var row = new ListViewItem { Text = item.Key.Title };
                row.SubItems.Add(item.Count.ToString());
                row.SubItems.Add(item.LastAccessed.ToString());
                row.SubItems.Add(item.PinnedCount.ToString());
                row.SubItems.Add(item.NotPinnedCount.ToString());
                recentDashboards.Items.Add(row);
            }
            recentDashboards.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
