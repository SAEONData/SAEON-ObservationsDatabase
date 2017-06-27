﻿using SAEON.Logs;
using SAEON.Observations.Core;
using Serilog;
using System;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SAEON.Observations.QuerySite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(HostingEnvironment.MapPath(@"~/App_Data/Logs/SAEON.Observations.QuerySite {Date}.txt"))
                .WriteTo.Seq("http://localhost:5341/")
                .CreateLogger();
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    Logging.Verbose("Starting application");
                    BootStrapper.Initialize();
                    AreaRegistration.RegisterAllAreas();
                    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                    RouteConfig.RegisterRoutes(RouteTable.Routes);
                    BundleConfig.RegisterBundles(BundleTable.Bundles);
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
