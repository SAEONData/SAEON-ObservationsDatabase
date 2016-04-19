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
namespace SAEON.ObservationsDB.Data{
    /// <summary>
    /// Strongly-typed collection for the VStationOrganisation class.
    /// </summary>
    [Serializable]
    public partial class VStationOrganisationCollection : ReadOnlyList<VStationOrganisation, VStationOrganisationCollection>
    {        
        public VStationOrganisationCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vStationOrganisation view.
    /// </summary>
    [Serializable]
    public partial class VStationOrganisation : ReadOnlyRecord<VStationOrganisation>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vStationOrganisation", TableType.View, DataService.GetInstance("ObservationsDB"));
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
                
                TableSchema.TableColumn colvarOrganisationID = new TableSchema.TableColumn(schema);
                colvarOrganisationID.ColumnName = "OrganisationID";
                colvarOrganisationID.DataType = DbType.Guid;
                colvarOrganisationID.MaxLength = 0;
                colvarOrganisationID.AutoIncrement = false;
                colvarOrganisationID.IsNullable = false;
                colvarOrganisationID.IsPrimaryKey = false;
                colvarOrganisationID.IsForeignKey = false;
                colvarOrganisationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationID);
                
                TableSchema.TableColumn colvarOrganisationRoleID = new TableSchema.TableColumn(schema);
                colvarOrganisationRoleID.ColumnName = "OrganisationRoleID";
                colvarOrganisationRoleID.DataType = DbType.Guid;
                colvarOrganisationRoleID.MaxLength = 0;
                colvarOrganisationRoleID.AutoIncrement = false;
                colvarOrganisationRoleID.IsNullable = false;
                colvarOrganisationRoleID.IsPrimaryKey = false;
                colvarOrganisationRoleID.IsForeignKey = false;
                colvarOrganisationRoleID.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationRoleID);
                
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
                
                TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
                colvarUserId.ColumnName = "UserId";
                colvarUserId.DataType = DbType.Guid;
                colvarUserId.MaxLength = 0;
                colvarUserId.AutoIncrement = false;
                colvarUserId.IsNullable = false;
                colvarUserId.IsPrimaryKey = false;
                colvarUserId.IsForeignKey = false;
                colvarUserId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserId);
                
                TableSchema.TableColumn colvarOrganisationName = new TableSchema.TableColumn(schema);
                colvarOrganisationName.ColumnName = "OrganisationName";
                colvarOrganisationName.DataType = DbType.AnsiString;
                colvarOrganisationName.MaxLength = 150;
                colvarOrganisationName.AutoIncrement = false;
                colvarOrganisationName.IsNullable = false;
                colvarOrganisationName.IsPrimaryKey = false;
                colvarOrganisationName.IsForeignKey = false;
                colvarOrganisationName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationName);
                
                TableSchema.TableColumn colvarOrganisationRoleName = new TableSchema.TableColumn(schema);
                colvarOrganisationRoleName.ColumnName = "OrganisationRoleName";
                colvarOrganisationRoleName.DataType = DbType.AnsiString;
                colvarOrganisationRoleName.MaxLength = 150;
                colvarOrganisationRoleName.AutoIncrement = false;
                colvarOrganisationRoleName.IsNullable = false;
                colvarOrganisationRoleName.IsPrimaryKey = false;
                colvarOrganisationRoleName.IsForeignKey = false;
                colvarOrganisationRoleName.IsReadOnly = false;
                
                schema.Columns.Add(colvarOrganisationRoleName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["ObservationsDB"].AddSchema("vStationOrganisation",schema);
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
	    public VStationOrganisation()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VStationOrganisation(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VStationOrganisation(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VStationOrganisation(string columnName, object columnValue)
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
	      
        [XmlAttribute("OrganisationID")]
        [Bindable(true)]
        public Guid OrganisationID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("OrganisationID");
		    }
            set 
		    {
			    SetColumnValue("OrganisationID", value);
            }
        }
	      
        [XmlAttribute("OrganisationRoleID")]
        [Bindable(true)]
        public Guid OrganisationRoleID 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("OrganisationRoleID");
		    }
            set 
		    {
			    SetColumnValue("OrganisationRoleID", value);
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
	      
        [XmlAttribute("UserId")]
        [Bindable(true)]
        public Guid UserId 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("UserId");
		    }
            set 
		    {
			    SetColumnValue("UserId", value);
            }
        }
	      
        [XmlAttribute("OrganisationName")]
        [Bindable(true)]
        public string OrganisationName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OrganisationName");
		    }
            set 
		    {
			    SetColumnValue("OrganisationName", value);
            }
        }
	      
        [XmlAttribute("OrganisationRoleName")]
        [Bindable(true)]
        public string OrganisationRoleName 
	    {
		    get
		    {
			    return GetColumnValue<string>("OrganisationRoleName");
		    }
            set 
		    {
			    SetColumnValue("OrganisationRoleName", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string Id = @"ID";
            
            public static string StationID = @"StationID";
            
            public static string OrganisationID = @"OrganisationID";
            
            public static string OrganisationRoleID = @"OrganisationRoleID";
            
            public static string StartDate = @"StartDate";
            
            public static string EndDate = @"EndDate";
            
            public static string UserId = @"UserId";
            
            public static string OrganisationName = @"OrganisationName";
            
            public static string OrganisationRoleName = @"OrganisationRoleName";
            
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
