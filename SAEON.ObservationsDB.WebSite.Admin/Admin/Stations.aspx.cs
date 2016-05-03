﻿using Ext.Net;
using SAEON.ObservationsDB.Data;
using System;
using System.Linq;
using SubSonic;
using Serilog;
using System.Collections.Generic;

public partial class Admin_Stations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            SiteStore.DataSource = new SiteCollection().OrderByAsc(SAEON.ObservationsDB.Data.Site.Columns.Name).Load();
            SiteStore.DataBind();
            OrganisationStore.DataSource = new OrganisationCollection().OrderByAsc(Organisation.Columns.Name).Load();
            OrganisationStore.DataBind();
            OrganisationRoleStore.DataSource = new OrganisationRoleCollection().OrderByAsc(OrganisationRole.Columns.Name).Load();
            OrganisationRoleStore.DataBind();
        }
    }

    #region Stations
    protected void StationsGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        StationsGrid.GetStore().DataSource = StationRepository.GetPagedList(e, e.Parameters[GridFilters1.ParamPrefix]);
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
        try
        {
            Station station = new Station();

            if (String.IsNullOrEmpty(tfID.Text))
                station.Id = Guid.NewGuid();
            else
                station = new Station(tfID.Text.Trim());

            if (!string.IsNullOrEmpty(tfCode.Text.Trim()))
                station.Code = tfCode.Text.Trim();
            if (!string.IsNullOrEmpty(tfName.Text.Trim()))
                station.Name = tfName.Text.Trim();
            station.Description = tfDescription.Text.Trim();
            station.SiteID = new Guid(cbSite.SelectedItem.Value.Trim());

            if (!string.IsNullOrEmpty(nfLatitude.Text))
                station.Latitude = Double.Parse(nfLatitude.Text);

            if (!string.IsNullOrEmpty(nfLongitude.Text))
                station.Longitude = Double.Parse(nfLongitude.Text);

            if (!string.IsNullOrEmpty(nfElevation.Text))
                station.Elevation = Int32.Parse(nfElevation.Text);

            if (!string.IsNullOrEmpty(tfUrl.Text))
                station.Url = tfUrl.Text;

            if (!String.IsNullOrEmpty(dfStartDate.Text) && (dfStartDate.SelectedDate.Year >= 1900))
                station.StartDate = dfStartDate.SelectedDate;
            if (!String.IsNullOrEmpty(dfEndDate.Text) && (dfEndDate.SelectedDate.Year >= 1900))
                station.EndDate = dfEndDate.SelectedDate;

            station.UserId = AuthHelper.GetLoggedInUserId;

            station.Save();
            Auditing.Log("Stations.Save", new Dictionary<string, object> {
                { "ID", station.Id }, { "Code", station.Code }, { "Name", station.Name } });

            StationsGrid.DataBind();

            DetailWindow.Hide();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Stations.Save");
            MessageBoxes.Error(ex, "Error", "Unable to save station");
        }
    }

    protected void StationsGridStore_Submit(object sender, StoreSubmitDataEventArgs e)
    {
        string type = FormatType.Text;
        string visCols = VisCols.Value.ToString();
        string gridData = GridData.Text;
        string sortCol = SortInfo.Text.Substring(0, SortInfo.Text.IndexOf("|"));
        string sortDir = SortInfo.Text.Substring(SortInfo.Text.IndexOf("|") + 1);

        string js = BaseRepository.BuildExportQ("VStation", gridData, visCols, sortCol, sortDir);

        BaseRepository.doExport(type, js);
    }

    #endregion

    #region Organisations

    protected void OrganisationLinksGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (e.Parameters["StationID"] != null && e.Parameters["StationID"].ToString() != "-1")
        {
            Guid Id = Guid.Parse(e.Parameters["StationID"].ToString());
            VStationOrganisationCollection StationOrganisationCol = new VStationOrganisationCollection()
                .Where(VStationOrganisation.Columns.StationID, Id)
                .OrderByAsc(VStationOrganisation.Columns.StartDate)
                .OrderByAsc(VStationOrganisation.Columns.EndDate)
                .OrderByAsc(VStationOrganisation.Columns.OrganisationName)
                .OrderByAsc(VStationOrganisation.Columns.OrganisationRoleName)
                .Load();
            OrganisationLinksGrid.GetStore().DataSource = StationOrganisationCol;
            OrganisationLinksGrid.GetStore().DataBind();
        }
    }

    protected void LinkOrganisation_Click(object sender, DirectEventArgs e)
    {
        try
        {
            RowSelectionModel masterRow = StationsGrid.SelectionModel.Primary as RowSelectionModel;
            var masterID = new Guid(masterRow.SelectedRecordID);
            StationOrganisation stationOrganisation = new StationOrganisation();
            stationOrganisation.StationID = masterID;
            stationOrganisation.OrganisationID = new Guid(cbOrganisation.SelectedItem.Value.Trim());
            stationOrganisation.OrganisationRoleID = new Guid(cbOrganisationRole.SelectedItem.Value.Trim());
            if (!String.IsNullOrEmpty(dfOrganisationStartDate.Text) && (dfOrganisationStartDate.SelectedDate.Year >= 1900))
                stationOrganisation.StartDate = dfOrganisationStartDate.SelectedDate;
            if (!String.IsNullOrEmpty(dfOrganisationEndDate.Text) && (dfOrganisationEndDate.SelectedDate.Year >= 1900))
                stationOrganisation.EndDate = dfOrganisationEndDate.SelectedDate;
            stationOrganisation.UserId = AuthHelper.GetLoggedInUserId;
            stationOrganisation.Save();
            Auditing.Log("Stations.AddOrganisationLink", new Dictionary<string, object> {
                { "StationID", masterID },
                { "OrganisationID", stationOrganisation.OrganisationID},
                { "OrganisationCode", stationOrganisation.Organisation.Code},
                { "RoleID", stationOrganisation.OrganisationRoleID },
                { "RoleCode", stationOrganisation.OrganisationRole.Code},
            });
            OrganisationLinksGrid.DataBind();
            OrganisationLinkWindow.Hide();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Stations.LinkOrganisation_Click");
            MessageBoxes.Error(ex, "Error", "Unable to link organisation");
        }
    }

    [DirectMethod]
    public void ConfirmDeleteOrganisationLink(Guid aID)
    {
        MessageBoxes.Confirm(
            "Confirm Delete",
            String.Format("DirectCall.DeleteOrganisationLink(\"{0}\",{{ eventMask: {{ showMask: true}}}});", aID.ToString()),
            "Are you sure you want to delete this organisation link?");
    }

    [DirectMethod]
    public void DeleteOrganisationLink(Guid aID)
    {
        try
        {
            new StationOrganisationController().Delete(aID);
            Auditing.Log("Stations.DeleteOrganisationLink", new Dictionary<string, object> { { "ID", aID } });
            OrganisationLinksGrid.DataBind();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Stations.DeleteOrganisationLink({aID})", aID);
            MessageBoxes.Error(ex, "Error", "Unable to delete organisation link");
        }
    }

    //protected void OrganisationLink(object sender, DirectEventArgs e)
    //{
    //    string actionType = e.ExtraParams["type"];
    //    string recordID = e.ExtraParams["id"];
    //    try
    //    {
    //        if (actionType == "Edit")
    //        {
    //            OrganisationLinkFormPanel.SetValues(new StationOrganisation(recordID));
    //            OrganisationLinkWindow.Show();
    //        }
    //        else if (actionType == "Delete")
    //        {
    //            new StationOrganisationController().Delete(recordID);
    //            Auditing.Log("Station.DeleteOrganisationLink", new Dictionary<string, object> { { "ID", recordID } });
    //            OrganisationLinksGrid.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Error(ex, "Stations.OrganisationLink({ActionType},{RecordID})", actionType, recordID);
    //        MessageBoxes.Error(ex, "Unable to {0} organisation link", actionType);
    //    }
    //}

    #endregion

    #region DataSources

    protected void DataSourcesGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (e.Parameters["StationID"] != null && e.Parameters["StationID"].ToString() != "-1")
        {
            Guid Id = Guid.Parse(e.Parameters["StationID"].ToString());
            DataSourceCollection col = new DataSourceCollection()
                .Where(DataSource.Columns.StationID, Id)
                .OrderByAsc(DataSource.Columns.Code)
                .Load();
            DataSourcesGrid.GetStore().DataSource = col;
            DataSourcesGrid.GetStore().DataBind();
        }
    }

    protected void AvailableDataSourcesStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (e.Parameters["StationID"] != null && e.Parameters["StationID"].ToString() != "-1")
        {
            Guid Id = Guid.Parse(e.Parameters["StationID"].ToString());
            DataSourceCollection col = new Select()
                .From(DataSource.Schema)
                .Where(DataSource.IdColumn)
                .NotIn(new Select(new string[] { DataSource.Columns.Id }).From(DataSource.Schema).Where(DataSource.IdColumn).IsEqualTo(Id))
                .And(DataSource.StationIDColumn)
                .IsNull()
                .OrderAsc(DataSource.Columns.Code)
                .ExecuteAsCollection<DataSourceCollection>();
            AvailableDataSourcesGrid.GetStore().DataSource = col;
            AvailableDataSourcesGrid.GetStore().DataBind();
        }
    }

    protected void LinkDataSources_Click(object sender, DirectEventArgs e)
    {
        try
        {
            RowSelectionModel sm = AvailableDataSourcesGrid.SelectionModel.Primary as RowSelectionModel;
            RowSelectionModel masterRow = StationsGrid.SelectionModel.Primary as RowSelectionModel;

            var masterID = new Guid(masterRow.SelectedRecordID);
            if (sm.SelectedRows.Count > 0)
            {
                foreach (SelectedRow row in sm.SelectedRows)
                {
                    DataSource dataSource = new DataSource(row.RecordID);
                    if (dataSource != null)
                    {
                        dataSource.StationID = masterID;
                        dataSource.UserId = AuthHelper.GetLoggedInUserId;
                        dataSource.Save();
                        Auditing.Log("Stations.AddDataSourceLink", new Dictionary<string, object> {
                            { "StationID", masterID }, { "ID", dataSource.Id }, { "Code", dataSource.Code }, { "Name", dataSource.Name } });
                    }
                }
                DataSourcesGrid.DataBind();
                AvailableDataSourcesWindow.Hide();
            }
            else
            {
                MessageBoxes.Info("Invalid Selection", "Select at least one instrument");
            }

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Stations.LinkDataSources_Click");
            MessageBoxes.Error(ex, "Error", "Unable to link data sources");
        }
    }

    [DirectMethod]
    public void ConfirmDeleteDataSourceLink(Guid aID)
    {
        MessageBoxes.Confirm(
            "Confirm Delete",
            String.Format("DirectCall.DeleteDataSourceLink(\"{0}\",{{ eventMask: {{ showMask: true}}}});", aID.ToString()),
            "Are you sure you want to delete this data source link?");
    }

    [DirectMethod]
    public void DeleteDataSourceLink(Guid aID)
    {
        try
        {
            DataSource dataSource = new DataSource(aID);
            if (dataSource != null)
            {
                dataSource.StationID = null;
                dataSource.UserId = AuthHelper.GetLoggedInUserId;
                dataSource.Save();
                Auditing.Log("Stations.DeleteDataSourceLink", new Dictionary<string, object> {
                        { "ID", dataSource.Id }, { "Code", dataSource.Code }, { "Name", dataSource.Name } });
                DataSourcesGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Stations.DeleteDataSourceLink({aID})", aID);
            MessageBoxes.Error(ex, "Error", "Unable to delete data source link");
        }
    }

    //protected void DataSourceLink(object sender, DirectEventArgs e)
    //{
    //    string actionType = e.ExtraParams["type"];
    //    string recordID = e.ExtraParams["id"];
    //    try
    //    {
    //        if (actionType == "Edit")
    //        {
    //        }
    //        else if (actionType == "Delete")
    //        {
    //            DataSource dataSource = new DataSource(recordID);
    //            if (dataSource != null)
    //            {
    //                dataSource.StationID = null;
    //                dataSource.UserId = AuthHelper.GetLoggedInUserId;
    //                dataSource.Save();
    //                Auditing.Log("Stations.DeleteDataSourceLink", new Dictionary<string, object> {
    //                    { "ID", dataSource.Id }, { "Code", dataSource.Code }, { "Name", dataSource.Name } });
    //                DataSourcesGrid.DataBind();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Error(ex, "Stations.DataSourceLink({ActionType},{RecordID})", actionType, recordID);
    //        MessageBoxes.Error(ex, "Unable to {0} data source link", actionType);
    //    }
    //}
    #endregion

}