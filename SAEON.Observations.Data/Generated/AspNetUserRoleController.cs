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
    /// Controller class for AspNetUserRoles
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AspNetUserRoleController
    {
        // Preload our schema..
        AspNetUserRole thisSchemaLoad = new AspNetUserRole();
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
        public AspNetUserRoleCollection FetchAll()
        {
            AspNetUserRoleCollection coll = new AspNetUserRoleCollection();
            Query qry = new Query(AspNetUserRole.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspNetUserRoleCollection FetchByID(object UserId)
        {
            AspNetUserRoleCollection coll = new AspNetUserRoleCollection().Where("UserId", UserId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AspNetUserRoleCollection FetchByQuery(Query qry)
        {
            AspNetUserRoleCollection coll = new AspNetUserRoleCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserId)
        {
            return (AspNetUserRole.Delete(UserId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserId)
        {
            return (AspNetUserRole.Destroy(UserId) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(string UserId,string RoleId)
        {
            Query qry = new Query(AspNetUserRole.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("UserId", UserId).AND("RoleId", RoleId);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string UserId,string RoleId)
	    {
		    AspNetUserRole item = new AspNetUserRole();
		    
            item.UserId = UserId;
            
            item.RoleId = RoleId;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string UserId,string RoleId)
	    {
		    AspNetUserRole item = new AspNetUserRole();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UserId = UserId;
				
			item.RoleId = RoleId;
				
	        item.Save(UserName);
	    }
    }
}
