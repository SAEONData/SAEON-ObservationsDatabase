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
    /// Controller class for Organisation_Site
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class OrganisationSiteController
    {
        // Preload our schema..
        OrganisationSite thisSchemaLoad = new OrganisationSite();
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
        public OrganisationSiteCollection FetchAll()
        {
            OrganisationSiteCollection coll = new OrganisationSiteCollection();
            Query qry = new Query(OrganisationSite.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrganisationSiteCollection FetchByID(object Id)
        {
            OrganisationSiteCollection coll = new OrganisationSiteCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public OrganisationSiteCollection FetchByQuery(Query qry)
        {
            OrganisationSiteCollection coll = new OrganisationSiteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (OrganisationSite.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (OrganisationSite.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid Id,Guid OrganisationID,Guid SiteID,Guid OrganisationRoleID,string StartDate,string EndDate,Guid UserId,DateTime? AddedAt,DateTime? UpdatedAt)
	    {
		    OrganisationSite item = new OrganisationSite();
		    
            item.Id = Id;
            
            item.OrganisationID = OrganisationID;
            
            item.SiteID = SiteID;
            
            item.OrganisationRoleID = OrganisationRoleID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.UserId = UserId;
            
            item.AddedAt = AddedAt;
            
            item.UpdatedAt = UpdatedAt;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid Id,Guid OrganisationID,Guid SiteID,Guid OrganisationRoleID,string StartDate,string EndDate,Guid UserId,DateTime? AddedAt,DateTime? UpdatedAt)
	    {
		    OrganisationSite item = new OrganisationSite();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.OrganisationID = OrganisationID;
				
			item.SiteID = SiteID;
				
			item.OrganisationRoleID = OrganisationRoleID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.UserId = UserId;
				
			item.AddedAt = AddedAt;
				
			item.UpdatedAt = UpdatedAt;
				
	        item.Save(UserName);
	    }
    }
}
