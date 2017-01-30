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
    /// Strongly-typed collection for the VDataSourceTransformation class.
    /// </summary>
    [Serializable]
    public partial class VDataSourceTransformationCollection : ReadOnlyList<VDataSourceTransformation, VDataSourceTransformationCollection>
    {        
        public VDataSourceTransformationCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vDataSourceTransformation view.
    /// </summary>
    [Serializable]
    public partial class VDataSourceTransformation : ReadOnlyRecord<VDataSourceTransformation>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vDataSourceTransformation", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarTransformationTypeID = new TableSchema.TableColumn(schema);
                colvarTransformationTypeID.ColumnName = "TransformationTypeID";
                colvarTransformationTypeID.DataType = DbType.Guid;
                colvarTransformationTypeID.MaxLength = 0;
                colvarTransformationTypeID.AutoIncrement = false;
                colvarTransformationTypeID.IsNullable = false;
                colvarTransformationTypeID.IsPrimaryKey = false;
                colvarTransformationTypeID.IsForeignKey = false;
                colvarTransformationTypeID.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransformationTypeID);
                
                TableSchema.TableColumn colvarPhenomenonID = new TableSchema.TableColumn(schema);
                colvarPhenomenonID.ColumnName = "PhenomenonID";
                colvarPhenomenonID.DataType = DbType.Guid;
                colvarPhenomenonID.MaxLength = 0;
                colvarPhenomenonID.AutoIncrement = false;
                colvarPhenomenonID.IsNullable = false;
                colvarPhenomenonID.IsPrimaryKey = false;
                colvarPhenomenonID.IsForeignKey = false;
                colvarPhenomenonID.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonID);
                
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
                
                TableSchema.TableColumn colvarDataSourceID = new TableSchema.TableColumn(schema);
                colvarDataSourceID.ColumnName = "DataSourceID";
                colvarDataSourceID.DataType = DbType.Guid;
                colvarDataSourceID.MaxLength = 0;
                colvarDataSourceID.AutoIncrement = false;
                colvarDataSourceID.IsNullable = false;
                colvarDataSourceID.IsPrimaryKey = false;
                colvarDataSourceID.IsForeignKey = false;
                colvarDataSourceID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDataSourceID);
                
                TableSchema.TableColumn colvarDefinition = new TableSchema.TableColumn(schema);
                colvarDefinition.ColumnName = "Definition";
                colvarDefinition.DataType = DbType.AnsiString;
                colvarDefinition.MaxLength = 2147483647;
                colvarDefinition.AutoIncrement = false;
                colvarDefinition.IsNullable = false;
                colvarDefinition.IsPrimaryKey = false;
                colvarDefinition.IsForeignKey = false;
                colvarDefinition.IsReadOnly = false;
                
                schema.Columns.Add(colvarDefinition);
                
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
                
                TableSchema.TableColumn colvarTransformationName = new TableSchema.TableColumn(schema);
                colvarTransformationName.ColumnName = "TransformationName";
                colvarTransformationName.DataType = DbType.AnsiString;
                colvarTransformationName.MaxLength = 150;
                colvarTransformationName.AutoIncrement = false;
                colvarTransformationName.IsNullable = false;
                colvarTransformationName.IsPrimaryKey = false;
                colvarTransformationName.IsForeignKey = false;
                colvarTransformationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarTransformationName);
                
                TableSchema.TableColumn colvarPhenomenonOfferingId = new TableSchema.TableColumn(schema);
                colvarPhenomenonOfferingId.ColumnName = "PhenomenonOfferingId";
                colvarPhenomenonOfferingId.DataType = DbType.Guid;
                colvarPhenomenonOfferingId.MaxLength = 0;
                colvarPhenomenonOfferingId.AutoIncrement = false;
                colvarPhenomenonOfferingId.IsNullable = true;
                colvarPhenomenonOfferingId.IsPrimaryKey = false;
                colvarPhenomenonOfferingId.IsForeignKey = false;
                colvarPhenomenonOfferingId.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhenomenonOfferingId);
                
                TableSchema.TableColumn colvarOfferingName = new TableSchema.TableColumn(schema);
                colvarOfferingName.ColumnName = "OfferingName";
                colvarOfferingName.DataType = DbType.AnsiString;
                colvarOfferingName.MaxLength = 150;
                colvarOfferingName.AutoIncrement = false;
                colvarOfferingName.IsNullable = true;
                colvarOfferingName.IsPrimaryKey = false;
                colvarOfferingName.IsForeignKey = false;
                colvarOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOfferingName);
                
                TableSchema.TableColumn colvarUnitOfMeasureId = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureId.ColumnName = "UnitOfMeasureId";
                colvarUnitOfMeasureId.DataType = DbType.Guid;
                colvarUnitOfMeasureId.MaxLength = 0;
                colvarUnitOfMeasureId.AutoIncrement = false;
                colvarUnitOfMeasureId.IsNullable = true;
                colvarUnitOfMeasureId.IsPrimaryKey = false;
                colvarUnitOfMeasureId.IsForeignKey = false;
                colvarUnitOfMeasureId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureId);
                
                TableSchema.TableColumn colvarUnitOfMeasureUnit = new TableSchema.TableColumn(schema);
                colvarUnitOfMeasureUnit.ColumnName = "UnitOfMeasureUnit";
                colvarUnitOfMeasureUnit.DataType = DbType.AnsiString;
                colvarUnitOfMeasureUnit.MaxLength = 100;
                colvarUnitOfMeasureUnit.AutoIncrement = false;
                colvarUnitOfMeasureUnit.IsNullable = true;
                colvarUnitOfMeasureUnit.IsPrimaryKey = false;
                colvarUnitOfMeasureUnit.IsForeignKey = false;
                colvarUnitOfMeasureUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarUnitOfMeasureUnit);
                
                TableSchema.TableColumn colvarNewPhenomenonOfferingID = new TableSchema.TableColumn(schema);
                colvarNewPhenomenonOfferingID.ColumnName = "NewPhenomenonOfferingID";
                colvarNewPhenomenonOfferingID.DataType = DbType.Guid;
                colvarNewPhenomenonOfferingID.MaxLength = 0;
                colvarNewPhenomenonOfferingID.AutoIncrement = false;
                colvarNewPhenomenonOfferingID.IsNullable = true;
                colvarNewPhenomenonOfferingID.IsPrimaryKey = false;
                colvarNewPhenomenonOfferingID.IsForeignKey = false;
                colvarNewPhenomenonOfferingID.IsReadOnly = false;
                
                schema.Columns.Add(colvarNewPhenomenonOfferingID);
                
                TableSchema.TableColumn colvarNewOfferingName = new TableSchema.TableColumn(schema);
                colvarNewOfferingName.ColumnName = "NewOfferingName";
                colvarNewOfferingName.DataType = DbType.AnsiString;
                colvarNewOfferingName.MaxLength = 150;
                colvarNewOfferingName.AutoIncrement = false;
                colvarNewOfferingName.IsNullable = true;
                colvarNewOfferingName.IsPrimaryKey = false;
                colvarNewOfferingName.IsForeignKey = false;
                colvarNewOfferingName.IsReadOnly = false;
                
                schema.Columns.Add(colvarNewOfferingName);
                
                TableSchema.TableColumn colvarNewPhenomenonUOMID = new TableSchema.TableColumn(schema);
                colvarNewPhenomenonUOMID.ColumnName = "NewPhenomenonUOMID";
                colvarNewPhenomenonUOMID.DataType = DbType.Guid;
                colvarNewPhenomenonUOMID.MaxLength = 0;
                colvarNewPhenomenonUOMID.AutoIncrement = false;
                colvarNewPhenomenonUOMID.IsNullable = true;
                colvarNewPhenomenonUOMID.IsPrimaryKey = false;
                colvarNewPhenomenonUOMID.IsForeignKey = false;
                colvarNewPhenomenonUOMID.IsReadOnly = false;
                
                schema.Columns.Add(colvarNewPhenomenonUOMID);
                
                TableSchema.TableColumn colvarNewUnitOfMeasureUnit = new TableSchema.TableColumn(schema);
                colvarNewUnitOfMeasureUnit.ColumnName = "NewUnitOfMeasureUnit";
                colvarNewUnitOfMeasureUnit.DataType = DbType.AnsiString;
                colvarNewUnitOfMeasureUnit.MaxLength = 100;
                colvarNewUnitOfMeasureUnit.AutoIncrement = false;
                colvarNewUnitOfMeasureUnit.IsNullable = true;
                colvarNewUnitOfMeasureUnit.IsPrimaryKey = false;
                colvarNewUnitOfMeasureUnit.IsForeignKey = false;
                colvarNewUnitOfMeasureUnit.IsReadOnly = false;
                
                schema.Columns.Add(colvarNewUnitOfMeasureUnit);
                
                TableSchema.TableColumn colvarIorder = new TableSchema.TableColumn(schema);
                colvarIorder.ColumnName = "iorder";
                colvarIorder.DataType = DbType.Int32;
                colvarIorder.MaxLength = 0;
                colvarIorder.AutoIncrement = false;
                colvarIorder.IsNullable = true;
                colvarIorder.IsPrimaryKey = false;
                colvarIorder.IsForeignKey = false;
                colvarIorder.IsReadOnly = false;
                
                schema.Columns.Add(colvarIorder);
                
                TableSchema.TableColumn colvarRank = new TableSchema.TableColumn(schema);
                colvarRank.ColumnName = "Rank";
                colvarRank.DataType = DbType.Int32;
                colvarRank.MaxLength = 0;
                colvarRank.AutoIncrement = false;
                colvarRank.IsNullable = true;
                colvarRank.IsPrimaryKey = false;
                colvarRank.IsForeignKey = false;
                colvarRank.IsReadOnly = false;
                
                schema.Columns.Add(colvarRank);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vDataSourceTransformation",schema);
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
	    public VDataSourceTransformation()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VDataSourceTransformation(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VDataSourceTransformation(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VDataSourceTransformation(string columnName, object columnValue)
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
	      
        [XmlAttribute("TransformationTypeID")]
        [Bindable(true)]
        public Guid TransformationTypeID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("TransformationTypeID");
		    }
            set 
		    {
			    SetColumnValue("TransformationTypeID", value);
            }
        }
	      
        [XmlAttribute("PhenomenonID")]
        [Bindable(true)]
        public Guid PhenomenonID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("PhenomenonID");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonID", value);
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
	      
        [XmlAttribute("DataSourceID")]
        [Bindable(true)]
        public Guid DataSourceID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("DataSourceID");
		    }
            set 
		    {
			    SetColumnValue("DataSourceID", value);
            }
        }
	      
        [XmlAttribute("Definition")]
        [Bindable(true)]
        public string Definition 
	    {
		    get
		    {
			    return GetColumnValue<string>("Definition");
		    }
            set 
		    {
			    SetColumnValue("Definition", value);
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
	      
        [XmlAttribute("TransformationName")]
        [Bindable(true)]
        public string TransformationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("TransformationName");
		    }
            set 
		    {
			    SetColumnValue("TransformationName", value);
            }
        }
	      
        [XmlAttribute("PhenomenonOfferingId")]
        [Bindable(true)]
        public Guid? PhenomenonOfferingId 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("PhenomenonOfferingId");
		    }
            set 
		    {
			    SetColumnValue("PhenomenonOfferingId", value);
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
	      
        [XmlAttribute("UnitOfMeasureId")]
        [Bindable(true)]
        public Guid? UnitOfMeasureId 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("UnitOfMeasureId");
		    }
            set 
		    {
			    SetColumnValue("UnitOfMeasureId", value);
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
	      
        [XmlAttribute("NewPhenomenonOfferingID")]
        [Bindable(true)]
        public Guid? NewPhenomenonOfferingID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("NewPhenomenonOfferingID");
		    }
            set 
		    {
			    SetColumnValue("NewPhenomenonOfferingID", value);
            }
        }
	      
        [XmlAttribute("NewOfferingName")]
        [Bindable(true)]
        public string NewOfferingName 
	    {
		    get
		    {
			    return GetColumnValue<string>("NewOfferingName");
		    }
            set 
		    {
			    SetColumnValue("NewOfferingName", value);
            }
        }
	      
        [XmlAttribute("NewPhenomenonUOMID")]
        [Bindable(true)]
        public Guid? NewPhenomenonUOMID 
	    {
		    get
		    {
			    return GetColumnValue<Guid?>("NewPhenomenonUOMID");
		    }
            set 
		    {
			    SetColumnValue("NewPhenomenonUOMID", value);
            }
        }
	      
        [XmlAttribute("NewUnitOfMeasureUnit")]
        [Bindable(true)]
        public string NewUnitOfMeasureUnit 
	    {
		    get
		    {
			    return GetColumnValue<string>("NewUnitOfMeasureUnit");
		    }
            set 
		    {
			    SetColumnValue("NewUnitOfMeasureUnit", value);
            }
        }
	      
        [XmlAttribute("Iorder")]
        [Bindable(true)]
        public int? Iorder 
	    {
		    get
		    {
			    return GetColumnValue<int?>("iorder");
		    }
            set 
		    {
			    SetColumnValue("iorder", value);
            }
        }
	      
        [XmlAttribute("Rank")]
        [Bindable(true)]
        public int? Rank 
	    {
		    get
		    {
			    return GetColumnValue<int?>("Rank");
		    }
            set 
		    {
			    SetColumnValue("Rank", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string TransformationTypeID = @"TransformationTypeID";
            
            public static string PhenomenonID = @"PhenomenonID";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string DataSourceID = @"DataSourceID";
            
            public static string Definition = @"Definition";
            
            public static string PhenomenonName = @"PhenomenonName";
            
            public static string TransformationName = @"TransformationName";
            
            public static string PhenomenonOfferingId = @"PhenomenonOfferingId";
            
            public static string OfferingName = @"OfferingName";
            
            public static string UnitOfMeasureId = @"UnitOfMeasureId";
            
            public static string UnitOfMeasureUnit = @"UnitOfMeasureUnit";
            
            public static string NewPhenomenonOfferingID = @"NewPhenomenonOfferingID";
            
            public static string NewOfferingName = @"NewOfferingName";
            
            public static string NewPhenomenonUOMID = @"NewPhenomenonUOMID";
            
            public static string NewUnitOfMeasureUnit = @"NewUnitOfMeasureUnit";
            
            public static string Iorder = @"iorder";
            
            public static string Rank = @"Rank";
            
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
