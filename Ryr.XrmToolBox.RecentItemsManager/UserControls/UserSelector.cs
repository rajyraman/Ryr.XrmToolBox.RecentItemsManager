﻿using Microsoft.Xrm.Sdk;
using Ryr.XrmToolBox.RecentItemsManager.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk.Query;

namespace Ryr.XrmToolBox.RecentItemsManager.UserControls
{
    public partial class UserSelector : UserControl
    {
        private int currentColumnOrder;
        private IOrganizationService service;

        public UserSelector()
        {
            InitializeComponent();
        }

        public List<Entity> SelectedItems
        {
            get { return lvUsers.SelectedItems.Cast<ListViewItem>().Select(e => (Entity)e.Tag).ToList(); }
        }
        public List<Entity> Items
        {
            get { return lvUsers.Items.Cast<ListViewItem>().Select(e => (Entity)e.Tag).ToList(); }
        }
        public IOrganizationService Service
        {
            set
            {
                service = value;
                if (service != null)
                {
                    LoadViews();
                }
            }
            get { return service; }
        }

        public void LoadViews()
        {
            if (service == null)
            {
                throw new Exception("IOrganization service is not initialized for this control");
            }

            var vManager = new ViewManager(service);
            lvUsers.Columns.Clear();

            List<ViewItem> items = vManager.RetrieveViews("systemuser");

            lvUsers.Columns.AddRange(new[]
            {
                new ColumnHeader {Text = "Last name", Width = 150},
                new ColumnHeader {Text = "First name", Width = 150},
                new ColumnHeader {Text = "Business unit", Width = 150}
            });

            if (items != null)
            {
                cbbViews.SelectedIndexChanged -= cbbViews_SelectedIndexChanged;
                cbbViews.Items.Clear();
                cbbViews.Items.AddRange(items.ToArray());
                cbbViews.SelectedIndexChanged += cbbViews_SelectedIndexChanged;
                cbbViews.SelectedIndex = 0;
            }
        }

        private void cbbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            var viewItem = (ViewItem)cbbViews.SelectedItem;
            PopulateUsers(viewItem.FetchXml);
        }

        public void PopulateUsers(string fetchXml)
        {
            lvUsers.Items.Clear();
            var entity = QueryHelper.GetItems(fetchXml, service);

            if (entity.EntityName == "systemuser")
            {
                lvUsers.Items.AddRange(entity.Entities.ToList()
                    .Select(record => new ListViewItem
                    {
                        Text = record.GetAttributeValue<string>("lastname"),
                        ImageIndex = 0,
                        StateImageIndex = 0,
                        Tag = record,
                        SubItems =
                        {
                            record.GetAttributeValue<string>("firstname"),
                            record.GetAttributeValue<EntityReference>("businessunitid").Name
                        }
                    })
                    .ToArray());
            }
            else if (entity.EntityName == "team")
            {
                lvUsers.Items.AddRange(entity.Entities.ToList()
                    .Select(record => new ListViewItem
                    {
                        Text = record.GetAttributeValue<string>("name"),
                        ImageIndex = 1,
                        StateImageIndex = 1,
                        Tag = record,
                        SubItems =
                        {
                            record.GetAttributeValue<EntityReference>("businessunitid").Name
                        }
                    })
                    .ToArray());
            }
        }

        private void llCheckAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvUsers.Items)
            {
                item.Checked = true;
            }
        }

        private void llCheckNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvUsers.Items)
            {
                item.Checked = false;
            }
        }

        private void llInvertSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (ListViewItem item in lvUsers.Items)
            {
                item.Checked = !item.Checked;
            }
        }

        private void lvUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == currentColumnOrder)
            {
                lvUsers.Sorting = lvUsers.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                lvUsers.ListViewItemSorter = new ListViewItemComparer(e.Column, lvUsers.Sorting);
            }
            else
            {
                currentColumnOrder = e.Column;
                lvUsers.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void lvUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ((MainControl)this.Parent.Parent.Parent).LoadSettings();
        }
    }
}