using Ryr.XrmToolBox.RecentItemsManager.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private RecentItemsHelper _recentItemsHelper;
        public MainControl()
        {
            InitializeComponent();
        }

        protected override void OnConnectionUpdated(ConnectionUpdatedEventArgs e)
        {
            base.OnConnectionUpdated(e);
            ExecuteMethod(LoadUsers);
        }

        private void LoadUsers()
        {
            userSelector1.Service = Service;
            userSelector1.LoadViews();
            _recentItemsHelper = new RecentItemsHelper(Service, ConnectionDetail);
            ClearPinLists();
            tsbRetrieveStats.Enabled = true;
            tsbRetrievePins.Enabled = true;
        }

        public void LoadSettings()
        {
            if (Service != null && userSelector1.Service == null)
            {
                userSelector1.Service = Service;
            }
            if (_recentItemsHelper == null)
            {
                _recentItemsHelper = new RecentItemsHelper(Service, ConnectionDetail);
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving MRU items...",
                AsyncArgument = userSelector1.SelectedItems,
                Work = (bw, e) =>
                {
                    var u = (List<Entity>) e.Argument;
                    e.Result = _recentItemsHelper.RetrieveRecentItemsForUsers(u);
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
        }

        private void TsbCloseClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbLoadCrmItems_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadUsers);
        }

        private void tsbRetrieveStats_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Calculating stats based on MRU items...",
                AsyncArgument = userSelector1.Items,
                Work = (bw, o) =>
                {
                    var ush = new RecentItemsHelper(Service, ConnectionDetail);
                    var u = (List<Entity>) o.Argument;
                    o.Result = ush.RetrieveRecentItemsForUsers(u);
                },
                PostWorkCallBack = o =>
                {
                    var allRecentItems = new List<RecentlyViewedItem>();
                    var recentItems = (List<KeyValuePair<EntityReference, List<RecentlyViewedItem>>>)o.Result;
                    recentItems.ForEach(x => allRecentItems.AddRange(x.Value));
                    new MRUStats(allRecentItems).Show();
                }
            });
        }

        public string RepositoryName => "Ryr.XrmToolBox.RecentItemsManager";
        public string UserName => "rajyraman";
        public string HelpUrl => "https://github.com/rajyraman/Ryr.XrmToolBox.RecentItemsManager/";

        private void tsbEditInFXB_Click(object sender, EventArgs e)
        {
            if (Service != null && userSelector1.Service == null)
            {
                userSelector1.Service = Service;
            }
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
                _recentItemsHelper = new RecentItemsHelper(Service, ConnectionDetail);
            }
            ClearPinLists();
            if (tsbRetrieveStats.Enabled)
            {
                tsbRetrieveStats.Enabled = true;
            }
            userSelector1.PopulateUsers(fetchXml);
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        private void recentItemsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var list = (ListView) sender;
            list.SelectedItems.Clear();
            list.Sorting = list.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            list.ListViewItemSorter = new ListViewItemComparer(e.Column, list.Sorting);
        }

        private void recordList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (recordList.SelectedItems.Count == 0) return;

            var selectedItem = (RecentlyViewedItem)recordList.SelectedItems[0].Tag;
            System.Diagnostics.Process.Start(
                selectedItem.DisplayName == "Dashboard"
                    ? $"{ConnectionDetail.WebApplicationUrl}workplace/home_dashboards.aspx?dashboardId={selectedItem.ObjectId}&{selectedItem.Action}"
                    : $"{ConnectionDetail.WebApplicationUrl}main.aspx?etc={selectedItem.EntityTypeCode}&id={selectedItem.ObjectId}&newWindow=true&pagetype=entityrecord");
        }

        private void viewList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (viewList.SelectedItems.Count == 0) return;

            var selectedItem = (RecentlyViewedItem)viewList.SelectedItems[0].Tag;
            System.Diagnostics.Process.Start(
                $"{ConnectionDetail.WebApplicationUrl}_root/homepage.aspx?etc={selectedItem.EntityTypeCode}&pagemode=iframe&viewid={selectedItem.ObjectId}&{selectedItem.Action}");

        }

        private void pinContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var toPinList = ((ContextMenuStrip) sender).SourceControl;
            if (toPinList.Name == "recordList")
            {
                PopulatePinListView(recordList, recordsPinList, e.ClickedItem.Text);
            }
            else
            {
                PopulatePinListView(viewList, viewPinList, e.ClickedItem.Text);
            }
        }

        private void PopulatePinListView(ListView sourceList, ListView targetList, string clickedOption)
        {
            if (sourceList.SelectedItems.Count == 0) return;

            foreach (ListViewItem record in sourceList.SelectedItems)
            {
                var pinItem = (RecentlyViewedItem) record.Tag;
                pinItem.PinStatus = clickedOption == "Pin" ? "Yes" : "No";
                var listItem = new ListViewItem
                {
                    Text = record.Text,
                    Tag = pinItem
                };
                listItem.SubItems.Add(record.SubItems[1]);
                listItem.SubItems.Add(pinItem.PinStatus);
                targetList.Items.Add(listItem);
            }
            targetList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            if(viewPinList.Items.Count > 0) viewPinList.Items.Clear();
            if (recordsPinList.Items.Count > 0) recordsPinList.Items.Clear();
        }

        private void tsbPin_Click(object sender, EventArgs ev)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating Pin status...",
                AsyncArgument = userSelector1.SelectedItems,
                Work = (bw, e) =>
                {
                    var u = (List<Entity>)e.Argument;
                    _recentItemsHelper.Pin(u, ListViewDelegates.GetItems(viewPinList));
                    _recentItemsHelper.Pin(u, ListViewDelegates.GetItems(recordsPinList));
                    ListViewDelegates.ClearColumns(recordsPinList);
                    ListViewDelegates.ClearColumns(viewPinList);
                    e.Result = "Completed";
                },
                PostWorkCallBack = e =>
                {
                    MessageBox.Show("Pin Status updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, "An error occured: " + e.Error.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        panel1.Enabled = true;
                        LoadSettings();
                    }
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });

        }

        private void ClearPinLists()
        {
            viewList.Items.Clear();
            viewPinList.Items.Clear();
            recordList.Items.Clear();
            recordsPinList.Items.Clear();
        }

        private void tsbRetrievePins_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}