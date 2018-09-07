﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using SAEON.Observations.Core.Entities;
using System;
using System.Linq;
using System.Web.Http;

namespace SAEON.Observations.WebAPI.Controllers.OData
{
    /// <summary>
    /// Sensors
    /// </summary>
    [ODataRoutePrefix("Sensors")]
    public class SensorsODController : NamedController<Sensor>
    {

        // GET: odata/Sensors
        /// <summary>
        /// Get all Sensors
        /// </summary>
        /// <returns>ListOf(Sensor)</returns>
        [EnableQuery, ODataRoute]
        public override IQueryable<Sensor> GetAll()
        {
            return base.GetAll();
        }

        // GET: odata/Sensors(5)
        /// <summary>
        /// Sensor by Id
        /// </summary>
        /// <param name="id">Id of Sensor</param>
        /// <returns>Sensor</returns>
        [EnableQuery, ODataRoute("({id})")]
        public override SingleResult<Sensor> GetById([FromODataUri] Guid id)
        {
            return base.GetById(id);
        }

        // GET: odata/Sensors(5)/Phenomenon
        /// <summary>
        /// Phenomena for the Sensor
        /// </summary>
        /// <param name="id">Id of the Sensor</param>
        /// <returns>ListOf(Phenomenon)</returns>
        [EnableQuery, ODataRoute("({id})/Phenomenon")]
        public SingleResult<Phenomenon> GetPhenomenon([FromODataUri] Guid id)
        {
            return GetSingle(id, s => s.Phenomenon, i => i.Sensors);
        }

        // GET: odata/Sensors(5)/Instruments
        /// <summary>
        /// Instruments for the Sensor
        /// </summary>
        /// <param name="id">Id of the Sensor</param>
        /// <returns>ListOf(Instrument)</returns>
        [EnableQuery, ODataRoute("({id})/Instruments")]
        public IQueryable<Instrument> GetInstruments([FromODataUri] Guid id)
        {
            return GetMany<Instrument>(id, s => s.Instruments, i => i.Sensors);
        }

    }
}
