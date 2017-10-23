using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Ryr.XrmToolBox.RecentItemsManager.AppCode;

namespace Ryr.XrmToolBox.RecentItemsManager
{
    internal class RecentItemsHelper
    {
        private IOrganizationService service;
        private ConnectionDetail detail;

        public RecentItemsHelper(IOrganizationService service, ConnectionDetail detail)
        {
            this.service = service;
            this.detail = detail;
        }

        public List<KeyValuePair<EntityReference, List<RecentlyViewedItem>>> RetrieveRecentItemsForUsers(List<Entity> users)
        {
            var result = new List<KeyValuePair<EntityReference, List<RecentlyViewedItem>>>();
            var currentUserId = detail.ServiceClient.OrganizationServiceProxy.CallerId;
            foreach (var user in users)
            {
                try
                {
                    detail.ServiceClient.OrganizationServiceProxy.CallerId = user.Id;
                    var records = detail.ServiceClient.OrganizationServiceProxy.RetrieveMultiple(
                        new FetchExpression($@"
                            <fetch distinct='false' no-lock='false' mapping='logical'>
                              <entity name='userentityuisettings'>
                                <attribute name='recentlyviewedxml' />
                                <attribute name='ownerid' />
                                <filter type='and'>
                                  <condition attribute='ownerid' operator='eq' value='{user.Id}' />
                                </filter>
                              </entity>
                            </fetch>")).Entities.ToList();
                    var userRecentlyViewedItems = records.Select(x =>
                    {
                        if (string.IsNullOrEmpty(x.GetAttributeValue<string>("recentlyviewedxml")))
                            return new KeyValuePair<EntityReference, List<RecentlyViewedItem>>(
                                x.GetAttributeValue<EntityReference>("ownerid"),
                                new List<RecentlyViewedItem>()
                            );
                        var recentlyViewedItemXml = XElement.Parse(x.GetAttributeValue<string>("recentlyviewedxml"));
                        var recentlyViewedItems = recentlyViewedItemXml.Descendants("RecentlyViewedItem");
                        var rvi = recentlyViewedItems.Select(r =>
                            new RecentlyViewedItem
                            {
                                Type = (RecentlyViewedType)int.Parse(r.Element("Type").Value),
                                ObjectId = Guid.TryParse(r.Element("ObjectId")?.Value, out Guid o) ? o : (Guid?)null,
                                EntityTypeCode = int.Parse(r.Element("EntityTypeCode").Value),
                                DisplayName = r.Element("DisplayName").Value == "System Form" ? "Dashboard" : r.Element("DisplayName").Value,
                                Title = r.Element("Title").Value,
                                Action = r.Element("Action").Value,
                                IconPath = r.Element("IconPath").Value,
                                PinStatus = bool.Parse(r.Element("PinStatus")?.Value) ? "Yes" : "No",
                                ProcessInstanceId = Guid.TryParse(r.Element("ProcessInstanceId")?.Value, out Guid pi) ? 
                                                    pi : (Guid?)null,
                                ProcessId = Guid.TryParse(r.Element("ProcessId")?.Value, out Guid p) ? 
                                            p : (Guid?)null,
                                LastAccessed = DateTime.Parse(r.Element("LastAccessed").Value, 
                                new CultureInfo("en-US", false)).ToLocalTime()
                            }).ToList();

                        return new KeyValuePair<EntityReference, List<RecentlyViewedItem>>(
                            x.GetAttributeValue<EntityReference>("ownerid"),
                            rvi
                            );
                    }).ToList();
                    result.AddRange(userRecentlyViewedItems);
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
            detail.ServiceClient.OrganizationServiceProxy.CallerId = currentUserId;
            return result;
        }
    }
}