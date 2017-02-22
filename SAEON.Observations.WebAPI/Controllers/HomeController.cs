﻿using System.Web.Mvc;

namespace SAEON.Observations.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The Observations Database WebAPI home page
        /// </summary>
        /// <returns></returns>
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About the Observations Database WebAPO
        /// </summary>
        /// <returns></returns>
        [Route("About")]

        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Contact SAEON
        /// </summary>
        /// <returns></returns>
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }
    }
}
