﻿using SAEON.Logs;
using SAEON.Observations.Core;
using SAEON.Observations.WebAPI.Controllers.SensorThingsAPI;
using System;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SAEON.Observations.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Logging
                 .CreateConfiguration(HostingEnvironment.MapPath(@"~/App_Data/Logs/SAEON.Observations.WebAPI {Date}.txt"))
                 .Create();
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    Logging.Verbose("Starting application");
                    BootStrapper.Initialize();
                    AreaRegistration.RegisterAllAreas();
                    GlobalConfiguration.Configure(WebApiConfig.Register);
                    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                    RouteConfig.RegisterRoutes(RouteTable.Routes);
                    BundleConfig.RegisterBundles(BundleTable.Bundles);
                    SensorThingsFactory.Load();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
    }
}

