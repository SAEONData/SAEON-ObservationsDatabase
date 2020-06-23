  ALTER TABLE [dbo].[aspnet_Membership]  DROP CONSTRAINT FK__aspnet_Me__Appli__766C7FFC;
  ALTER TABLE [dbo].[aspnet_Membership]  DROP CONSTRAINT FK__aspnet_Me__UserI__0F382DC6;
  ALTER TABLE [dbo].[aspnet_Paths]  DROP CONSTRAINT FK__aspnet_Pa__Appli__7854C86E;
  ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  DROP CONSTRAINT FK__aspnet_Pe__PathI__7948ECA7;
  ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  DROP CONSTRAINT FK__aspnet_Pe__PathI__7A3D10E0;
  ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  DROP CONSTRAINT FK__aspnet_Pe__UserI__2156DE01;
  ALTER TABLE [dbo].[aspnet_Profile]  DROP CONSTRAINT FK__aspnet_Pr__UserI__7B313519;
  ALTER TABLE [dbo].[aspnet_Roles]  DROP CONSTRAINT FK__aspnet_Ro__Appli__7760A435;
  ALTER TABLE [dbo].[aspnet_Users]  DROP CONSTRAINT FK__aspnet_Us__Appli__75785BC3;
  ALTER TABLE [dbo].[aspnet_UsersInRoles]  DROP CONSTRAINT FK__aspnet_Us__RoleI__7E0DA1C4;
  ALTER TABLE [dbo].[aspnet_UsersInRoles]  DROP CONSTRAINT FK__aspnet_Us__UserI__17CD73C7;
  ALTER TABLE [dbo].[AuditLog]  DROP CONSTRAINT FK_AuditLog_aspnet_Users;
  ALTER TABLE [dbo].[DataLog]  DROP CONSTRAINT FK_DataLog_aspnet_Users;
  ALTER TABLE [dbo].[DataSchema]  DROP CONSTRAINT FK_DataSchema_aspnet_Users;
  ALTER TABLE [dbo].[DataSource]  DROP CONSTRAINT FK_DataSource_aspnet_Users;
  ALTER TABLE [dbo].[DataSourceTransformation]  DROP CONSTRAINT FK_DataSourceTransformation_aspnet_Users;
  ALTER TABLE [dbo].[DataSourceType]  DROP CONSTRAINT FK_DataSourceType_aspnet_Users;
  ALTER TABLE [dbo].[ImportBatch]  DROP CONSTRAINT FK_ImportBatch_aspnet_Users;
  ALTER TABLE [dbo].[Instrument]  DROP CONSTRAINT FK_Instrument_aspnet_Users;
  ALTER TABLE [dbo].[Instrument_Sensor]  DROP CONSTRAINT FK_Instrument_Sensor_aspnet_Users;
  ALTER TABLE [dbo].[Observation]  DROP CONSTRAINT FK_Observation_aspnet_Users;
  ALTER TABLE [dbo].[Offering]  DROP CONSTRAINT FK_Offering_aspnet_Users;
  ALTER TABLE [dbo].[Organisation]  DROP CONSTRAINT FK_Organisation_aspnet_Users;
  ALTER TABLE [dbo].[Organisation_Instrument]  DROP CONSTRAINT FK_Organisation_Instrument_aspnet_Users;
  ALTER TABLE [dbo].[Organisation_Site]  DROP CONSTRAINT FK_Organisation_Site_aspnet_Users;
  ALTER TABLE [dbo].[Organisation_Station]  DROP CONSTRAINT FK_Organisation_Station_aspnet_Users;
  ALTER TABLE [dbo].[OrganisationRole]  DROP CONSTRAINT FK_OrganisationRole_aspnet_Users;
  ALTER TABLE [dbo].[Phenomenon]  DROP CONSTRAINT FK_Phenomenon_aspnet_Users;
  ALTER TABLE [dbo].[PhenomenonOffering]  DROP CONSTRAINT FK_PhenomenonOffering_aspnet_Users;
  ALTER TABLE [dbo].[PhenomenonUOM]  DROP CONSTRAINT FK_PhenomenonUOM_aspnet_Users;
  ALTER TABLE [dbo].[Programme]  DROP CONSTRAINT FK_Programme_aspnet_Users;
  ALTER TABLE [dbo].[Project]  DROP CONSTRAINT FK_Project_aspnet_Users;
  ALTER TABLE [dbo].[Project_Station]  DROP CONSTRAINT FK_Project_Station_aspnet_Users;
  ALTER TABLE [dbo].[RoleModule]  DROP CONSTRAINT FK_RoleModule_aspnet_Roles;
  ALTER TABLE [dbo].[SchemaColumn]  DROP CONSTRAINT FK_SchemaColumn_aspnet_Users;
  ALTER TABLE [dbo].[SchemaColumnType]  DROP CONSTRAINT FK_SchemaColumnType_aspnet_Users;
  ALTER TABLE [dbo].[Sensor]  DROP CONSTRAINT FK_Sensor_aspnet_Users;
  ALTER TABLE [dbo].[Site]  DROP CONSTRAINT FK_Site_aspnet_Users;
  ALTER TABLE [dbo].[Station]  DROP CONSTRAINT FK_Station_aspnet_Users;
  ALTER TABLE [dbo].[Station_Instrument]  DROP CONSTRAINT FK_Station_Instrument_aspnet_Users;
  ALTER TABLE [dbo].[Status]  DROP CONSTRAINT FK_Status_aspnet_Users;
  ALTER TABLE [dbo].[StatusReason]  DROP CONSTRAINT FK_StatusReason_aspnet_Users;
  ALTER TABLE [dbo].[TransformationType]  DROP CONSTRAINT FK_TransformationType_aspnet_Users;
  ALTER TABLE [dbo].[UnitOfMeasure]  DROP CONSTRAINT FK_UnitOfMeasure_aspnet_Users;