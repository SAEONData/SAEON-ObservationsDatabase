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
    /// Strongly-typed collection for the VSensorThingsAPIThing class.
    /// </summary>
    [Serializable]
    public partial class VSensorThingsAPIThingCollection : ReadOnlyList<VSensorThingsAPIThing, VSensorThingsAPIThingCollection>
    {        
        public VSensorThingsAPIThingCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vSensorThingsAPIThings view.
    /// </summary>
    [Serializable]
    public partial class VSensorThingsAPIThing : ReadOnlyRecord<VSensorThingsAPIThing>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vSensorThingsAPIThings", TableType.View, DataService.GetInstance("ObservationsDB"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "ID";
                colvarId.DataType = DbType.Guid;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = false;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = false;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                
                schema.Columns.Add(colvarId);
                
                TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
                colvarCode.ColumnName = "Code";
                colvarCode.DataType = DbType.AnsiString;
                colvarCode.MaxLength = 50;
                colvarCode.AutoIncrement = false;
                colvarCode.IsNullable = false;
                colvarCode.IsPrimaryKey = false;
                colvarCode.IsForeignKey = false;
                colvarCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarCode);
                
                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.AnsiString;
                colvarName.MaxLength = 150;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                
                schema.Columns.Add(colvarName);
                
                TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
                colvarDescription.ColumnName = "Description";
                colvarDescription.DataType = DbType.AnsiString;
                colvarDescription.MaxLength = 5000;
                colvarDescription.AutoIncrement = false;
                colvarDescription.IsNullable = true;
                colvarDescription.IsPrimaryKey = false;
                colvarDescription.IsForeignKey = false;
                colvarDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarDescription);
                
                TableSchema.TableColumn colvarKind = new TableSchema.TableColumn(schema);
                colvarKind.ColumnName = "Kind";
                colvarKind.DataType = DbType.AnsiString;
                colvarKind.MaxLength = 10;
                colvarKind.AutoIncrement = false;
                colvarKind.IsNullable = false;
                colvarKind.IsPrimaryKey = false;
                colvarKind.IsForeignKey = false;
                colvarKind.IsReadOnly = false;
                
                schema.Columns.Add(colvarKind);
                
                TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
                colvarUrl.ColumnName = "Url";
                colvarUrl.DataType = DbType.AnsiString;
                colvarUrl.MaxLength = 250;
                colvarUrl.AutoIncrement = false;
                colvarUrl.IsNullable = true;
                colvarUrl.IsPrimaryKey = false;
                colvarUrl.IsForeignKey = false;
                colvarUrl.IsReadOnly = false;
                
                schema.Columns.Add(colvarUrl);
                
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
                DataService.Providers["ObservationsDB"].AddSchema("vSensorThingsAPIThings",schema);
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
	    public VSensorThingsAPIThing()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSensorThingsAPIThing(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VSensorThingsAPIThing(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VSensorThingsAPIThing(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("Id")]
        [Bindable(true)]
        public Guid Id 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("ID");
		    }
            set 
		    {
			    SetColumnValue("ID", value);
            }
        }
	      
        [XmlAttribute("Code")]
        [Bindable(true)]
        public string Code 
	    {
		    get
		    {
			    return GetColumnValue<string>("Code");
		    }
            set 
		    {
			    SetColumnValue("Code", value);
            }
        }
	      
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name");
		    }
            set 
		    {
			    SetColumnValue("Name", value);
            }
        }
	      
        [XmlAttribute("Description")]
        [Bindable(true)]
        public string Description 
	    {
		    get
		    {
			    return GetColumnValue<string>("Description");
		    }
            set 
		    {
			    SetColumnValue("Description", value);
            }
        }
	      
        [XmlAttribute("Kind")]
        [Bindable(true)]
        public string Kind 
	    {
		    get
		    {
			    return GetColumnValue<string>("Kind");
		    }
            set 
		    {
			    SetColumnValue("Kind", value);
            }
        }
	      
        [XmlAttribute("Url")]
        [Bindable(true)]
        public string Url 
	    {
		    get
		    {
			    return GetColumnValue<string>("Url");
		    }
            set 
		    {
			    SetColumnValue("Url", value);
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
            
            public static string Code = @"Code";
            
            public static string Name = @"Name";
            
            public static string Description = @"Description";
            
            public static string Kind = @"Kind";
            
            public static string Url = @"Url";
            
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