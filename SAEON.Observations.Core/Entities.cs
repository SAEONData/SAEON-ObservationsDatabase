﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAEON.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace SAEON.Observations.Core
{
    public static class EntityConfig
    {
        public static string BaseUrl { get; set; }
    }

    /// <summary>
    /// Absolute base class
    /// </summary>
    public abstract class BaseEntity
    {
        [NotMapped, JsonIgnore]
        public string EntitySetName { get; protected set; } = null;
        [NotMapped, JsonIgnore]
        public List<string> Links { get; } = new List<string>();
    }

    public abstract class GuidIdEntity : BaseEntity
    {
        /// <summary>
        /// Id of the Entity
        /// </summary>
        //[Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [HiddenInput]
        public Guid Id { get; set; }

        /// <summary>
        /// Navigation links of this Entity
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> NavigationLinks
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EntitySetName))
                    return null;
                else
                {
                    var result = new Dictionary<string, string>
                    {
                        { "Self", $"{EntityConfig.BaseUrl}/{EntitySetName}/{Id}" }
                    };
                    foreach (var link in Links.OrderBy(i => i))
                    {
                        result.Add(link, $"{EntityConfig.BaseUrl}/{EntitySetName}/{Id}/{link}");
                    }
                    return result;
                };
            }
        }
    }

    public abstract class IntIdEntity : BaseEntity
    {
        /// <summary>
        /// Id of the Entity
        /// </summary>
        //[Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [HiddenInput]
        public int Id { get; set; }

        /// <summary>
        /// Navigation links of this Entity
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> NavigationLinks
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EntitySetName))
                    return null;
                else
                {
                    var result = new Dictionary<string, string>
                    {
                        { "Self", $"{EntityConfig.BaseUrl}/{EntitySetName}/{Id}" }
                    };
                    foreach (var link in Links.OrderBy(i => i))
                    {
                        result.Add(link, $"{EntityConfig.BaseUrl}/{EntitySetName}/{Id}/{link}");
                    }
                    return result;
                };
            }
        }
    }

    public abstract class LongIdEntity : BaseEntity
    {
        /// <summary>
        /// Id of the Entity
        /// </summary>
        //[Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [HiddenInput]
        public long Id { get; set; }

        /// <summary>
        /// Navigation links of this Entity
        /// </summary>
        [NotMapped]
        public Dictionary<string, string> NavigationLinks
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EntitySetName))
                    return null;
                else
                {
                    var result = new Dictionary<string, string>
                    {
                        { "Self", $"{EntityConfig.BaseUrl}/{EntitySetName}/{Id}" }
                    };
                    foreach (var link in Links.OrderBy(i => i))
                    {
                        result.Add(link, $"{EntityConfig.BaseUrl}/{EntitySetName}/{Id}/{link}");
                    }
                    return result;
                };
            }
        }
    }

    /// <summary>
    /// Base for entities
    /// </summary>
    public abstract class IdedEntity : GuidIdEntity
    {
        [JsonIgnore, Timestamp, Column(Order = 10000), ConcurrencyCheck, ScaffoldColumn(false)]
        [HiddenInput]
        public byte[] RowVersion { get; set; }
        [JsonIgnore, Required]
        public Guid UserId { get; set; }
    }

    public abstract class NamedEntity : IdedEntity
    {
        /// <summary>
        /// Name of the Entity
        /// </summary>
        [Required, StringLength(150)]
        public string Name { get; set; }
    }

    public abstract class CodedEntity : NamedEntity
    {
        /// <summary>
        /// Code of the Entity
        /// </summary>
        [Required, StringLength(50)]
        public string Code { get; set; }
    }

    /// <summary>
    /// Data Schema entity
    /// </summary>
    [Table("DataSchema")]
    public class DataSchema : CodedEntity
    {
        /// <summary>
        /// DataSourceTypeId of the DataSchema
        /// </summary>
        [Required]
        public Guid DataSourceTypeId { get; set; }
        /// <summary>
        /// Description of the DataSchema
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }

        // Navigation
        public DataSourceType DataSourceType { get; set; }
    }

    /// <summary>
    /// Data Source entity
    /// </summary>
    [Table("DataSource")]
    public class DataSource : CodedEntity
    {
        public Guid DataSchemaId { get; set; }
        /// <summary>
        /// Description of the DataSource
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the DataSource
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// Update Frequency of the DataSource
        /// Enum of {AdHoc, Daily, Weekly, Monthly, Quarterly, Annually, Hourly}
        /// </summary>
        public int UpdateFreq { get; set; }
        /// <summary>
        /// Last update of the DataSource
        /// </summary>
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// StartDate of the DataSource, null means always
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the DataSource, null means always
        /// </summary>
        public DateTime? EndDate { get; set; }

        // Navigation
        public DataSchema DataSchema { get; set; }
        public List<Sensor> Sensors { get; set; }
    }

    [Table("DataSourceType")]
    public class DataSourceType : BaseEntity
    {
        /// <summary>
        /// Id of the Entity
        /// </summary>
        //[Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        [HiddenInput]
        public Guid Id { get; set; }
        [Timestamp, Column(Order = 10000), ConcurrencyCheck, ScaffoldColumn(false)]
        [HiddenInput]

        public byte[] RowVersion { get; set; }
        public Guid? UserId { get; set; }

        //public EntityListItem AsEntityListItem => new EntityListItem { Id = Id, Code = Code };

        /// <summary>
        /// Code of the Entity
        /// </summary>
        [Required, StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// Description of the Instrument
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }

        // Navigation
        public List<DataSchema> DataSchemas { get; set; }
    }

    public enum DOIType { ObservationsDb, Organisation, Programme, Project, Site, Station, Dataset, Periodic, AdHoc }

    /// <summary>
    /// DigitalObjectIdentifiers entity
    /// </summary>
    public class DigitalObjectIdentifier : IntIdEntity
    {
        [HiddenInput]
        public int? ParentID { get; set; }
        [Required]
        [DisplayName("DOI Type")]
        public DOIType DOIType { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DOI { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "DOI Url")]
        public string DOIUrl { get; set; }
        /// <summary>
        /// Name of the DigitalObjectIdentifier
        /// </summary>
        [StringLength(1000)]
        public string Name { get; set; }
        /// <summary>
        /// MetadataJson of the DigitalObjectIdentifier
        /// </summary>
        [Required, StringLength(5000)]
        public string MetadataJson { get; set; }
        /// <summary>
        /// Sha256 of the MetadataJson of the DigitalObjectIdentifier
        /// </summary>
        [MinLength(32), MaxLength(32)]
        public byte[] MetadataJsonSha256 { get; set; }
        /// <summary>
        /// Url of the ODP metadata record of the DigitalObjectIdentifier
        /// </summary>
        [Required, StringLength(250)]
        public string MetadataUrl { get; set; }
        /// <summary>
        /// ODP Id for the download
        /// </summary>
        [Required]
        public Guid OpenDataPlatformId { get; set; }
        /// <summary>
        /// UserId of user who added the UserDownload
        /// </summary>
        [StringLength(128), ScaffoldColumn(false)]
        public string AddedBy { get; set; }
        /// <summary>
        /// UserId of user who last updated the UserDownload 
        /// </summary>
        [StringLength(128), ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
        [Timestamp, ConcurrencyCheck, ScaffoldColumn(false)]
        [HiddenInput]
        public byte[] RowVersion { get; set; }

        // Navigation
        public DigitalObjectIdentifier Parent { get; set; }
        public List<DigitalObjectIdentifier> Children { get; set; }
        public List<Organisation> Organisations { get; set; }
        public List<Programme> Programmes { get; set; }
        public List<Project> Projects { get; set; }
        public List<Site> Sites { get; set; }
        public List<Station> Stations { get; set; }
        public List<UserDownload> UserDownloads { get; set; }
    }

    /// <summary>
    /// Instrument entity
    /// </summary>
    [Table("Instrument")]
    public class Instrument : CodedEntity
    {
        /// <summary>
        /// Description of the Instrument
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Instrument
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// StartDate of the Instrument, null means always
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the Instrument, null means always
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Latitude of the Instrument
        /// </summary>
        public double? Latitude { get; set; }
        /// <summary>
        /// Longitude of the Instrument
        /// </summary>
        public double? Longitude { get; set; }
        /// <summary>
        /// Elevation of the Instrument, positive above sea level, negative below sea level
        /// </summary>
        public double? Elevation { get; set; }

        // Navigation
        //#if NET472
        //        /// <summary>
        //        /// The Organisations linked to this Instrument
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Organisation> Organisations { get; set; }

        //        /// <summary>
        //        /// Stations linked to this Instrument
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Station> Stations { get; set; }

        //        /// <summary>
        //        /// Sensors linked to this Instrument
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Sensor> Sensors { get; set; }
        //#else
        /// <summary>
        /// The Organisations linked to this Instrument
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Organisation> Organisations => OrganisationInstruments?.Select(oi => oi.Organisation).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<OrganisationInstrument> OrganisationInstruments { get; set; }

        /// <summary>
        /// Stations linked to this Instrument
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Station> Stations => StationInstruments?.Select(si => si.Station).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<StationInstrument> StationInstruments { get; set; }

        /// <summary>
        /// Sensors linked to this Instrument
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Sensor> Sensors => InstrumentSensors?.Select(i => i.Sensor).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<InstrumentSensor> InstrumentSensors { get; set; }

        public Instrument() : base()
        {
            EntitySetName = "Instruments";
            Links.Add("Organisations");
            Links.Add("Stations");
            Links.Add("Sensors");
        }
    }

    /// <summary>
    /// Offering entity
    /// </summary>
    [Table("Offering")]
    public class Offering : CodedEntity
    {
        /// Description of the Offering
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }

        // Navigation
        //#if NET472
        //        ///// <summary>
        //        ///// Phenomena of this Offering
        //        ///// </summary>
        //        [JsonIgnore]
        //        public List<Phenomenon> Phenomena => PhenomenonOfferings?.Select(i => i.Phenomenon).ToList();
        //        [JsonIgnore]
        //        public List<PhenomenonOffering> PhenomenonOfferings { get; set; }
        //#else
        /// <summary>
        /// Phenomena of this Offering
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Phenomenon> Phenomena => PhenomenonOfferings?.Select(po => po.Phenomenon).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<PhenomenonOffering> PhenomenonOfferings { get; set; }

        public Offering() : base()
        {
            EntitySetName = "Offerings";
            Links.Add("Phenomena");

        }
    }

    /// <summary>
    /// Organisation entity
    /// </summary>
    [Table("Organisation")]
    public class Organisation : CodedEntity
    {
        /// <summary>
        /// Description of the Organisation
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Organisation
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// DigitalObjectIdentifierID of the Organisation
        /// </summary>
        [JsonIgnore]
        public int? DigitalObjectIdentifierID { get; set; }

        // Navigation
        [JsonIgnore]
        public DigitalObjectIdentifier DigitalObjectIdentifier { get; set; }
        //#if NET472
        //        /// <summary>
        //        /// The Sites linked to this Organisation
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Site> Sites { get; set; }

        //        /// <summary>
        //        /// The Stations linked to this Organisation
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Station> Stations { get; set; }

        //        /// <summary>
        //        /// The Instruments linked to this Organisation
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Instrument> Instruments { get; set; }
        //#else
        /// <summary>
        /// The Instruments linked to this Organisation
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Instrument> Instruments => OrganisationInstruments?.Select(oi => oi.Instrument).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<OrganisationInstrument> OrganisationInstruments { get; set; }

        /// <summary>
        /// The Sites linked to this Organisation
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Site> Sites => OrganisationSites?.Select(os => os.Site).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<OrganisationSite> OrganisationSites { get; set; }

        /// <summary>
        /// The Stations linked to this Organisation
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Station> Stations => OrganisationStations?.Select(os => os.Station).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<OrganisationStation> OrganisationStations { get; set; }

        public Organisation() : base()
        {
            EntitySetName = "Organisations";
            Links.Add("Sites");
            Links.Add("Stations");
            Links.Add("Instruments");
        }
    }

    /// <summary>
    /// OrganisationRole entity
    /// </summary>
    public class OrganisationRole : CodedEntity
    {
        // Navigation
        //public List<Organisation> Organisations { get; set; }
    }

    /// <summary>
    /// Phenomenon entity
    /// </summary>
    [Table("Phenomenon")]
    public class Phenomenon : CodedEntity
    {
        /// <summary>
        /// Description of the Phenomenon
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Phenomenon
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }

        // Navigation
        //#if NET472
        //        /// <summary>
        //        /// Offerings of this Phenomenon
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Offering> Offerings => PhenomenonOfferings?.Select(i => i.Offering).ToList();
        //        [JsonIgnore]
        //        public List<PhenomenonOffering> PhenomenonOfferings { get; set; }

        //        ///// <summary>
        //        ///// Units of this Phenomenon
        //        ///// </summary>
        //        [JsonIgnore]
        //        public List<Unit> Units => PhenomenonUnits?.Select(i => i.Unit).ToList();
        //        [JsonIgnore]
        //        public List<PhenomenonUnit> PhenomenonUnits { get; set; }

        //        /// <summary>
        //        /// Sensors linked to this Phenomenon
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Sensor> Sensors { get; set; }
        //#else
        /// <summary>
        /// Offerings of this Phenomenon
        /// </summary>
        [JsonIgnore]
        public List<Offering> Offerings => PhenomenonOfferings?.Select(ph => ph.Offering).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<PhenomenonOffering> PhenomenonOfferings { get; set; }

        /// <summary>
        /// Units of this Phenomenon
        /// </summary>
        [JsonIgnore]
        public List<Unit> Units => PhenomenonUnits?.Select(pu => pu.Unit).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<PhenomenonUnit> PhenomenonUnits { get; set; }

        /// <summary>
        /// Sensors linked to this Phenomenon
        /// </summary>
        [JsonIgnore, SwaggerIgnore]
        public List<Sensor> Sensors { get; set; }

        public Phenomenon() : base()
        {
            EntitySetName = "Phenomena";
            Links.Add("Offerings");
            Links.Add("Sensors");
            Links.Add("Units");
        }
    }

    /// <summary>
    /// Programme entity
    /// </summary>
    [Table("Programme")]
    public class Programme : CodedEntity
    {
        /// <summary>
        /// Description of the Programme
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Programme
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// StartDate of the Programme, null means always
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the Programme, null means always
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// DigitalObjectIdentifierID of the Programme
        /// </summary>
        [JsonIgnore]
        public int? DigitalObjectIdentifierID { get; set; }

        // Navigation
        /// <summary>
        /// DigitalObjectIdentifier of the Programme
        /// </summary>
        [JsonIgnore]
        public DigitalObjectIdentifier DigitalObjectIdentifier { get; set; }

        /// <summary>
        /// The Projects linked to this Programme
        /// </summary>
        [JsonIgnore]
        public List<Project> Projects { get; set; }

        public Programme() : base()
        {
            EntitySetName = "Programmes";
            Links.Add("Projects");
        }
    }

    /// <summary>
    /// Project entity
    /// </summary>
    [Table("Project")]
    public class Project : CodedEntity
    {
        /// <summary>
        /// The Programme of the Project
        /// </summary>
        [Required, JsonIgnore]
        public Guid ProgrammeId { get; set; }
        /// Description of the Project
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Project
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// StartDate of the Project, null means always
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the Project, null means always
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// DigitalObjectIdentifierID of the Project
        /// </summary>
        [JsonIgnore]
        public int? DigitalObjectIdentifierID { get; set; }

        // Navigation
        /// <summary>
        /// DigitalObjectIdentifier of the Project
        /// </summary>
        [JsonIgnore]
        public DigitalObjectIdentifier DigitalObjectIdentifier { get; set; }

        /// <summary>
        /// The Programme of the Project
        /// </summary>
        [JsonIgnore]
        public Programme Programme { get; set; }

        /// <summary>
        /// The Stations linked to this Project
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Station> Stations => ProjectStations?.Select(ps => ps.Station).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<ProjectStation> ProjectStations { get; set; }

        public Project() : base()
        {
            EntitySetName = "Projects";
            Links.Add("Programmes");
            Links.Add("Stations");
        }
    }

    /// <summary>
    /// Sensor entity
    /// </summary>
    [Table("Sensor")]
    public class Sensor : CodedEntity
    {
        /// <summary>
        /// Description of the Sensor
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Sensor
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        [Required]
        public Guid DataSourceId { get; set; }
        /// <summary>
        /// PhenomenonId of the sensor
        /// </summary>
        public Guid PhenomenonId { get; set; }
        /// <summary>
        /// Latitude of the Sensor
        /// </summary>
        public double? Latitude { get; set; }
        /// <summary>
        /// Longitude of the Sensor
        /// </summary>
        public double? Longitude { get; set; }
        /// <summary>
        /// Elevation of the Sensor, positive above sea level, negative below sea level
        /// </summary>
        public double? Elevation { get; set; }

        // Navigation
        [JsonIgnore]
        public DataSource DataSource { get; set; }

        //#if NET472
        //        /// <summary>
        //        /// Phenomenon of the Sensor
        //        /// </summary>
        //        [JsonIgnore]
        //        public Phenomenon Phenomenon { get; set; }

        //        /// <summary>
        //        /// Instruments linked to this Sensor
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Instrument> Instruments { get; set; }

        //        /// <summary>
        //        /// Observations linked to this Sensor
        //        /// </summary>
        //        //[JsonIgnore]
        //        //public List<SensorObservation> SensorObservations { get; set; }

        //#else
        /// <summary>
        /// Phenomenon of the Sensor
        /// </summary>
        [JsonIgnore]
        public Phenomenon Phenomenon { get; set; }

        /// <summary>
        /// Instruments linked to this Sensor
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Instrument> Instruments => InstrumentSensors?.Select(i => i.Instrument).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<InstrumentSensor> InstrumentSensors { get; set; }

        public Sensor() : base()
        {
            EntitySetName = "Sensors";
            Links.Add("Site");
            Links.Add("Organisations");
            Links.Add("Projects");
            Links.Add("Instruments");
            Links.Add("Observations");
        }
    }

    /// <summary>
    /// Site entity
    /// </summary>
    [Table("Site")]
    public class Site : CodedEntity
    {
        /// <summary>
        /// Description of the Site
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Url of the Site
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// StartDate of the Site, null means always
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the Site, null means always
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// DigitalObjectIdentifierID of the Site
        /// </summary>
        [JsonIgnore]
        public int? DigitalObjectIdentifierID { get; set; }

        // Navigation
        /// <summary>
        /// DigitalObjectIdentifier of the Site
        /// </summary>
        [JsonIgnore]
        public DigitalObjectIdentifier DigitalObjectIdentifier { get; set; }

        /// <summary>
        /// The Organisations linked to this Site
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Organisation> Organisations => OrganisationSites?.Select(os => os.Organisation).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<OrganisationSite> OrganisationSites { get; set; }

        /// <summary>
        /// The Stations linked to this Site
        /// </summary>
        [JsonIgnore, SwaggerIgnore]
        public List<Station> Stations { get; set; }

        public Site() : base()
        {
            EntitySetName = "Sites";
            Links.Add("Organisations");
            Links.Add("Stations");
        }
    }

    /// <summary>
    /// Station entity
    /// </summary>
    [Table("Station")]
    public class Station : CodedEntity
    {
        /// <summary>
        /// Description of the Station
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// The SiteId of the Station
        /// </summary>
        [Required, JsonIgnore]
        public Guid SiteId { get; set; }
        /// <summary>
        /// Url of the Station
        /// </summary>
        [Url, StringLength(250)]
        public string Url { get; set; }
        /// <summary>
        /// StartDate of the site, null means always
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate of the Station, null means always
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Latitude of the Station
        /// </summary>
        public double? Latitude { get; set; }
        /// <summary>
        /// Logitude of the Station
        /// </summary>
        public double? Longitude { get; set; }
        /// <summary>
        /// Elevation of the Station, positive above sea level, negative below sea level
        /// </summary>
        public double? Elevation { get; set; }

        /// <summary>
        /// DigitalObjectIdentifierID of the Station
        /// </summary>
        [JsonIgnore]
        public int? DigitalObjectIdentifierID { get; set; }

        // Navigation
        /// <summary>
        /// DigitalObjectIdentifier of the Station
        /// </summary>
        [JsonIgnore]
        public DigitalObjectIdentifier DigitalObjectIdentifier { get; set; }

        /// <summary>
        /// Site of the Station
        /// </summary>
        [JsonIgnore]
        public Site Site { get; set; }

        /// <summary>
        /// The Organisations linked to this Station
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Organisation> Organisations => OrganisationStations?.Select(os => os.Organisation).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<OrganisationStation> OrganisationStations { get; set; }

        /// <summary>
        /// The Projects linked to this Station
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Project> Projects => ProjectStations?.Select(ps => ps.Project).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<ProjectStation> ProjectStations { get; set; }

        /// <summary>
        /// Instruments linked to this Station
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Instrument> Instruments => StationInstruments?.Select(si => si.Instrument).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<StationInstrument> StationInstruments { get; set; }

        public Station() : base()
        {
            EntitySetName = "Stations";
            Links.Add("Site");
            Links.Add("Organisations");
            Links.Add("Projects");
            Links.Add("Instruments");
        }
    }


    /// <summary>
    /// Unit Entity
    /// </summary>
    [Table("UnitOfMeasure")]
    public class Unit : CodedEntity
    {
        /// <summary>
        /// Symbol of the Unit
        /// </summary>
        [Required, StringLength(20), Column("UnitSymbol")]
        public string Symbol { get; set; }

        // Navigation
        //#if NET472
        //        /// <summary>
        //        /// Phenomena of this Unit
        //        /// </summary>
        //        [JsonIgnore]
        //        public List<Phenomenon> Phenomena => PhenomenonUnits?.Select(i => i.Phenomenon).ToList();
        //        [JsonIgnore]
        //        public List<PhenomenonUnit> PhenomenonUnits { get; set; }
        //#else
        /// <summary>
        /// Phenomena of this Unit
        /// </summary>
        [NotMapped, JsonIgnore]
        public List<Phenomenon> Phenomena => PhenomenonUnits?.Select(pu => pu.Phenomenon).ToList();
        [JsonIgnore, SwaggerIgnore]
        public List<PhenomenonUnit> PhenomenonUnits { get; set; }

        public Unit() : base()
        {
            EntitySetName = "Units";
            Links.Add("Phenomena");
        }
    }

    /// <summary>
    /// UserDownload entity
    /// </summary>
    public class UserDownload : NamedEntity
    {
        /// <summary>
        /// Description of the UserDownload
        /// DataCite Abstracts, should include citation format
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// Title of the DownLoad
        /// DataCite Titles
        /// </summary>
        [Required, StringLength(5000)]
        public string Title { get; set; }
        /// <summary>
        /// How this DownLoad should be cited
        /// </summary>
        [Required, StringLength(5000)]
        public string Citation { get; set; }
        /// <summary>
        /// Keywords of the Download, semi-colon separated
        /// </summary>
        [Required, StringLength(1000)]
        public string Keywords { get; set; }
        /// <summary>
        /// When the query for the download was executed
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// The input of the query that generated the download
        /// </summary>
        [Required, StringLength(5000), Display(Name = "Input")]
        public string Input { get; set; }
        /// <summary>
        /// Requery Url for download
        /// </summary>
        [Required, StringLength(2000), Display(Name = "Requery Url")]
        public string RequeryUrl { get; set; }
        /// <summary>
        /// DigitalObjectIdentifierID of the download
        /// </summary>
        [Required, Display(Name = "Digital Object Identifier (DOI)")]
        public int DigitalObjectIdentifierId { get; set; }
        /// <summary>
        /// Json sent to metadata service
        /// </summary>
        [Required, Display(Name = "Metadata Json")]
        public string MetadataJson { get; set; }
        /// <summary>
        /// Metadata Url for download
        /// </summary>
        [Required, StringLength(2000), Display(Name = "Metadata Url")]
        public string MetadataUrl { get; set; }
        /// <summary>
        /// ODP Id for the download
        /// </summary>
        public Guid OpenDataPlatformId { get; set; }
        /// <summary>
        /// Url to view the download
        /// </summary>
        [Required, StringLength(2000), Display(Name = "Download Url")]
        public string DownloadUrl { get; set; }
        /// <summary>
        /// Full file name of Zip on server
        /// </summary>
        [Required, StringLength(2000), Display(Name = "Zip Full Name")]
        public string ZipFullName { get; set; }
        /// <summary>
        /// SHA256 checksum of Zip
        /// </summary>
        [Required, StringLength(64), Display(Name = "Zip SHA256 Checksum")]
        public string ZipCheckSum { get; set; }
        /// <summary>
        /// Url to Zip of the download
        /// </summary>
        [Required, StringLength(2000), Display(Name = "Zip Url")]
        public string ZipUrl { get; set; }
        /// <summary>
        /// Places of the DownLoad
        /// Lookup on GeoNames in format Name:Country:Lat:Lon, semi-colon separated
        /// </summary>
        [Required, StringLength(5000)]
        public string Places { get; set; }
        /// <summary>
        /// North-most Latitude of the download
        /// </summary>
        public double? LatitudeNorth { get; set; } // +N to -S
        /// <summary>
        /// South-most Latitude of the download
        /// </summary>
        public double? LatitudeSouth { get; set; } // +N to -S
        /// <summary>
        /// West-morthmost Longitude of the download
        /// </summary>
        public double? LongitudeWest { get; set; } // -W to +E
        /// <summary>
        /// East-morthmost Longitude of the download
        /// </summary>
        public double? LongitudeEast { get; set; } // -W to +E
        /// <summary>
        /// Minimum elevation of the download
        /// </summary>
        public double? ElevationMinimum { get; set; }
        /// <summary>
        /// Maximum elevation of the download
        /// </summary>
        public double? ElevationMaximum { get; set; }
        /// <summary>
        /// Start date of the download
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of the download
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// UserId of the UserDownload
        /// </summary>
        [ScaffoldColumn(false)]
        [HiddenInput]
        public new string UserId { get; set; }
        /// <summary>
        /// <summary>
        /// UserId of user who added the UserDownload
        /// </summary>
        [Required, StringLength(128), ScaffoldColumn(false)]
        public string AddedBy { get; set; }
        /// <summary>
        /// Time the UserDownload was added
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime? AddedAt { get; set; }
        ///// <summary>
        ///// UserId of user who last updated the UserDownload
        ///// </summary>
        [Required, StringLength(128), ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Time the UserDownload was updated
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public DigitalObjectIdentifier DigitalObjectIdentifier { get; set; }
    }

    /// <summary>
    /// UserQuery entity
    /// </summary>
    public class UserQuery : NamedEntity
    {
        /// <summary>
        /// Description of the UserQuery
        /// </summary>
        [StringLength(5000)]
        public string Description { get; set; }
        /// <summary>
        /// URI of the user query
        /// </summary>
        [Required, StringLength(5000), Display(Name = "Input")]
        public string QueryInput { get; set; }
        /// <summary>
        /// UserId of UserQuery
        /// </summary>
        [ScaffoldColumn(false)]
        [HiddenInput]
        public new string UserId { get; set; }
        /// <summary>
        /// UserId of user who added the UserQuery
        /// </summary>
        [StringLength(128), ScaffoldColumn(false)]
        public string AddedBy { get; set; }
        /// <summary>
        /// Time the UserDownload was added
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime? AddedAt { get; set; }
        /// <summary>
        /// UserId of user who last updated the UserQuery
        /// </summary>
        [StringLength(128), ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Time the UserDownload was updated
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime? UpdatedAt { get; set; }
    }

    [Table("vImportBatchSummary")]
    public class ImportBatchSummary : GuidIdEntity
    {
        public Guid ImportBatchId { get; set; }

        public Guid OrganisationId { get; set; }
        public string OrganisationCode { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationDescription { get; set; }
        public string OrganisationUrl { get; set; }
        public Guid ProgrammeId { get; set; }
        public string ProgrammeCode { get; set; }
        public string ProgrammeName { get; set; }
        public string ProgrammeDescription { get; set; }
        public string ProgrammeUrl { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectUrl { get; set; }
        public Guid SiteId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string SiteDescription { get; set; }
        public string SiteUrl { get; set; }
        public Guid StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string StationDescription { get; set; }
        public string StationUrl { get; set; }
        public Guid InstrumentId { get; set; }
        public string InstrumentCode { get; set; }
        public string InstrumentName { get; set; }
        public string InstrumentDescription { get; set; }
        public string InstrumentUrl { get; set; }
        public Guid SensorId { get; set; }
        public string SensorCode { get; set; }
        public string SensorName { get; set; }
        public string SensorDescription { get; set; }
        public string SensorUrl { get; set; }
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public string PhenomenonDescription { get; set; }
        public string PhenomenonUrl { get; set; }
        public Guid PhenomenonOfferingId { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        public string OfferingDescription { get; set; }
        [Column("PhenomenonUOMID")]
        public Guid PhenomenonUnitId { get; set; }
        [Column("UnitOfMeasureCode")]
        public string UnitCode { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
        [Column("UnitOfMeasureSymbol")]
        public string UnitSymbol { get; set; }
        public int Count { get; set; }
        public double? Minimum { get; set; }
        public double? Maximum { get; set; }
        public double? Average { get; set; }
        public double? StandardDeviation { get; set; }
        public double? Variance { get; set; }
        public double? LatitudeNorth { get; set; } // +N to -S
        public double? LatitudeSouth { get; set; } // +N to -S
        public double? LongitudeWest { get; set; } // -W to +E
        public double? LongitudeEast { get; set; } // -W to +E
        public double? ElevationMinimum { get; set; }
        public double? ElevationMaximum { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    //[Table("vInventoryDatasets")]
    //[Keyless]
    public class InventoryDataset : BaseEntity
    {
        // Remove once OData allows Keyless views
        [Key]
        public long Id { get; set; }
        public Guid SiteId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public Guid StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public Guid PhenomenonOfferingId { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        [Column("PhenomenonUOMID")]
        public Guid PhenomenonUnitId { get; set; }
        [Column("UnitOfMeasureCode")]
        public string UnitCode { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
        public int Count { get; set; }
        public double? LatitudeNorth { get; set; } // +N to -S
        public double? LatitudeSouth { get; set; } // +N to -S
        public double? LongitudeWest { get; set; } // -W to +E
        public double? LongitudeEast { get; set; } // -W to +E
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    //[Table("vInventorySensors")]
    //[Keyless]
    public class InventorySensor : BaseEntity
    {
        // Remove once OData allows Keyless views
        [Key]
        public long Id { get; set; }
        public Guid SiteId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public Guid StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public Guid InstrumentId { get; set; }
        public string InstrumentCode { get; set; }
        public string InstrumentName { get; set; }
        public Guid SensorId { get; set; }
        public string SensorCode { get; set; }
        public string SensorName { get; set; }
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public Guid PhenomenonOfferingId { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        [Column("PhenomenonUOMID")]
        public Guid PhenomenonUnitId { get; set; }
        [Column("UnitOfMeasureCode")]
        public string UnitCode { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
        public int Count { get; set; }
        public double? LatitudeNorth { get; set; } // +N to -S
        public double? LatitudeSouth { get; set; } // +N to -S
        public double? LongitudeWest { get; set; } // -W to +E
        public double? LongitudeEast { get; set; } // -W to +E
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    //[Keyless]
    public class Location : BaseEntity
    {
        public Guid OrganisationID { get; set; }
        public string OrganisationName { get; set; }
        public Guid SiteID { get; set; }
        public string SiteName { get; set; }
        public Guid StationID { get; set; }
        public string StationName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Elevation { get; set; }
        public string Url { get; set; }

        // Navigation
        //public Organisation Organisation { get; set; }
        //public Site Site { get; set; }
        //public Station Station { get; set; }
    }

    //[Keyless]
    public class Feature : BaseEntity
    {
        public Guid PhenomenonID { get; set; }
        public string PhenomenonName { get; set; }
        public Guid PhenomenonOfferingID { get; set; }
        public Guid OfferingID { get; set; }
        public string OfferingName { get; set; }
        [Column("PhenomenonUOMID")]
        public Guid PhenomenonUnitID { get; set; }
        [Column("UnitOfMeasureID")]
        public Guid UnitID { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
    }

    [Table("vObservationExpansion")]
    public class ObservationExpansion : IntIdEntity
    {
        public Guid ImportBatchId { get; set; }
        public Guid SiteId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string SiteDescription { get; set; }
        public string SiteUrl { get; set; }
        public Guid StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string StationDescription { get; set; }
        public string StationUrl { get; set; }
        public Guid InstrumentId { get; set; }
        public string InstrumentCode { get; set; }
        public string InstrumentName { get; set; }
        public string InstrumentDescription { get; set; }
        public string InstrumentUrl { get; set; }
        public Guid SensorId { get; set; }
        public string SensorCode { get; set; }
        public string SensorName { get; set; }
        public string SensorDescription { get; set; }
        public string SensorUrl { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Elevation { get; set; }
        public Guid PhenomenonId { get; set; }
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public string PhenomenonDescription { get; set; }
        public Guid PhenomenonOfferingId { get; set; }
        public Guid OfferingId { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        public string OfferingDescription { get; set; }
        [Column("PhenomenonUOMID")]
        public Guid PhenomenonUnitId { get; set; }
        [Column("UnitOfMeasureID")]
        public Guid UnitId { get; set; }
        [Column("UnitOfMeasureCode")]
        public string UnitCode { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
        [Column("UnitOfMeasureSymbol")]
        public string UnitSymbol { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime ValueDay { get; set; }
        public int ValueYear { get; set; }
        public int ValueDecade { get; set; }
        public double? RawValue { get; set; }
        public double? DataValue { get; set; }
        public string TextValue { get; set; }
        public string Comment { get; set; }
        public Guid? CorrelationId { get; set; }
        public Guid? StatusId { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public Guid? StatusReasonId { get; set; }
        public string StatusReasonCode { get; set; }
        public string StatusReasonName { get; set; }
        public string StatusReasonDescription { get; set; }
    }

    //[Table("vStationDatasets")]
    //[Keyless]
    public class Dataset : BaseEntity
    {
        // Remove once OData allows Keyless views
        [Key]
        public long Id { get; set; }
        public Guid StationId { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string StationDescription { get; set; }
        public Guid PhenomenonId { get; set; }
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public string PhenomenonDescription { get; set; }
        //public Guid PhenomenonOfferingID { get; set; }
        public Guid OfferingId { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        public string OfferingDescription { get; set; }
        //[Column("PhenomenonUOMID")]
        //public Guid PhenomenonUnitID { get; set; }
        [Column("UnitOfMeasureID")]
        public Guid UnitId { get; set; }
        [Column("UnitOfMeasureCode")]
        public string UnitCode { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
        [Column("UnitOfMeasureSymbol")]
        public string UnitSymbol { get; set; }
        public int? Count { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? LatitudeNorth { get; set; }
        public double? LatitudeSouth { get; set; }
        public double? LongitudeWest { get; set; }
        public double? LongitudeEast { get; set; }
        public double? ElevationMinimum { get; set; }
        public double? ElevationMaximum { get; set; }

        // Navigation
        [JsonIgnore]
        public Station Station { get; set; }
    }

    [Table("vStationObservations")]
    public class Observation : IntIdEntity
    {
        //public Guid ImportBatchId { get; set; } 
        public Guid StationId { get; set; }
        public Guid InstrumentId { get; set; }
        public string InstrumentCode { get; set; }
        public string InstrumentName { get; set; }
        public string InstrumentDescription { get; set; }
        public Guid SensorId { get; set; }
        public string SensorCode { get; set; }
        public string SensorName { get; set; }
        public string SensorDescription { get; set; }
        public DateTime ValueDate { get; set; }
        //public double? RawValue { get; set; }
        public double? DataValue { get; set; }
        public string TextValue { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Elevation { get; set; }
        public Guid PhenomenonId { get; set; }
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public string PhenomenonDescription { get; set; }
        //public Guid PhenomenonOfferingId { get; set; }
        public Guid OfferingId { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        public string OfferingDescription { get; set; }
        //[Column("PhenomenonUOMID")]
        //public Guid PhenomenonUnitId { get; set; }
        [Column("UnitOfMeasureID")]
        public Guid UnitId { get; set; }
        [Column("UnitOfMeasureCode")]
        public string UnitCode { get; set; }
        [Column("UnitOfMeasureUnit")]
        public string UnitName { get; set; }
        [Column("UnitOfMeasureSymbol")]
        public string UnitSymbol { get; set; }
        public string Comment { get; set; }
        public Guid? CorrelationId { get; set; }
        //public Guid? StatusId { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        //public Guid? StatusReasonId { get; set; }
        public string StatusReasonCode { get; set; }
        public string StatusReasonName { get; set; }
        public string StatusReasonDescription { get; set; }

        // Navigation
        [JsonIgnore]
        public Station Station { get; set; }
    }

    #region SensorThingsAPI

    [Table("vSensorThingsAPIDatastreams")]
    public class SensorThingsDatastream : GuidIdEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid InstrumentId { get; set; }
        public string InstrumentCode { get; set; }
        public string InstrumentName { get; set; }
        public Guid PhenomenonId { get; set; }
        public string PhenomenonName { get; set; }
        public string PhenomenonDescription { get; set; }
        public string PhenomenonUrl { get; set; }
        public Guid PhenomenonOfferingId { get; set; }
        public Guid OfferingId { get; set; }
        public string OfferingName { get; set; }
        public string OfferingDescription { get; set; }
        public Guid PhenomenonUnitId { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public string UnitOfMeasureUnit { get; set; }
        public string UnitOfMeasureSymbol { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? LatitudeNorth { get; set; }
        public double? LatitudeSouth { get; set; }
        public double? LongitudeWest { get; set; }
        public double? LongitudeEast { get; set; }
    }

    [Table("vSensorThingsAPIFeaturesOfInterest")]
    public class SensorThingsFeatureOfInterest : GuidIdEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Elevation { get; set; }
    }

    [Table("vSensorThingsAPIHistoricalLocations")]
    public class SensorThingsHistoricalLocation : GuidIdEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Elevation { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    [Table("vSensorThingsAPILocations")]
    public class SensorThingsLocation : GuidIdEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Elevation { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    [Table("vSensorThingsAPIObservations")]
    public class SensorThingsObservation : IntIdEntity
    {
        public Guid SensorId { get; set; }
        public Guid PhenomenonOfferingID { get; set; }
        public Guid PhenomenonUnitId { get; set; }
        [Column("ValueDate")]
        public DateTime Date { get; set; }
        [Column("DataValue")]
        public double? Value { get; set; } = null;
    }

    [Table("vSensorThingsAPIObservedProperties")]
    public class SensorThingsObservedProperty : GuidIdEntity
    {
        public string PhenomenonCode { get; set; }
        public string PhenomenonName { get; set; }
        public string PhenomenonDescription { get; set; }
        public string PhenomenonUrl { get; set; }
        public string OfferingCode { get; set; }
        public string OfferingName { get; set; }
        public string OfferingDescription { get; set; }
    }

    [Table("vSensorThingsAPISensors")]
    public class SensorThingsSensor : GuidIdEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Guid PhenomenonOfferingId { get; set; }
    }

    [Table("vSensorThingsAPIThings")]
    public class SensorThingsThing : GuidIdEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Kind { get; set; }
        public string Url { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    #endregion

    #region ManyToManyTables
    //> Remove once EFCore has many to many
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("Instrument_Sensor")]
    public class InstrumentSensor : IdedEntity
    {
        public Guid InstrumentId { get; set; }
        public Guid SensorId { get; set; }
        // Navigation
        public Instrument Instrument { get; set; }
        public Sensor Sensor { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("Organisation_Instrument")]
    public class OrganisationInstrument : IdedEntity
    {
        public Guid OrganisationId { get; set; }
        public Guid InstrumentId { get; set; }
        // Navigation
        public Organisation Organisation { get; set; }
        public Instrument Instrument { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("Organisation_Site")]
    public class OrganisationSite : IdedEntity
    {
        public Guid OrganisationId { get; set; }
        public Guid SiteId { get; set; }
        // Navigation
        public Organisation Organisation { get; set; }
        public Site Site { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("Organisation_Station")]
    public class OrganisationStation : IdedEntity
    {
        public Guid OrganisationId { get; set; }
        public Guid StationId { get; set; }
        // Navigation
        public Organisation Organisation { get; set; }
        public Station Station { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("PhenomenonOffering")]
    public class PhenomenonOffering : IdedEntity
    {
        [Required]
        public Guid PhenomenonId { get; set; }
        [Required]
        public Guid OfferingId { get; set; }

        // Navigation
        public Phenomenon Phenomenon { get; set; }
        public Offering Offering { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("PhenomenonUOM")]
    public class PhenomenonUnit : IdedEntity
    {
        [Required]
        public Guid PhenomenonId { get; set; }
        [Required, Column("UnitOfMeasureID")]
        public Guid UnitId { get; set; }

        // Navigation
        public Phenomenon Phenomenon { get; set; }
        public Unit Unit { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("Project_Station")]
    public class ProjectStation : IdedEntity
    {
        public Guid ProjectId { get; set; }
        public Guid StationId { get; set; }
        // Navigation
        public Project Project { get; set; }
        public Station Station { get; set; }
    }

    //[ApiExplorerSettings(IgnoreApi = true)]
    [Table("Station_Instrument")]
    public class StationInstrument : IdedEntity
    {
        public Guid StationId { get; set; }
        public Guid InstrumentId { get; set; }
        // Navigation
        public Station Station { get; set; }
        public Instrument Instrument { get; set; }
    }
    //< Remove once EFCore has many to many
    #endregion


    public class ObservationsDbContext : DbContext
    {
        //#if NET472
        //        public ObservationsDbContext(string tenantConnectionString) : base(tenantConnectionString)
        //        {
        //            //Configuration.ProxyCreationEnabled = false;
        //            //Configuration.LazyLoadingEnabled = false;
        //            var logLevel = ConfigurationManager.AppSettings["EntityFrameworkSAEONLogs"] ?? "Information";
        //            if (logLevel.Equals("Verbose", StringComparison.CurrentCultureIgnoreCase))
        //                Database.Log = s => SAEONLogs.Verbose(s);
        //            //else
        //            //    Database.Log = s => SAEONLogs.Information(s);
        //            Database.CommandTimeout = 30 * 60;
        //        }
        //#else
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContectAccessor;

        public ObservationsDbContext(DbContextOptions<ObservationsDbContext> options, IConfiguration config, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _config = config;
            _httpContectAccessor = httpContextAccessor;
            Database.SetCommandTimeout(30 * 60);
        }

        public DbSet<DataSchema> DataSchemas { get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<DataSourceType> DataSourceTypes { get; set; }
        public DbSet<DigitalObjectIdentifier> DigitalObjectIdentifiers { get; set; }

        public DbSet<ImportBatchSummary> ImportBatchSummary { get; set; }
        public DbSet<InventoryDataset> InventoryDatasets { get; set; }
        public DbSet<InventorySensor> InventorySensors { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Offering> Offerings { get; set; }
        public DbSet<ObservationExpansion> ObservationExpansions { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationRole> OrganisationRoles { get; set; }
        public DbSet<Phenomenon> Phenomena { get; set; }
        public DbSet<PhenomenonOffering> PhenomenonOfferings { get; set; }
        public DbSet<PhenomenonUnit> PhenomenonUnits { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Dataset> Datasets { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UserDownload> UserDownloads { get; set; }
        public DbSet<UserQuery> UserQueries { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Feature> Features { get; set; }

        // SensorThings
        public DbSet<SensorThingsDatastream> SensorThingsDatastreams { get; set; }
        public DbSet<SensorThingsFeatureOfInterest> SensorThingsFeaturesOfInterest { get; set; }
        public DbSet<SensorThingsHistoricalLocation> SensorThingsHistoricalLocations { get; set; }
        public DbSet<SensorThingsLocation> SensorThingsLocations { get; set; }
        public DbSet<SensorThingsObservation> SensorThingsObservations { get; set; }
        public DbSet<SensorThingsObservedProperty> SensorThingsObservedProperies { get; set; }
        public DbSet<SensorThingsSensor> SensorThingsSensors { get; set; }
        public DbSet<SensorThingsThing> SensorThingsThings { get; set; }

        //#if NET472
        //        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //        {
        //            base.OnModelCreating(modelBuilder);
        //            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
        //            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //            //modelBuilder.Entity<Phenomenon>()
        //            //    .HasMany<Offering>(l => l.Offerings)
        //            //    .WithMany(r => r.Phenomena)
        //            //    .Map(cs =>
        //            //    {
        //            //        cs.MapLeftKey("PhenomenonID");
        //            //        cs.MapRightKey("OfferingID");
        //            //        cs.ToTable("PhenomenonOffering");
        //            //    });
        //            //modelBuilder.Entity<Phenomenon>()
        //            //    .HasMany<Unit>(l => l.Units)
        //            //    .WithMany(r => r.Phenomena)
        //            //    .Map(cs =>
        //            //    {
        //            //        cs.MapLeftKey("PhenomenonID");
        //            //        cs.MapRightKey("UnitOfMeasureID");
        //            //        cs.ToTable("PhenomenonUOM");
        //            //    });
        //            modelBuilder.Entity<Instrument>()
        //                .HasMany<Sensor>(l => l.Sensors)
        //                .WithMany(r => r.Instruments)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("InstrumentID");
        //                    cs.MapRightKey("SensorID");
        //                    cs.ToTable("Instrument_Sensor");
        //                });
        //            modelBuilder.Entity<Organisation>()
        //                .HasMany<Site>(l => l.Sites)
        //                .WithMany(r => r.Organisations)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("OrganisationID");
        //                    cs.MapRightKey("SiteID");
        //                    cs.ToTable("Organisation_Site");
        //                });
        //            modelBuilder.Entity<Organisation>()
        //                .HasMany<Station>(l => l.Stations)
        //                .WithMany(r => r.Organisations)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("OrganisationID");
        //                    cs.MapRightKey("StationID");
        //                    cs.ToTable("Organisation_Station");
        //                });
        //            modelBuilder.Entity<Organisation>()
        //                .HasMany<Instrument>(l => l.Instruments)
        //                .WithMany(r => r.Organisations)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("OrganisationID");
        //                    cs.MapRightKey("InstrumentID");
        //                    cs.ToTable("Organisation_Instrument");
        //                });
        //            modelBuilder.Entity<Project>()
        //                .HasMany<Station>(l => l.Stations)
        //                .WithMany(r => r.Projects)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("ProjectID");
        //                    cs.MapRightKey("StationID");
        //                    cs.ToTable("Project_Station");
        //                });
        //            modelBuilder.Entity<Station>()
        //                .HasMany<Instrument>(l => l.Instruments)
        //                .WithMany(r => r.Stations)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("StationID");
        //                    cs.MapRightKey("InstrumentID");
        //                    cs.ToTable("Station_Instrument");
        //                });
        //            modelBuilder.Entity<Unit>().Property(p => p.Name).HasColumnName("Unit");
        //        }
        //#else
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            using (SAEONLogs.MethodCall(GetType()))
            {
                var tenant = TenantAuthenticationHandler.GetTenantFromHeaders(_httpContectAccessor.HttpContext.Request, _config);
                var connectionString = _config.GetConnectionString(tenant);
                optionsBuilder.UseSqlServer(connectionString);
                //SAEONLogs.Debug("Tenant: {Tenant} ConnectionString: {ConnectionString}", tenant, connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Feature>().HasNoKey().ToView("vFeatures");
            modelBuilder.Entity<Location>().HasNoKey().ToView("vLocations");
            modelBuilder.Entity<InventoryDataset>().HasNoKey().ToView("vInventoryDatasets");
            modelBuilder.Entity<InventorySensor>().HasNoKey().ToView("vInventorySensors");
            modelBuilder.Entity<Dataset>().HasNoKey().ToView("vStationDatasets");
            modelBuilder.Entity<DigitalObjectIdentifier>().Property("DOIType").HasConversion<byte>();
            modelBuilder.Entity<DigitalObjectIdentifier>().HasOne(i => i.Parent).WithMany(i => i.Children).HasForeignKey(i => i.ParentID);
            //> Remove once EFCore has many to many
            modelBuilder.Entity<InstrumentSensor>().HasKey(e => new { e.InstrumentId, e.SensorId });
            modelBuilder.Entity<InstrumentSensor>().HasOne(i => i.Instrument).WithMany(i => i.InstrumentSensors).HasForeignKey(pt => pt.InstrumentId);
            modelBuilder.Entity<InstrumentSensor>().HasOne(i => i.Sensor).WithMany(i => i.InstrumentSensors).HasForeignKey(pt => pt.SensorId);
            modelBuilder.Entity<OrganisationInstrument>().HasKey(e => new { e.OrganisationId, e.InstrumentId });
            modelBuilder.Entity<OrganisationInstrument>().HasOne(i => i.Organisation).WithMany(i => i.OrganisationInstruments).HasForeignKey(i => i.OrganisationId);
            modelBuilder.Entity<OrganisationInstrument>().HasOne(i => i.Instrument).WithMany(i => i.OrganisationInstruments).HasForeignKey(i => i.InstrumentId);
            modelBuilder.Entity<OrganisationSite>().HasKey(e => new { e.OrganisationId, e.SiteId });
            modelBuilder.Entity<OrganisationSite>().HasOne(i => i.Organisation).WithMany(i => i.OrganisationSites).HasForeignKey(i => i.OrganisationId);
            modelBuilder.Entity<OrganisationSite>().HasOne(i => i.Site).WithMany(i => i.OrganisationSites).HasForeignKey(i => i.SiteId);
            modelBuilder.Entity<OrganisationStation>().HasKey(e => new { e.OrganisationId, e.StationId });
            modelBuilder.Entity<OrganisationStation>().HasOne(i => i.Organisation).WithMany(i => i.OrganisationStations).HasForeignKey(i => i.OrganisationId);
            modelBuilder.Entity<OrganisationStation>().HasOne(i => i.Station).WithMany(i => i.OrganisationStations).HasForeignKey(i => i.StationId);
            modelBuilder.Entity<PhenomenonOffering>().HasKey(e => new { e.PhenomenonId, e.OfferingId });
            modelBuilder.Entity<PhenomenonOffering>().HasOne(i => i.Phenomenon).WithMany(i => i.PhenomenonOfferings).HasForeignKey(i => i.PhenomenonId);
            modelBuilder.Entity<PhenomenonOffering>().HasOne(i => i.Offering).WithMany(i => i.PhenomenonOfferings).HasForeignKey(i => i.OfferingId);
            modelBuilder.Entity<PhenomenonUnit>().HasKey(e => new { e.PhenomenonId, e.UnitId });
            modelBuilder.Entity<PhenomenonUnit>().HasOne(i => i.Phenomenon).WithMany(i => i.PhenomenonUnits).HasForeignKey(i => i.PhenomenonId);
            modelBuilder.Entity<PhenomenonUnit>().HasOne(i => i.Unit).WithMany(i => i.PhenomenonUnits).HasForeignKey(i => i.UnitId);
            modelBuilder.Entity<ProjectStation>().HasKey(e => new { e.ProjectId, e.StationId });
            modelBuilder.Entity<ProjectStation>().HasOne(i => i.Project).WithMany(i => i.ProjectStations).HasForeignKey(i => i.ProjectId);
            modelBuilder.Entity<ProjectStation>().HasOne(i => i.Station).WithMany(i => i.ProjectStations).HasForeignKey(i => i.StationId);
            modelBuilder.Entity<StationInstrument>().HasKey(e => new { e.StationId, e.InstrumentId });
            modelBuilder.Entity<StationInstrument>().HasOne(i => i.Station).WithMany(i => i.StationInstruments).HasForeignKey(i => i.StationId);
            modelBuilder.Entity<StationInstrument>().HasOne(i => i.Instrument).WithMany(i => i.StationInstruments).HasForeignKey(i => i.InstrumentId);
            //< Remove once EFCore has many to many
        }
    }
}
