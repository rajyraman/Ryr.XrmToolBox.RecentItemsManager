using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Windows.Forms;
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
        private List<Entity> _recentlyViewedRecords;

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
                    _recentlyViewedRecords = detail.ServiceClient.OrganizationServiceProxy.RetrieveMultiple(
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
                    var userRecentlyViewedItems = _recentlyViewedRecords.Select(x =>
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
                                ObjectId = Guid.TryParse(r.Element("ObjectId")?.Value, out Guid o) ? 
                                           o : (Guid?)null,
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

        public void Pin(List<Entity> users, ListViewItem[] recordPin)
        {
            var groupedPinItems = recordPin.Select(x => (RecentlyViewedItem)x.Tag)
                                    .GroupBy(x=>x.EntityTypeCode)
                                    .ToList();
            var pinElements = recordPin.Select(x =>
            {
                var item = (RecentlyViewedItem) x.Tag;
                var pinStatus = item.PinStatus == "Yes" ? "true" : "false";
                var entityName = item.DisplayName == "Dashboard" ? "System Form" : item.DisplayName;
                var xml = $@"<RecentlyViewedItem><Type>{(int)item.Type}</Type><ObjectId>{item.ObjectId:B}</ObjectId><EntityTypeCode>{item.EntityTypeCode}</EntityTypeCode><DisplayName>{entityName}</DisplayName><Title>{item.Title}</Title><Action>{HttpUtility.HtmlEncode(item.Action)}</Action><IconPath>{item.IconPath}</IconPath><PinStatus>{pinStatus}</PinStatus><ProcessInstanceId>{item.ProcessInstanceId}</ProcessInstanceId><ProcessId>{item.ProcessId}</ProcessId><LastAccessed>{DateTime.UtcNow.ToString("M/d/yyyy HH:mm:ss")}</LastAccessed></RecentlyViewedItem>";
                return new
                {
                    RecentItem = item,
                    RecentItemXml = xml
                };
            })
            .GroupBy(x=>x.RecentItem.EntityTypeCode)
            .ToList();
            var currentUserId = detail.ServiceClient.OrganizationServiceProxy.CallerId;
            var recentlyViewedXml = _recentlyViewedRecords.Select(x =>
            {
                var xml = x.GetAttributeValue<string>("recentlyviewedxml") ??
                                      "<RecentlyViewedEntityData etc=''></RecentlyViewedEntityData>";
                return new
                {
                    x.Id,
                    OwnerId = x.GetAttributeValue<EntityReference>("ownerid").Id,
                    RecentlyViewedXml = xml,
                    RecentlyViewedXmlElements = XElement.Parse(xml).Elements()
                };
            }).ToList();
            foreach (var user in users)
            {
                detail.ServiceClient.OrganizationServiceProxy.CallerId = user.Id;
                var recentXmlForUser = recentlyViewedXml.Where(x => x.OwnerId == user.Id);
                foreach (var groupedPinItem in groupedPinItems)
                {
                    foreach (var pinItem in groupedPinItem)
                    {
                        var pinStatus = pinItem.PinStatus == "Yes" ? "true" : "false";
                        var matchedXml = recentXmlForUser.FirstOrDefault(x =>
                            x.RecentlyViewedXmlElements.Any(y => y.Element("ObjectId").Value.Equals(pinItem.ObjectId?.ToString("B"),
                            StringComparison.CurrentCultureIgnoreCase)));
                        var pin = new Entity("userentityuisettings")
                        {
                            ["ownerid"] = user.ToEntityReference()
                        };
                        if (matchedXml != null)
                        {
                            var f = matchedXml.RecentlyViewedXmlElements.First(x =>
                                x.Element("ObjectId").Value.Equals(pinItem.ObjectId?.ToString("B"),
                                StringComparison.CurrentCultureIgnoreCase));
                            f.Element("PinStatus").Value = pinStatus;
                            pin["recentlyviewedxml"] = $@"<RecentlyViewedEntityData etc=""{pinItem.EntityTypeCode}"">{string.Join("", matchedXml.RecentlyViewedXmlElements)}</RecentlyViewedEntityData>";
                            pin.Id = matchedXml.Id;
                            detail.ServiceClient.OrganizationServiceProxy.Update(pin);
                        }
                        else
                        {
                            matchedXml = recentXmlForUser.FirstOrDefault(x =>
                                XElement.Parse(x.RecentlyViewedXml).Attribute("etc").Value.Equals(pinItem.EntityTypeCode.ToString(),
                                    StringComparison.CurrentCultureIgnoreCase));
                            var newPinXml = string.Join("",
                                pinElements.Where(x => x.Key == groupedPinItem.Key)
                                    .Select(x => string.Join("", x.Select(y => y.RecentItemXml))));
                            if (matchedXml == null)
                            {
                                var itemToPin = new Entity("userentityuisettings")
                                {
                                    ["ownerid"] = user.ToEntityReference(),
                                    ["recentlyviewedxml"] = $@"<RecentlyViewedEntityData etc=""{groupedPinItem.Key}"">{newPinXml}</RecentlyViewedEntityData>"
                                };
                                detail.ServiceClient.OrganizationServiceProxy.Create(itemToPin);
                            }
                            else
                            {
                                pin["recentlyviewedxml"] = $@"<RecentlyViewedEntityData etc=""{pinItem.EntityTypeCode}"">{newPinXml}{string.Join("", matchedXml.RecentlyViewedXmlElements)}</RecentlyViewedEntityData>";
                                pin.Id = matchedXml.Id;
                                detail.ServiceClient.OrganizationServiceProxy.Update(pin);
                            }
                        }
                    }
                }
                detail.ServiceClient.OrganizationServiceProxy.CallerId = currentUserId;
            }
        }
    }
}