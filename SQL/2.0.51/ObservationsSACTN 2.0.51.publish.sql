﻿/*
Deployment script for ObservationsSACTN

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ObservationsSACTN"
:setvar DefaultFilePrefix "ObservationsSACTN"
:setvar DefaultDataPath "D:\Program Files\Microsoft SQL Server\MSSQL14.SAEON\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Program Files\Microsoft SQL Server\MSSQL14.SAEON\MSSQL\DATA\"

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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Altering [dbo].[DataSourceTransformation]...';


GO
ALTER TABLE [dbo].[DataSourceTransformation]
    ADD [ParamA] FLOAT NULL,
        [ParamB] FLOAT NULL,
        [ParamC] FLOAT NULL,
        [ParamD] FLOAT NULL,
        [ParamE] FLOAT NULL,
        [ParamF] FLOAT NULL,
        [ParamG] FLOAT NULL,
        [ParamH] FLOAT NULL,
        [ParamI] FLOAT NULL,
        [ParamJ] FLOAT NULL,
        [ParamK] FLOAT NULL,
        [ParamL] FLOAT NULL,
        [ParamM] FLOAT NULL,
        [ParamN] FLOAT NULL,
        [ParamO] FLOAT NULL,
        [ParamP] FLOAT NULL,
        [ParamQ] FLOAT NULL,
        [ParamR] FLOAT NULL,
        [ParamS] FLOAT NULL,
        [ParamT] FLOAT NULL,
        [ParamU] FLOAT NULL,
        [ParamV] FLOAT NULL,
        [ParamW] FLOAT NULL,
        [ParamX] FLOAT NULL,
        [ParamY] FLOAT NULL;


GO
PRINT N'Refreshing [dbo].[vDataLog]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vDataLog]';


GO
PRINT N'Refreshing [dbo].[vDataSourceTransformation]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[vDataSourceTransformation]';


GO
PRINT N'Update complete.';


GO
