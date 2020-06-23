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
	/// Strongly-typed collection for the DigitalObjectIdentifier class.
	/// </summary>
    [Serializable]
	public partial class DigitalObjectIdentifierCollection : ActiveList<DigitalObjectIdentifier, DigitalObjectIdentifierCollection>
	{	   
		public DigitalObjectIdentifierCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DigitalObjectIdentifierCollection</returns>
		public DigitalObjectIdentifierCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DigitalObjectIdentifier o = this[i];
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
	/// This is an ActiveRecord class which wraps the DigitalObjectIdentifiers table.
	/// </summary>
	[Serializable]
	public partial class DigitalObjectIdentifier : ActiveRecord<DigitalObjectIdentifier>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DigitalObjectIdentifier()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DigitalObjectIdentifier(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DigitalObjectIdentifier(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DigitalObjectIdentifier(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DigitalObjectIdentifiers", TableType.Table, DataService.GetInstance("ObservationsDB"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarDoi = new TableSchema.TableColumn(schema);
				colvarDoi.ColumnName = "DOI";
				colvarDoi.DataType = DbType.AnsiString;
				colvarDoi.MaxLength = 36;
				colvarDoi.AutoIncrement = false;
				colvarDoi.IsNullable = true;
				colvarDoi.IsPrimaryKey = false;
				colvarDoi.IsForeignKey = false;
				colvarDoi.IsReadOnly = true;
				colvarDoi.DefaultSetting = @"";
				colvarDoi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDoi);
				
				TableSchema.TableColumn colvarDOIUrl = new TableSchema.TableColumn(schema);
				colvarDOIUrl.ColumnName = "DOIUrl";
				colvarDOIUrl.DataType = DbType.AnsiString;
				colvarDOIUrl.MaxLength = 52;
				colvarDOIUrl.AutoIncrement = false;
				colvarDOIUrl.IsNullable = true;
				colvarDOIUrl.IsPrimaryKey = false;
				colvarDOIUrl.IsForeignKey = false;
				colvarDOIUrl.IsReadOnly = true;
				colvarDOIUrl.DefaultSetting = @"";
				colvarDOIUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDOIUrl);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.AnsiString;
				colvarName.MaxLength = 1000;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = true;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
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
				
				TableSchema.TableColumn colvarAddedBy = new TableSchema.TableColumn(schema);
				colvarAddedBy.ColumnName = "AddedBy";
				colvarAddedBy.DataType = DbType.AnsiString;
				colvarAddedBy.MaxLength = 128;
				colvarAddedBy.AutoIncrement = false;
				colvarAddedBy.IsNullable = false;
				colvarAddedBy.IsPrimaryKey = false;
				colvarAddedBy.IsForeignKey = false;
				colvarAddedBy.IsReadOnly = false;
				colvarAddedBy.DefaultSetting = @"";
				colvarAddedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddedBy);
				
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
				
				TableSchema.TableColumn colvarUpdatedBy = new TableSchema.TableColumn(schema);
				colvarUpdatedBy.ColumnName = "UpdatedBy";
				colvarUpdatedBy.DataType = DbType.AnsiString;
				colvarUpdatedBy.MaxLength = 128;
				colvarUpdatedBy.AutoIncrement = false;
				colvarUpdatedBy.IsNullable = false;
				colvarUpdatedBy.IsPrimaryKey = false;
				colvarUpdatedBy.IsForeignKey = false;
				colvarUpdatedBy.IsReadOnly = false;
				colvarUpdatedBy.DefaultSetting = @"";
				colvarUpdatedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedBy);
				
				TableSchema.TableColumn colvarRowVersion = new TableSchema.TableColumn(schema);
				colvarRowVersion.ColumnName = "RowVersion";
				colvarRowVersion.DataType = DbType.Binary;
				colvarRowVersion.MaxLength = 0;
				colvarRowVersion.AutoIncrement = false;
				colvarRowVersion.IsNullable = false;
				colvarRowVersion.IsPrimaryKey = false;
				colvarRowVersion.IsForeignKey = false;
				colvarRowVersion.IsReadOnly = true;
				colvarRowVersion.DefaultSetting = @"";
				colvarRowVersion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRowVersion);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ObservationsDB"].AddSchema("DigitalObjectIdentifiers",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Doi")]
		[Bindable(true)]
		public string Doi 
		{
			get { return GetColumnValue<string>(Columns.Doi); }
			set { SetColumnValue(Columns.Doi, value); }
		}
		  
		[XmlAttribute("DOIUrl")]
		[Bindable(true)]
		public string DOIUrl 
		{
			get { return GetColumnValue<string>(Columns.DOIUrl); }
			set { SetColumnValue(Columns.DOIUrl, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("AddedAt")]
		[Bindable(true)]
		public DateTime? AddedAt 
		{
			get { return GetColumnValue<DateTime?>(Columns.AddedAt); }
			set { SetColumnValue(Columns.AddedAt, value); }
		}
		  
		[XmlAttribute("AddedBy")]
		[Bindable(true)]
		public string AddedBy 
		{
			get { return GetColumnValue<string>(Columns.AddedBy); }
			set { SetColumnValue(Columns.AddedBy, value); }
		}
		  
		[XmlAttribute("UpdatedAt")]
		[Bindable(true)]
		public DateTime? UpdatedAt 
		{
			get { return GetColumnValue<DateTime?>(Columns.UpdatedAt); }
			set { SetColumnValue(Columns.UpdatedAt, value); }
		}
		  
		[XmlAttribute("UpdatedBy")]
		[Bindable(true)]
		public string UpdatedBy 
		{
			get { return GetColumnValue<string>(Columns.UpdatedBy); }
			set { SetColumnValue(Columns.UpdatedBy, value); }
		}
		  
		[XmlAttribute("RowVersion")]
		[Bindable(true)]
		public byte[] RowVersion 
		{
			get { return GetColumnValue<byte[]>(Columns.RowVersion); }
			set { SetColumnValue(Columns.RowVersion, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDoi,string varDOIUrl,string varName,DateTime? varAddedAt,string varAddedBy,DateTime? varUpdatedAt,string varUpdatedBy,byte[] varRowVersion)
		{
			DigitalObjectIdentifier item = new DigitalObjectIdentifier();
			
			item.Doi = varDoi;
			
			item.DOIUrl = varDOIUrl;
			
			item.Name = varName;
			
			item.AddedAt = varAddedAt;
			
			item.AddedBy = varAddedBy;
			
			item.UpdatedAt = varUpdatedAt;
			
			item.UpdatedBy = varUpdatedBy;
			
			item.RowVersion = varRowVersion;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varDoi,string varDOIUrl,string varName,DateTime? varAddedAt,string varAddedBy,DateTime? varUpdatedAt,string varUpdatedBy,byte[] varRowVersion)
		{
			DigitalObjectIdentifier item = new DigitalObjectIdentifier();
			
				item.Id = varId;
			
				item.Doi = varDoi;
			
				item.DOIUrl = varDOIUrl;
			
				item.Name = varName;
			
				item.AddedAt = varAddedAt;
			
				item.AddedBy = varAddedBy;
			
				item.UpdatedAt = varUpdatedAt;
			
				item.UpdatedBy = varUpdatedBy;
			
				item.RowVersion = varRowVersion;
			
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
        
        
        
        public static TableSchema.TableColumn DoiColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DOIUrlColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedAtColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedByColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedAtColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UpdatedByColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn RowVersionColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string Doi = @"DOI";
			 public static string DOIUrl = @"DOIUrl";
			 public static string Name = @"Name";
			 public static string AddedAt = @"AddedAt";
			 public static string AddedBy = @"AddedBy";
			 public static string UpdatedAt = @"UpdatedAt";
			 public static string UpdatedBy = @"UpdatedBy";
			 public static string RowVersion = @"RowVersion";
						
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
