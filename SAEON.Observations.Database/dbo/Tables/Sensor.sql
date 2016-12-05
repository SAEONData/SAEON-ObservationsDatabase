﻿--> Changed 2.0.3 20160503 TimPN
--CREATE TABLE [dbo].[SensorProcedure] (
CREATE TABLE [dbo].[Sensor] (
--< Changed 2.0.3 20160503 TimPN
    [ID]           UNIQUEIDENTIFIER CONSTRAINT [DF_Sensor_ID] DEFAULT (newid()) NOT NULL,
    [Code]         VARCHAR (50)     NOT NULL,
    [Name]         VARCHAR (150)    NOT NULL,
    [Description]  VARCHAR (5000)   NULL,
    [Url]          VARCHAR (250)    NULL,
--> Removed 2.0.17 20161128 TimPN
--    [StationID]    UNIQUEIDENTIFIER NOT NULL,
--< Removed 2.0.17 20161128 TimPN
    [PhenomenonID] UNIQUEIDENTIFIER NOT NULL,
    [DataSourceID] UNIQUEIDENTIFIER NOT NULL,
    [DataSchemaID] UNIQUEIDENTIFIER NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
--> Added 2.0.8 20160718 TimPN
    [AddedAt] DATETIME NULL CONSTRAINT [DF_Sensor_AddedAt] DEFAULT GetDate(), 
    [UpdatedAt] DATETIME NULL CONSTRAINT [DF_Sensor_UpdatedAt] DEFAULT GetDate(), 
--< Added 2.0.8 20160718 TimPN
--> Changed 2.0.8 20160718 TimPN
--    CONSTRAINT [PK_Sensor] PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT [PK_Sensor] PRIMARY KEY NONCLUSTERED ([ID]),
--< Changed 2.0.8 20160718 TimPN
    CONSTRAINT [FK_Sensor_aspnet_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]),
    CONSTRAINT [FK_Sensor_DataSource] FOREIGN KEY ([DataSourceID]) REFERENCES [dbo].[DataSource] ([ID]),
    CONSTRAINT [FK_Sensor_DataSchema] FOREIGN KEY ([DataSchemaID]) REFERENCES [dbo].[DataSchema] ([ID]),
    CONSTRAINT [FK_Sensor_Phenomenon] FOREIGN KEY ([PhenomenonID]) REFERENCES [dbo].[Phenomenon] ([ID]),
--> Removed 2.0.17 20161128 TimPN
--    CONSTRAINT [FK_Sensor_Station] FOREIGN KEY ([StationID]) REFERENCES [dbo].[Station] ([ID]),
--< Removed 2.0.17 20161128 TimPN
--> Changed 2.0.0 20160329 TimPN
--    CONSTRAINT [IX_Sensor_Code] UNIQUE ([Code])
    CONSTRAINT [UX_Sensor_Code] UNIQUE ([Code]),
--< Changed 2.0.0 20160329 TimPN
--> Added 2.0.1 20160406 TimPN
--> Removed 2.0.4 20160506 TimPN, re-add once duplicate names fixed
--    CONSTRAINT [UX_Sensor_Name] UNIQUE ([Name])
--< Removed 2.0.4 20160506 TimPN
--< Added 2.0.1 20160406 TimPN
);
--> Added 2.0.8 20160718 TimPN
GO
CREATE CLUSTERED INDEX [CX_Sensor] ON [dbo].[Sensor] ([AddedAt])
--< Added 2.0.8 20160718 TimPN
--> Removed 2.0.0 20160329 TimPN
--GO
--CREATE UNIQUE INDEX [IX_Sensor_Name] ON [dbo].[Sensor]([Name]);
--< Removed 2.0.0 20160329 TimPN
--> Added 2.0.1 20160406 TimPN
GO
--> Removed 2.0.17 20161128 TimPN
--CREATE INDEX [IX_Sensor_StationID] ON [dbo].[Sensor] ([StationID])
--GO
--< Removed 2.0.17 20161128 TimPN
CREATE INDEX [IX_Sensor_PhenomenonID] ON [dbo].[Sensor] ([PhenomenonID])
GO
CREATE INDEX [IX_Sensor_DataSourceID] ON [dbo].[Sensor] ([DataSourceID])
GO
CREATE INDEX [IX_Sensor_DataSchemaID] ON [dbo].[Sensor] ([DataSchemaID])
GO
CREATE INDEX [IX_Sensor_UserId] ON [dbo].[Sensor] ([UserId])
--< Added 2.0.1 20160406 TimPN
--> Added 2.0.8 20160718 TimPN
--> Changed 2.0.15 20161102 TimPN
GO
CREATE TRIGGER [dbo].[TR_Sensor_Insert] ON [dbo].[Sensor]
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
        Sensor src
        inner join inserted ins 
            on (ins.ID = src.ID)
END
GO
CREATE TRIGGER [dbo].[TR_Sensor_Update] ON [dbo].[Sensor]
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
        Sensor src
        inner join inserted ins
            on (ins.ID = src.ID)
		inner join deleted del
			on (del.ID = src.ID)
END
--< Changed 2.0.15 20161102 TimPN
--< Added 2.0.8 20160718 TimPN


