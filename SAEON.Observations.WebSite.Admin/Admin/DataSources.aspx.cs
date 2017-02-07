﻿using Ext.Net;
using NCalc;
using Newtonsoft.Json;
using SAEON.Observations.Data;
using Serilog;
using SubSonic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DataSources : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            DataSchemaStore.DataSource = new DataSchemaCollection().OrderByAsc(DataSchema.Columns.Name).Load();
            DataSchemaStore.DataBind();

            Dictionary<int, string> frequencylist = listHelper.GetUpdateFrequencyList();

            foreach (var item in frequencylist)
            {
                cbUpdateFrequency.Items.Insert(cbUpdateFrequency.Items.ToArray().Length, new Ext.Net.ListItem(item.Value, item.Key.ToString()));
            }

            TransformationTypeStore.DataSource = new TransformationTypeCollection().OrderByAsc(TransformationType.Columns.Name).Load();
            TransformationTypeStore.DataBind();

            PhenomenonStore.DataSource = new PhenomenonCollection().OrderByAsc(Phenomenon.Columns.Name).Load();
            PhenomenonStore.DataBind();

            InstrumentStore.DataSource = new InstrumentCollection().OrderByAsc(Instrument.Columns.Name).Load();
            InstrumentStore.DataBind();
        }
    }

    #region Data Sources
    protected void DataSourcesGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataSourcesGrid.GetStore().DataSource = DataSourceRepository.GetPagedList(e, e.Parameters[GridFilters1.ParamPrefix]);
    }

    protected void ValidateField(object sender, RemoteValidationEventArgs e)
    {

        DataSourceCollection col = new DataSourceCollection();

        string checkColumn = String.Empty,
               errorMessage = String.Empty;

        if (e.ID == "tfCode")
        {
            checkColumn = DataSource.Columns.Code;
            errorMessage = "The specified DataSource Code already exists";
        }
        else if (e.ID == "tfName")
        {
            checkColumn = DataSource.Columns.Name;
            errorMessage = "The specified DataSource Name already exists";

        }
        //else if (e.ID == "ContentPlaceHolder1_tfUrl")
        //{
        //    checkColumn = DataSource.Columns.Url;
        //    errorMessage = "Url is required when update frequency is not ad-hoc";
        //}
        //else if (e.ID == "ContentPlaceHolder1_cbUpdateFrequency")
        //{
        //    checkColumn = DataSource.Columns.Url;
        //    errorMessage = "Url and start date is required when update frequency is not ad-hoc";
        //}
        //else if (e.ID == "ContentPlaceHolder1_StartDate")
        //{
        //    checkColumn = DataSource.Columns.StartDate;
        //    errorMessage = "Start date is required when update frequency is not ad-hoc";
        //}


        if (e.ID == "tfCode" || e.ID == "tfName")
        {
            if (String.IsNullOrEmpty(tfID.Text.ToString()))
                col = new DataSourceCollection().Where(checkColumn, e.Value.ToString().Trim()).Load();
            else
                col = new DataSourceCollection().Where(checkColumn, e.Value.ToString().Trim()).Where(DataSource.Columns.Id, SubSonic.Comparison.NotEquals, tfID.Text.Trim()).Load();

            if (col.Count > 0)
            {
                e.Success = false;
                e.ErrorMessage = errorMessage;
            }
            else
                e.Success = true;
        }
        //else if (e.ID == "ContentPlaceHolder1_tfUrl")
        //{
        //    if (cbUpdateFrequency.SelectedItem.Text == "Ad-Hoc")
        //    {
        //        e.Success = true; 
        //    }
        //    else
        //    {
        //        if (tfUrl.Text.Length != 0)
        //        {
        //            e.Success = true; 
        //        }
        //        else
        //        {
        //            e.Success = false;
        //            e.ErrorMessage = errorMessage; 
        //        }
        //    }
        //}
        //else if (e.ID == "ContentPlaceHolder1_StartDate")
        //{
        //    if (cbUpdateFrequency.SelectedItem.Text == "Ad-Hoc")
        //    {
        //        e.Success = true;
        //    }
        //    else
        //    {
        //        if (StartDate.Text != "0001/01/01 00:00:00")
        //        {
        //            e.Success = true;
        //        }
        //        else
        //        {
        //            e.Success = false;
        //            e.ErrorMessage = errorMessage;
        //        }
        //    }
        //}
        //else if (e.ID == "ContentPlaceHolder1_cbUpdateFrequency")
        //{
        //    if (cbUpdateFrequency.SelectedItem.Text == "Ad-Hoc")
        //    {
        //        e.Success = true;
        //    }
        //    else
        //    {
        //        if (tfUrl.Text.Length != 0 && StartDate.Text != "0001/01/01 00:00:00")
        //        {
        //            e.Success = true;
        //        }
        //        else
        //        {
        //            e.Success = false;
        //            e.ErrorMessage = errorMessage;
        //        }
        //    }
        //}


    }

    protected void Save(object sender, DirectEventArgs e)
    {
        try
        {
            DataSource ds = new DataSource();

            if (String.IsNullOrEmpty(tfID.Text))
                ds.Id = Guid.NewGuid();
            else
                ds = new DataSource(tfID.Text.Trim());

            ds.Code = tfCode.Text.Trim();
            ds.Name = tfName.Text.Trim();
            ds.Description = tfDescription.Text.Trim();
            ds.Url = tfUrl.Text;
            //ds.DataSourceTypeID = new Guid(cbDataSourceType.SelectedItem.Value);
            //ds.DefaultNullValue = Int64.Parse(nfDefaultValue.Value.ToString());

            ds.UpdateFreq = int.Parse(cbUpdateFrequency.SelectedItem.Value);

            if (cbDataSchema.SelectedItem.Value == null)
                ds.DataSchemaID = null;
            else
            {
                SensorCollection col = new Select().From(Sensor.Schema)
                    .Where(Sensor.Columns.DataSourceID).IsEqualTo(ds.Id)
                    .And(Sensor.Columns.DataSchemaID).IsNotNull()
                    .ExecuteAsCollection<SensorCollection>();

                if (!col.Any())
                {
                    ds.DataSchemaID = Guid.Parse(cbDataSchema.SelectedItem.Value);
                }
                else
                {
                    Log.Verbose($"DirectCall.DeleteSensorSchemas(\"{ds.Id.ToString()}\",{{ eventMask: {{ showMask: true}}}});");
                    MessageBoxes.Confirm("Confirm",
                        $"DirectCall.DeleteSensorSchemas(\"{ds.Id.ToString()}\",{{ eventMask: {{ showMask: true}}}});",
                        $"This data source can't have a data schema because sensor{(col.Count > 1 ? "s" : "")} {string.Join(", ", col)} are already linked to a data schema. Clear the schema from these sensor{(col.Count > 1 ? "s" : "")}?");
                    return;
                }
            }


            if (StartDate.SelectedDate.Date.Year < 1900)
                ds.StartDate = null;
            else
                ds.StartDate = StartDate.SelectedDate;
            if (EndDate.SelectedDate.Date.Year < 1900)
                ds.EndDate = null;
            else
                ds.EndDate = EndDate.SelectedDate;

            ds.UserId = AuthHelper.GetLoggedInUserId;

            ds.Save();
            Auditing.Log("DataSources.Save", new Dictionary<string, object> {
                { "ID", ds.Id }, { "Code", ds.Code }, { "Name", ds.Name } });
            DataSourcesGrid.DataBind();

            DetailWindow.Hide();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unable to save data source");
            throw;
        }
    }

    [DirectMethod]
    public void DeleteSensorSchemas(Guid aId)
    {
        try
        {
            SensorCollection col = new Select().From(Sensor.Schema)
                .Where(Sensor.Columns.DataSourceID).IsEqualTo(aId)
                .And(Sensor.Columns.DataSchemaID).IsNotNull()
                .ExecuteAsCollection<SensorCollection>();
            foreach (var sensor in col)
            {
                sensor.DataSchemaID = null;
                sensor.Save();
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unable to delete sensor schemas");
            throw;
        }
    }

    protected void DataSourcesGridStore_Submit(object sender, StoreSubmitDataEventArgs e)
    {
        string type = FormatType.Text;
        string visCols = VisCols.Value.ToString();
        string gridData = GridData.Text;
        string sortCol = SortInfo.Text.Substring(0, SortInfo.Text.IndexOf("|"));
        string sortDir = SortInfo.Text.Substring(SortInfo.Text.IndexOf("|") + 1);

        string js = BaseRepository.BuildExportQ("VDataSource", gridData, visCols, sortCol, sortDir);

        BaseRepository.doExport(type, js);
    }

    #endregion

    #region Instruments

    protected void InstrumentLinksGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (e.Parameters["DataSourceID"] != null && e.Parameters["DataSourceID"].ToString() != "-1")
        {
            Guid Id = Guid.Parse(e.Parameters["DataSourceID"].ToString());
            VInstrumentDataSourceCollection col = new VInstrumentDataSourceCollection()
                .Where(VInstrumentDataSource.Columns.DataSourceID, Id)
                .OrderByAsc(VInstrumentDataSource.Columns.StartDate)
                .OrderByAsc(VInstrumentDataSource.Columns.EndDate)
                .OrderByAsc(VInstrumentDataSource.Columns.InstrumentName)
                .Load();
            InstrumentLinksGrid.GetStore().DataSource = col;
            InstrumentLinksGrid.GetStore().DataBind();
        }
    }

    protected void InstrumentLinkSave(object sender, DirectEventArgs e)
    {
        try
        {
            RowSelectionModel masterRow = DataSourcesGrid.SelectionModel.Primary as RowSelectionModel;
            var masterID = new Guid(masterRow.SelectedRecordID);
            InstrumentDataSource instrumentDataSource = new InstrumentDataSource(Utilities.MakeGuid(InstrumentLinkID.Value));
            instrumentDataSource.DataSourceID = masterID;
            instrumentDataSource.InstrumentID = new Guid(cbInstrument.SelectedItem.Value.Trim());
            if (dfInstrumentStartDate.SelectedDate.Year < 1900)
                instrumentDataSource.StartDate = null;
            else
                instrumentDataSource.StartDate = dfInstrumentStartDate.SelectedDate;
            if (dfInstrumentEndDate.SelectedDate.Year < 1900)
                instrumentDataSource.EndDate = null;
            else
                instrumentDataSource.EndDate = dfInstrumentEndDate.SelectedDate;
            instrumentDataSource.UserId = AuthHelper.GetLoggedInUserId;
            instrumentDataSource.Save();
            Auditing.Log("DataSources.AddInstrumentLink", new Dictionary<string, object> {
                { "DataSourceID", instrumentDataSource.DataSourceID },
                { "DataSourceCode", instrumentDataSource.DataSource.Code },
                { "InstrumentID", instrumentDataSource.InstrumentID},
                { "InstrumentCode", instrumentDataSource.Instrument.Code},
                { "StartDate", instrumentDataSource.StartDate },
                { "EndDate", instrumentDataSource.EndDate}
            });
            InstrumentLinksGrid.DataBind();
            InstrumentLinkWindow.Hide();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DataSources.LinkInstrument_Click");
            MessageBoxes.Error(ex, "Error", "Unable to link instrument");
        }
    }

    [DirectMethod]
    public void ConfirmDeleteInstrumentLink(Guid aID)
    {
        MessageBoxes.Confirm(
            "Confirm Delete",
            $"DirectCall.DeleteInstrumentLink(\"{aID.ToString()}\",{{ eventMask: {{ showMask: true}}}});",
            "Are you sure you want to delete this instrument link?");
    }

    [DirectMethod]
    public void DeleteInstrumentLink(Guid aID)
    {
        try
        {
            InstrumentDataSource.Delete(aID);
            Auditing.Log("DataSources.DeleteInstrumentLink", new Dictionary<string, object> { { "ID", aID } });
            InstrumentLinksGrid.DataBind();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DataSources.DeleteInstrumentLink({aID})", aID);
            MessageBoxes.Error(ex, "Error", "Unable to delete instrument link");
        }
    }

    [DirectMethod]
    public void AddInstrumentClick(object sender, DirectEventArgs e)
    {
        //X.Redirect(X.ResourceManager.ResolveUrl("Admin/Sites"));
    }
    #endregion

    #region Data Source Transformations
    protected void TransformationsGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (e.Parameters["DataSourceID"] != null && e.Parameters["DataSourceID"].ToString() != "-1")
        {

            try
            {
                Guid Id = Guid.Parse(e.Parameters["DataSourceID"].ToString());

                VDataSourceTransformationCollection trCol = new VDataSourceTransformationCollection()
                    .Where(VDataSourceTransformation.Columns.DataSourceID, Id)
                    .OrderByAsc(VDataSourceTransformation.Columns.Iorder)
                    .OrderByAsc(VDataSourceTransformation.Columns.Rank)
                    .Load();

                TransformationsGrid.GetStore().DataSource = trCol;
                TransformationsGrid.GetStore().DataBind();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unable to load transformations");
                throw;
            }
        }
    }

    protected void SaveTransformation(object sender, DirectEventArgs e)
    {
        try
        {

            RowSelectionModel masterRow = DataSourcesGrid.SelectionModel.Primary as RowSelectionModel;
            var masterID = new Guid(masterRow.SelectedRecordID);
            DataSourceTransformation dstransform = null;
            if (String.IsNullOrEmpty(tfTransID.Text))
            {
                dstransform = new DataSourceTransformation();
            }
            else
            {
                dstransform = new DataSourceTransformation(tfTransID.Text.Trim());
            }

            // --> Removed 20170126 TimPN
            ////Check for outdated Transforms
            //SqlQuery q = new Select().From<DataSourceTransformation>()
            //            .Where(DataSourceTransformation.TransformationTypeIDColumn).IsEqualTo(cbTransformType.SelectedItem.Value)
            //            .And(DataSourceTransformation.PhenomenonIDColumn).IsEqualTo(cbPhenomenon.SelectedItem.Value)
            //            .And(DataSourceTransformation.DataSourceIDColumn).IsEqualTo(datasourceRow.SelectedRecordID)
            //            .AndExpression(DataSourceTransformation.EndDateColumn.QualifiedName).IsNull().Or(DataSourceTransformation.EndDateColumn).IsGreaterThanOrEqualTo(dfTransStart.SelectedDate).CloseExpression();

            //if (String.IsNullOrEmpty(tfTransID.Text))
            //    dstransform.Id = Guid.NewGuid();
            //else
            //{
            //    dstransform = new DataSourceTransformation(tfTransID.Text.Trim());
            //    q = q.And(DataSourceTransformation.IdColumn).IsNotEqualTo(dstransform.Id);
            //}
            //DataSourceTransformationCollection OutdatedItems = q.ExecuteAsCollection<DataSourceTransformationCollection>();
            // --< Removed 20170126 TimPN

            // --> Removed 20170126 TimPN
            //foreach (var item in OutdatedItems)
            //{
            //    item.EndDate = dfTransStart.SelectedDate.Date;
            //    item.Save();
            //}
            // --< Removed 20170126 TimPN

            dstransform.DataSourceID = masterID;
            dstransform.TransformationTypeID = new Guid(cbTransformType.SelectedItem.Value);
            dstransform.PhenomenonID = new Guid(cbPhenomenon.SelectedItem.Value);

            if (cbOffering.SelectedItem.Value != null)
                dstransform.PhenomenonOfferingID = new Guid(cbOffering.SelectedItem.Value);
            else
                dstransform.PhenomenonOfferingID = null;

            if (cbUnitofMeasure.SelectedItem.Value != null)
                dstransform.PhenomenonUOMID = new Guid(cbUnitofMeasure.SelectedItem.Value);
            else
                dstransform.PhenomenonUOMID = null;

            //9ca36c10-cbad-4862-9f28-591acab31237 = Quality Control on Values
            if (new Guid(cbTransformType.SelectedItem.Value) != new Guid("9ca36c10-cbad-4862-9f28-591acab31237"))
            {

                if (sbNewOffering.SelectedItem.Value != null)
                    dstransform.NewPhenomenonOfferingID = new Guid(sbNewOffering.SelectedItem.Value);
                else
                    dstransform.NewPhenomenonOfferingID = null;

                if (sbNewUoM.SelectedItem.Value != null)
                    dstransform.NewPhenomenonUOMID = new Guid(sbNewUoM.SelectedItem.Value);
                else
                    dstransform.NewPhenomenonUOMID = null;
            }
            else
            {
                dstransform.NewPhenomenonOfferingID = null;
                dstransform.NewPhenomenonUOMID = null;
            }
            //

            if (dfTransStart.SelectedDate.Year < 1900)
            {
                dstransform.StartDate = null;
            }
            else
                dstransform.StartDate = dfTransStart.SelectedDate;
            if (dfTransEnd.SelectedDate.Year < 1900)
                dstransform.EndDate = null;
            else
                dstransform.EndDate = dfTransEnd.SelectedDate;
            dstransform.Definition = tfDefinition.Text.Trim().ToLower();
            dstransform.Rank = (int)tfRank.Number;
            dstransform.Save();
            Auditing.Log("DataSources.SaveTransformation", new Dictionary<string, object> {
                { "DataSourceID", dstransform.DataSourceID},
                { "DataSourceCode", dstransform.DataSource.Code},
                { "TransformationTypeID", dstransform.TransformationTypeID},
                { "TransformationTypeName", dstransform.TransformationType.Name },
                { "PhenmenonID", dstransform.PhenomenonID},
                {"PhenomenonName", dstransform.Phenomenon.Name },
                {"PhenomenonOfferingID", dstransform.PhenomenonOfferingID },
                {"OfferingName", dstransform.PhenomenonOffering?.Offering.Name },
                {"PhenomenonUnitOfMeasureID", dstransform.PhenomenonUOMID },
                {"UnitOfMeasureUnit", dstransform.PhenomenonUOM?.UnitOfMeasure.Unit },
                {"NewPhenomenonOfferingID", dstransform.NewPhenomenonOfferingID },
                {"NewPhenomenonUnitOfMeasureID", dstransform.NewPhenomenonUOMID },
                {"StartDate", dstransform.StartDate },
                {"EndDate", dstransform.EndDate },
                {"Rank", dstransform.Rank }
                });

            TransformationsGrid.GetStore().DataBind();

            TransformationDetailWindow.Hide();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unable to save transformation");
            MessageBoxes.Error(ex, "Error", "Unable to save transformation");
            throw;
        }
    }

    [DirectMethod]
    public void ConfirmDeleteTransformation(Guid aID)
    {
        MessageBoxes.Confirm(
            "Confirm Delete",
            String.Format("DirectCall.DeleteTransformation(\"{0}\",{{ eventMask: {{ showMask: true}}}});", aID.ToString()),
            "Are you sure you want to delete this transformation?");
    }

    [DirectMethod]
    public void DeleteTransformation(Guid aID)
    {
        try
        {
            DataSourceTransformation.Delete(aID);
            Auditing.Log("DataSource.DeleteTransformation", new Dictionary<string, object> { { "ID", aID } });
            TransformationsGrid.GetStore().DataBind();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DataSource.DeleteTransform({aID})", aID);
            MessageBoxes.Error(ex, "Error", "Unable to delete transformation");
        }
    }

    protected void cbOffering_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        var Id = cbPhenomenon.SelectedItem.Value;

        cbOffering.GetStore().DataSource = new Select(PhenomenonOffering.IdColumn, Offering.NameColumn)
                 .From(Offering.Schema)
                 .InnerJoin(PhenomenonOffering.OfferingIDColumn, Offering.IdColumn)
                 .Where(PhenomenonOffering.Columns.PhenomenonID).IsEqualTo(Id)
                 .ExecuteDataSet().Tables[0];
        cbOffering.GetStore().DataBind();
    }

    protected void cbUnitofMeasure_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        var Id = cbPhenomenon.SelectedItem.Value;

        cbUnitofMeasure.GetStore().DataSource = new Select(PhenomenonUOM.IdColumn, UnitOfMeasure.UnitColumn)
               .From(UnitOfMeasure.Schema)
               .InnerJoin(PhenomenonUOM.UnitOfMeasureIDColumn, UnitOfMeasure.IdColumn)
               .Where(PhenomenonUOM.Columns.PhenomenonID).IsEqualTo(Id)
               .ExecuteDataSet().Tables[0];
        cbUnitofMeasure.GetStore().DataBind();
    }

    //////////////
    protected void cbNewOffering_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        var Id = cbPhenomenon.SelectedItem.Value;

        sbNewOffering.GetStore().DataSource = new Select(PhenomenonOffering.IdColumn, Offering.NameColumn)
                 .From(Offering.Schema)
                 .InnerJoin(PhenomenonOffering.OfferingIDColumn, Offering.IdColumn)
                 .Where(PhenomenonOffering.Columns.PhenomenonID).IsEqualTo(Id)
                 .ExecuteDataSet().Tables[0];
        sbNewOffering.GetStore().DataBind();
    }

    protected void cbNewUnitofMeasure_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        var Id = cbPhenomenon.SelectedItem.Value;

        sbNewUoM.GetStore().DataSource = new Select(PhenomenonUOM.IdColumn, UnitOfMeasure.UnitColumn)
               .From(UnitOfMeasure.Schema)
               .InnerJoin(PhenomenonUOM.UnitOfMeasureIDColumn, UnitOfMeasure.IdColumn)
               .Where(PhenomenonUOM.Columns.PhenomenonID).IsEqualTo(Id)
               .ExecuteDataSet().Tables[0];
        sbNewUoM.GetStore().DataBind();
    }

    protected void OnDefinitionValidation(object sender, RemoteValidationEventArgs e)
    {


        try
        {
            string json = String.Concat("{", e.Value.ToString(), "}");

            if (cbTransformType.SelectedItem.Value == null)
            {
                e.ErrorMessage = "Select a transformation type.";
                e.Success = false;
            }
            else
            {
                switch (cbTransformType.SelectedItem.Value)
                {
                    case TransformationType.RatingTable:
                        JSON.Deserialize<Dictionary<double, double>>(json);
                        e.Success = true;
                        break;
                    case TransformationType.QualityControlValues:
                        JSON.Deserialize<Dictionary<string, double>>(json);
                        e.Success = true;
                        break;
                    case TransformationType.Lookup:
                        JSON.Deserialize<Dictionary<string, double>>(json);
                        e.Success = true;
                        break;
                    case TransformationType.CorrectionValues:
                        Dictionary<string, string> corrvals = JSON.Deserialize<Dictionary<string, string>>(json);

                        if (corrvals.Count > 1)
                        {
                            e.Success = false;
                            e.ErrorMessage = "Only one expression is currently supported";
                        }
                        else if (!corrvals.ContainsKey("eq"))
                        {
                            e.Success = false;
                            e.ErrorMessage = "The Key value of this value should be \" eq \"";
                        }
                        else
                        {
                            Expression exp = new Expression(corrvals["eq"]);

                            if (!corrvals["eq"].Contains("[value]"))
                            {
                                e.Success = false;
                                e.ErrorMessage = "The expression accepts only one one variable - [value]";
                            }
                            else if (exp.HasErrors())
                            {
                                e.Success = false;
                                e.ErrorMessage = String.Concat("Error in expression - ", exp.Error);
                            }
                            else
                                e.Success = true;

                        }

                        break;
                }
            }
        }
        catch
        {
            e.ErrorMessage = "Invalid Definition.";
            e.Success = false;
        }
    }

    #endregion

    #region Roles
    protected void SaveRoleDetail(object sender, DirectEventArgs e)
    {
        try
        {
            DataSourceRole dsRole = new DataSourceRole(hiddenRoleDetail.Text);

            if (dfRoleDetailStart.SelectedDate.Year < 1900)
                dsRole.DateStart = null;
            else
                dsRole.DateStart = dfRoleDetailStart.SelectedDate;
            if (dfRoleDetailEnd.SelectedDate.Year < 1900)
                dsRole.DateEnd = null;
            else
                dsRole.DateEnd = dfRoleDetailEnd.SelectedDate;
            dsRole.IsRoleReadOnly = cbIsRoleReadOnly.Checked;

            dsRole.Save();

            Auditing.Log("DataSources.SaveRoleDetail", new Dictionary<string, object> {
                { "DataSourceID", dsRole.DataSourceID},
                { "DataSourceCode", dsRole.DataSource.Code},
                { "RoleID", dsRole.RoleId },
                { "RoleName", dsRole.AspnetRole.RoleName },
                { "DateStart", dsRole.DateStart },
                { "DateEnd", dsRole.DateEnd},
                { "IsReadOnly", dsRole.IsRoleReadOnly }
                            });
            RolesGrid.GetStore().DataBind();

            RoleDetailWindow.Hide();

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unable to save role detail");
            MessageBoxes.Error(ex, "Error", "Unable to save role detail");
        }
    }

    protected void RolesGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {

        if (e.Parameters["DataSourceID"] != null && e.Parameters["DataSourceID"].ToString() != "-1")
        {

            Guid Id = Guid.Parse(e.Parameters["DataSourceID"].ToString());
            VDataSourceRoleCollection col = new VDataSourceRoleCollection()
                .Where(VDataSourceRole.Columns.DataSourceID, Id)
                .OrderByAsc(VDataSourceRole.Columns.RoleName)
                .Load();
            RolesGrid.GetStore().DataSource = col;
            RolesGrid.GetStore().DataBind();
        }
    }

    protected void AvailableRolesGridStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (e.Parameters["DataSourceID"] != null && e.Parameters["DataSourceID"].ToString() != "-1")
        {
            Guid Id = Guid.Parse(e.Parameters["DataSourceID"].ToString());
            AspnetRoleCollection col = new Select()
                .From(AspnetRole.Schema)
                .Where(AspnetRole.RoleIdColumn).NotIn(new Select(new String[] { DataSourceRole.Columns.RoleId })
                .From(DataSourceRole.Schema)
                .Where(DataSourceRole.DataSourceIDColumn).IsEqualTo(Id))
                .ExecuteAsCollection<AspnetRoleCollection>();
            AvailableRolesGridStore.DataSource = col;
            AvailableRolesGridStore.DataBind();
        }
    }

    protected void RoleLinksSave(object sender, DirectEventArgs e)
    {
        try
        {
            RowSelectionModel sm = AvailableRolesGrid.SelectionModel.Primary as RowSelectionModel;
            RowSelectionModel dataSourceRow = DataSourcesGrid.SelectionModel.Primary as RowSelectionModel;

            string dataSourceID = dataSourceRow.SelectedRecordID;
            if (sm.SelectedRows.Count == 0)
            {
                MessageBoxes.Error("Invalid Selection", "Select at least one data source");
            }
            else
            {
                foreach (SelectedRow row in sm.SelectedRows)
                {
                    AspnetRole aspRole = new AspnetRole(row.RecordID);
                    DataSourceRole role = new DataSourceRole();
                    role.DataSourceID = Utilities.MakeGuid(dataSourceID);
                    role.RoleId = aspRole.RoleId;
                    role.RoleName = aspRole.RoleName;
                    role.IsRoleReadOnly = false;
                    role.UserId = AuthHelper.GetLoggedInUserId;
                    role.Save();
                    Auditing.Log("DataSources.AddRoleLink", new Dictionary<string, object> {
                                { "DataSourceID", role.DataSourceID},
                                { "DataSourceCode", role.DataSource.Code},
                                { "RoleID", role.RoleId },
                                { "RoleName", role.AspnetRole.RoleName }
                            });
                }
                RolesGridStore.DataBind();
                AvailableRolesGridStore.DataBind();
                AvailableRolesWindow.Hide();
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DataSources.LinkRole_Click");
            MessageBoxes.Error(ex, "Error", "Unable to link role");
        }
    }

    //protected void AcceptRoleButton_Click(object sender, DirectEventArgs e)
    //{

    //    RowSelectionModel sm = AvailableRolesGrid.SelectionModel.Primary as RowSelectionModel;
    //    RowSelectionModel DataSourcerow = DataSourcesGrid.SelectionModel.Primary as RowSelectionModel;

    //    string DataSourceID = DataSourcerow.SelectedRecordID;

    //    //
    //    string data = e.ExtraParams["RoleValues"];
    //    JsonObject[] jObj = JSON.Deserialize<JsonObject[]>(data);
    //    int nrRoles = 0;
    //    foreach (JsonObject jsonObject in jObj)
    //    {
    //        nrRoles++;
    //        Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonObject.ToString());

    //        string[] colms = new string[values.Count()];
    //        int i = 0;
    //        foreach (var item in values)
    //        {
    //            colms[i] = item.Value;
    //            i++;
    //        }

    //        DataSourceRole role = new DataSourceRole();
    //        role.RoleId = new Guid(colms[0]);
    //        role.DataSourceID = new Guid(DataSourceID);
    //        role.DateStart = DateTime.Parse(colms[3]);
    //        role.DateEnd = DateTime.Parse(colms[4]);
    //        role.RoleName = colms[1];
    //        role.IsRoleReadOnly = bool.Parse(colms[5]);

    //        role.Save();
    //    }
    //    //

    //    if (nrRoles == 0)
    //    {
    //        X.Msg.Show(new MessageBoxConfig
    //        {
    //            Title = "Invalid Selection",
    //            Message = "Select at least one Role",
    //            Buttons = MessageBox.Button.OK,
    //            Icon = MessageBox.Icon.INFO
    //        });
    //    }
    //    else
    //    {
    //        RolesGrid.GetStore().DataBind();
    //        RoleGrid.GetStore().DataBind();
    //        AvailableRoleWindow.Hide();
    //    }

    //}

    [DirectMethod]
    public void ConfirmDeleteRole(Guid aID)
    {
        MessageBoxes.Confirm(
            "Confirm Delete",
            String.Format("DirectCall.DeleteRoleLink(\"{0}\",{{ eventMask: {{ showMask: true}}}});", aID.ToString()),
            "Are you sure you want to delete this role link?");
    }

    [DirectMethod]
    public void DeleteRoleLink(Guid aID)
    {
        try
        {
            DataSourceRole.Delete(aID);
            Auditing.Log("DataSource.DeleteRoleLink", new Dictionary<string, object> { { "ID", aID } });
            RolesGridStore.DataBind();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DataSource.DeleteRoleLink({aID})", aID);
            MessageBoxes.Error(ex, "Error", "Unable to delete role link");
        }
    }

    #endregion


}