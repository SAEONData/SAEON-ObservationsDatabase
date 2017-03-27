﻿using SAEON.Observations.Core;
using SAEON.Observations.QuerySite.Models;
using Syncfusion.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SAEON.Observations.QuerySite.Controllers
{
    [Authorize]
    public class QueryController : BaseWebApiController
    {

        public QueryController() : base()
        {
            using (Logging.MethodCall(this.GetType()))
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (Logging.MethodCall(this.GetType()))
            {
                base.Dispose(disposing);
            }
        }

        private QueryModel SessionModel
        {
            get
            {
                return GetSessionModel<QueryModel>();
            }
            set
            {
                SetSessionModel<QueryModel>(value);
            }
        }

        // GET: Query
        public async Task<ActionResult> Index()
        {
            using (Logging.MethodCall(this.GetType()))
            {
                var model = SessionModel;
                if (model.Locations == null)
                {
                    model.Locations = await GetLocations();
                }
                if (model.Features == null)
                {
                    model.Features = await GetFeatures();
                }
                SessionModel = model;
                Logging.Verbose("Model: {@model}", model);
                return View("Features", model);
            }
        }

        [HttpGet]
        public ActionResult Locations()
        {
            using (Logging.MethodCall(this.GetType()))
            {
                return View(SessionModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationsPost(QueryModel data)
        {
            using (Logging.MethodCall<QueryModel>(this.GetType()))
            {
                RedirectToAction("Features");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Features()
        {
            using (Logging.MethodCall(this.GetType()))
            {
                return View(SessionModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FeaturesPost(QueryModel data)
        {
            using (Logging.MethodCall<QueryModel>(this.GetType()))
            {
                RedirectToAction("TimeFrame");
                return View();
            }
        }

        public PartialViewResult UpdateSelectedFeatures(List<string> features)
        {
            using (Logging.MethodCall(this.GetType()))
            {
                try
                {
                    Logging.Verbose("SelectedFeatures: {features}", features);
                    var model = SessionModel;
                    var selectedFeatures = new List<Feature>();
                    if (features != null)
                    {
                        // Set IsCheck for all
                        foreach (var feature in model.Features.Where(i => features.Contains(i.Key)))
                        {
                            feature.IsChecked = true;
                        }
                        // Only select offerings
                        var offerings = features.Where(l => l.StartsWith("OFF~")).ToList();
                        Logging.Verbose("SelectedOfferings: {offerings}", offerings);
                        selectedFeatures = model.Features.Where(l => offerings.Contains(l.Key)).OrderBy(l => l.Text).ToList();
                    }
                    Logging.Verbose("SelectedFeatures: {@features}", selectedFeatures);
                    model.SelectedFeatures = selectedFeatures;
                    SessionModel = model;
                    Logging.Verbose("Model: {@model}", model);
                    return PartialView("SelectedFeaturesPost", model);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        public PartialViewResult UpdateSelectedLocations(List<string> locations)
        {
            using (Logging.MethodCall(this.GetType()))
            {
                try
                {
                    Logging.Verbose("SelectedLocations: {locations}", locations);
                    var model = SessionModel;
                    var selectedLocations = new List<Location>();
                    if (locations != null)
                    {
                        // Set IsCheck for all
                        foreach (var location in model.Locations.Where(i => locations.Contains(i.Key)))
                        {
                            location.IsChecked = true;
                        }
                        // Only select stations
                        var stations = locations.Where(l => l.StartsWith("STA~")).ToList();
                        Logging.Verbose("SelectedStations: {stations}", stations);
                        selectedLocations = model.Locations.Where(l => stations.Contains(l.Key)).OrderBy(l => l.Name).ToList();
                    }
                    Logging.Verbose("SelectedLocations: {@locations}", selectedLocations);
                    model.SelectedLocations = selectedLocations;
                    SessionModel = model;
                    Logging.Verbose("Model: {@model}", model);
                    return PartialView("SelectedLocationsPost", model);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        protected async Task<List<Feature>> GetFeatures()
        {
            return (await GetList<Feature>("Features")).ToList();
        }

        protected async Task<List<Location>> GetLocations()
        {
            return (await GetList<Location>("Locations")).ToList();
        }

    }
}