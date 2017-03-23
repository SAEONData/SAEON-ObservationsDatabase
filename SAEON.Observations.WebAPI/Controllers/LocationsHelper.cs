﻿using SAEON.Observations.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SAEON.Observations.WebAPI.Controllers
{
    public static class LocationsHelper
    {
        public static IQueryable<Location> GetLocations(ObservationsDbContext db)
        {
            using (Logging.MethodCall<Location>(typeof(LocationsHelper)))
            {
                try
                {
                    var result = new List<Location>();
                    foreach (var organisation in db.Organisations
                        .Include(i => i.Sites.Select(s => s.Stations))
                        //.Where(i => i.HasSites && i.Sites.Any(s => s.HasStations))
                        .OrderBy(i => i.Name))
                    {
                        var organisationNode = new Location
                        {
                            Id = organisation.Id,
                            Key = $"|ORG|{organisation.Id}|",
                            Text = organisation.Name,
                            HasChildren = organisation.HasSites
                        };
                        result.Add(organisationNode);
                        foreach (var site in organisation.Sites/*.Where(i => i.HasStations)*/.OrderBy(i => i.Name))
                        {
                            var siteNode = new Location
                            {
                                Id = site.Id,
                                ParentId = organisationNode.Id,
                                Key = $"|SIT|{site.Id}{organisationNode.Key}",
                                ParentKey = organisationNode.Key,
                                Text = site.Name,
                                HasChildren = site.HasStations
                            };
                            result.Add(siteNode);
                            foreach (var station in site.Stations.OrderBy(i => i.Name))
                            {
                                var stationNode = new Location
                                {
                                    Id = station.Id,
                                    ParentId = siteNode.Id,
                                    Key = $"|STA|{station.Id}{siteNode.Key}",
                                    ParentKey = siteNode.Key,
                                    Text = station.Name,
                                    Name = $"{site.Name} - {station.Name}",
                                    HasChildren = false
                                };
                                result.Add(stationNode);
                            }
                        }
                    }
                    return result.AsQueryable();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex, "Unable to get Locations");
                    throw;
                }
            }
        }

    }
}