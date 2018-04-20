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
    /// Strongly-typed collection for the VInventoryInstrument class.
    /// </summary>
    [Serializable]
    public partial class VInventoryInstrumentCollection : ReadOnlyList<VInventoryInstrument, VInventoryInstrumentCollection>
    {        
        public VInventoryInstrumentCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vInventoryInstruments view.
    /// </summary>
    [Serializable]
    public partial class VInventoryInstrument : ReadOnlyRecord<VInventoryInstrument>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vInventoryInstruments", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarSurrogateKey = new TableSchema.TableColumn(schema);
                colvarSurrogateKey.ColumnName = "SurrogateKey";
                colvarSurrogateKey.DataType = DbType.AnsiString;
                colvarSurrogateKey.MaxLength = 301;
                colvarSurrogateKey.AutoIncrement = false;
                colvarSurrogateKey.IsNullable = false;
                colvarSurrogateKey.IsPrimaryKey = false;
                colvarSurrogateKey.IsForeignKey = false;
                colvarSurrogateKey.IsReadOnly = false;
                
                schema.Columns.Add(colvarSurrogateKey);
                
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
                
                TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
                colvarStatus.ColumnName = "Status";
                colvarStatus.DataType = DbType.AnsiString;
                colvarStatus.MaxLength = 150;
                colvarStatus.AutoIncrement = false;
                colvarStatus.IsNullable = false;
                colvarStatus.IsPrimaryKey = false;
                colvarStatus.IsForeignKey = false;
                colvarStatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarStatus);
                
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
                
                TableSchema.TableColumn colvarMinimum = new TableSchema.TableColumn(schema);
                colvarMinimum.ColumnName = "Minimum";
                colvarMinimum.DataType = DbType.Double;
                colvarMinimum.MaxLength = 0;
                colvarMinimum.AutoIncrement = false;
                colvarMinimum.IsNullable = true;
                colvarMinimum.IsPrimaryKey = false;
                colvarMinimum.IsForeignKey = false;
                colvarMinimum.IsReadOnly = false;
                
                schema.Columns.Add(colvarMinimum);
                
                TableSchema.TableColumn colvarMaximum = new TableSchema.TableColumn(schema);
                colvarMaximum.ColumnName = "Maximum";
                colvarMaximum.DataType = DbType.Double;
                colvarMaximum.MaxLength = 0;
                colvarMaximum.AutoIncrement = false;
                colvarMaximum.IsNullable = true;
                colvarMaximum.IsPrimaryKey = false;
                colvarMaximum.IsForeignKey = false;
                colvarMaximum.IsReadOnly = false;
                
                schema.Columns.Add(colvarMaximum);
                
                TableSchema.TableColumn colvarAverage = new TableSchema.TableColumn(schema);
                colvarAverage.ColumnName = "Average";
                colvarAverage.DataType = DbType.Double;
                colvarAverage.MaxLength = 0;
                colvarAverage.AutoIncrement = false;
                colvarAverage.IsNullable = true;
                colvarAverage.IsPrimaryKey = false;
                colvarAverage.IsForeignKey = false;
                colvarAverage.IsReadOnly = false;
                
                schema.Columns.Add(colvarAverage);
                
                TableSchema.TableColumn colvarStandardDeviation = new TableSchema.TableColumn(schema);
                colvarStandardDeviation.ColumnName = "StandardDeviation";
                colvarStandardDeviation.DataType = DbType.Double;
                colvarStandardDeviation.MaxLength = 0;
                colvarStandardDeviation.AutoIncrement = false;
                colvarStandardDeviation.IsNullable = true;
                colvarStandardDeviation.IsPrimaryKey = false;
                colvarStandardDeviation.IsForeignKey = false;
                colvarStandardDeviation.IsReadOnly = false;
                
                schema.Columns.Add(colvarStandardDeviation);
                
                TableSchema.TableColumn colvarVariance = new TableSchema.TableColumn(schema);
                colvarVariance.ColumnName = "Variance";
                colvarVariance.DataType = DbType.Double;
                colvarVariance.MaxLength = 0;
                colvarVariance.AutoIncrement = false;
                colvarVariance.IsNullable = true;
                colvarVariance.IsPrimaryKey = false;
                colvarVariance.IsForeignKey = false;
                colvarVariance.IsReadOnly = false;
                
                schema.Columns.Add(colvarVariance);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vInventoryInstruments",schema);
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
	    public VInventoryInstrument()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VInventoryInstrument(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VInventoryInstrument(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VInventoryInstrument(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SurrogateKey")]
        [Bindable(true)]
        public string SurrogateKey 
	    {
		    get
		    {
			    return GetColumnValue<string>("SurrogateKey");
		    }
            set 
		    {
			    SetColumnValue("SurrogateKey", value);
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
	      
        [XmlAttribute("Status")]
        [Bindable(true)]
        public string Status 
	    {
		    get
		    {
			    return GetColumnValue<string>("Status");
		    }
            set 
		    {
			    SetColumnValue("Status", value);
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
	      
        [XmlAttribute("Minimum")]
        [Bindable(true)]
        public double? Minimum 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Minimum");
		    }
            set 
		    {
			    SetColumnValue("Minimum", value);
            }
        }
	      
        [XmlAttribute("Maximum")]
        [Bindable(true)]
        public double? Maximum 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Maximum");
		    }
            set 
		    {
			    SetColumnValue("Maximum", value);
            }
        }
	      
        [XmlAttribute("Average")]
        [Bindable(true)]
        public double? Average 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Average");
		    }
            set 
		    {
			    SetColumnValue("Average", value);
            }
        }
	      
        [XmlAttribute("StandardDeviation")]
        [Bindable(true)]
        public double? StandardDeviation 
	    {
		    get
		    {
			    return GetColumnValue<double?>("StandardDeviation");
		    }
            set 
		    {
			    SetColumnValue("StandardDeviation", value);
            }
        }
	      
        [XmlAttribute("Variance")]
        [Bindable(true)]
        public double? Variance 
	    {
		    get
		    {
			    return GetColumnValue<double?>("Variance");
		    }
            set 
		    {
			    SetColumnValue("Variance", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SurrogateKey = @"SurrogateKey";
            
            public static string InstrumentName = @"InstrumentName";
            
            public static string Status = @"Status";
            
            public static string Count = @"Count";
            
            public static string Minimum = @"Minimum";
            
            public static string Maximum = @"Maximum";
            
            public static string Average = @"Average";
            
            public static string StandardDeviation = @"StandardDeviation";
            
            public static string Variance = @"Variance";
            
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
