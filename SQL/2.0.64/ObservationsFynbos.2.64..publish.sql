﻿/*
Deployment script for ObservationsFynbos

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ObservationsFynbos"
:setvar DefaultFilePrefix "ObservationsFynbos"
:setvar DefaultDataPath "D:\Program Files\Microsoft SQL Server\MSSQL15.SAEON2019\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Program Files\Microsoft SQL Server\MSSQL15.SAEON2019\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


--GO
--IF EXISTS (SELECT 1
--           FROM   [master].[dbo].[sysdatabases]
--           WHERE  [name] = N'$(DatabaseName)')
--    BEGIN
--        ALTER DATABASE [$(DatabaseName)]
--            SET TEMPORAL_HISTORY_RETENTION ON 
--            WITH ROLLBACK IMMEDIATE;
--    END


GO
/*
The column [dbo].[DigitalObjectIdentifiers].[Title] on table [dbo].[DigitalObjectIdentifiers] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[DigitalObjectIdentifiers])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[UserDownloads].[Citation] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[ElevationMaximum] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[ElevationMinimum] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[EndDate] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[Keywords] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[LatitudeNorth] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[LatitudeSouth] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[LongitudeEast] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[LongitudeWest] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[MetadataJson] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[MetadataURL] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[OpenDataPlatformID] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[Places] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[StartDate] is being dropped, data loss could occur.

The column [dbo].[UserDownloads].[Title] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[UserDownloads])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping Index [dbo].[Observation].[IX_Observation_ValueDecade]...';


GO
DROP INDEX [IX_Observation_ValueDecade]
    ON [dbo].[Observation];


GO
PRINT N'Dropping Index [dbo].[Observation].[IX_Observation_ValueYear]...';


GO
DROP INDEX [IX_Observation_ValueYear]
    ON [dbo].[Observation];


GO
PRINT N'Dropping Index [dbo].[Observation].[IX_Observation_SensorID]...';


GO
DROP INDEX [IX_Observation_SensorID]
    ON [dbo].[Observation];


GO
PRINT N'Dropping Index [dbo].[Observation].[IX_Observation_StatusID]...';


GO
DROP INDEX [IX_Observation_StatusID]
    ON [dbo].[Observation];


GO
PRINT N'Dropping Unique Constraint [dbo].[UX_Observation]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [UX_Observation];


GO
PRINT N'Altering Table [dbo].[DigitalObjectIdentifiers]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[DigitalObjectIdentifiers]
    ADD [Title]        VARCHAR (5000) NOT NULL,
        [CitationHtml] VARCHAR (5000) NULL,
        [CitationText] VARCHAR (5000) NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering Table [dbo].[ImportBatchSummary]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[ImportBatchSummary]
    ADD [VerifiedCount] INT NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating Index [dbo].[ImportBatchSummary].[IX_ImportBatchSummary_ElevationMaximum]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatchSummary_ElevationMaximum]
    ON [dbo].[ImportBatchSummary]([ElevationMaximum] ASC);


GO
PRINT N'Creating Index [dbo].[ImportBatchSummary].[IX_ImportBatchSummary_ElevationMinimum]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatchSummary_ElevationMinimum]
    ON [dbo].[ImportBatchSummary]([ElevationMinimum] ASC);


GO
PRINT N'Creating Index [dbo].[ImportBatchSummary].[IX_ImportBatchSummary_LatitudeNorth]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatchSummary_LatitudeNorth]
    ON [dbo].[ImportBatchSummary]([LatitudeNorth] ASC);


GO
PRINT N'Creating Index [dbo].[ImportBatchSummary].[IX_ImportBatchSummary_LatitudeSouth]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatchSummary_LatitudeSouth]
    ON [dbo].[ImportBatchSummary]([LatitudeSouth] ASC);


GO
PRINT N'Creating Index [dbo].[ImportBatchSummary].[IX_ImportBatchSummary_LongitudeEast]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatchSummary_LongitudeEast]
    ON [dbo].[ImportBatchSummary]([LongitudeEast] ASC);


GO
PRINT N'Creating Index [dbo].[ImportBatchSummary].[IX_ImportBatchSummary_LongitudeWest]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatchSummary_LongitudeWest]
    ON [dbo].[ImportBatchSummary]([LongitudeWest] ASC);


GO
PRINT N'Altering Table [dbo].[Observation]...';


GO
ALTER TABLE [dbo].[Observation] DROP COLUMN [ValueYear], COLUMN [ValueDecade];


GO
ALTER TABLE [dbo].[Observation]
    ADD [ValueYear]   AS (Year([ValueDate])),
        [ValueDecade] AS (Year([ValueDate]) / 10 * 10);


GO
PRINT N'Creating Unique Constraint [dbo].[UX_Observation]...';


GO
ALTER TABLE [dbo].[Observation]
    ADD CONSTRAINT [UX_Observation] UNIQUE NONCLUSTERED ([SensorID] ASC, [ValueDate] ASC, [PhenomenonOfferingID] ASC, [PhenomenonUOMID] ASC, [Elevation] ASC) ON [Observations];


GO
PRINT N'Creating Index [dbo].[Observation].[IX_Observation_ValueDecade]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueDecade]
    ON [dbo].[Observation]([ValueDecade] ASC)
    ON [Observations];


GO
PRINT N'Creating Index [dbo].[Observation].[IX_Observation_ValueYear]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueYear]
    ON [dbo].[Observation]([ValueYear] ASC)
    ON [Observations];


GO
PRINT N'Creating Index [dbo].[Observation].[IX_Observation_SensorID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_SensorID]
    ON [dbo].[Observation]([SensorID] ASC)
    INCLUDE([ValueDate], [DataValue], [PhenomenonOfferingID], [PhenomenonUOMID], [ImportBatchID], [Elevation], [Latitude], [Longitude], [ValueDay])
    ON [Observations];


GO
PRINT N'Creating Index [dbo].[Observation].[IX_Observation_StatusID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_StatusID]
    ON [dbo].[Observation]([StatusID] ASC)
    INCLUDE([SensorID], [PhenomenonOfferingID], [PhenomenonUOMID], [ImportBatchID])
    ON [Observations];


GO
PRINT N'Altering Table [dbo].[UserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[UserDownloads] DROP COLUMN [Citation], COLUMN [ElevationMaximum], COLUMN [ElevationMinimum], COLUMN [EndDate], COLUMN [Keywords], COLUMN [LatitudeNorth], COLUMN [LatitudeSouth], COLUMN [LongitudeEast], COLUMN [LongitudeWest], COLUMN [MetadataJson], COLUMN [MetadataURL], COLUMN [OpenDataPlatformID], COLUMN [Places], COLUMN [StartDate], COLUMN [Title];


GO
ALTER TABLE [dbo].[UserDownloads]
    ADD [IsDeleted] BIT NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vUserDownloads]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vUserDownloads]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering View [dbo].[vImportBatchSummary]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vImportBatchSummary]
AS 
Select
  ImportBatchSummary.*, 
  Phenomenon.ID PhenomenonID, Phenomenon.Code PhenomenonCode, Phenomenon.Name PhenomenonName, Phenomenon.Description PhenomenonDescription, Phenomenon.Url PhenomenonUrl,
  OfferingID OfferingID, Offering.Code OfferingCode, Offering.Name OfferingName, Offering.Description OfferingDescription, 
  UnitOfMeasureID, UnitOfMeasure.Code UnitOfMeasureCode, UnitOfMeasure.Unit UnitOfMeasureUnit, UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Sensor.Code SensorCode, Sensor.Name SensorName, Sensor.Description SensorDescription,  Sensor.Url SensorUrl,
  Instrument.Code InstrumentCode, Instrument.Name InstrumentName, Instrument.Description InstrumentDescription, Instrument.Url InstrumentUrl,
  Station.Code StationCode, Station.Name StationName, Station.Description StationDescription, Station.Url StationUrl,
  Site.Code SiteCode, Site.Name SiteName, Site.Description SiteDescription, Site.Url SiteUrl,
  Project.ID ProjectID, Project.Code ProjectCode, Project.Name ProjectName, Project.Description ProjectDescription, Project.Url ProjectUrl,
  Programme.ID ProgrammeID, Programme.Code ProgrammeCode, Programme.Name ProgrammeName, Programme.Description ProgrammeDescription, Programme.Url ProgrammeUrl,
  Organisation.ID OrganisationID, Organisation.Code OrganisationCode, Organisation.Name OrganisationName, Organisation.Description OrganisationDescription, Organisation.Url OrganisationUrl
From
  ImportBatchSummary
  inner join Sensor
    on (ImportBatchSummary.SensorID = Sensor.ID)
  inner join Instrument
    on (ImportBatchSummary.InstrumentID = Instrument.ID)
  inner join Station
    on (ImportBatchSummary.StationID = Station.ID)
  inner join Site
    on (ImportBatchSummary.SiteID = Site.ID)
  inner join PhenomenonOffering
    on (ImportBatchSummary.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (ImportBatchSummary.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  left join Project_Station
    on (Project_Station.StationID = Station.ID)
  left join Project
    on (Project_Station.ProjectID = Project.ID)
  left join Programme
    on (Project.ProgrammeID = Programme.ID)
  left join vStationOrganisation
    on (vStationOrganisation.StationID = Station.ID)
  left join Organisation
    on (vStationOrganisation.OrganisationID = Organisation.ID)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering View [dbo].[vFeatures]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vFeatures]
AS 
Select distinct
  PhenomenonID, PhenomenonName, PhenomenonUrl,
  PhenomenonOfferingID, OfferingID, OfferingName,
  PhenomenonUOMID, UnitOfMeasureID, UnitOfMeasureUnit
from
  vImportBatchSummary
where
  (Count > 0) and 
  (LatitudeNorth is not null) and (LatitudeSouth is not null) and 
  (LongitudeEast is not null) and (LongitudeWest is not null)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vInventorySensors]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vInventorySensors]';


GO
PRINT N'Altering View [dbo].[vLocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vLocations]
AS
Select distinct
  OrganisationID, OrganisationName, OrganisationUrl,
  ProgrammeID, ProgrammeName, ProgrammeUrl,
  ProjectID, ProjectName, ProjectUrl,
  SiteID, SiteName, SiteUrl,
  StationID, StationName, StationUrl,
  (LatitudeNorth + LatitudeSouth) / 2 Latitude,
  (LongitudeWest + LongitudeEast) / 2 Longitude,
  (ElevationMaximum + ElevationMinimum) / 2 Elevation
from
  vImportBatchSummary
where
  (Count > 0) and (ProjectID is not null)
  --and 
  --(LatitudeNorth is not null) and (LatitudeSouth is not null) and
  --(LongitudeWest is not null) and (LongitudeEast is not null)
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vStationDatasets]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vStationDatasets]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPIDatastreams]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIDatastreams]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPILocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPILocations]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPIObservedProperties]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIObservedProperties]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPISensors]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPISensors]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPIThings]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIThings]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPIFeaturesOfInterest]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIFeaturesOfInterest]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPIHistoricalLocations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIHistoricalLocations]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering View [dbo].[vObservationExpansion]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER VIEW [dbo].[vObservationExpansion]
AS
Select distinct
  Observation.ID, Observation.ImportBatchID, ImportBatch.Code ImportBatchCode, ImportBatch.ImportDate ImportBatchDate, 
  Observation.ValueDate, Observation.ValueDay, Observation.ValueYear, Observation.ValueDecade, 
  Observation.RawValue, Observation.DataValue, Observation.TextValue, 
  Observation.Comment, Observation.CorrelationID,
  Site.ID SiteID, Site.Code SiteCode, Site.Name SiteName, Site.Description SiteDescription, Site.Url SiteUrl,
  Station.ID StationID, Station.Code StationCode, Station.Name StationName, Station.Description StationDescription, Station.Url StationUrl,
  Instrument.ID InstrumentID, Instrument.Code InstrumentCode, Instrument.Name InstrumentName, Instrument.Description InstrumentDescription, Instrument.Url InstrumentUrl,
  Observation.SensorID, Sensor.Code SensorCode, Sensor.Name SensorName, Sensor.Description SensorDescription, Sensor.Url SensorUrl,
  Coalesce(Observation.Latitude, Sensor.Latitude, Instrument_Sensor.Latitude, Instrument.Latitude, Station_Instrument.Latitude, Station.Latitude) Latitude,
  Coalesce(Observation.Longitude, Sensor.Longitude, Instrument_Sensor.Longitude, Instrument.Longitude, Station_Instrument.Longitude, Station.Longitude) Longitude,
  Coalesce(Observation.Elevation, Sensor.Elevation, Instrument_Sensor.Elevation, Instrument.Elevation, Station_Instrument.Elevation, Station.Elevation) Elevation,
  Observation.PhenomenonOfferingID, Phenomenon.ID PhenomenonID, Phenomenon.Code PhenomenonCode, Phenomenon.Name PhenomenonName, Phenomenon.Description PhenomenonDescription, Phenomenon.Url PhenomenonUrl,
  Offering.ID OfferingID, Offering.Code OfferingCode, Offering.Name OfferingName, Offering.Description OfferingDescription,
  Observation.PhenomenonUOMID, UnitOfMeasure.ID UnitOfMeasureID, UnitOfMeasure.Code UnitOfMeasureCode, UnitOfMeasure.Unit UnitOfMeasureUnit, UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Observation.StatusID, Status.Code StatusCode, Status.Name StatusName, Status.Description StatusDescription,
  Observation.StatusReasonID, StatusReason.Code StatusReasonCode, StatusReason.Name StatusReasonName, StatusReason.Description StatusReasonDescription,
  Observation.UserId, Observation.AddedDate, Observation.AddedAt, Observation.UpdatedAt
from
  Observation
  inner join ImportBatch
    on (Observation.ImportBatchID = ImportBatch.ID)
  inner join Sensor
    on (Observation.SensorID = Sensor.ID)
  inner join Instrument_Sensor
    on (Observation.SensorID = Instrument_Sensor.SensorID) 
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) 
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument_Sensor.InstrumentID) 
  inner join Station
    on (Station_Instrument.StationID = Station.ID) 
  inner join Site
    on (Station.SiteID = Site.ID) 
  inner join PhenomenonOffering
    on (Observation.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Phenomenon
    on (PhenomenonOffering.PhenomenonID = Phenomenon.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (Observation.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  left join Status
    on (Observation.StatusID = Status.ID)
  left join StatusReason
    on (Observation.StatusReasonID = StatusReason.ID)
Where
  ((Instrument_Sensor.StartDate is null) or (Observation.ValueDate >= Instrument_Sensor.StartDate)) and
  ((Instrument_Sensor.EndDate is null) or (Observation.ValueDate <= Instrument_Sensor.EndDate)) and
  ((Instrument.StartDate is null) or (Observation.ValueDay >= Instrument.StartDate)) and
  ((Instrument.EndDate is null) or (Observation.ValueDay <= Instrument.EndDate)) and
  ((Station_Instrument.StartDate is null) or (Observation.ValueDay >= Station_Instrument.StartDate)) and
  ((Station_Instrument.EndDate is null) or (Observation.ValueDay <= Station_Instrument.EndDate)) and
  ((Station.StartDate is null) or (Observation.ValueDay >= Station.StartDate))  and
  ((Station.EndDate is null) or (Observation.ValueDay <= Station.EndDate)) and
  ((Site.StartDate is null) or (Observation.ValueDay >= Site.StartDate)) and
  ((Site.EndDate is null) or (Observation.ValueDay <= Site.EndDate))
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vSensorThingsAPIObservations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSensorThingsAPIObservations]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vObservation]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservation]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vObservationJSON]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationJSON]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing View [dbo].[vStationObservations]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vStationObservations]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Altering View [dbo].[vDataLog]...';


GO
ALTER VIEW [dbo].[vDataLog]
AS

SELECT 
d.ID, 
d.ImportDate,
Site.Name SiteName,
Station.Name StationName,
Instrument.Name InstrumentName,
d.SensorID,
Sensor.Name SensorName,
CASE 
    WHEN d.SensorID is null then 1
    ELSE 0
END SensorInvalid,

d.ValueDate,
d.InvalidDateValue, 
CASE 
    WHEN ValueDate is null then 1
    ELSE 0
END DateValueInvalid,

d.InvalidTimeValue, 
CASE 
    WHEN InvalidTimeValue is not null then 1
    ELSE 0
END TimeValueInvalid,

CASE 
    WHEN InvalidDateValue is null AND InvalidTimeValue IS NULL Then ValueDate
    WHEN ValueTime is not null then ValueTime 
END ValueTime,


d.RawValue,
d.ValueText,
CASE
    WHEN d.RawValue is null then 1
    ELSE 0
END RawValueInvalid,	

d.DataValue,
d.TransformValueText, 
CASE
    WHEN d.DataValue is null then 1
    ELSE 0
END DataValueInvalid,

d.PhenomenonOfferingID, 
CASE
    WHEN d.PhenomenonOfferingID is null then 1
    ELSE 0
END OfferingInvalid,

d.PhenomenonUOMID, 
CASE
    WHEN d.PhenomenonUOMID is null then 1
    ELSE 0
END UOMInvalid,

p.Name PhenomenonName,
o.Name OfferingName,
uom.Unit,

d.DataSourceTransformationID,
tt.Name Transformation,
d.StatusID,
s.Name [Status],
d.ImportBatchID,
d.RawFieldValue,
d.Comment

FROM DataLog d
  left join Sensor 
    on (d.SensorID = Sensor.ID) 
  left join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) 
  left join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) 
  left join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) 
  left join Station 
    on (Station_Instrument.StationID = Station.ID) 
  left join Site
    on (Station.SiteID = Site.ID) 
  LEFT JOIN PhenomenonOffering po
    ON d.PhenomenonOfferingID = po.ID
  LEFT JOIN Phenomenon p
    on po.PhenomenonID = p.ID
  LEFT JOIN Offering o
    on po.OfferingID = o.ID
  LEFT JOIN PhenomenonUOM pu
    on d.PhenomenonUOMID = pu.ID
  LEFT JOIN UnitOfMeasure uom
    on pu.UnitOfMeasureID = uom.ID
  LEFT JOIN DataSourceTransformation ds
    on d.DataSourceTransformationID = ds.ID
  LEFT JOIN TransformationType tt
    on ds.TransformationTypeID = tt.ID
  INNER JOIN [Status] s
    on d.StatusID = s.ID
-- Need out of date observations in datalog
--WHERE
--  ((Instrument_Sensor.StartDate is null) or (d.ValueDate >= Instrument_Sensor.StartDate)) and
--  ((Instrument_Sensor.EndDate is null) or (d.ValueDate <= Instrument_Sensor.EndDate)) and
--  ((Instrument.StartDate is null) or (d.ValueDay >= Instrument.StartDate )) and
--  ((Instrument.EndDate is null) or (d.ValueDay <= Instrument.EndDate)) and
--  ((Station_Instrument.StartDate is null) or (d.ValueDay >= Station_Instrument.StartDate)) and
--  ((Station_Instrument.EndDate is null) or (d.ValueDay <= Station_Instrument.EndDate)) and
--  ((Station.StartDate is null) or (d.ValueDay >= Station.StartDate)) and
--  ((Station.EndDate is null) or (d.ValueDay <= Station.EndDate)) and
--  ((Site.StartDate is null) or  (d.ValueDay >= Site.StartDate)) and
--  ((Site.EndDate is null) or  (d.ValueDay <= Site.EndDate))
GO
PRINT N'Creating View [dbo].[vInventoryDatasets]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
CREATE VIEW [dbo].[vInventoryDatasets]
AS 
Select
  Row_Number() over (order by StationCode, PhenomenonCode, OfferingCode, UnitOfMeasureCode) ID, s.*
from
(
Select
  OrganisationID, OrganisationCode, OrganisationName, OrganisationDescription, OrganisationUrl,
  ProgrammeID, ProgrammeCode, ProgrammeName, ProgrammeDescription, ProgrammeUrl,
  ProjectID, ProjectCode, ProjectName, ProjectDescription, ProjectUrl,
  SiteID, SiteCode, SiteName, SiteDescription, SiteUrl,
  StationID, StationCode, StationName, StationDescription, StationUrl,
  PhenomenonID, PhenomenonCode, PhenomenonName, PhenomenonDescription, PhenomenonUrl,
  PhenomenonOfferingID, OfferingID, OfferingCode, OfferingName, OfferingDescription,
  PhenomenonUOMID, UnitOfMeasureID, UnitOfMeasureCode, UnitOfMeasureUnit, UnitOfMeasureSymbol,
  Sum(Count) Count,
  Sum(VerifiedCount) VerifiedCount,
  Min(StartDate) StartDate,
  Max(EndDate) EndDate,
  Max(LatitudeNorth) LatitudeNorth,
  Min(LatitudeSouth) LatitudeSouth,
  Min(LongitudeWest) LongitudeWest,
  Max(LongitudeEast) LongitudeEast,
  Min(ElevationMinimum) ElevationMinimum,
  Max(ElevationMaximum) ElevationMaximum
from
  vImportBatchSummary
group by
  OrganisationID, OrganisationCode, OrganisationName, OrganisationDescription, OrganisationUrl,
  ProgrammeID, ProgrammeCode, ProgrammeName, ProgrammeDescription, ProgrammeUrl,
  ProjectID, ProjectCode, ProjectName, ProjectDescription, ProjectUrl,
  SiteID, SiteCode, SiteName, SiteDescription, SiteUrl,
  StationID, StationCode, StationName, StationDescription, StationUrl,
  PhenomenonID, PhenomenonCode, PhenomenonName, PhenomenonDescription, PhenomenonUrl,
  PhenomenonOfferingID, OfferingID, OfferingCode, OfferingName, OfferingDescription,
  PhenomenonUOMID, UnitOfMeasureID, UnitOfMeasureCode, UnitOfMeasureUnit, UnitOfMeasureSymbol
) s
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Update complete.';


GO
