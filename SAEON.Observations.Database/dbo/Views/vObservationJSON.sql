﻿CREATE VIEW [dbo].[vObservationJSON]
AS
Select
  ID,
  ValueDate,
  ValueDay,
  ValueYear,
  ValueDecade,
  TextValue,
  RawValue,
  DataValue,
  Comment,
  CorrelationID,
  Latitude,
  Longitude,
  Elevation,
  ImportBatchID 'ImportBatch.ID',
  ImportBatchCode 'ImportBatch.Code',
  ImportBatchDate 'ImportBatch.Date',
  SiteID 'Site.ID',
  SiteCode 'Site.Code',
  SiteName 'Site.Name',
  StationID 'Station.ID',
  StationCode 'Station.Code',
  StationName 'Station.Name',
  InstrumentID 'Instrument.ID',
  InstrumentCode 'Instrument.Code',
  InstrumentName 'Instrument.Name',
  SensorID 'Sensor.ID',
  SensorCode 'Sensor.Code',
  SensorName 'Sensor.Name',
  PhenomenonID 'Phenomenon.ID',
  PhenomenonCode 'Phenomenon.Code',
  PhenomenonName 'Phenomenon.Name',
  OfferingID 'Offering.ID',
  OfferingCode 'Offering.Code',
  OfferingName 'Offering.Name',
  UnitOfMeasureID 'Unit.ID',
  UnitOfMeasureCode 'Unit.Code',
  UnitOfMeasureUnit 'Unit.Name',
  UnitOfMeasureSymbol 'Unit.Symbol',
  StatusID 'Status.ID',
  StatusCode 'Status.Code',
  StatusName 'Status.Name',
  StatusReasonID 'StatusReason.ID',
  StatusReasonCode 'StatusReason.Code',
  StatusReasonName 'StatusReason.Name'
from
  vObservationExpansion
