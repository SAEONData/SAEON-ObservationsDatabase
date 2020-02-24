﻿using SAEON.Observations.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SAEON.Observations.WebAPI.Controllers.WebAPI
{
    /// <summary>
    /// </summary>
    [RoutePrefix("Api/Stations")]
    public class StationsController : CodedApiController<Station>
    {
        //protected override List<Expression<Func<Station, object>>> GetIncludes()
        //{
        //    var list = base.GetIncludes();
        //    list.Add(i => i.Site);
        //    list.Add(i => i.Instruments);
        //    return list;
        //}

        /// <summary>
        /// All Stations
        /// </summary>
        /// <returns>ListOf(Station)</returns>
        public override IQueryable<Station> GetAll()
        {
            return base.GetAll();
        }

        /// <summary>
        /// Station by Id
        /// </summary>
        /// <param name="id">The Id of the Station</param>
        /// <returns>Station</returns>
        [ResponseType(typeof(Station))]
        public override async Task<IHttpActionResult> GetByIdAsync([FromUri] Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        /// <summary>
        /// Station by Name
        /// </summary>
        /// <param name="name">The Name of the Station</param>
        /// <returns>Station</returns>
        [ResponseType(typeof(Station))]
        public override async Task<IHttpActionResult> GetByNameAsync([FromUri] string name)
        {
            return await base.GetByNameAsync(name);
        }

        /// <summary>
        /// Station by Code
        /// </summary>
        /// <param name="code">The Code of the Station</param>
        /// <returns>Station</returns>
        [ResponseType(typeof(Station))]
        public override async Task<IHttpActionResult> GetByCodeAsync([FromUri] string code)
        {
            return await base.GetByCodeAsync(code);
        }

        // GET: Stations/5/Site
        /// <summary>
        /// Site of a Station
        /// </summary>
        /// <param name="id">The Id of the Station</param>
        /// <returns>Site</returns>
        [Route("{id:guid}/Site")]
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> GetSiteAsync([FromUri] Guid id)
        {
            return await GetSingleAsync<Site>(id, s => s.Site);
        }

        // GET: Stations/5/Instruments
        /// <summary>
        /// Instruments for the Station
        /// </summary>
        /// <param name="id">Id of the Station</param>
        /// <returns>ListOf(Instrument)</returns>
        [Route("{id:guid}/Instruments")]
        public IQueryable<Instrument> GetInstruments([FromUri] Guid id)
        {
            return GetMany<Instrument>(id, s => s.Instruments);
        }

        // GET: Stations/5/Organisations
        /// <summary>
        /// Organisations for the Station
        /// </summary>
        /// <param name="id">Id of the Station</param>
        /// <returns>ListOf(Organisation)</returns>
        [Route("{id:guid}/Organisations")]
        public IQueryable<Organisation> GetOrganisations([FromUri] Guid id)
        {
            return GetMany<Organisation>(id, s => s.Organisations);
        }

        // GET: Stations/5/Projects
        /// <summary>
        /// Projects for the Station
        /// </summary>
        /// <param name="id">Id of the Station</param>
        /// <returns>ListOf(Project)</returns>
        [Route("{id:guid}/Projects")]
        public IQueryable<Project> GetProjects([FromUri] Guid id)
        {
            return GetMany<Project>(id, s => s.Projects);
        }

    }
}
