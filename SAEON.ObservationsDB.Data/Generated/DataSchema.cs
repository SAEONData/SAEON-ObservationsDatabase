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
namespace SAEON.ObservationsDB.Data
{
	/// <summary>
	/// Strongly-typed collection for the DataSchema class.
	/// </summary>
    [Serializable]
	public partial class DataSchemaCollection : ActiveList<DataSchema, DataSchemaCollection>
	{	   
		public DataSchemaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DataSchemaCollection</returns>
		public DataSchemaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DataSchema o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the DataSchema table.
	/// </summary>
	[Serializable]
	public partial class DataSchema : ActiveRecord<DataSchema>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DataSchema()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DataSchema(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DataSchema(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DataSchema(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("DataSchema", TableType.Table, DataService.GetInstance("SqlDataProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Guid;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				
						colvarId.DefaultSetting = @"(newid())";
				colvarId.ForeignKeyTableName = "";
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
				colvarCode.DefaultSetting = @"";
				colvarCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCode);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 100;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
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
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarDataSourceTypeID = new TableSchema.TableColumn(schema);
				colvarDataSourceTypeID.ColumnName = "DataSourceTypeID";
				colvarDataSourceTypeID.DataType = DbType.Guid;
				colvarDataSourceTypeID.MaxLength = 0;
				colvarDataSourceTypeID.AutoIncrement = false;
				colvarDataSourceTypeID.IsNullable = false;
				colvarDataSourceTypeID.IsPrimaryKey = false;
				colvarDataSourceTypeID.IsForeignKey = true;
				colvarDataSourceTypeID.IsReadOnly = false;
				colvarDataSourceTypeID.DefaultSetting = @"";
				
					colvarDataSourceTypeID.ForeignKeyTableName = "DataSourceType";
				schema.Columns.Add(colvarDataSourceTypeID);
				
				TableSchema.TableColumn colvarIgnoreFirst = new TableSchema.TableColumn(schema);
				colvarIgnoreFirst.ColumnName = "IgnoreFirst";
				colvarIgnoreFirst.DataType = DbType.Int32;
				colvarIgnoreFirst.MaxLength = 0;
				colvarIgnoreFirst.AutoIncrement = false;
				colvarIgnoreFirst.IsNullable = false;
				colvarIgnoreFirst.IsPrimaryKey = false;
				colvarIgnoreFirst.IsForeignKey = false;
				colvarIgnoreFirst.IsReadOnly = false;
				
						colvarIgnoreFirst.DefaultSetting = @"((0))";
				colvarIgnoreFirst.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIgnoreFirst);
				
				TableSchema.TableColumn colvarIgnoreLast = new TableSchema.TableColumn(schema);
				colvarIgnoreLast.ColumnName = "IgnoreLast";
				colvarIgnoreLast.DataType = DbType.Int32;
				colvarIgnoreLast.MaxLength = 0;
				colvarIgnoreLast.AutoIncrement = false;
				colvarIgnoreLast.IsNullable = false;
				colvarIgnoreLast.IsPrimaryKey = false;
				colvarIgnoreLast.IsForeignKey = false;
				colvarIgnoreLast.IsReadOnly = false;
				
						colvarIgnoreLast.DefaultSetting = @"((0))";
				colvarIgnoreLast.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIgnoreLast);
				
				TableSchema.TableColumn colvarCondition = new TableSchema.TableColumn(schema);
				colvarCondition.ColumnName = "Condition";
				colvarCondition.DataType = DbType.AnsiString;
				colvarCondition.MaxLength = 500;
				colvarCondition.AutoIncrement = false;
				colvarCondition.IsNullable = true;
				colvarCondition.IsPrimaryKey = false;
				colvarCondition.IsForeignKey = false;
				colvarCondition.IsReadOnly = false;
				colvarCondition.DefaultSetting = @"";
				colvarCondition.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCondition);
				
				TableSchema.TableColumn colvarDataSchemaX = new TableSchema.TableColumn(schema);
				colvarDataSchemaX.ColumnName = "DataSchema";
				colvarDataSchemaX.DataType = DbType.AnsiString;
				colvarDataSchemaX.MaxLength = 2147483647;
				colvarDataSchemaX.AutoIncrement = false;
				colvarDataSchemaX.IsNullable = true;
				colvarDataSchemaX.IsPrimaryKey = false;
				colvarDataSchemaX.IsForeignKey = false;
				colvarDataSchemaX.IsReadOnly = false;
				colvarDataSchemaX.DefaultSetting = @"";
				colvarDataSchemaX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDataSchemaX);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = false;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				colvarUserId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserId);
				
				TableSchema.TableColumn colvarDelimiter = new TableSchema.TableColumn(schema);
				colvarDelimiter.ColumnName = "Delimiter";
				colvarDelimiter.DataType = DbType.AnsiString;
				colvarDelimiter.MaxLength = 3;
				colvarDelimiter.AutoIncrement = false;
				colvarDelimiter.IsNullable = true;
				colvarDelimiter.IsPrimaryKey = false;
				colvarDelimiter.IsForeignKey = false;
				colvarDelimiter.IsReadOnly = false;
				colvarDelimiter.DefaultSetting = @"";
				colvarDelimiter.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDelimiter);
				
				TableSchema.TableColumn colvarSplitSelector = new TableSchema.TableColumn(schema);
				colvarSplitSelector.ColumnName = "SplitSelector";
				colvarSplitSelector.DataType = DbType.AnsiString;
				colvarSplitSelector.MaxLength = 50;
				colvarSplitSelector.AutoIncrement = false;
				colvarSplitSelector.IsNullable = true;
				colvarSplitSelector.IsPrimaryKey = false;
				colvarSplitSelector.IsForeignKey = false;
				colvarSplitSelector.IsReadOnly = false;
				colvarSplitSelector.DefaultSetting = @"";
				colvarSplitSelector.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSplitSelector);
				
				TableSchema.TableColumn colvarSplitIndex = new TableSchema.TableColumn(schema);
				colvarSplitIndex.ColumnName = "SplitIndex";
				colvarSplitIndex.DataType = DbType.Int32;
				colvarSplitIndex.MaxLength = 0;
				colvarSplitIndex.AutoIncrement = false;
				colvarSplitIndex.IsNullable = true;
				colvarSplitIndex.IsPrimaryKey = false;
				colvarSplitIndex.IsForeignKey = false;
				colvarSplitIndex.IsReadOnly = false;
				colvarSplitIndex.DefaultSetting = @"";
				colvarSplitIndex.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSplitIndex);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SqlDataProvider"].AddSchema("DataSchema",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public Guid Id 
		{
			get { return GetColumnValue<Guid>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Code")]
		[Bindable(true)]
		public string Code 
		{
			get { return GetColumnValue<string>(Columns.Code); }
			set { SetColumnValue(Columns.Code, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("DataSourceTypeID")]
		[Bindable(true)]
		public Guid DataSourceTypeID 
		{
			get { return GetColumnValue<Guid>(Columns.DataSourceTypeID); }
			set { SetColumnValue(Columns.DataSourceTypeID, value); }
		}
		  
		[XmlAttribute("IgnoreFirst")]
		[Bindable(true)]
		public int IgnoreFirst 
		{
			get { return GetColumnValue<int>(Columns.IgnoreFirst); }
			set { SetColumnValue(Columns.IgnoreFirst, value); }
		}
		  
		[XmlAttribute("IgnoreLast")]
		[Bindable(true)]
		public int IgnoreLast 
		{
			get { return GetColumnValue<int>(Columns.IgnoreLast); }
			set { SetColumnValue(Columns.IgnoreLast, value); }
		}
		  
		[XmlAttribute("Condition")]
		[Bindable(true)]
		public string Condition 
		{
			get { return GetColumnValue<string>(Columns.Condition); }
			set { SetColumnValue(Columns.Condition, value); }
		}
		  
		[XmlAttribute("DataSchemaX")]
		[Bindable(true)]
		public string DataSchemaX 
		{
			get { return GetColumnValue<string>(Columns.DataSchemaX); }
			set { SetColumnValue(Columns.DataSchemaX, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid UserId 
		{
			get { return GetColumnValue<Guid>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		  
		[XmlAttribute("Delimiter")]
		[Bindable(true)]
		public string Delimiter 
		{
			get { return GetColumnValue<string>(Columns.Delimiter); }
			set { SetColumnValue(Columns.Delimiter, value); }
		}
		  
		[XmlAttribute("SplitSelector")]
		[Bindable(true)]
		public string SplitSelector 
		{
			get { return GetColumnValue<string>(Columns.SplitSelector); }
			set { SetColumnValue(Columns.SplitSelector, value); }
		}
		  
		[XmlAttribute("SplitIndex")]
		[Bindable(true)]
		public int? SplitIndex 
		{
			get { return GetColumnValue<int?>(Columns.SplitIndex); }
			set { SetColumnValue(Columns.SplitIndex, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public SAEON.ObservationsDB.Data.SensorProcedureCollection SensorProcedureRecords()
		{
			return new SAEON.ObservationsDB.Data.SensorProcedureCollection().Where(SensorProcedure.Columns.DataSchemaID, Id).Load();
		}
		public SAEON.ObservationsDB.Data.DataSourceCollection DataSourceRecords()
		{
			return new SAEON.ObservationsDB.Data.DataSourceCollection().Where(DataSource.Columns.DataSchemaID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a DataSourceType ActiveRecord object related to this DataSchema
		/// 
		/// </summary>
		public SAEON.ObservationsDB.Data.DataSourceType DataSourceType
		{
			get { return SAEON.ObservationsDB.Data.DataSourceType.FetchByID(this.DataSourceTypeID); }
			set { SetColumnValue("DataSourceTypeID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,string varCode,string varName,string varDescription,Guid varDataSourceTypeID,int varIgnoreFirst,int varIgnoreLast,string varCondition,string varDataSchemaX,Guid varUserId,string varDelimiter,string varSplitSelector,int? varSplitIndex)
		{
			DataSchema item = new DataSchema();
			
			item.Id = varId;
			
			item.Code = varCode;
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.DataSourceTypeID = varDataSourceTypeID;
			
			item.IgnoreFirst = varIgnoreFirst;
			
			item.IgnoreLast = varIgnoreLast;
			
			item.Condition = varCondition;
			
			item.DataSchemaX = varDataSchemaX;
			
			item.UserId = varUserId;
			
			item.Delimiter = varDelimiter;
			
			item.SplitSelector = varSplitSelector;
			
			item.SplitIndex = varSplitIndex;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varId,string varCode,string varName,string varDescription,Guid varDataSourceTypeID,int varIgnoreFirst,int varIgnoreLast,string varCondition,string varDataSchemaX,Guid varUserId,string varDelimiter,string varSplitSelector,int? varSplitIndex)
		{
			DataSchema item = new DataSchema();
			
				item.Id = varId;
			
				item.Code = varCode;
			
				item.Name = varName;
			
				item.Description = varDescription;
			
				item.DataSourceTypeID = varDataSourceTypeID;
			
				item.IgnoreFirst = varIgnoreFirst;
			
				item.IgnoreLast = varIgnoreLast;
			
				item.Condition = varCondition;
			
				item.DataSchemaX = varDataSchemaX;
			
				item.UserId = varUserId;
			
				item.Delimiter = varDelimiter;
			
				item.SplitSelector = varSplitSelector;
			
				item.SplitIndex = varSplitIndex;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DataSourceTypeIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn IgnoreFirstColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn IgnoreLastColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ConditionColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DataSchemaXColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn DelimiterColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SplitSelectorColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn SplitIndexColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Code = @"Code";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string DataSourceTypeID = @"DataSourceTypeID";
			 public static string IgnoreFirst = @"IgnoreFirst";
			 public static string IgnoreLast = @"IgnoreLast";
			 public static string Condition = @"Condition";
			 public static string DataSchemaX = @"DataSchema";
			 public static string UserId = @"UserId";
			 public static string Delimiter = @"Delimiter";
			 public static string SplitSelector = @"SplitSelector";
			 public static string SplitIndex = @"SplitIndex";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}