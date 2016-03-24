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
namespace Observations.Data
{
    /// <summary>
    /// Controller class for SensorProcedure
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SensorProcedureController
    {
        // Preload our schema..
        SensorProcedure thisSchemaLoad = new SensorProcedure();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public SensorProcedureCollection FetchAll()
        {
            SensorProcedureCollection coll = new SensorProcedureCollection();
            Query qry = new Query(SensorProcedure.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SensorProcedureCollection FetchByID(object Id)
        {
            SensorProcedureCollection coll = new SensorProcedureCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SensorProcedureCollection FetchByQuery(Query qry)
        {
            SensorProcedureCollection coll = new SensorProcedureCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SensorProcedure.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SensorProcedure.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,string Code,string Name,string Description,string Url,Guid StationID,Guid PhenomenonID,Guid DataSourceID,Guid? DataSchemaID,Guid UserId)
	    {
		    SensorProcedure item = new SensorProcedure();
		    
            item.Id = Id;
            
            item.Code = Code;
            
            item.Name = Name;
            
            item.Description = Description;
            
            item.Url = Url;
            
            item.StationID = StationID;
            
            item.PhenomenonID = PhenomenonID;
            
            item.DataSourceID = DataSourceID;
            
            item.DataSchemaID = DataSchemaID;
            
            item.UserId = UserId;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,string Code,string Name,string Description,string Url,Guid StationID,Guid PhenomenonID,Guid DataSourceID,Guid? DataSchemaID,Guid UserId)
	    {
		    SensorProcedure item = new SensorProcedure();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Code = Code;
				
			item.Name = Name;
				
			item.Description = Description;
				
			item.Url = Url;
				
			item.StationID = StationID;
				
			item.PhenomenonID = PhenomenonID;
				
			item.DataSourceID = DataSourceID;
				
			item.DataSchemaID = DataSchemaID;
				
			item.UserId = UserId;
				
	        item.Save(UserName);
	    }
    }
}