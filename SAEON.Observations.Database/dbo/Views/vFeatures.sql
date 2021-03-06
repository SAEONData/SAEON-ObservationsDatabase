﻿CREATE VIEW [dbo].[vFeatures]
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