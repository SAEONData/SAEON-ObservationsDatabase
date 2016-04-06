﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SAEON.ObservationsDB.Data;
using System.Xml;
using System.Xml.Xsl;

public partial class _Station : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new ProjectSiteCollection().OrderByAsc(ProjectSite.Columns.Name).Load();
            this.Store1.DataBind();
        }
    }

    protected void StationStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        this.StationGrid.GetStore().DataSource = StationRepository.GetPagedList(e, e.Parameters[this.GridFilters1.ParamPrefix]);
    }

    protected void ValidateField(object sender, RemoteValidationEventArgs e)
    {

        StationCollection col = new StationCollection();

        string checkColumn = String.Empty,
               errorMessage = String.Empty;

        if (e.ID == "tfCode")
        {
            checkColumn = Station.Columns.Code;
            errorMessage = "The specified Station Code already exists";
        }
        else if (e.ID == "tfName")
        {
            checkColumn = Station.Columns.Name;
            errorMessage = "The specified Station Name already exists";

        }

        if (String.IsNullOrEmpty(tfID.Text.ToString()))
            col = new StationCollection().Where(checkColumn, e.Value.ToString().Trim()).Load();
        else
            col = new StationCollection().Where(checkColumn, e.Value.ToString().Trim()).Where(Station.Columns.Id, SubSonic.Comparison.NotEquals, tfID.Text.Trim()).Load();

        if (col.Count > 0)
        {
            e.Success = false;
            e.ErrorMessage = errorMessage;
        }
        else
            e.Success = true;
    }

    protected void Save(object sender, DirectEventArgs e)
    {

        Station stat = new Station();

        if (String.IsNullOrEmpty(tfID.Text))
            stat.Id = Guid.NewGuid();
        else
            stat = new Station(tfID.Text.Trim());

        stat.Code = tfCode.Text.Trim();
        stat.Name = tfName.Text.Trim();
        stat.Description = tfDescription.Text.Trim();
        stat.ProjectSiteID = new Guid(cbProjectSite.SelectedItem.Value.Trim());

        if (!string.IsNullOrEmpty(nfLatitude.Text))
            stat.Latitude = Double.Parse(nfLatitude.Text);

        if (!string.IsNullOrEmpty(nfLongitude.Text))
            stat.Longitude = Double.Parse(nfLongitude.Text);

        if (!string.IsNullOrEmpty(nfElevation.Text))
            stat.Elevation = Int32.Parse(nfElevation.Text);

        if (!string.IsNullOrEmpty(tfUrl.Text))
            stat.Url = tfUrl.Text;

        stat.UserId = AuthHelper.GetLoggedInUserId;

        stat.Save();

        StationGrid.DataBind();

        this.DetailWindow.Hide();
    }

	protected void StationStore_Submit(object sender, StoreSubmitDataEventArgs e)
	{
		string type = FormatType.Text;
		string visCols = VisCols.Value.ToString();
		string gridData = GridData.Text;
		string sortCol = SortInfo.Text.Substring(0, SortInfo.Text.IndexOf("|"));
		string sortDir = SortInfo.Text.Substring(SortInfo.Text.IndexOf("|") + 1);

		string js = BaseRepository.BuildExportQ("VStation", gridData, visCols, sortCol, sortDir);

		BaseRepository.doExport(type, js);
	}
}