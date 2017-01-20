﻿/*
Deployment script for ObservationsTest

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ObservationsTest"
:setvar DefaultFilePrefix "ObservationsTest"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SAEON\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.SAEON\MSSQL\DATA\"

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


GO
PRINT N'Dropping [dbo].[DF_ImportBatch_ImportDate]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [DF_ImportBatch_ImportDate];


GO
PRINT N'Dropping [dbo].[DF_ImportBatch_AddedAt]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [DF_ImportBatch_AddedAt];


GO
PRINT N'Dropping [dbo].[DF_ImportBatch_UpdatedAt]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [DF_ImportBatch_UpdatedAt];


GO
PRINT N'Dropping [dbo].[DF_ImportBatch_ID]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [DF_ImportBatch_ID];


GO
PRINT N'Dropping [dbo].[FK_Observation_ImportBatch]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_ImportBatch];


GO
PRINT N'Dropping [dbo].[FK_Progress_ImportBatch]...';


GO
ALTER TABLE [dbo].[Progress] DROP CONSTRAINT [FK_Progress_ImportBatch];


GO
PRINT N'Dropping [dbo].[FK_DataLog_ImportBatch]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_ImportBatch];


GO
PRINT N'Dropping [dbo].[FK_ImportBatch_DataSource]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [FK_ImportBatch_DataSource];


GO
PRINT N'Dropping [dbo].[FK_ImportBatch_aspnet_Users]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [FK_ImportBatch_aspnet_Users];


GO
PRINT N'Dropping [dbo].[FK_ImportBatch_Status]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [FK_ImportBatch_Status];


GO
PRINT N'Dropping [dbo].[FK_ImportBatch_StatusReason]...';


GO
ALTER TABLE [dbo].[ImportBatch] DROP CONSTRAINT [FK_ImportBatch_StatusReason];


GO
PRINT N'Starting rebuilding table [dbo].[ImportBatch]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ImportBatch] (
    [ID]             UNIQUEIDENTIFIER           CONSTRAINT [DF_ImportBatch_ID] DEFAULT newid() ROWGUIDCOL NOT NULL,
    [Code]           INT                        IDENTITY (1, 1) NOT NULL,
    [DataSourceID]   UNIQUEIDENTIFIER           NOT NULL,
    [ImportDate]     DATETIME                   CONSTRAINT [DF_ImportBatch_ImportDate] DEFAULT getdate() NOT NULL,
    [Status]         INT                        NOT NULL,
    [UserId]         UNIQUEIDENTIFIER           NOT NULL,
    [FileName]       VARCHAR (250)              NULL,
    [LogFileName]    VARCHAR (250)              NULL,
    [Comment]        VARCHAR (8000)             NULL,
    [StatusID]       UNIQUEIDENTIFIER           NULL,
    [StatusReasonID] UNIQUEIDENTIFIER           NULL,
    [Problems]       VARCHAR (1000)             NULL,
    [SourceFile]     VARBINARY (MAX) FILESTREAM NULL,
    [Pass1File]      VARBINARY (MAX) FILESTREAM NULL,
    [Pass2File]      VARBINARY (MAX) FILESTREAM NULL,
    [Pass3File]      VARBINARY (MAX) FILESTREAM NULL,
    [Pass4File]      VARBINARY (MAX) FILESTREAM NULL,
    [AddedAt]        DATETIME                   CONSTRAINT [DF_ImportBatch_AddedAt] DEFAULT GetDate() NULL,
    [UpdatedAt]      DATETIME                   CONSTRAINT [DF_ImportBatch_UpdatedAt] DEFAULT GetDate() NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ImportBatch1] PRIMARY KEY NONCLUSTERED ([ID] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_UX_ImportBatch_Code1] UNIQUE NONCLUSTERED ([Code] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_UX_ImportBatch1] UNIQUE NONCLUSTERED ([DataSourceID] ASC, [ImportDate] ASC, [LogFileName] ASC)
);

CREATE UNIQUE CLUSTERED INDEX [tmp_ms_xx_index_CX_ImportBatch1]
    ON [dbo].[tmp_ms_xx_ImportBatch]([AddedAt] ASC);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ImportBatch])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ImportBatch] ON;
        INSERT INTO [dbo].[tmp_ms_xx_ImportBatch] ([AddedAt], [ID], [Code], [DataSourceID], [ImportDate], [Status], [UserId], [FileName], [LogFileName], [Comment], [StatusID], [StatusReasonID], [SourceFile], [Pass1File], [Pass2File], [Pass3File], [Pass4File], [UpdatedAt])
        SELECT   [AddedAt],
                 [ID],
                 [Code],
                 [DataSourceID],
                 [ImportDate],
                 [Status],
                 [UserId],
                 [FileName],
                 [LogFileName],
                 [Comment],
                 [StatusID],
                 [StatusReasonID],
                 [SourceFile],
                 [Pass1File],
                 [Pass2File],
                 [Pass3File],
                 [Pass4File],
                 [UpdatedAt]
        FROM     [dbo].[ImportBatch]
        ORDER BY [AddedAt] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_ImportBatch] OFF;
    END

DROP TABLE [dbo].[ImportBatch];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ImportBatch]', N'ImportBatch';

EXECUTE sp_rename N'[dbo].[ImportBatch].[tmp_ms_xx_index_CX_ImportBatch1]', N'CX_ImportBatch', N'INDEX';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ImportBatch1]', N'PK_ImportBatch', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UX_ImportBatch_Code1]', N'UX_ImportBatch_Code', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UX_ImportBatch1]', N'UX_ImportBatch', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[ImportBatch].[IX_ImportBatch_DataSourceID]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatch_DataSourceID]
    ON [dbo].[ImportBatch]([DataSourceID] ASC);


GO
PRINT N'Creating [dbo].[ImportBatch].[IX_ImportBatch_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatch_UserId]
    ON [dbo].[ImportBatch]([UserId] ASC);


GO
PRINT N'Creating [dbo].[ImportBatch].[IX_ImportBatch_ImportDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatch_ImportDate]
    ON [dbo].[ImportBatch]([DataSourceID] ASC, [ImportDate] ASC);


GO
PRINT N'Creating [dbo].[ImportBatch].[IX_ImportBatch_LogFileName]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatch_LogFileName]
    ON [dbo].[ImportBatch]([DataSourceID] ASC, [LogFileName] ASC);


GO
PRINT N'Creating [dbo].[ImportBatch].[IX_ImportBatch_StatusID]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatch_StatusID]
    ON [dbo].[ImportBatch]([StatusID] ASC);


GO
PRINT N'Creating [dbo].[ImportBatch].[IX_ImportBatch_StatusReasonID]...';


GO
CREATE NONCLUSTERED INDEX [IX_ImportBatch_StatusReasonID]
    ON [dbo].[ImportBatch]([StatusReasonID] ASC);


GO
PRINT N'Creating [dbo].[FK_Observation_ImportBatch]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Progress_ImportBatch]...';


GO
ALTER TABLE [dbo].[Progress] WITH NOCHECK
    ADD CONSTRAINT [FK_Progress_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_ImportBatch]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[FK_ImportBatch_DataSource]...';


GO
ALTER TABLE [dbo].[ImportBatch] WITH NOCHECK
    ADD CONSTRAINT [FK_ImportBatch_DataSource] FOREIGN KEY ([DataSourceID]) REFERENCES [dbo].[DataSource] ([ID]);


GO
PRINT N'Creating [dbo].[FK_ImportBatch_aspnet_Users]...';


GO
ALTER TABLE [dbo].[ImportBatch] WITH NOCHECK
    ADD CONSTRAINT [FK_ImportBatch_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_ImportBatch_Status]...';


GO
ALTER TABLE [dbo].[ImportBatch] WITH NOCHECK
    ADD CONSTRAINT [FK_ImportBatch_Status] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([ID]);


GO
PRINT N'Creating [dbo].[FK_ImportBatch_StatusReason]...';


GO
ALTER TABLE [dbo].[ImportBatch] WITH NOCHECK
    ADD CONSTRAINT [FK_ImportBatch_StatusReason] FOREIGN KEY ([StatusReasonID]) REFERENCES [dbo].[StatusReason] ([ID]);


GO
PRINT N'Creating [dbo].[TR_ImportBatch_Insert]...';


GO
CREATE TRIGGER [dbo].[TR_ImportBatch_Insert] ON [dbo].[ImportBatch]
FOR INSERT
AS
BEGIN
    SET NoCount ON
    Update
        src
    set
        AddedAt = GETDATE(),
        UpdatedAt = NULL
    from
        ImportBatch src
        inner join inserted ins
            on (ins.ID = src.ID)
END
GO
PRINT N'Creating [dbo].[TR_ImportBatch_Update]...';


GO
CREATE TRIGGER [dbo].[TR_ImportBatch_Update] ON [dbo].[ImportBatch]
FOR UPDATE
AS
BEGIN
    SET NoCount ON
    Update
        src
    set
--> Changed 2.0.19 20161205 TimPN
--		AddedAt = del.AddedAt,
        AddedAt = Coalesce(del.AddedAt, ins.AddedAt, GetDate ()),
--< Changed 2.0.19 20161205 TimPN
        UpdatedAt = GETDATE()
    from
        ImportBatch src
        inner join inserted ins
            on (ins.ID = src.ID)
		inner join deleted del
			on (del.ID = src.ID)
END
--< Changed 2.0.15 20161102 TimPN
--< Added 2.0.8 20160715 TimPN
GO
PRINT N'Refreshing [dbo].[vImportBatch]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vImportBatch]';


GO
PRINT N'Altering [dbo].[vDataLog]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
ALTER VIEW [dbo].[vDataLog]
AS

SELECT 
d.ID, 
d.ImportDate,

--> Added 2.0.17 20161128 TimPN
Site.Name SiteName,
Station.Name StationName,
Instrument.Name InstrumentName,
--< Added 2.0.17 20161128 TimPN
--> Removed 2.0.17 20161128 TimPN
--org.Name Organisation,
--ps.[Description] ProjectSite,
--st.Name StationName,
--< Removed 2.0.17 20161128 TimPN
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

--> Changed 2.0.3 20160421 TimPN
--d.PhenonmenonUOMID, 
d.PhenomenonUOMID, 
--< Changed 2.0.3 20160421 TimPN
CASE
--> Changed 2.0.3 20160421 TimPN
--    WHEN d.PhenonmenonUOMID is null then 1
    WHEN d.PhenomenonUOMID is null then 1
--< Changed 2.0.3 20160421 TimPN
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
--> Removed 2.0.17 20161128 TimPN
--LEFT JOIN Sensor sp
--    on d.SensorID = sp.ID
--LEFT JOIN Station st
--    on sp.StationID = st.ID
--LEFT JOIN ProjectSite ps
--    on st.ProjectSiteID = ps.ID
--LEFT JOIN Organisation org
--    on ps.OrganisationID = org.ID
--< Removed 2.0.17 20161128 TimPN
--> Added 2.0.17 20161128 TimPN
  inner join Sensor 
    on (d.SensorID = Sensor.ID) 
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Instrument_Sensor.StartDate is null) or (d.ValueDate >= Instrument_Sensor.StartDate)) and
--	   ((Instrument_Sensor.EndDate is null) or (d.ValueDate <= Instrument_Sensor.EndDate))
	   ((Instrument_Sensor.StartDate is null) or (Cast(d.ValueDate as Date) >= Instrument_Sensor.StartDate)) and
	   ((Instrument_Sensor.EndDate is null) or (Cast(d.ValueDate as Date) <= Instrument_Sensor.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Instrument.StartDate is null) or (d.ValueDate >= Instrument.StartDate )) and
--	   ((Instrument.EndDate is null) or (d.ValueDate <= Instrument.EndDate))
	   ((Instrument.StartDate is null) or (Cast(d.ValueDate as Date) >= Instrument.StartDate )) and
	   ((Instrument.EndDate is null) or (Cast(d.ValueDate as Date) <= Instrument.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Station_Instrument.StartDate is null) or (d.ValueDate >= Station_Instrument.StartDate)) and
--	   ((Station_Instrument.EndDate is null) or (d.ValueDate <= Station_Instrument.EndDate))
	   ((Station_Instrument.StartDate is null) or (Cast(d.ValueDate as Date) >= Station_Instrument.StartDate)) and
	   ((Station_Instrument.EndDate is null) or (Cast(d.ValueDate as Date) <= Station_Instrument.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Station 
    on (Station_Instrument.StationID = Station.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Station.StartDate is null) or (Cast(d.ValueDate as Date) >= Cast(Station.StartDate as Date))) and
--	   ((Station.EndDate is null) or (Cast(d.ValueDate as Date) <= Cast(Station.EndDate as Date)))
	   ((Station.StartDate is null) or (Cast(d.ValueDate as Date) >= Station.StartDate)) and
	   ((Station.EndDate is null) or (Cast(d.ValueDate as Date) <= Station.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Site
    on (Station.SiteID = Site.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Site.StartDate is null) or  (Cast(d.ValueDate as Date) >= Cast(Site.StartDate as Date))) and
--	   ((Site.EndDate is null) or  (Cast(d.ValueDate as Date) <= Cast(Site.EndDate as Date)))
	   ((Site.StartDate is null) or  (Cast(d.ValueDate as Date) >= Site.StartDate)) and
	   ((Site.EndDate is null) or  (Cast(d.ValueDate as Date) <= Site.EndDate))
--< Changed 2.0.22 20170111 TimPN
--< Added 2.0.17 20161128 TimPN
LEFT JOIN PhenomenonOffering po
 ON d.PhenomenonOfferingID = po.ID
LEFT JOIN Phenomenon p
    on po.PhenomenonID = p.ID
LEFT JOIN Offering o
    on po.OfferingID = o.ID
LEFT JOIN PhenomenonUOM pu
--> Changed 2.0.3 20160421 TimPN
--    on d.PhenonmenonUOMID = pu.ID
    on d.PhenomenonUOMID = pu.ID
--< Changed 2.0.3 20160421 TimPN
LEFT JOIN UnitOfMeasure uom
    on pu.UnitOfMeasureID = uom.ID
LEFT JOIN DataSourceTransformation ds
    on d.DataSourceTransformationID = ds.ID
LEFT JOIN TransformationType tt
    on ds.TransformationTypeID = tt.ID
INNER JOIN [Status] s
    on d.StatusID = s.ID
GO
PRINT N'Altering [dbo].[vInventory]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
--> Removed 2.0.17 20161128 TimPN
--CREATE VIEW [dbo].[vInventory]
--AS
--Select 
-- ps.Name Site,
-- s.Name Station,
-- sp.Name Sensor,
-- p.Name Phenomenon,
-- d.StartDate,
-- d.EndDate
--FROM Station s with (nolock)
-- INNER Join ProjectSite ps with (nolock)
-- on  ps.ID=  s.ProjectSiteID
--INNER Join Sensor sp with (nolock)
-- on s.ID = sp.StationID
--INNER Join Phenomenon p with (nolock)
-- on  sp.PhenomenonID = p.ID 

--INNER JOIN 
--(
-- SELECT SensorID,MIN(ValueDate) StartDate,MAX(ValueDate) EndDate
--  FROM Observation with (nolock)
-- Group By SensorID
--)d
--ON sp.ID = d.SensorID
--< Removed 2.0.17 20161128 TimPN
--> Added 2.0.17 20161128 TimPN
ALTER VIEW [dbo].[vInventory]
AS
Select 
  Site.Name Site,
  Station.Name Station,
  Instrument.Name Instrument,
  Sensor.Name Sensor,
  p.Name Phenomenon,
  d.StartDate,
  d.EndDate
from
  Sensor 
  INNER JOIN 
  (
--> Changed 2.0.22 20170111 TimPN
--     SELECT SensorID,MIN(ValueDate) StartDate,MAX(ValueDate) EndDate
     SELECT SensorID,MIN(Cast(ValueDate as Date)) StartDate,MAX(Cast(ValueDate as Date)) EndDate
--< Changed 2.0.22 20170111 TimPN
     FROM Observation
     Group By SensorID
  ) d
    ON (Sensor.ID = d.SensorID)
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) and
	   ((Instrument_Sensor.StartDate is null) or (d.StartDate >= Instrument_Sensor.StartDate)) and
	   ((Instrument_Sensor.EndDate is null) or (d.EndDate <= Instrument_Sensor.EndDate))
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
	   ((Instrument.StartDate is null) or (d.StartDate >= Instrument.StartDate )) and
	   ((Instrument.EndDate is null) or (d.EndDate <= Instrument.EndDate))
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) and
	   ((Station_Instrument.StartDate is null) or (d.StartDate >= Station_Instrument.StartDate)) and
	   ((Station_Instrument.EndDate is null) or (d.EndDate <= Station_Instrument.EndDate))
  inner join Station 
    on (Station_Instrument.StationID = Station.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Station.StartDate is null) or (Cast(d.StartDate as Date) >= Cast(Station.StartDate as Date))) and
--	   ((Station.EndDate is null) or (Cast(d.EndDate as Date) <= Cast(Station.EndDate as Date)))
	   ((Station.StartDate is null) or (d.StartDate >= Station.StartDate)) and
	   ((Station.EndDate is null) or (d.EndDate <= Station.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Site
    on (Station.SiteID = Site.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Site.StartDate is null) or  (Cast(d.StartDate as Date) >= Cast(Site.StartDate as Date))) and
--	   ((Site.EndDate is null) or  (Cast(d.EndDate as Date) <= Cast(Site.EndDate as Date)))
	   ((Site.StartDate is null) or  (d.StartDate >= Site.StartDate)) and
	   ((Site.EndDate is null) or  (d.EndDate <= Site.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Phenomenon p 
   on (Sensor.PhenomenonID = p.ID )
--< Added 2.0.17 20161128 TimPN
GO
PRINT N'Altering [dbo].[vObservation]...';


GO
--> Changed 2.0.3 20160503 TimPN
--Renamed SensorProcedure to Sensor
--< Changed 2.0.3 20160503 TimPN
ALTER VIEW [dbo].[vObservation]
AS
--> Changed 2.0.16 20161107 TimPN
--> Changed 2.0.3 20160421 TimPN
--SELECT     o.ID, o.SensorID, o.PhenonmenonOfferingID, o.PhenonmenonUOMID, o.UserId, o.RawValue, o.DataValue, o.ImportBatchID, o.ValueDate, 
--SELECT     o.ID, o.SensorID, o.PhenomenonOfferingID, o.PhenomenonUOMID, o.UserId, o.RawValue, o.DataValue, o.ImportBatchID, o.ValueDate, 
--< Changed 2.0.3 20160421 TimPN
--                      sp.Code AS spCode, sp.Description AS spDesc, sp.Name AS spName, sp.Url AS spURL, sp.DataSchemaID, sp.DataSourceID, sp.PhenomenonID, sp.StationID, 
--                      ph.Name AS phName, st.Name AS stName, ds.Name AS dsName, ISNULL(dschema.Name,dschema1.Name) AS dschemaName, offer.Name AS offName, offer.ID AS offID, ps.Name AS psName, 
--                      ps.ID AS psID, org.Name AS orgName, org.ID AS orgID, uom.Unit AS uomUnit, uom.UnitSymbol AS uomSymbol, users.UserName,
--                      o.Comment
--FROM         dbo.Observation AS o INNER JOIN
--                      dbo.Sensor AS sp ON sp.ID = o.SensorID INNER JOIN
--                      dbo.Phenomenon AS ph ON ph.ID = sp.PhenomenonID INNER JOIN
--> Changed 2.0.3 20160421 TimPN
--                      dbo.PhenomenonOffering AS phOff ON phOff.ID = o.PhenonmenonOfferingID INNER JOIN  
--                      dbo.PhenomenonOffering AS phOff ON phOff.ID = o.PhenomenonOfferingID INNER JOIN  
--< Changed 2.0.3 20160421 TimPN
--                      dbo.Offering AS offer ON offer.ID = phOff.OfferingID INNER JOIN
--> Changed 2.0.3 20160421 TimPN
--                      dbo.PhenomenonUOM AS puom ON puom.ID = o.PhenonmenonUOMID INNER JOIN
--                      dbo.PhenomenonUOM AS puom ON puom.ID = o.PhenomenonUOMID INNER JOIN
--< Changed 2.0.3 20160421 TimPN
--                      dbo.Station AS st ON st.ID = sp.StationID INNER JOIN
--                      dbo.DataSource AS ds ON ds.ID = sp.DataSourceID LEFT JOIN
--                      dbo.DataSchema AS dschema1 ON dschema1.ID = ds.DataSchemaID LEFT JOIN
--                      dbo.DataSchema AS dschema ON dschema.ID = sp.DataSchemaID INNER JOIN                   
--                      dbo.ProjectSite AS ps ON ps.ID = st.ProjectSiteID INNER JOIN
--                      dbo.Organisation AS org ON org.ID = ps.OrganisationID INNER JOIN
--                      dbo.UnitOfMeasure AS uom ON uom.ID = puom.UnitOfMeasureID INNER JOIN
--                      dbo.aspnet_Users AS users ON users.UserId = o.UserId 
SELECT 
  o.ID, o.SensorID, o.PhenomenonOfferingID, o.PhenomenonUOMID, o.RawValue, o.DataValue, o.ImportBatchID, o.ValueDate, o.Comment, 
  o.UserId, aspnet_Users.UserName,
  Status.Name StatusName,
  StatusReason.Name StatusReasonName,
  Offering.ID OfferingID,
  Offering.Name OfferingName,
  UnitOfMeasure.ID UnitOfMeasureID,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Sensor.Name SensorName,
  Phenomenon.ID PhenomenonID,
  Phenomenon.Name PhenomenonName,
  DataSource.ID DataSourceID,
  DataSource.Name DataSourceName,
  IsNull(SensorSchema.Name, DataSourceSchema.Name) DataSchemaName,
  Instrument.ID InstrumentID,
  Instrument.Name InstrumentName,
  Station.ID StationID,
  Station.Name StationName,
  Site.ID SiteID,
  Site.Name SiteName,
  Organisation.ID OrganisationID,
  Organisation.Name OrganisationName
FROM
  Observation o
  left join Status
    on (o.StatusID = Status.ID)
  left join StatusReason
    on (o.StatusReasonID = StatusReason.ID)
  inner join PhenomenonOffering
    on (o.PhenomenonOfferingID = PhenomenonOffering.ID)
  inner join Offering
    on (PhenomenonOffering.OfferingID = Offering.ID)
  inner join PhenomenonUOM
    on (o.PhenomenonUOMID = PhenomenonUOM.ID)
  inner join UnitOfMeasure
    on (PhenomenonUOM.UnitOfMeasureID = UnitOfMeasure.ID)
  inner join Sensor 
    on (o.SensorID = Sensor.ID)
  inner join Phenomenon
    on (Sensor.PhenomenonID = Phenomenon.ID)
  left join DataSchema SensorSchema
    on (Sensor.DataSchemaID = SensorSchema.ID)
  inner join DataSource
    on (Sensor.DataSourceID = DataSource.ID)
  left join DataSchema DataSourceSchema
    on (DataSource.DataSchemaID = DataSourceSchema.ID)
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Instrument_Sensor.StartDate is null) or (o.ValueDate >= Instrument_Sensor.StartDate)) and
--	   ((Instrument_Sensor.EndDate is null) or (o.ValueDate <= Instrument_Sensor.EndDate))
	   ((Instrument_Sensor.StartDate is null) or (Cast(o.ValueDate as Date) >= Instrument_Sensor.StartDate)) and
	   ((Instrument_Sensor.EndDate is null) or (Cast(o.ValueDate as Date) <= Instrument_Sensor.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Instrument.StartDate is null) or (o.ValueDate >= Instrument.StartDate )) and
--	   ((Instrument.EndDate is null) or (o.ValueDate <= Instrument.EndDate))
	   ((Instrument.StartDate is null) or (Cast(o.ValueDate as Date) >= Instrument.StartDate )) and
	   ((Instrument.EndDate is null) or (Cast(o.ValueDate as Date) <= Instrument.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Station_Instrument.StartDate is null) or (o.ValueDate >= Station_Instrument.StartDate)) and
--	   ((Station_Instrument.EndDate is null) or (o.ValueDate <= Station_Instrument.EndDate))
	   ((Station_Instrument.StartDate is null) or (Cast(o.ValueDate as Date) >= Station_Instrument.StartDate)) and
	   ((Station_Instrument.EndDate is null) or (Cast(o.ValueDate as Date) <= Station_Instrument.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Station 
    on (Station_Instrument.StationID = Station.ID) and
--> Changed 2.0.22 20170111 TimPN
	   ((Station.StartDate is null) or (Cast(o.ValueDate as Date) >= Cast(Station.StartDate as Date))) and
	   ((Station.EndDate is null) or (Cast(o.ValueDate as Date) <= Cast(Station.EndDate as Date)))
--< Changed 2.0.22 20170111 TimPN
  inner join Site
    on (Station.SiteID = Site.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Site.StartDate is null) or  (Cast(o.ValueDate as Date) >= Cast(Site.StartDate as Date))) and
--	   ((Site.EndDate is null) or  (Cast(o.ValueDate as Date) <= Cast(Site.EndDate as Date)))
	   ((Site.StartDate is null) or  (Cast(o.ValueDate as Date) >= Site.StartDate)) and
	   ((Site.EndDate is null) or  (Cast(o.ValueDate as Date) <= Site.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Organisation_Site
    on (Organisation_Site.SiteID = Site.ID) and
--> Changed 2.0.22 20170111 TimPN
--	   ((Organisation_Site.StartDate is null) or (Cast(o.ValueDate as Date) >= Cast(Organisation_Site.StartDate as Date))) and
--	   ((Organisation_Site.EndDate is null) or (Cast(o.ValueDate as Date) <= Cast(Organisation_Site.EndDate as Date)))
	   ((Organisation_Site.StartDate is null) or (Cast(o.ValueDate as Date) >= Organisation_Site.StartDate)) and
	   ((Organisation_Site.EndDate is null) or (Cast(o.ValueDate as Date) <= Organisation_Site.EndDate))
--< Changed 2.0.22 20170111 TimPN
  inner join Organisation
    on (Organisation_Site.OrganisationID = Organisation.ID)
  inner join aspnet_Users
    on (o.UserId = aspnet_Users.UserId)
--< Changed 2.0.16 20161107 TimPN
GO
PRINT N'Refreshing [dbo].[vObservationRoles]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationRoles]';


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_ImportBatch];

ALTER TABLE [dbo].[Progress] WITH CHECK CHECK CONSTRAINT [FK_Progress_ImportBatch];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_ImportBatch];

ALTER TABLE [dbo].[ImportBatch] WITH CHECK CHECK CONSTRAINT [FK_ImportBatch_DataSource];

ALTER TABLE [dbo].[ImportBatch] WITH CHECK CHECK CONSTRAINT [FK_ImportBatch_aspnet_Users];

ALTER TABLE [dbo].[ImportBatch] WITH CHECK CHECK CONSTRAINT [FK_ImportBatch_Status];

ALTER TABLE [dbo].[ImportBatch] WITH CHECK CHECK CONSTRAINT [FK_ImportBatch_StatusReason];


GO
PRINT N'Update complete.';


GO
