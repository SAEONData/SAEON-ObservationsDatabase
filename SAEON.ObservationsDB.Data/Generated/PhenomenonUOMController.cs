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
    /// Controller class for PhenomenonUOM
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PhenomenonUOMController
    {
        // Preload our schema..
        PhenomenonUOM thisSchemaLoad = new PhenomenonUOM();
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
        public PhenomenonUOMCollection FetchAll()
        {
            PhenomenonUOMCollection coll = new PhenomenonUOMCollection();
            Query qry = new Query(PhenomenonUOM.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PhenomenonUOMCollection FetchByID(object Id)
        {
            PhenomenonUOMCollection coll = new PhenomenonUOMCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PhenomenonUOMCollection FetchByQuery(Query qry)
        {
            PhenomenonUOMCollection coll = new PhenomenonUOMCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (PhenomenonUOM.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (PhenomenonUOM.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,Guid PhenomenonID,Guid UnitOfMeasureID,bool IsDefault,Guid? UserId)
	    {
		    PhenomenonUOM item = new PhenomenonUOM();
		    
            item.Id = Id;
            
            item.PhenomenonID = PhenomenonID;
            
            item.UnitOfMeasureID = UnitOfMeasureID;
            
            item.IsDefault = IsDefault;
            
            item.UserId = UserId;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,Guid PhenomenonID,Guid UnitOfMeasureID,bool IsDefault,Guid? UserId)
	    {
		    PhenomenonUOM item = new PhenomenonUOM();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.PhenomenonID = PhenomenonID;
				
			item.UnitOfMeasureID = UnitOfMeasureID;
				
			item.IsDefault = IsDefault;
				
			item.UserId = UserId;
				
	        item.Save(UserName);
	    }
    }
}
