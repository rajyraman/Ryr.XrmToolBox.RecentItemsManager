using Ryr.XrmToolBox.RecentItemsManager.AppCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using ComboBox = System.Windows.Forms.ComboBox;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using View = System.Web.UI.WebControls.View;

namespace Ryr.XrmToolBox.RecentItemsManager
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin, IHelpPlugin, IMessageBusHost
    {
        private const string ACTIVE_USERS_FETCH = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' ><entity name='systemuser' ><attribute name='fullname' /><order attribute='fullname' descending='false' /><attribute name='businessunitid' /><attribute name='siteid' /><filter type='and' ><condition attribute='isdisabled' operator='eq' value='0' /><condition attribute='accessmode' operator='ne' value='3' /></filter><attribute name='systemuserid' /></entity></fetch>";
        private int recentRecordsColumnOrder;
        private int recentViewsColumnOrder;
        public MainControl()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            userSelector1.Service = Service;
            userSelector1.LoadViews();
        }

        public void LoadSettings()
        {
            var ush = new RecentItemsHelper(Service, ConnectionDetail);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing...",
                AsyncArgument = userSelector1.SelectedItems,
                Work = (bw, e) =>
                {
                    var u = (List<Entity>) e.Argument;
                    e.Result = ush.RetrieveRecentItemsForUsers(u);
                },
                PostWorkCallBack = e =>
                {
                    var recentItems = (List<KeyValuePair<EntityReference, List<RecentlyViewedItem>>>)e.Result;
                    var recentRecords = recentItems.Select(x => x.Value.Where(y => y.Type == RecentlyViewedType.Record).ToList()).ToList();
                    PopulateListView(recentRecords, recordList);

                    var recentViews = recentItems.Select(x => x.Value.Where(y => y.Type == RecentlyViewedType.View).ToList()).ToList();
                    PopulateListView(recentViews, viewList);
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, "An error occured: " + e.Error.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        panel1.Enabled = true;
                    }
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void PopulateListView(List<List<RecentlyViewedItem>> recentlyViewedItems, ListView control)
        {
            control.Items.Clear();
            var result = new List<RecentlyViewedItem>();
            foreach (var recentlyViewedItem in recentlyViewedItems)
            {
                result.AddRange(recentlyViewedItem);
            }
            foreach (var r in result.OrderByDescending(x => x.LastAccessed))
            {
                var row = new ListViewItem {Text = r.DisplayName, Tag = r};
                row.SubItems.Add(r.Title);
                row.SubItems.Add(r.LastAccessed.ToString());
                row.SubItems.Add(r.PinStatus);
                control.Items.Add(row);
            }
            control.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void TsbCloseClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbLoadCrmItems_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadUsers);
        }

        private void tsbUpdateUserSettings_Click(object sender, EventArgs e)
        {
            if (userSelector1.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "No user has been selected!", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing update...",
                AsyncArgument = new Tuple<List<Entity>, Entity>(userSelector1.SelectedItems, null),
                Work = (bw, evt) =>
                {
                    var updateUserSettings = (Tuple<List<Entity>, Entity>)evt.Argument;

                    foreach (var updateUserSetting in updateUserSettings.Item1)
                    {
                        bw.ReportProgress(0, "Updating settings for user " + updateUserSetting.GetAttributeValue<string>("fullname"));
                    }
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, "An error occured: " + evt.Error.ToString(), "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                },
                ProgressChanged = evt => { SetWorkingMessage(evt.UserState.ToString()); }
            });
        }

        public void LoadCurrentUserSetting(Entity settings)
        {
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
        }

        public string RepositoryName => "Ryr.XrmToolBox.RecentItemsManager";
        public string UserName => "rajyraman";
        public string HelpUrl => "https://github.com/MscrmTools/Ryr.XrmToolBox.RecentItemsManager/wiki";

        private void tsbEditInFXB_Click(object sender, EventArgs e)
        {
            if (Service != null && userSelector1.Service == null)
            {
                userSelector1.Service = Service;
            }
            ExecuteMethod(LoadSettings);
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder");
            var fetchXml = (((ComboBox)userSelector1.Controls.Find("cbbViews", true)?[0]).SelectedItem as ViewItem)?.FetchXml;
            messageBusEventArgs.TargetArgument = fetchXml ?? ACTIVE_USERS_FETCH;
            OnOutgoingMessage(this, messageBusEventArgs);
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin != "FetchXML Builder") return;

            var fetchXml = (string)message.TargetArgument;
            if (Service != null && userSelector1.Service == null)
            {
                userSelector1.Service = Service;
            }
            userSelector1.PopulateUsers(fetchXml);
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        private void recordList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == recentRecordsColumnOrder)
            {
                recordList.Sorting = recordList.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                recordList.ListViewItemSorter = new ListViewItemComparer(e.Column, recordList.Sorting);
            }
            else
            {
                recentRecordsColumnOrder = e.Column;
                recordList.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void viewList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == recentViewsColumnOrder)
            {
                viewList.Sorting = recordList.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                viewList.ListViewItemSorter = new ListViewItemComparer(e.Column, viewList.Sorting);
            }
            else
            {
                recentViewsColumnOrder = e.Column;
                viewList.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void recordList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (recordList.SelectedItems.Count == 0) return;

            var selectedItem = (RecentlyViewedItem)recordList.SelectedItems[0].Tag;
            if (selectedItem.DisplayName == "Dashboard")
            {
                System.Diagnostics.Process.Start(
                    $"{ConnectionDetail.WebApplicationUrl}workplace/home_dashboards.aspx?dashboardId={selectedItem.ObjectId}&{selectedItem.Action}");
            }
            else
            {
                System.Diagnostics.Process.Start(
                    $"{ConnectionDetail.WebApplicationUrl}main.aspx?etc={selectedItem.EntityTypeCode}&id={selectedItem.ObjectId}&newWindow=true&pagetype=entityrecord");
            }
        }

        private void viewList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (viewList.SelectedItems.Count == 0) return;

            var selectedItem = (RecentlyViewedItem)viewList.SelectedItems[0].Tag;
            System.Diagnostics.Process.Start(
                $"{ConnectionDetail.WebApplicationUrl}_root/homepage.aspx?etc={selectedItem.EntityTypeCode}&pagemode=iframe&viewid={selectedItem.ObjectId}&{selectedItem.Action}");

        }
    }
}