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
    /// Strongly-typed collection for the VSensorDate class.
    /// </summary>
    [Serializable]
    public partial class VSensorDateCollection : ReadOnlyList<VSensorDate, VSensorDateCollection>
    {        
        public VSensorDateCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vSensorDates view.
    /// </summary>
    [Serializable]
    public partial class VSensorDate : ReadOnlyRecord<VSensorDate>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vSensorDates", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
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
                
                TableSchema.TableColumn colvarInstrumenSensorStartDate = new TableSchema.TableColumn(schema);
                colvarInstrumenSensorStartDate.ColumnName = "InstrumenSensorStartDate";
                colvarInstrumenSensorStartDate.DataType = DbType.Date;
                colvarInstrumenSensorStartDate.MaxLength = 0;
                colvarInstrumenSensorStartDate.AutoIncrement = false;
                colvarInstrumenSensorStartDate.IsNullable = true;
                colvarInstrumenSensorStartDate.IsPrimaryKey = false;
                colvarInstrumenSensorStartDate.IsForeignKey = false;
                colvarInstrumenSensorStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumenSensorStartDate);
                
                TableSchema.TableColumn colvarInstrumenSensorEndDate = new TableSchema.TableColumn(schema);
                colvarInstrumenSensorEndDate.ColumnName = "InstrumenSensorEndDate";
                colvarInstrumenSensorEndDate.DataType = DbType.Date;
                colvarInstrumenSensorEndDate.MaxLength = 0;
                colvarInstrumenSensorEndDate.AutoIncrement = false;
                colvarInstrumenSensorEndDate.IsNullable = true;
                colvarInstrumenSensorEndDate.IsPrimaryKey = false;
                colvarInstrumenSensorEndDate.IsForeignKey = false;
                colvarInstrumenSensorEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumenSensorEndDate);
                
                TableSchema.TableColumn colvarInstrumentName = new TableSchema.TableColumn(schema);
                colvarInstrumentName.ColumnName = "InstrumentName";
                colvarInstrumentName.DataType = DbType.AnsiString;
                colvarInstrumentName.MaxLength = 150;
                colvarInstrumentName.AutoIncrement = false;
                colvarInstrumentName.IsNullable = true;
                colvarInstrumentName.IsPrimaryKey = false;
                colvarInstrumentName.IsForeignKey = false;
                colvarInstrumentName.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentName);
                
                TableSchema.TableColumn colvarInstrumentStartDate = new TableSchema.TableColumn(schema);
                colvarInstrumentStartDate.ColumnName = "InstrumentStartDate";
                colvarInstrumentStartDate.DataType = DbType.Date;
                colvarInstrumentStartDate.MaxLength = 0;
                colvarInstrumentStartDate.AutoIncrement = false;
                colvarInstrumentStartDate.IsNullable = true;
                colvarInstrumentStartDate.IsPrimaryKey = false;
                colvarInstrumentStartDate.IsForeignKey = false;
                colvarInstrumentStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentStartDate);
                
                TableSchema.TableColumn colvarInstrumentEndDate = new TableSchema.TableColumn(schema);
                colvarInstrumentEndDate.ColumnName = "InstrumentEndDate";
                colvarInstrumentEndDate.DataType = DbType.Date;
                colvarInstrumentEndDate.MaxLength = 0;
                colvarInstrumentEndDate.AutoIncrement = false;
                colvarInstrumentEndDate.IsNullable = true;
                colvarInstrumentEndDate.IsPrimaryKey = false;
                colvarInstrumentEndDate.IsForeignKey = false;
                colvarInstrumentEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstrumentEndDate);
                
                TableSchema.TableColumn colvarStationInstrumentStartDate = new TableSchema.TableColumn(schema);
                colvarStationInstrumentStartDate.ColumnName = "StationInstrumentStartDate";
                colvarStationInstrumentStartDate.DataType = DbType.Date;
                colvarStationInstrumentStartDate.MaxLength = 0;
                colvarStationInstrumentStartDate.AutoIncrement = false;
                colvarStationInstrumentStartDate.IsNullable = true;
                colvarStationInstrumentStartDate.IsPrimaryKey = false;
                colvarStationInstrumentStartDate.IsForeignKey = false;
                colvarStationInstrumentStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationInstrumentStartDate);
                
                TableSchema.TableColumn colvarStationInstrumentEndDate = new TableSchema.TableColumn(schema);
                colvarStationInstrumentEndDate.ColumnName = "StationInstrumentEndDate";
                colvarStationInstrumentEndDate.DataType = DbType.Date;
                colvarStationInstrumentEndDate.MaxLength = 0;
                colvarStationInstrumentEndDate.AutoIncrement = false;
                colvarStationInstrumentEndDate.IsNullable = true;
                colvarStationInstrumentEndDate.IsPrimaryKey = false;
                colvarStationInstrumentEndDate.IsForeignKey = false;
                colvarStationInstrumentEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationInstrumentEndDate);
                
                TableSchema.TableColumn colvarStationName = new TableSchema.TableColumn(schema);
                colvarStationName.ColumnName = "StationName";
                colvarStationName.DataType = DbType.AnsiString;
                colvarStationName.MaxLength = 150;
                colvarStationName.AutoIncrement = false;
                colvarStationName.IsNullable = true;
                colvarStationName.IsPrimaryKey = false;
                colvarStationName.IsForeignKey = false;
                colvarStationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationName);
                
                TableSchema.TableColumn colvarStationStartDate = new TableSchema.TableColumn(schema);
                colvarStationStartDate.ColumnName = "StationStartDate";
                colvarStationStartDate.DataType = DbType.Date;
                colvarStationStartDate.MaxLength = 0;
                colvarStationStartDate.AutoIncrement = false;
                colvarStationStartDate.IsNullable = true;
                colvarStationStartDate.IsPrimaryKey = false;
                colvarStationStartDate.IsForeignKey = false;
                colvarStationStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationStartDate);
                
                TableSchema.TableColumn colvarStationEndDate = new TableSchema.TableColumn(schema);
                colvarStationEndDate.ColumnName = "StationEndDate";
                colvarStationEndDate.DataType = DbType.Date;
                colvarStationEndDate.MaxLength = 0;
                colvarStationEndDate.AutoIncrement = false;
                colvarStationEndDate.IsNullable = true;
                colvarStationEndDate.IsPrimaryKey = false;
                colvarStationEndDate.IsForeignKey = false;
                colvarStationEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStationEndDate);
                
                TableSchema.TableColumn colvarSiteName = new TableSchema.TableColumn(schema);
                colvarSiteName.ColumnName = "SiteName";
                colvarSiteName.DataType = DbType.AnsiString;
                colvarSiteName.MaxLength = 150;
                colvarSiteName.AutoIncrement = false;
                colvarSiteName.IsNullable = true;
                colvarSiteName.IsPrimaryKey = false;
                colvarSiteName.IsForeignKey = false;
                colvarSiteName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteName);
                
                TableSchema.TableColumn colvarSiteStartDate = new TableSchema.TableColumn(schema);
                colvarSiteStartDate.ColumnName = "SiteStartDate";
                colvarSiteStartDate.DataType = DbType.Date;
                colvarSiteStartDate.MaxLength = 0;
                colvarSiteStartDate.AutoIncrement = false;
                colvarSiteStartDate.IsNullable = true;
                colvarSiteStartDate.IsPrimaryKey = false;
                colvarSiteStartDate.IsForeignKey = false;
                colvarSiteStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteStartDate);
                
                TableSchema.TableColumn colvarSiteEndDate = new TableSchema.TableColumn(schema);
                colvarSiteEndDate.ColumnName = "SiteEndDate";
                colvarSiteEndDate.DataType = DbType.Date;
                colvarSiteEndDate.MaxLength = 0;
                colvarSiteEndDate.AutoIncrement = false;
                colvarSiteEndDate.IsNullable = true;
                colvarSiteEndDate.IsPrimaryKey = false;
                colvarSiteEndDate.IsForeignKey = false;
                colvarSiteEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarSiteEndDate);
                
                TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
                colvarStartDate.ColumnName = "StartDate";
                colvarStartDate.DataType = DbType.Date;
                colvarStartDate.MaxLength = 0;
                colvarStartDate.AutoIncrement = false;
                colvarStartDate.IsNullable = true;
                colvarStartDate.IsPrimaryKey = false;
                colvarStartDate.IsForeignKey = false;
                colvarStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStartDate);
                
                TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
                colvarEndDate.ColumnName = "EndDate";
                colvarEndDate.DataType = DbType.Date;
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
                DataService.Providers["ObservationsDB"].AddSchema("vSensorDates",schema);
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
	    public VSensorDate()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSensorDate(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VSensorDate(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VSensorDate(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
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
	      
        [XmlAttribute("InstrumenSensorStartDate")]
        [Bindable(true)]
        public DateTime? InstrumenSensorStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("InstrumenSensorStartDate");
		    }
            set 
		    {
			    SetColumnValue("InstrumenSensorStartDate", value);
            }
        }
	      
        [XmlAttribute("InstrumenSensorEndDate")]
        [Bindable(true)]
        public DateTime? InstrumenSensorEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("InstrumenSensorEndDate");
		    }
            set 
		    {
			    SetColumnValue("InstrumenSensorEndDate", value);
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
	      
        [XmlAttribute("InstrumentStartDate")]
        [Bindable(true)]
        public DateTime? InstrumentStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("InstrumentStartDate");
		    }
            set 
		    {
			    SetColumnValue("InstrumentStartDate", value);
            }
        }
	      
        [XmlAttribute("InstrumentEndDate")]
        [Bindable(true)]
        public DateTime? InstrumentEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("InstrumentEndDate");
		    }
            set 
		    {
			    SetColumnValue("InstrumentEndDate", value);
            }
        }
	      
        [XmlAttribute("StationInstrumentStartDate")]
        [Bindable(true)]
        public DateTime? StationInstrumentStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StationInstrumentStartDate");
		    }
            set 
		    {
			    SetColumnValue("StationInstrumentStartDate", value);
            }
        }
	      
        [XmlAttribute("StationInstrumentEndDate")]
        [Bindable(true)]
        public DateTime? StationInstrumentEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StationInstrumentEndDate");
		    }
            set 
		    {
			    SetColumnValue("StationInstrumentEndDate", value);
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
	      
        [XmlAttribute("StationStartDate")]
        [Bindable(true)]
        public DateTime? StationStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StationStartDate");
		    }
            set 
		    {
			    SetColumnValue("StationStartDate", value);
            }
        }
	      
        [XmlAttribute("StationEndDate")]
        [Bindable(true)]
        public DateTime? StationEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("StationEndDate");
		    }
            set 
		    {
			    SetColumnValue("StationEndDate", value);
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
	      
        [XmlAttribute("SiteStartDate")]
        [Bindable(true)]
        public DateTime? SiteStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("SiteStartDate");
		    }
            set 
		    {
			    SetColumnValue("SiteStartDate", value);
            }
        }
	      
        [XmlAttribute("SiteEndDate")]
        [Bindable(true)]
        public DateTime? SiteEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("SiteEndDate");
		    }
            set 
		    {
			    SetColumnValue("SiteEndDate", value);
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
		    
		    
            public static string SensorID = @"SensorID";
            
            public static string SensorName = @"SensorName";
            
            public static string InstrumenSensorStartDate = @"InstrumenSensorStartDate";
            
            public static string InstrumenSensorEndDate = @"InstrumenSensorEndDate";
            
            public static string InstrumentName = @"InstrumentName";
            
            public static string InstrumentStartDate = @"InstrumentStartDate";
            
            public static string InstrumentEndDate = @"InstrumentEndDate";
            
            public static string StationInstrumentStartDate = @"StationInstrumentStartDate";
            
            public static string StationInstrumentEndDate = @"StationInstrumentEndDate";
            
            public static string StationName = @"StationName";
            
            public static string StationStartDate = @"StationStartDate";
            
            public static string StationEndDate = @"StationEndDate";
            
            public static string SiteName = @"SiteName";
            
            public static string SiteStartDate = @"SiteStartDate";
            
            public static string SiteEndDate = @"SiteEndDate";
            
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
