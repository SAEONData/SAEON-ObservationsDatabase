﻿--> Added 2.0.26 20170130 TimPN
CREATE VIEW [dbo].[vDownloads]
AS
Select
  Observation.ID,
  Site.ID SiteID,
  Site.Code SiteCode,
  Site.Name SiteName,
  Site.Description SiteDescription,
  Site.Url SiteUrl,
  Station.ID StationID,
  Station.Code StationCode,
  Station.Name StationName,
  Station.Description StationDescription,
  Station.Url StationUrl,
  Station.Latitude StationLatitude,
  Station.Longitude StationLongitude,
  Station.Elevation StationElevation,
  Instrument.ID InstrumentID,
  Instrument.Code InstrumentCode,
  Instrument.Name InstrumentName,
  Instrument.Description InstrumentDescription,
  Instrument.Url InstrumentUrl,
  Sensor.ID SensorID,
  Sensor.Code SensorCode,
  Sensor.Name SensorName,
  Sensor.Description SensorDescription,
  Sensor.Url SensorUrl,
  Phenomenon.ID PhenomenonID,
  Phenomenon.Code PhenomenonCode,
  Phenomenon.Name PhenomenonName,
  Phenomenon.Description PhenomenonDescription,
  Phenomenon.Url PhenomenonUrl,
  PhenomenonOffering.ID PhenomenonOfferingID,
  Offering.ID OfferingID,
  Offering.Code OfferingCode,
  Offering.Name OfferingName,
  Offering.Description OfferingDescription,
  PhenomenonUOM.ID PhenomenonUnitOfMeasureID,
  UnitOfMeasure.ID UnitOfMeasureID,
  UnitOfMeasure.Code UnitOfMeasureCode,
  UnitOfMeasure.Unit UnitOfMeasureUnit,
  UnitOfMeasure.UnitSymbol UnitOfMeasureSymbol,
  Phenomenon.Name + ', ' + Offering.Name + ', ' + UnitOfMeasure.UnitSymbol Feature,
  Observation.ValueDate,
  Observation.ValueDay,
  Observation.RawValue,
  Observation.DataValue,
  Observation.Comment,
  Observation.CorrelationID
from
  Observation
  inner join Status
    on (Observation.StatusID = Status.ID)
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
  inner join Instrument_Sensor
    on (Instrument_Sensor.SensorID = Sensor.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Instrument_Sensor.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Instrument_Sensor.StartDate)) and
       --((Instrument_Sensor.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Instrument_Sensor.EndDate))
       ((Instrument_Sensor.StartDate is null) or (Observation.ValueDay >= Instrument_Sensor.StartDate)) and
       ((Instrument_Sensor.EndDate is null) or (Observation.ValueDay <= Instrument_Sensor.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Instrument
    on (Instrument_Sensor.InstrumentID = Instrument.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Instrument.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Instrument.StartDate )) and
       --((Instrument.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Instrument.EndDate))
       ((Instrument.StartDate is null) or (Observation.ValueDay >= Instrument.StartDate )) and
       ((Instrument.EndDate is null) or (Observation.ValueDay <= Instrument.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Station_Instrument
    on (Station_Instrument.InstrumentID = Instrument.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Station_Instrument.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Station_Instrument.StartDate)) and
       --((Station_Instrument.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Station_Instrument.EndDate))
       ((Station_Instrument.StartDate is null) or (Observation.ValueDay >= Station_Instrument.StartDate)) and
       ((Station_Instrument.EndDate is null) or (Observation.ValueDay <= Station_Instrument.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Station
    on (Station_Instrument.StationID = Station.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Station.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Cast(Station.StartDate as Date))) and
       --((Station.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Cast(Station.EndDate as Date)))
       ((Station.StartDate is null) or (Observation.ValueDay = Station.StartDate)) and
       ((Station.EndDate is null) or (Observation.ValueDay <= Station.EndDate))
--< Changed 2.0.31 20170423 TimPN
  inner join Site
    on (Station.SiteID = Site.ID) and
--> Changed 2.0.31 20170423 TimPN
       --((Site.StartDate is null) or (Cast(Observation.ValueDate as Date) >= Cast(Site.StartDate as Date))) and
       --((Site.EndDate is null) or (Cast(Observation.ValueDate as Date) <= Cast(Site.EndDate as Date)))
       ((Site.StartDate is null) or (Observation.ValueDay >= Site.StartDate)) and
       ((Site.EndDate is null) or (Observation.ValueDay <= Site.EndDate))
--< Changed 2.0.31 20170423 TimPN
where
  (Status.Name = 'Verified')
--< Added 2.0.26 20170130 TimPN
