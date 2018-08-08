using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace SAEON.Observations.Data{
    /// <summary>
    /// Strongly-typed collection for the VInventory class.
    /// </summary>
    [Serializable]
    public partial class VInventoryCollection : ReadOnlyList<VInventory, VInventoryCollection>
    {        
        public VInventoryCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vInventory view.
    /// </summary>
    [Serializable]
    public partial class VInventory : ReadOnlyRecord<VInventory>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vInventory", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Int64;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = true;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarSiteID = new TableSchema.TableColumn(schema);
                colvarSiteID.ColumnName = "SiteID";
                colvarSiteID.DataType = DbType.Guid;
                colvarSiteID.MaxLength = 0;
                colvarSiteID.AutoIncrement = false;
                colvarSiteID.IsNullable = false;
                colvarSiteID.IsPrimaryKey = false;
                colvarSiteID.IsForeignKey = false;
                colvarSiteID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteID);
                
                TableSchema.TableColumn colvarSiteCode = new TableSchema.TableColumn(schema);
                colvarSiteCode.ColumnName = "SiteCode";
                colvarSiteCode.DataType = DbType.AnsiString;
                colvarSiteCode.MaxLength = 50;
                colvarSiteCode.AutoIncrement = false;
                colvarSiteCode.IsNullable = false;
                colvarSiteCode.IsPrimaryKey = false;
                colvarSiteCode.IsForeignKey = false;
                colvarSiteCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteCode);
                
                TableSchema.TableColumn colvarSiteName = new TableSchema.TableColumn(schema);
                colvarSiteName.ColumnName = "SiteName";
                colvarSiteName.DataType = DbType.AnsiString;
                colvarSiteName.MaxLength = 150;
                colvarSiteName.AutoIncrement = false;
                colvarSiteName.IsNullable = false;
                colvarSiteName.IsPrimaryKey = false;
                colvarSiteName.IsForeignKey = false;
                colvarSiteName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteName);
                
                TableSchema.TableColumn colvarStationID = new TableSchema.TableColumn(schema);
                colvarStationID.ColumnName = "StationID";
                colvarStationID.DataType = DbType.Guid;
                colvarStationID.MaxLength = 0;
                colvarStationID.AutoIncrement = false;
                colvarStationID.IsNullable = false;
                colvarStationID.IsPrimaryKey = false;
                colvarStationID.IsForeignKey = false;
                colvarStationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationID);
                
                TableSchema.TableColumn colvarStationCode = new TableSchema.TableColumn(schema);
                colvarStationCode.ColumnName = "StationCode";
                colvarStationCode.DataType = DbType.AnsiString;
                colvarStationCode.MaxLength = 50;
                colvarStationCode.AutoIncrement = false;
                colvarStationCode.IsNullable = false;
                colvarStationCode.IsPrimaryKey = false;
                colvarStationCode.IsForeignKey = false;
                colvarStationCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationCode);
                
                TableSchema.TableColumn colvarStationName = new TableSchema.TableColumn(schema);
                colvarStationName.ColumnName = "StationName";
                colvarStationName.DataType = DbType.AnsiString;
                colvarStationName.MaxLength = 150;
                colvarStationName.AutoIncrement = false;
                colvarStationName.IsNullable = false;
                colvarStationName.IsPrimaryKey = false;
                colvarStationName.IsForeignKey = false;
                colvarStationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationName);
                
                TableSchema.TableColumn colvarInstrumentID = new TableSchema.TableColumn(schema);
                colvarInstrumentID.ColumnName = "InstrumentID";
                colvarInstrumentID.DataType = DbType.Guid;
                colvarInstrumentID.MaxLength = 0;
                colvarInstrumentID.AutoIncrement = false;
                colvarInstrumentID.IsNullable = false;
                colvarInstrumentID.IsPrimaryKey = false;
                colvarInstrumentID.IsForeignKey = false;
                colvarInstrumentID.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentID);
                
                TableSchema.TableColumn colvarInstrumentCode = new TableSchema.TableColumn(schema);
                colvarInstrumentCode.ColumnName = "InstrumentCode";
                colvarInstrumentCode.DataType = DbType.AnsiString;
                colvarInstrumentCode.MaxLength = 50;
                colvarInstrumentCode.AutoIncrement = false;
                colvarInstrumentCode.IsNullable = false;
                colvarInstrumentCode.IsPrimaryKey = false;
                colvarInstrumentCode.IsForeignKey = false;
                colvarInstrumentCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentCode);
                
                TableSchema.TableColumn colvarInstrumentName = new TableSchema.TableColumn(schema);
                colvarInstrumentName.ColumnName = "InstrumentName";
                colvarInstrumentName.DataType = DbType.AnsiString;
                colvarInstrumentName.MaxLength = 150;
                colvarInstrumentName.AutoIncrement = false;
                colvarInstrumentName.IsNullable = false;
                colvarInstrumentName.IsPrimaryKey = false;
                colvarInstrumentName.IsForeignKey = false;
                colvarInstrumentName.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentName);
                
                TableSchema.TableColumn colvarSensorID = new TableSchema.TableColumn(schema);
                colvarSensorID.ColumnName = "SensorID";
                colvarSensorID.DataType = DbType.Guid;
                colvarSensorID.MaxLength = 0;
                colvarSensorID.AutoIncrement = false;
                colvarSensorID.IsNullable = false;
                colvarSensorID.IsPrimaryKey = false;
                colvarSensorID.IsForeignKey = false;
                colvarSensorID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorID);
                
                TableSchema.TableColumn colvarSensorCode = new TableSchema.TableColumn(schema);
                colvarSensorCode.ColumnName = "SensorCode";
                colvarSensorCode.DataType = DbType.AnsiString;
                colvarSensorCode.MaxLength = 50;
                colvarSensorCode.AutoIncrement = false;
                colvarSensorCode.IsNullable = false;
                colvarSensorCode.IsPrimaryKey = false;
                colvarSensorCode.IsForeignKey = false;
                colvarSensorCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorCode);
                
                TableSchema.TableColumn colvarSensorName = new TableSchema.TableColumn(schema);
                colvarSensorName.ColumnName = "SensorName";
                colvarSensorName.DataType = DbType.AnsiString;
                colvarSensorName.MaxLength = 150;
                colvarSensorName.AutoIncrement = false;
                colvarSensorName.IsNullable = false;
                colvarSensorName.IsPrimaryKey = false;
                colvarSensorName.IsForeignKey = false;
                colvarSensorName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSensorName);
                
                TableSchema.TableColumn colvarPhenomenonCode = new TableSchema.TableColumn(schema);
                colvarPhenomenonCode.ColumnName = "PhenomenonCode";
                colvarPhenomenonCode.DataType = DbType.AnsiString;
                colvarPhenomenonCode.MaxLength = 50;
                colvarPhenomenonCode.AutoIncrement = false;
                colvarPhenomenonCode.IsNullable = false;
                colvarPhenomenonCode.IsPrimaryKey = false;
                colvarPhenomenonCode.IsForeignKey = false;
                colvarPhenomenonCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonCode);
                
                TableSchema.TableColumn colvarPhenomenonName = new TableSchema.TableColumn(schema);
                colvarPhenomenonName.ColumnName = "PhenomenonName";
                colvarPhenomenonName.DataType = DbType.AnsiString;
                colvarPhenomenonName.MaxLength = 150;
                colvarPhenomenonName.AutoIncrement = false;
                colvarPhenomenonName.IsNullable = false;
                colvarPhenomenonName.IsPrimaryKey = false;
                colvarPhenomenonName.IsForeignKey = false;
                colvarPhenomenonName.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonName);
                
                TableSchema.TableColumn colvarPhenomenonOfferingID = new TableSchema.TableColumn(schema);
                colvarPhenomenonOfferingID.ColumnName = "PhenomenonOfferingID";
                colvarPhenomenonOfferingID.DataType = DbType.Guid;
                colvarPhenomenonOfferingID.MaxLength = 0;
                colvarPhenomenonOfferingID.AutoIncrement = false;
                colvarPhenomenonOfferingID.IsNullable = false;
                colvarPhenomenonOfferingID.IsPrimaryKey = false;
                colvarPhenomenonOfferingID.IsForeignKey = false;
                colvarPhenomenonOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonOfferingID);
                
                TableSchema.TableColumn colvarOfferingCode = new TableSchema.TableColumn(schema);
                colvarOfferingCode.ColumnName = "OfferingCode";
                colvarOfferingCode.DataType = DbType.AnsiString;
                colvarOfferingCode.MaxLength = 50;
                colvarOfferingCode.AutoIncrement = false;
                colvarOfferingCode.IsNullable = false;
                colvarOfferingCode.IsPrimaryKey = false;
                colvarOfferingCode.IsForeignKey = false;
                colvarOfferingCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingCode);
                
                TableSchema.TableColumn colvarOfferingName = new TableSchema.TableColumn(schema);
                colvarOfferingName.ColumnName = "OfferingName";
                colvarOfferingName.DataType = DbType.AnsiString;
                colvarOfferingName.MaxLength = 150;
                colvarOfferingName.AutoIncrement = false;
                colvarOfferingName.IsNullable = false;
                colvarOfferingName.IsPrimaryKey = false;
                colvarOfferingName.IsForeignKey = false;
                colvarOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingName);
                
                TableSchema.TableColumn colvarPhenomenonUOMID = new TableSchema.TableColumn(schema);
                colvarPhenomenonUOMID.ColumnName = "PhenomenonUOMID";
                colvarPhenomenonUOMID.DataType = DbType.Guid;
                colvarPhenomenonUOMID.MaxLength = 0;
                colvarPhenomenonUOMID.AutoIncrement = false;
                colvarPhenomenonUOMID.IsNullable = false;
                colvarPhenomenonUOMID.IsPrimaryKey = false;
                colvarPhenomenonUOMID.IsForeignKey = false;
                colvarPhenomenonUOMID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonUOMID);
                
                TableSchema.TableColumn colvarUnitOfMeasureCode = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureCode.ColumnName = "UnitOfMeasureCode";
                colvarUnitOfMeasureCode.DataType = DbType.AnsiString;
                colvarUnitOfMeasureCode.MaxLength = 50;
                colvarUnitOfMeasureCode.AutoIncrement = false;
                colvarUnitOfMeasureCode.IsNullable = false;
                colvarUnitOfMeasureCode.IsPrimaryKey = false;
                colvarUnitOfMeasureCode.IsForeignKey = false;
                colvarUnitOfMeasureCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureCode);
                
                TableSchema.TableColumn colvarUnitOfMeasureUnit = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureUnit.ColumnName = "UnitOfMeasureUnit";
                colvarUnitOfMeasureUnit.DataType = DbType.AnsiString;
                colvarUnitOfMeasureUnit.MaxLength = 100;
                colvarUnitOfMeasureUnit.AutoIncrement = false;
                colvarUnitOfMeasureUnit.IsNullable = false;
                colvarUnitOfMeasureUnit.IsPrimaryKey = false;
                colvarUnitOfMeasureUnit.IsForeignKey = false;
                colvarUnitOfMeasureUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureUnit);
                
                TableSchema.TableColumn colvarCount = new TableSchema.TableColumn(schema);
                colvarCount.ColumnName = "Count";
                colvarCount.DataType = DbType.Int32;
                colvarCount.MaxLength = 0;
                colvarCount.AutoIncrement = false;
                colvarCount.IsNullable = true;
                colvarCount.IsPrimaryKey = false;
                colvarCount.IsForeignKey = false;
                colvarCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarCount);
                
                TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
                colvarStartDate.ColumnName = "StartDate";
                colvarStartDate.DataType = DbType.DateTime;
                colvarStartDate.MaxLength = 0;
                colvarStartDate.AutoIncrement = false;
                colvarStartDate.IsNullable = true;
                colvarStartDate.IsPrimaryKey = false;
                colvarStartDate.IsForeignKey = false;
                colvarStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStartDate);
                
                TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
                colvarEndDate.ColumnName = "EndDate";
                colvarEndDate.DataType = DbType.DateTime;
                colvarEndDate.MaxLength = 0;
                colvarEndDate.AutoIncrement = false;
                colvarEndDate.IsNullable = true;
                colvarEndDate.IsPrimaryKey = false;
                colvarEndDate.IsForeignKey = false;
                colvarEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEndDate);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vInventory",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public VInventory()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VInventory(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VInventory(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VInventory(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public long? Id 
	    {
		    get
		    {
			    return GetColumnValue<long?>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("SiteID")]
        [Bindable(true)]
        public Guid SiteID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SiteID");
		    }
            set 
		    {
			    SetColumnValue("SiteID", value);
            }
        }
	      
        [XmlAttribute("SiteCode")]
        [Bindable(true)]
        public string SiteCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteCode");
		    }
            set 
		    {
			    SetColumnValue("SiteCode", value);
            }
        }
	      
        [XmlAttribute("SiteName")]
        [Bindable(true)]
        public string SiteName 
	    {
		    get
		    {
			    return GetColumnValue<string>("SiteName");
		    }
            set 
		    {
			    SetColumnValue("SiteName", value);
            }
        }
	      
        [XmlAttribute("StationID")]
        [Bindable(true)]
        public Guid StationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("StationID");
		    }
            set 
		    {
			    SetColumnValue("StationID", value);
            }
        }
	      
        [XmlAttribute("StationCode")]
        [Bindable(true)]
        public string StationCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationCode");
		    }
            set 
		    {
			    SetColumnValue("StationCode", value);
            }
        }
	      
        [XmlAttribute("StationName")]
        [Bindable(true)]
        public string StationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StationName");
		    }
            set 
		    {
			    SetColumnValue("StationName", value);
            }
        }
	      
        [XmlAttribute("InstrumentID")]
        [Bindable(true)]
        public Guid InstrumentID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("InstrumentID");
		    }
            set 
		    {
			    SetColumnValue("InstrumentID", value);
            }
        }
	      
        [XmlAttribute("InstrumentCode")]
        [Bindable(true)]
        public string InstrumentCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("InstrumentCode");
		    }
            set 
		    {
			    SetColumnValue("InstrumentCode", value);
            }
        }
	      
        [XmlAttribute("InstrumentName")]
        [Bindable(true)]
        public string InstrumentName 
	    {
		    get
		    {
			    return GetColumnValue<string>("InstrumentName");
		    }
            set 
		    {
			    SetColumnValue("InstrumentName", value);
            }
        }
	      
        [XmlAttribute("SensorID")]
        [Bindable(true)]
        public Guid SensorID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("SensorID");
		    }
            set 
		    {
			    SetColumnValue("SensorID", value);
            }
        }
	      
        [XmlAttribute("SensorCode")]
        [Bindable(true)]
        public string SensorCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("SensorCode");
		    }
            set 
		    {
			    SetColumnValue("SensorCode", value);
            }
        }
	      
        [XmlAttribute("SensorName")]
        [Bindable(true)]
        public string SensorName 
	    {
		    get
		    {
			    return GetColumnValue<string>("SensorName");
		    }
            set 
		    {
			    SetColumnValue("SensorName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonCode")]
        [Bindable(true)]
        public string PhenomenonCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonCode");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonCode", value);
            }
        }
	      
        [XmlAttribute("PhenomenonName")]
        [Bindable(true)]
        public string PhenomenonName 
	    {
		    get
		    {
			    return GetColumnValue<string>("PhenomenonName");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonOfferingID")]
        [Bindable(true)]
        public Guid PhenomenonOfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonOfferingID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonOfferingID", value);
            }
        }
	      
        [XmlAttribute("OfferingCode")]
        [Bindable(true)]
        public string OfferingCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingCode");
		    }
            set 
		    {
			    SetColumnValue("OfferingCode", value);
            }
        }
	      
        [XmlAttribute("OfferingName")]
        [Bindable(true)]
        public string OfferingName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OfferingName");
		    }
            set 
		    {
			    SetColumnValue("OfferingName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonUOMID")]
        [Bindable(true)]
        public Guid PhenomenonUOMID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonUOMID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonUOMID", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureCode")]
        [Bindable(true)]
        public string UnitOfMeasureCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureCode");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureCode", value);
            }
        }
	      
        [XmlAttribute("UnitOfMeasureUnit")]
        [Bindable(true)]
        public string UnitOfMeasureUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("UnitOfMeasureUnit");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureUnit", value);
            }
        }
	      
        [XmlAttribute("Count")]
        [Bindable(true)]
        public int? Count 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Count");
		    }
            set 
		    {
			    SetColumnValue("Count", value);
            }
        }
	      
        [XmlAttribute("StartDate")]
        [Bindable(true)]
        public DateTime? StartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StartDate");
		    }
            set 
		    {
			    SetColumnValue("StartDate", value);
            }
        }
	      
        [XmlAttribute("EndDate")]
        [Bindable(true)]
        public DateTime? EndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("EndDate");
		    }
            set 
		    {
			    SetColumnValue("EndDate", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string SiteID = @"SiteID";
            
            public static string SiteCode = @"SiteCode";
            
            public static string SiteName = @"SiteName";
            
            public static string StationID = @"StationID";
            
            public static string StationCode = @"StationCode";
            
            public static string StationName = @"StationName";
            
            public static string InstrumentID = @"InstrumentID";
            
            public static string InstrumentCode = @"InstrumentCode";
            
            public static string InstrumentName = @"InstrumentName";
            
            public static string SensorID = @"SensorID";
            
            public static string SensorCode = @"SensorCode";
            
            public static string SensorName = @"SensorName";
            
            public static string PhenomenonCode = @"PhenomenonCode";
            
            public static string PhenomenonName = @"PhenomenonName";
            
            public static string PhenomenonOfferingID = @"PhenomenonOfferingID";
            
            public static string OfferingCode = @"OfferingCode";
            
            public static string OfferingName = @"OfferingName";
            
            public static string PhenomenonUOMID = @"PhenomenonUOMID";
            
            public static string UnitOfMeasureCode = @"UnitOfMeasureCode";
            
            public static string UnitOfMeasureUnit = @"UnitOfMeasureUnit";
            
            public static string Count = @"Count";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
