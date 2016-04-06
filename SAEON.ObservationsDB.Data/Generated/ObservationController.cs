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
    /// Controller class for Observation
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ObservationController
    {
        // Preload our schema..
        Observation thisSchemaLoad = new Observation();
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
        public ObservationCollection FetchAll()
        {
            ObservationCollection coll = new ObservationCollection();
            Query qry = new Query(Observation.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ObservationCollection FetchByID(object Id)
        {
            ObservationCollection coll = new ObservationCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ObservationCollection FetchByQuery(Query qry)
        {
            ObservationCollection coll = new ObservationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (Observation.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (Observation.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid SensorProcedureID,DateTime ValueDate,double? RawValue,double? DataValue,string Comment,Guid PhenonmenonOfferingID,Guid PhenonmenonUOMID,int ImportBatchID,Guid UserId,DateTime AddedDate)
	    {
		    Observation item = new Observation();
		    
            item.SensorProcedureID = SensorProcedureID;
            
            item.ValueDate = ValueDate;
            
            item.RawValue = RawValue;
            
            item.DataValue = DataValue;
            
            item.Comment = Comment;
            
            item.PhenonmenonOfferingID = PhenonmenonOfferingID;
            
            item.PhenonmenonUOMID = PhenonmenonUOMID;
            
            item.ImportBatchID = ImportBatchID;
            
            item.UserId = UserId;
            
            item.AddedDate = AddedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,Guid SensorProcedureID,DateTime ValueDate,double? RawValue,double? DataValue,string Comment,Guid PhenonmenonOfferingID,Guid PhenonmenonUOMID,int ImportBatchID,Guid UserId,DateTime AddedDate)
	    {
		    Observation item = new Observation();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SensorProcedureID = SensorProcedureID;
				
			item.ValueDate = ValueDate;
				
			item.RawValue = RawValue;
				
			item.DataValue = DataValue;
				
			item.Comment = Comment;
				
			item.PhenonmenonOfferingID = PhenonmenonOfferingID;
				
			item.PhenonmenonUOMID = PhenonmenonUOMID;
				
			item.ImportBatchID = ImportBatchID;
				
			item.UserId = UserId;
				
			item.AddedDate = AddedDate;
				
	        item.Save(UserName);
	    }
    }
}