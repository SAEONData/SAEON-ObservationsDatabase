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
namespace SAEON.Observations.Data
{
	/// <summary>
	/// Strongly-typed collection for the DataSourceTransformation class.
	/// </summary>
    [Serializable]
	public partial class DataSourceTransformationCollection : ActiveList<DataSourceTransformation, DataSourceTransformationCollection>
	{	   
		public DataSourceTransformationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DataSourceTransformationCollection</returns>
		public DataSourceTransformationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DataSourceTransformation o = this[i];
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
	/// This is an ActiveRecord class which wraps the DataSourceTransformation table.
	/// </summary>
	[Serializable]
	public partial class DataSourceTransformation : ActiveRecord<DataSourceTransformation>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DataSourceTransformation()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DataSourceTransformation(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DataSourceTransformation(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DataSourceTransformation(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DataSourceTransformation", TableType.Table, DataService.GetInstance("ObservationsDB"));
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
				
				TableSchema.TableColumn colvarTransformationTypeID = new TableSchema.TableColumn(schema);
				colvarTransformationTypeID.ColumnName = "TransformationTypeID";
				colvarTransformationTypeID.DataType = DbType.Guid;
				colvarTransformationTypeID.MaxLength = 0;
				colvarTransformationTypeID.AutoIncrement = false;
				colvarTransformationTypeID.IsNullable = false;
				colvarTransformationTypeID.IsPrimaryKey = false;
				colvarTransformationTypeID.IsForeignKey = true;
				colvarTransformationTypeID.IsReadOnly = false;
				colvarTransformationTypeID.DefaultSetting = @"";
				
					colvarTransformationTypeID.ForeignKeyTableName = "TransformationType";
				schema.Columns.Add(colvarTransformationTypeID);
				
				TableSchema.TableColumn colvarPhenomenonID = new TableSchema.TableColumn(schema);
				colvarPhenomenonID.ColumnName = "PhenomenonID";
				colvarPhenomenonID.DataType = DbType.Guid;
				colvarPhenomenonID.MaxLength = 0;
				colvarPhenomenonID.AutoIncrement = false;
				colvarPhenomenonID.IsNullable = false;
				colvarPhenomenonID.IsPrimaryKey = false;
				colvarPhenomenonID.IsForeignKey = true;
				colvarPhenomenonID.IsReadOnly = false;
				colvarPhenomenonID.DefaultSetting = @"";
				
					colvarPhenomenonID.ForeignKeyTableName = "Phenomenon";
				schema.Columns.Add(colvarPhenomenonID);
				
				TableSchema.TableColumn colvarPhenomenonOfferingID = new TableSchema.TableColumn(schema);
				colvarPhenomenonOfferingID.ColumnName = "PhenomenonOfferingID";
				colvarPhenomenonOfferingID.DataType = DbType.Guid;
				colvarPhenomenonOfferingID.MaxLength = 0;
				colvarPhenomenonOfferingID.AutoIncrement = false;
				colvarPhenomenonOfferingID.IsNullable = true;
				colvarPhenomenonOfferingID.IsPrimaryKey = false;
				colvarPhenomenonOfferingID.IsForeignKey = true;
				colvarPhenomenonOfferingID.IsReadOnly = false;
				colvarPhenomenonOfferingID.DefaultSetting = @"";
				
					colvarPhenomenonOfferingID.ForeignKeyTableName = "PhenomenonOffering";
				schema.Columns.Add(colvarPhenomenonOfferingID);
				
				TableSchema.TableColumn colvarPhenomenonUOMID = new TableSchema.TableColumn(schema);
				colvarPhenomenonUOMID.ColumnName = "PhenomenonUOMID";
				colvarPhenomenonUOMID.DataType = DbType.Guid;
				colvarPhenomenonUOMID.MaxLength = 0;
				colvarPhenomenonUOMID.AutoIncrement = false;
				colvarPhenomenonUOMID.IsNullable = true;
				colvarPhenomenonUOMID.IsPrimaryKey = false;
				colvarPhenomenonUOMID.IsForeignKey = true;
				colvarPhenomenonUOMID.IsReadOnly = false;
				colvarPhenomenonUOMID.DefaultSetting = @"";
				
					colvarPhenomenonUOMID.ForeignKeyTableName = "PhenomenonUOM";
				schema.Columns.Add(colvarPhenomenonUOMID);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = false;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
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
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
				TableSchema.TableColumn colvarDataSourceID = new TableSchema.TableColumn(schema);
				colvarDataSourceID.ColumnName = "DataSourceID";
				colvarDataSourceID.DataType = DbType.Guid;
				colvarDataSourceID.MaxLength = 0;
				colvarDataSourceID.AutoIncrement = false;
				colvarDataSourceID.IsNullable = false;
				colvarDataSourceID.IsPrimaryKey = false;
				colvarDataSourceID.IsForeignKey = true;
				colvarDataSourceID.IsReadOnly = false;
				colvarDataSourceID.DefaultSetting = @"";
				
					colvarDataSourceID.ForeignKeyTableName = "DataSource";
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
				colvarDefinition.DefaultSetting = @"";
				colvarDefinition.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDefinition);
				
				TableSchema.TableColumn colvarNewPhenomenonOfferingID = new TableSchema.TableColumn(schema);
				colvarNewPhenomenonOfferingID.ColumnName = "NewPhenomenonOfferingID";
				colvarNewPhenomenonOfferingID.DataType = DbType.Guid;
				colvarNewPhenomenonOfferingID.MaxLength = 0;
				colvarNewPhenomenonOfferingID.AutoIncrement = false;
				colvarNewPhenomenonOfferingID.IsNullable = true;
				colvarNewPhenomenonOfferingID.IsPrimaryKey = false;
				colvarNewPhenomenonOfferingID.IsForeignKey = true;
				colvarNewPhenomenonOfferingID.IsReadOnly = false;
				colvarNewPhenomenonOfferingID.DefaultSetting = @"";
				
					colvarNewPhenomenonOfferingID.ForeignKeyTableName = "PhenomenonOffering";
				schema.Columns.Add(colvarNewPhenomenonOfferingID);
				
				TableSchema.TableColumn colvarNewPhenomenonUOMID = new TableSchema.TableColumn(schema);
				colvarNewPhenomenonUOMID.ColumnName = "NewPhenomenonUOMID";
				colvarNewPhenomenonUOMID.DataType = DbType.Guid;
				colvarNewPhenomenonUOMID.MaxLength = 0;
				colvarNewPhenomenonUOMID.AutoIncrement = false;
				colvarNewPhenomenonUOMID.IsNullable = true;
				colvarNewPhenomenonUOMID.IsPrimaryKey = false;
				colvarNewPhenomenonUOMID.IsForeignKey = true;
				colvarNewPhenomenonUOMID.IsReadOnly = false;
				colvarNewPhenomenonUOMID.DefaultSetting = @"";
				
					colvarNewPhenomenonUOMID.ForeignKeyTableName = "PhenomenonUOM";
				schema.Columns.Add(colvarNewPhenomenonUOMID);
				
				TableSchema.TableColumn colvarRank = new TableSchema.TableColumn(schema);
				colvarRank.ColumnName = "Rank";
				colvarRank.DataType = DbType.Int32;
				colvarRank.MaxLength = 0;
				colvarRank.AutoIncrement = false;
				colvarRank.IsNullable = true;
				colvarRank.IsPrimaryKey = false;
				colvarRank.IsForeignKey = false;
				colvarRank.IsReadOnly = false;
				
						colvarRank.DefaultSetting = @"((0))";
				colvarRank.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRank);
				
				TableSchema.TableColumn colvarSensorID = new TableSchema.TableColumn(schema);
				colvarSensorID.ColumnName = "SensorID";
				colvarSensorID.DataType = DbType.Guid;
				colvarSensorID.MaxLength = 0;
				colvarSensorID.AutoIncrement = false;
				colvarSensorID.IsNullable = true;
				colvarSensorID.IsPrimaryKey = false;
				colvarSensorID.IsForeignKey = true;
				colvarSensorID.IsReadOnly = false;
				colvarSensorID.DefaultSetting = @"";
				
					colvarSensorID.ForeignKeyTableName = "Sensor";
				schema.Columns.Add(colvarSensorID);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "UserId";
				colvarUserId.DataType = DbType.Guid;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = true;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = true;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				
					colvarUserId.ForeignKeyTableName = "aspnet_Users";
				schema.Columns.Add(colvarUserId);
				
				TableSchema.TableColumn colvarAddedAt = new TableSchema.TableColumn(schema);
				colvarAddedAt.ColumnName = "AddedAt";
				colvarAddedAt.DataType = DbType.DateTime;
				colvarAddedAt.MaxLength = 0;
				colvarAddedAt.AutoIncrement = false;
				colvarAddedAt.IsNullable = true;
				colvarAddedAt.IsPrimaryKey = false;
				colvarAddedAt.IsForeignKey = false;
				colvarAddedAt.IsReadOnly = false;
				
						colvarAddedAt.DefaultSetting = @"(getdate())";
				colvarAddedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddedAt);
				
				TableSchema.TableColumn colvarUpdatedAt = new TableSchema.TableColumn(schema);
				colvarUpdatedAt.ColumnName = "UpdatedAt";
				colvarUpdatedAt.DataType = DbType.DateTime;
				colvarUpdatedAt.MaxLength = 0;
				colvarUpdatedAt.AutoIncrement = false;
				colvarUpdatedAt.IsNullable = true;
				colvarUpdatedAt.IsPrimaryKey = false;
				colvarUpdatedAt.IsForeignKey = false;
				colvarUpdatedAt.IsReadOnly = false;
				
						colvarUpdatedAt.DefaultSetting = @"(getdate())";
				colvarUpdatedAt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedAt);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ObservationsDB"].AddSchema("DataSourceTransformation",schema);
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
		  
		[XmlAttribute("TransformationTypeID")]
		[Bindable(true)]
		public Guid TransformationTypeID 
		{
			get { return GetColumnValue<Guid>(Columns.TransformationTypeID); }
			set { SetColumnValue(Columns.TransformationTypeID, value); }
		}
		  
		[XmlAttribute("PhenomenonID")]
		[Bindable(true)]
		public Guid PhenomenonID 
		{
			get { return GetColumnValue<Guid>(Columns.PhenomenonID); }
			set { SetColumnValue(Columns.PhenomenonID, value); }
		}
		  
		[XmlAttribute("PhenomenonOfferingID")]
		[Bindable(true)]
		public Guid? PhenomenonOfferingID 
		{
			get { return GetColumnValue<Guid?>(Columns.PhenomenonOfferingID); }
			set { SetColumnValue(Columns.PhenomenonOfferingID, value); }
		}
		  
		[XmlAttribute("PhenomenonUOMID")]
		[Bindable(true)]
		public Guid? PhenomenonUOMID 
		{
			get { return GetColumnValue<Guid?>(Columns.PhenomenonUOMID); }
			set { SetColumnValue(Columns.PhenomenonUOMID, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public DateTime StartDate 
		{
			get { return GetColumnValue<DateTime>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("EndDate")]
		[Bindable(true)]
		public DateTime? EndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EndDate); }
			set { SetColumnValue(Columns.EndDate, value); }
		}
		  
		[XmlAttribute("DataSourceID")]
		[Bindable(true)]
		public Guid DataSourceID 
		{
			get { return GetColumnValue<Guid>(Columns.DataSourceID); }
			set { SetColumnValue(Columns.DataSourceID, value); }
		}
		  
		[XmlAttribute("Definition")]
		[Bindable(true)]
		public string Definition 
		{
			get { return GetColumnValue<string>(Columns.Definition); }
			set { SetColumnValue(Columns.Definition, value); }
		}
		  
		[XmlAttribute("NewPhenomenonOfferingID")]
		[Bindable(true)]
		public Guid? NewPhenomenonOfferingID 
		{
			get { return GetColumnValue<Guid?>(Columns.NewPhenomenonOfferingID); }
			set { SetColumnValue(Columns.NewPhenomenonOfferingID, value); }
		}
		  
		[XmlAttribute("NewPhenomenonUOMID")]
		[Bindable(true)]
		public Guid? NewPhenomenonUOMID 
		{
			get { return GetColumnValue<Guid?>(Columns.NewPhenomenonUOMID); }
			set { SetColumnValue(Columns.NewPhenomenonUOMID, value); }
		}
		  
		[XmlAttribute("Rank")]
		[Bindable(true)]
		public int? Rank 
		{
			get { return GetColumnValue<int?>(Columns.Rank); }
			set { SetColumnValue(Columns.Rank, value); }
		}
		  
		[XmlAttribute("SensorID")]
		[Bindable(true)]
		public Guid? SensorID 
		{
			get { return GetColumnValue<Guid?>(Columns.SensorID); }
			set { SetColumnValue(Columns.SensorID, value); }
		}
		  
		[XmlAttribute("UserId")]
		[Bindable(true)]
		public Guid? UserId 
		{
			get { return GetColumnValue<Guid?>(Columns.UserId); }
			set { SetColumnValue(Columns.UserId, value); }
		}
		  
		[XmlAttribute("AddedAt")]
		[Bindable(true)]
		public DateTime? AddedAt 
		{
			get { return GetColumnValue<DateTime?>(Columns.AddedAt); }
			set { SetColumnValue(Columns.AddedAt, value); }
		}
		  
		[XmlAttribute("UpdatedAt")]
		[Bindable(true)]
		public DateTime? UpdatedAt 
		{
			get { return GetColumnValue<DateTime?>(Columns.UpdatedAt); }
			set { SetColumnValue(Columns.UpdatedAt, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public SAEON.Observations.Data.DataLogCollection DataLogRecords()
		{
			return new SAEON.Observations.Data.DataLogCollection().Where(DataLog.Columns.DataSourceTransformationID, Id).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AspnetUser ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.AspnetUser AspnetUser
		{
			get { return SAEON.Observations.Data.AspnetUser.FetchByID(this.UserId); }
			set { SetColumnValue("UserId", value.UserId); }
		}
		
		
		/// <summary>
		/// Returns a DataSource ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.DataSource DataSource
		{
			get { return SAEON.Observations.Data.DataSource.FetchByID(this.DataSourceID); }
			set { SetColumnValue("DataSourceID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a Phenomenon ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.Phenomenon Phenomenon
		{
			get { return SAEON.Observations.Data.Phenomenon.FetchByID(this.PhenomenonID); }
			set { SetColumnValue("PhenomenonID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a PhenomenonOffering ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.PhenomenonOffering PhenomenonOffering
		{
			get { return SAEON.Observations.Data.PhenomenonOffering.FetchByID(this.NewPhenomenonOfferingID); }
			set { SetColumnValue("NewPhenomenonOfferingID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a PhenomenonOffering ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.PhenomenonOffering PhenomenonOfferingToPhenomenonOfferingID
		{
			get { return SAEON.Observations.Data.PhenomenonOffering.FetchByID(this.PhenomenonOfferingID); }
			set { SetColumnValue("PhenomenonOfferingID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a PhenomenonUOM ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.PhenomenonUOM PhenomenonUOM
		{
			get { return SAEON.Observations.Data.PhenomenonUOM.FetchByID(this.NewPhenomenonUOMID); }
			set { SetColumnValue("NewPhenomenonUOMID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a PhenomenonUOM ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.PhenomenonUOM PhenomenonUOMToPhenomenonUOMID
		{
			get { return SAEON.Observations.Data.PhenomenonUOM.FetchByID(this.PhenomenonUOMID); }
			set { SetColumnValue("PhenomenonUOMID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a Sensor ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.Sensor Sensor
		{
			get { return SAEON.Observations.Data.Sensor.FetchByID(this.SensorID); }
			set { SetColumnValue("SensorID", value.Id); }
		}
		
		
		/// <summary>
		/// Returns a TransformationType ActiveRecord object related to this DataSourceTransformation
		/// 
		/// </summary>
		public SAEON.Observations.Data.TransformationType TransformationType
		{
			get { return SAEON.Observations.Data.TransformationType.FetchByID(this.TransformationTypeID); }
			set { SetColumnValue("TransformationTypeID", value.Id); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varId,Guid varTransformationTypeID,Guid varPhenomenonID,Guid? varPhenomenonOfferingID,Guid? varPhenomenonUOMID,DateTime varStartDate,DateTime? varEndDate,Guid varDataSourceID,string varDefinition,Guid? varNewPhenomenonOfferingID,Guid? varNewPhenomenonUOMID,int? varRank,Guid? varSensorID,Guid? varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt)
		{
			DataSourceTransformation item = new DataSourceTransformation();
			
			item.Id = varId;
			
			item.TransformationTypeID = varTransformationTypeID;
			
			item.PhenomenonID = varPhenomenonID;
			
			item.PhenomenonOfferingID = varPhenomenonOfferingID;
			
			item.PhenomenonUOMID = varPhenomenonUOMID;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.DataSourceID = varDataSourceID;
			
			item.Definition = varDefinition;
			
			item.NewPhenomenonOfferingID = varNewPhenomenonOfferingID;
			
			item.NewPhenomenonUOMID = varNewPhenomenonUOMID;
			
			item.Rank = varRank;
			
			item.SensorID = varSensorID;
			
			item.UserId = varUserId;
			
			item.AddedAt = varAddedAt;
			
			item.UpdatedAt = varUpdatedAt;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varId,Guid varTransformationTypeID,Guid varPhenomenonID,Guid? varPhenomenonOfferingID,Guid? varPhenomenonUOMID,DateTime varStartDate,DateTime? varEndDate,Guid varDataSourceID,string varDefinition,Guid? varNewPhenomenonOfferingID,Guid? varNewPhenomenonUOMID,int? varRank,Guid? varSensorID,Guid? varUserId,DateTime? varAddedAt,DateTime? varUpdatedAt)
		{
			DataSourceTransformation item = new DataSourceTransformation();
			
				item.Id = varId;
			
				item.TransformationTypeID = varTransformationTypeID;
			
				item.PhenomenonID = varPhenomenonID;
			
				item.PhenomenonOfferingID = varPhenomenonOfferingID;
			
				item.PhenomenonUOMID = varPhenomenonUOMID;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.DataSourceID = varDataSourceID;
			
				item.Definition = varDefinition;
			
				item.NewPhenomenonOfferingID = varNewPhenomenonOfferingID;
			
				item.NewPhenomenonUOMID = varNewPhenomenonUOMID;
			
				item.Rank = varRank;
			
				item.SensorID = varSensorID;
			
				item.UserId = varUserId;
			
				item.AddedAt = varAddedAt;
			
				item.UpdatedAt = varUpdatedAt;
			
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
        
        
        
        public static TableSchema.TableColumn TransformationTypeIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PhenomenonIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PhenomenonOfferingIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PhenomenonUOMIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn EndDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DataSourceIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DefinitionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn NewPhenomenonOfferingIDColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn NewPhenomenonUOMIDColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn RankColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn SensorIDColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedAtColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string TransformationTypeID = @"TransformationTypeID";
			 public static string PhenomenonID = @"PhenomenonID";
			 public static string PhenomenonOfferingID = @"PhenomenonOfferingID";
			 public static string PhenomenonUOMID = @"PhenomenonUOMID";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string DataSourceID = @"DataSourceID";
			 public static string Definition = @"Definition";
			 public static string NewPhenomenonOfferingID = @"NewPhenomenonOfferingID";
			 public static string NewPhenomenonUOMID = @"NewPhenomenonUOMID";
			 public static string Rank = @"Rank";
			 public static string SensorID = @"SensorID";
			 public static string UserId = @"UserId";
			 public static string AddedAt = @"AddedAt";
			 public static string UpdatedAt = @"UpdatedAt";
						
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
