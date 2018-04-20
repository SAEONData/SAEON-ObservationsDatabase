﻿--> Added 20170523 2.0.32 TimPN
CREATE VIEW [dbo].[vInventoryYears]
AS 
Select
  Cast(ValueYear as VarChar(10))+'~'+IsNull(StatusName,'') SurrogateKey,
  --Station.ID StationID, PhenomenonOffering.ID PhenomenonOfferingID, 
  ValueYear Year, IsNull(StatusName,'No status') Status, 
  Count(*) Count, Min(DataValue) Minimum, Max(DataValue) Maximum, Avg(DataValue) Average, StDev(DataValue) StandardDeviation, Var(DataValue) Variance
from
  vObservationExpansion
group by
  ValueYear, StatusName
--< Added 20170523 2.0.32 TimPN
