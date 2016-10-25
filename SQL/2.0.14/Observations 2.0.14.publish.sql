﻿/*
Deployment script for Observations

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Observations"
:setvar DefaultFilePrefix "Observations"
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
PRINT N'Rename refactoring operation with key b1dffd34-adcf-4c1c-b921-b9d401038bb6 is skipped, element [dbo].[Observation].[CorerelationID] (SqlSimpleColumn) will not be renamed to CorrelationID';


GO
PRINT N'Dropping [dbo].[DF_DataLog_AddedAt]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_AddedAt];


GO
PRINT N'Dropping [dbo].[DF_DataLog_UpdatedAt]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_UpdatedAt];


GO
PRINT N'Dropping [dbo].[DF_DataLog_ImportDate]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_ImportDate];


GO
PRINT N'Dropping [dbo].[DF_DataLog_ID]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [DF_DataLog_ID];


GO
PRINT N'Dropping [dbo].[DF_Observation_AddedDate]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_AddedDate];


GO
PRINT N'Dropping [dbo].[DF_Observation_AddedAt]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_AddedAt];


GO
PRINT N'Dropping [dbo].[DF_Observation_UpdatedAt]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_UpdatedAt];


GO
PRINT N'Dropping [dbo].[DF_Observation_ID]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [DF_Observation_ID];


GO
PRINT N'Dropping [dbo].[FK_DataLog_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_PhenomenonOffering];


GO
PRINT N'Dropping [dbo].[FK_DataLog_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_PhenomenonUOM];


GO
PRINT N'Dropping [dbo].[FK_DataLog_Sensor]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_Sensor];


GO
PRINT N'Dropping [dbo].[FK_DataLog_StatusReason]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_StatusReason];


GO
PRINT N'Dropping [dbo].[FK_DataLog_aspnet_Users]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_aspnet_Users];


GO
PRINT N'Dropping [dbo].[FK_DataLog_ImportBatch]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_ImportBatch];


GO
PRINT N'Dropping [dbo].[FK_DataLog_DataSourceTransformation]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_DataSourceTransformation];


GO
PRINT N'Dropping [dbo].[FK_DataLog_Status]...';


GO
ALTER TABLE [dbo].[DataLog] DROP CONSTRAINT [FK_DataLog_Status];


GO
PRINT N'Dropping [dbo].[FK_Observation_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_PhenomenonOffering];


GO
PRINT N'Dropping [dbo].[FK_Observation_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_PhenomenonUOM];


GO
PRINT N'Dropping [dbo].[FK_Observation_Sensor]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_Sensor];


GO
PRINT N'Dropping [dbo].[FK_Observation_Status]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_Status];


GO
PRINT N'Dropping [dbo].[FK_Observation_StatusReason]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_StatusReason];


GO
PRINT N'Dropping [dbo].[FK_Observation_aspnet_Users]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_aspnet_Users];


GO
PRINT N'Dropping [dbo].[FK_Observation_ImportBatch]...';


GO
ALTER TABLE [dbo].[Observation] DROP CONSTRAINT [FK_Observation_ImportBatch];


GO
PRINT N'Starting rebuilding table [dbo].[DataLog]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_DataLog] (
    [ID]                         UNIQUEIDENTIFIER CONSTRAINT [DF_DataLog_ID] DEFAULT newid() NOT NULL,
    [SensorID]                   UNIQUEIDENTIFIER NULL,
    [ImportDate]                 DATETIME         CONSTRAINT [DF_DataLog_ImportDate] DEFAULT (getdate()) NOT NULL,
    [ValueDate]                  DATETIME         NULL,
    [ValueTime]                  DATETIME         NULL,
    [ValueText]                  VARCHAR (50)     NOT NULL,
    [TransformValueText]         VARCHAR (50)     NULL,
    [RawValue]                   FLOAT (53)       NULL,
    [DataValue]                  FLOAT (53)       NULL,
    [Comment]                    VARCHAR (250)    NULL,
    [InvalidDateValue]           VARCHAR (50)     NULL,
    [InvalidTimeValue]           VARCHAR (50)     NULL,
    [InvalidOffering]            VARCHAR (50)     NULL,
    [InvalidUOM]                 VARCHAR (50)     NULL,
    [DataSourceTransformationID] UNIQUEIDENTIFIER NULL,
    [StatusID]                   UNIQUEIDENTIFIER NOT NULL,
    [StatusReasonID]             UNIQUEIDENTIFIER NULL,
    [ImportStatus]               VARCHAR (500)    NOT NULL,
    [UserId]                     UNIQUEIDENTIFIER NULL,
    [PhenomenonOfferingID]       UNIQUEIDENTIFIER NULL,
    [PhenomenonUOMID]            UNIQUEIDENTIFIER NULL,
    [ImportBatchID]              UNIQUEIDENTIFIER NOT NULL,
    [RawRecordData]              VARCHAR (500)    NULL,
    [RawFieldValue]              VARCHAR (50)     NOT NULL,
    [CorrelationID]              UNIQUEIDENTIFIER NULL,
    [AddedAt]                    DATETIME         CONSTRAINT [DF_DataLog_AddedAt] DEFAULT GetDate() NULL,
    [UpdatedAt]                  DATETIME         CONSTRAINT [DF_DataLog_UpdatedAt] DEFAULT GetDate() NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_DataLog1] PRIMARY KEY NONCLUSTERED ([ID] ASC),
    CONSTRAINT [tmp_ms_xx_constraint_UX_DataLog1] UNIQUE NONCLUSTERED ([ImportBatchID] ASC, [SensorID] ASC, [ImportDate] ASC, [ValueDate] ASC, [ValueTime] ASC, [PhenomenonOfferingID] ASC, [PhenomenonUOMID] ASC)
);

CREATE CLUSTERED INDEX [tmp_ms_xx_index_CX_DataLog1]
    ON [dbo].[tmp_ms_xx_DataLog]([AddedAt] ASC);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[DataLog])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_DataLog] ([AddedAt], [ID], [SensorID], [ImportDate], [ValueDate], [ValueTime], [ValueText], [TransformValueText], [RawValue], [DataValue], [Comment], [InvalidDateValue], [InvalidTimeValue], [InvalidOffering], [InvalidUOM], [DataSourceTransformationID], [StatusID], [StatusReasonID], [ImportStatus], [UserId], [PhenomenonOfferingID], [PhenomenonUOMID], [ImportBatchID], [RawRecordData], [RawFieldValue], [UpdatedAt])
        SELECT   [AddedAt],
                 [ID],
                 [SensorID],
                 [ImportDate],
                 [ValueDate],
                 [ValueTime],
                 [ValueText],
                 [TransformValueText],
                 [RawValue],
                 [DataValue],
                 [Comment],
                 [InvalidDateValue],
                 [InvalidTimeValue],
                 [InvalidOffering],
                 [InvalidUOM],
                 [DataSourceTransformationID],
                 [StatusID],
                 [StatusReasonID],
                 [ImportStatus],
                 [UserId],
                 [PhenomenonOfferingID],
                 [PhenomenonUOMID],
                 [ImportBatchID],
                 [RawRecordData],
                 [RawFieldValue],
                 [UpdatedAt]
        FROM     [dbo].[DataLog]
        ORDER BY [AddedAt] ASC;
    END

DROP TABLE [dbo].[DataLog];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_DataLog]', N'DataLog';

EXECUTE sp_rename N'[dbo].[DataLog].[tmp_ms_xx_index_CX_DataLog1]', N'CX_DataLog', N'INDEX';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_DataLog1]', N'PK_DataLog', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UX_DataLog1]', N'UX_DataLog', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_ImportBatchID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_ImportBatchID]
    ON [dbo].[DataLog]([ImportBatchID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_SensorID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_SensorID]
    ON [dbo].[DataLog]([SensorID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_DataSourceTransformationID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_DataSourceTransformationID]
    ON [dbo].[DataLog]([DataSourceTransformationID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_PhenomenonOfferingID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_PhenomenonOfferingID]
    ON [dbo].[DataLog]([PhenomenonOfferingID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_PhenomenonUOMID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_PhenomenonUOMID]
    ON [dbo].[DataLog]([PhenomenonUOMID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_StatusID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_StatusID]
    ON [dbo].[DataLog]([StatusID] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_UserId]
    ON [dbo].[DataLog]([UserId] ASC);


GO
PRINT N'Creating [dbo].[DataLog].[IX_DataLog_StatusReasonID]...';


GO
CREATE NONCLUSTERED INDEX [IX_DataLog_StatusReasonID]
    ON [dbo].[DataLog]([StatusReasonID] ASC);


GO
PRINT N'Starting rebuilding table [dbo].[Observation]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Observation] (
    [ID]                   UNIQUEIDENTIFIER     CONSTRAINT [DF_Observation_ID] DEFAULT newid() NOT NULL,
    [SensorID]             UNIQUEIDENTIFIER     NOT NULL,
    [ValueDate]            DATETIME             NOT NULL,
    [RawValue]             FLOAT (53)           NULL,
    [DataValue]            FLOAT (53)           NULL,
    [Comment]              VARCHAR (250) SPARSE NULL,
    [PhenomenonOfferingID] UNIQUEIDENTIFIER     NOT NULL,
    [PhenomenonUOMID]      UNIQUEIDENTIFIER     NOT NULL,
    [ImportBatchID]        UNIQUEIDENTIFIER     NOT NULL,
    [StatusID]             UNIQUEIDENTIFIER     NULL,
    [StatusReasonID]       UNIQUEIDENTIFIER     NULL,
    [CorrelationID]        UNIQUEIDENTIFIER     NULL,
    [UserId]               UNIQUEIDENTIFIER     NOT NULL,
    [AddedDate]            DATETIME             CONSTRAINT [DF_Observation_AddedDate] DEFAULT getdate() NOT NULL,
    [AddedAt]              DATETIME             CONSTRAINT [DF_Observation_AddedAt] DEFAULT GetDate() NULL,
    [UpdatedAt]            DATETIME             CONSTRAINT [DF_Observation_UpdatedAt] DEFAULT GetDate() NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Observation1] PRIMARY KEY NONCLUSTERED ([ID] ASC) ON [Observations],
    CONSTRAINT [tmp_ms_xx_constraint_UX_Observation1] UNIQUE NONCLUSTERED ([SensorID] ASC, [ImportBatchID] ASC, [ValueDate] ASC, [PhenomenonOfferingID] ASC, [PhenomenonUOMID] ASC) ON [Observations]
);

CREATE CLUSTERED INDEX [tmp_ms_xx_index_CX_Observation1]
    ON [dbo].[tmp_ms_xx_Observation]([AddedAt] ASC)
    ON [Observations];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Observation])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Observation] ([AddedAt], [ID], [SensorID], [ValueDate], [RawValue], [DataValue], [Comment], [PhenomenonOfferingID], [PhenomenonUOMID], [ImportBatchID], [StatusID], [StatusReasonID], [UserId], [AddedDate], [UpdatedAt])
        SELECT   [AddedAt],
                 [ID],
                 [SensorID],
                 [ValueDate],
                 [RawValue],
                 [DataValue],
                 [Comment],
                 [PhenomenonOfferingID],
                 [PhenomenonUOMID],
                 [ImportBatchID],
                 [StatusID],
                 [StatusReasonID],
                 [UserId],
                 [AddedDate],
                 [UpdatedAt]
        FROM     [dbo].[Observation]
        ORDER BY [AddedAt] ASC;
    END

DROP TABLE [dbo].[Observation];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Observation]', N'Observation';

EXECUTE sp_rename N'[dbo].[Observation].[tmp_ms_xx_index_CX_Observation1]', N'CX_Observation', N'INDEX';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Observation1]', N'PK_Observation', N'OBJECT';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_UX_Observation1]', N'UX_Observation', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation]
    ON [dbo].[Observation]([SensorID] ASC, [ValueDate] ASC, [RawValue] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ImportBatchID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ImportBatchID]
    ON [dbo].[Observation]([ImportBatchID] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_SensorID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_SensorID]
    ON [dbo].[Observation]([SensorID] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_PhenomenonOfferingID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_PhenomenonOfferingID]
    ON [dbo].[Observation]([PhenomenonOfferingID] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_PhenomenonUOMID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_PhenomenonUOMID]
    ON [dbo].[Observation]([PhenomenonUOMID] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_UserId]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_UserId]
    ON [dbo].[Observation]([UserId] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_AddedDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_AddedDate]
    ON [dbo].[Observation]([SensorID] ASC, [AddedDate] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_ValueDate]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_ValueDate]
    ON [dbo].[Observation]([SensorID] ASC, [ValueDate] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_StatusID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_StatusID]
    ON [dbo].[Observation]([StatusID] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_StatusReasonID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_StatusReasonID]
    ON [dbo].[Observation]([StatusReasonID] ASC)
    ON [Observations];


GO
PRINT N'Creating [dbo].[Observation].[IX_Observation_CorrelationID]...';


GO
CREATE NONCLUSTERED INDEX [IX_Observation_CorrelationID]
    ON [dbo].[Observation]([CorrelationID] ASC)
    ON [Observations];


GO
PRINT N'Altering [dbo].[SchemaColumn]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
ALTER TABLE [dbo].[SchemaColumn] ALTER COLUMN [FixedTime] VARCHAR (10) NULL;


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[FK_DataLog_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_PhenomenonOffering] FOREIGN KEY ([PhenomenonOfferingID]) REFERENCES [dbo].[PhenomenonOffering] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_PhenomenonUOM] FOREIGN KEY ([PhenomenonUOMID]) REFERENCES [dbo].[PhenomenonUOM] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_Sensor]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_Sensor] FOREIGN KEY ([SensorID]) REFERENCES [dbo].[Sensor] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_StatusReason]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_StatusReason] FOREIGN KEY ([StatusReasonID]) REFERENCES [dbo].[StatusReason] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_aspnet_Users]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_DataLog_ImportBatch]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_DataSourceTransformation]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_DataSourceTransformation] FOREIGN KEY ([DataSourceTransformationID]) REFERENCES [dbo].[DataSourceTransformation] ([ID]);


GO
PRINT N'Creating [dbo].[FK_DataLog_Status]...';


GO
ALTER TABLE [dbo].[DataLog] WITH NOCHECK
    ADD CONSTRAINT [FK_DataLog_Status] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_PhenomenonOffering]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_PhenomenonOffering] FOREIGN KEY ([PhenomenonOfferingID]) REFERENCES [dbo].[PhenomenonOffering] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_PhenomenonUOM]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_PhenomenonUOM] FOREIGN KEY ([PhenomenonUOMID]) REFERENCES [dbo].[PhenomenonUOM] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_Sensor]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_Sensor] FOREIGN KEY ([SensorID]) REFERENCES [dbo].[Sensor] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_Status]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_Status] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_StatusReason]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_StatusReason] FOREIGN KEY ([StatusReasonID]) REFERENCES [dbo].[StatusReason] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Observation_aspnet_Users]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_Observation_ImportBatch]...';


GO
ALTER TABLE [dbo].[Observation] WITH NOCHECK
    ADD CONSTRAINT [FK_Observation_ImportBatch] FOREIGN KEY ([ImportBatchID]) REFERENCES [dbo].[ImportBatch] ([ID]);


GO
PRINT N'Creating [dbo].[TR_DataLog_Insert]...';


GO
CREATE TRIGGER [dbo].[TR_DataLog_Insert] ON [dbo].[DataLog]
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
        inserted ins 
        inner join DataLog src
            on (ins.ID = src.ID)
END
GO
PRINT N'Creating [dbo].[TR_DataLog_Update]...';


GO
CREATE TRIGGER [dbo].[TR_DataLog_Update] ON [dbo].[DataLog]
FOR UPDATE
AS
BEGIN
    SET NoCount ON
    --if UPDATE(AddedAt) RAISERROR ('Cannot update AddedAt.', 16, 1)
    Update 
        src 
    set 
        UpdatedAt = GETDATE()
    from
        inserted ins 
        inner join DataLog src
            on (ins.ID = src.ID)
END
--< Added 2.0.8 20160708 TimPN
GO
PRINT N'Creating [dbo].[TR_Observation_Insert]...';


GO
CREATE TRIGGER [dbo].[TR_Observation_Insert] ON [dbo].[Observation]
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
        inserted ins
        inner join Observation src
            on (ins.ID = src.ID)
END
GO
PRINT N'Creating [dbo].[TR_Observation_Update]...';


GO
CREATE TRIGGER [dbo].[TR_Observation_Update] ON [dbo].[Observation]
FOR UPDATE
AS
BEGIN
    SET NoCount ON
    --if UPDATE(AddedAt) RAISERROR ('Cannot update AddedAt.', 16, 1)
    Update
        src
    set
        UpdatedAt = GETDATE()
    from
        inserted ins
        inner join Observation src
            on (ins.ID = src.ID)
END
--< Added 2.0.8 20160718 TimPN
GO
PRINT N'Refreshing [dbo].[vDataLog]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vDataLog]';


GO
PRINT N'Refreshing [dbo].[vInventory]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vInventory]';


GO
PRINT N'Refreshing [dbo].[vObservation]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservation]';


GO
PRINT N'Refreshing [dbo].[vObservationRoles]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vObservationRoles]';


GO
PRINT N'Refreshing [dbo].[vSchemaColumn]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vSchemaColumn]';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[vObservationsList]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
--> Added 2.0.15 20161024 TimPN
CREATE VIEW [dbo].[vObservationsList]
AS 
SELECT 
  Observation.*,
  Sensor.Code SensorCode,
  Sensor.Name SensorName,
  Phenomenon.Code PhenomenonCode,
  Phenomenon.Name PhenomenonName,
  Offering.Code OfferingCode,
  Offering.Name OfferingName,
  UnitOfMeasure.Code UnitOfMeasureCode,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  Status.Code StatusCode,
  Status.Name StatusName,
  StatusReason.Code StatusReasonCode,
  StatusReason.Name StatusReasonName
FROM
  Observation
  inner join Sensor
    on (Observation.SensorID = Sensor.ID)
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
--> Added 2.0.15 20161024 TimPN
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Refreshing [dbo].[progress_Status_Raw]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[progress_Status_Raw]';


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b1dffd34-adcf-4c1c-b921-b9d401038bb6')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b1dffd34-adcf-4c1c-b921-b9d401038bb6')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_PhenomenonOffering];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_PhenomenonUOM];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_Sensor];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_StatusReason];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_aspnet_Users];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_ImportBatch];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_DataSourceTransformation];

ALTER TABLE [dbo].[DataLog] WITH CHECK CHECK CONSTRAINT [FK_DataLog_Status];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_PhenomenonOffering];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_PhenomenonUOM];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_Sensor];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_Status];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_StatusReason];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_aspnet_Users];

ALTER TABLE [dbo].[Observation] WITH CHECK CHECK CONSTRAINT [FK_Observation_ImportBatch];


GO
PRINT N'Update complete.';


GO
