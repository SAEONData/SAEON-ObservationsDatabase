﻿<%@ Page Title="Data Schemas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DataSchemas.aspx.cs" Inherits="Admin_DataSchemas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../JS/DataSchemas.js"></script>
    <script type="text/javascript" src="../JS/generic.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var submitValue = function (format) {
            GridData.setValue(Ext.encode(ContentPlaceHolder1_GridFilters1.buildQuery(ContentPlaceHolder1_GridFilters1.getFilterData())));
            //VisCols.setValue(Ext.encode(ContentPlaceHolder1_DataSchemaGrid.getRowsValues({ visibleOnly: true, excludeId: true })[0]));
            var viscolsNew = makenewJsonForExport(ContentPlaceHolder1_DataSchemaGrid.getColumnModel().getColumnsBy(function (column, colIndex) { return !this.isHidden(colIndex); }))
            VisCols.setValue(viscolsNew);
            FormatType.setValue(format);
            SortInfo.setValue(ContentPlaceHolder1_GridFilters1.store.sortInfo.field + "|" + ContentPlaceHolder1_GridFilters1.store.sortInfo.direction);

            ContentPlaceHolder1_DataSchemaGrid.submitData(false);
        };

    </script>
    <ext:Store ID="DataSourceTypeStore" runat="server">
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="Id" Type="Auto" />
                    <ext:RecordField Name="Description" Type="String" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Hidden ID="GridData" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="VisCols" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="FormatType" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="SortInfo" runat="server" ClientIDMode="Static" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center MarginsSummary="5 0 0 5">
                    <ext:Panel ID="Panel1" runat="server" Title="Data Schemas" Layout="Fit">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnAdd" runat="server" Icon="Add" Text="Add Schema" ClientIDMode="Static">
                                        <ToolTips>
                                            <ext:ToolTip ID="ToolTip1" runat="server" Html="Add" />
                                        </ToolTips>
                                        <Listeners>
                                            <Click Fn="New" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                    <ext:Button ID="Button10" runat="server" Text="To Excel" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="submitValue('exc');" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="Button11" runat="server" Text="To CSV" Icon="PageAttach">
                                        <Listeners>
                                            <Click Handler="submitValue('csv');" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:GridPanel ID="DataSchemasGrid" runat="server" Border="false">
                                <Store>
                                    <ext:Store ID="DataSchemasGridStore" runat="server" RemoteSort="true" OnRefreshData="DataSchemasGridStore_RefreshData"
                                        OnSubmitData="DataSchemasGridStore_Submit">
                                        <Proxy>
                                            <ext:PageProxy />
                                        </Proxy>
                                        <Reader>
                                            <ext:JsonReader IDProperty="Id">
                                                <Fields>
                                                    <ext:RecordField Name="Id" Type="Auto" />
                                                    <ext:RecordField Name="Code" Type="String" />
                                                    <ext:RecordField Name="Name" Type="String" />
                                                    <ext:RecordField Name="IgnoreFirst" Type="Int" />
                                                    <ext:RecordField Name="IgnoreLast" Type="Int" />
                                                    <ext:RecordField Name="Condition" Type="String" />
                                                    <ext:RecordField Name="Delimiter" Type="String" />
                                                    <ext:RecordField Name="Description" Type="String" />
                                                    <ext:RecordField Name="DataSourceTypeID" Type="String" />
                                                    <ext:RecordField Name="DataSourceTypeCode" Type="String" />
                                                    <ext:RecordField Name="DataSourceTypeDesc" Type="String" />
                                                    <ext:RecordField Name="SplitSelector" Type="String" />
                                                    <ext:RecordField Name="SplitIndex" Type="Int" UseNull="true" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        <BaseParams>
                                            <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                            <ext:Parameter Name="limit" Value="25" Mode="Raw" />
                                            <ext:Parameter Name="sort" Value="" />
                                            <ext:Parameter Name="dir" Value="" />
                                        </BaseParams>
                                        <SortInfo Field="Name" Direction="ASC" />
                                        <DirectEventConfig IsUpload="true" />
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:Column Header="Code" DataIndex="Code" Width="200" />
                                        <ext:Column Header="Name" DataIndex="Name" Width="200" />
                                        <ext:Column Header="Description" DataIndex="Description" Width="200" />
                                        <ext:Column Header="Source Type Code" Width="100" DataIndex="DataSourceTypeCode" />
                                        <ext:Column Header="Source Type Description" Width="150" DataIndex="DataSourceTypeDesc" />
                                        <ext:CommandColumn Width="75">
                                            <Commands>
                                                <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="Edit" />
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                        <Listeners>
                                            <RowSelect Fn="MasterRowSelect" Buffer="250" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <Plugins>
                                    <ext:GridFilters runat="server" ID="GridFilters1">
                                        <Filters>
                                            <ext:StringFilter DataIndex="ID" />
                                            <ext:StringFilter DataIndex="Code" />
                                            <ext:StringFilter DataIndex="Name" />
                                            <ext:StringFilter DataIndex="Description" />
                                            <ext:StringFilter DataIndex="DataSourceTypeCode" />
                                            <ext:StringFilter DataIndex="DataSourceTypeDesc" />
                                        </Filters>
                                    </ext:GridFilters>
                                </Plugins>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25" EmptyMsg="No data found" />
                                </BottomBar>
                                <Listeners>
                                    <Command Fn="onCommand" />
                                </Listeners>
<%--                                <DirectEvents>
                                    <Command OnEvent="onCommand">
                                        <ExtraParams>
                                            <ext:Parameter Name="type" Value="params[0]" Mode="Raw" />
                                            <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                        </ExtraParams>
                                        <EventMask ShowMask="true" />
                                    </Command>
                                </DirectEvents>--%>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                </Center>
                <South Collapsible="true" Split="true" MinHeight="250">
                    <ext:TabPanel ID="pnlSouth" runat="server" Height="250" TabPosition="Top" Border="false" ClientIDMode="Static">
                        <Items>
                            <ext:Panel ID="pnlSchemaColumns" runat="server" Title="Schema Columns" Layout="FitLayout"
                                Height="200" ClientIDMode="Static">
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar4" runat="server">
                                        <Items>
                                            <ext:Button ID="btnSchemaColumnAdd" runat="server" Icon="Add" Text="Add Schema Column" ClientIDMode="Static">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip4" runat="server" Html="Link" />
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="if(Ext.getCmp('#{DataSchemasGrid}') && #{DataSchemasGrid}.getSelectionModel().hasSelection()){#{SchemaColumnAddWindow}.show()}else{Ext.Msg.alert('Invalid Selection','Select a DataSchema.')}" />
                                                </Listeners>
                                            </ext:Button>
                                            <%-- 
                                            <ext:Button ID="btnAddSchemaColumn" runat="server" Icon="Add" Text="Add SchemaColumn">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip5" runat="server" Html="Add" />
                                                </ToolTips>
                                                <DirectEvents>
                                                    <Click OnEvent="AddSchemaColumnClick" />
                                                </DirectEvents>
                                            </ext:Button>
                                            --%>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Items>
                                    <ext:GridPanel ID="SchemaColumnsGrid" runat="server" Border="false" ClientIDMode="Static">
                                        <Store>
                                            <ext:Store ID="SchemaColumnsGridStore" runat="server" OnRefreshData="SchemaColumnsGridStore_RefreshData">
                                                <Proxy>
                                                    <ext:PageProxy />
                                                </Proxy>
                                                <Reader>
                                                    <ext:JsonReader IDProperty="Id">
                                                        <Fields>
                                                            <ext:RecordField Name="Id" Type="Auto" />
                                                            <ext:RecordField Name="DataSchemaID" Type="Auto" />
                                                            <ext:RecordField Name="Name" Type="Auto" />
                                                            <ext:RecordField Name="Number" Type="Auto" />
                                                            <ext:RecordField Name="Width" Type="Auto" />
                                                            <ext:RecordField Name="SchemaColumnTypeID" Type="Auto" />
                                                            <ext:RecordField Name="SchemaColumnTypeName" Type="Auto" />
                                                            <ext:RecordField Name="PhenomenonID" Type="Auto" />
                                                            <ext:RecordField Name="PhenomenonName" Type="Auto" />
                                                            <ext:RecordField Name="OfferingID" Type="Auto" />
                                                            <ext:RecordField Name="OfferingName" Type="Auto" />
                                                            <ext:RecordField Name="UnitOfMeasureID" Type="Auto" />
                                                            <ext:RecordField Name="UnitOfMeasureName" Type="Auto" />
                                                            <ext:RecordField Name="EmptyValue" Type="Auto" />
                                                            <ext:RecordField Name="FixedTime" Type="Auto" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                                <BaseParams>
                                                    <ext:Parameter Name="DataSchemaID" Value="Ext.getCmp('#{DataSchemasGrid}') && #{DataSchemasGrid}.getSelectionModel().hasSelection() ? #{DataSchemasGrid}.getSelectionModel().getSelected().id : -1"
                                                        Mode="Raw" />
                                                </BaseParams>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel ID="ColumnModel4" runat="server">
                                            <Columns>
                                                <ext:Column Header="Name" DataIndex="Name" Width="200" />
                                                <ext:Column Header="Width" DataIndex="Width" Width="100" />
                                                <ext:Column Header="Type" DataIndex="SchemaColumnTypeName" Width="100" />
                                                <ext:Column Header="Phenomenon" DataIndex="PhenomenonName" Width="150" />
                                                <ext:Column Header="Offering" DataIndex="OfferingName" Width="1500" />
                                                <ext:Column Header="Unit of measure" DataIndex="UnitOfMeasureName" Width="150" />
                                                <ext:Column Header="Empty value" DataIndex="EmptyValue" Width="100" />
                                                <ext:Column Header="Fixed time" DataIndex="FixedTime" Width="100" />
                                                <ext:CommandColumn Width="150">
                                                    <Commands>
                                                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="Edit" />
                                                        <ext:GridCommand Icon="LinkDelete" CommandName="Delete" Text="Unlink" />
                                                    </Commands>
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>
                                        <SelectionModel>
                                            <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" SingleSelect="true">
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                        <LoadMask ShowMask="true" />
                                        <Listeners>
                                            <Command Fn="OnSchemaColumnAddCommand" />
                                        </Listeners>
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
                </South>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    <ext:Window ID="DetailWindow" runat="server" Width="640" Height="470" Closable="true"
        Hidden="true" Collapsible="false" Title="Data Schema Detail" Maximizable="false"
        Layout="Fit" AutoScroll="true" ClientIDMode="Static">
        <Content>
            <ext:FormPanel ID="DetailsFormPanel" runat="server" Title="" MonitorPoll="500" MonitorValid="true"
                MonitorResize="true" Padding="10" ButtonAlign="Right" Layout="RowLayout" ClientIDMode="Static">
                <LoadMask ShowMask="true" />
                <Items>
                    <ext:Hidden ID="tfID" DataIndex="Id" runat="server" ClientIDMode="Static">
                    </ext:Hidden>
                    <ext:Container ID="Container1" runat="server" Layout="Column" Height="100">
                        <Items>
                            <ext:Container ID="Container2" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextField ID="tfCode" DataIndex="Code" IsRemoteValidation="true" MaxLength="50"
                                        runat="server" FieldLabel="Code" AnchorHorizontal="93%" AllowBlank="false" BlankText="Code is a required"
                                        MsgTarget="Side" ClientIDMode="Static">
                                        <RemoteValidation OnValidation="ValidateField" />
                                    </ext:TextField>
                                    <ext:ComboBox ID="cbDataSourceType" runat="server" StoreID="DataSourceTypeStore" Editable="false" BlankText="Source Type is required"
                                        MsgTarget="Side" DisplayField="Description" ValueField="Id" TypeAhead="true"
                                        Mode="Local" ForceSelection="true" TriggerAction="All" AllowBlank="false" DataIndex="DataSourceTypeID"
                                        EmptyText="Select Source Type" SelectOnFocus="true" FieldLabel="Source Type"
                                        AnchorHorizontal="93%">
<%--                                        <Listeners>
                                            <Select Handler="#{cbDataSourceType}.getValue() == '25839703-3cb3-4c23-aca3-4399cc52ecde'?#{cbDelimiter}.allowBlank=false:#{cbDelimiter}.allowBlank=true;#{cbDelimiter}.clearValue();#{cbDelimiter}.clearInvalid();#{cbDelimiter}.markAsValid();" />
                                        </Listeners>--%>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container3" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextField ID="tfName" DataIndex="Name" MaxLength="150" IsRemoteValidation="true"
                                        runat="server" FieldLabel="Name" AnchorHorizontal="93%" AllowBlank="false" BlankText="Name is a required"
                                        MsgTarget="Side" ClientIDMode="Static">
                                        <RemoteValidation OnValidation="ValidateField" />
                                    </ext:TextField>
                                    <ext:ComboBox ID="cbDelimiter" runat="server" Editable="false" MsgTarget="Side" TypeAhead="true"
                                        Mode="Local" ForceSelection="true" TriggerAction="All" DataIndex="Delimiter"
                                        EmptyText="Select Delimiter" SelectOnFocus="true" BlankText="Delimiter is required for this Source Type"
                                        FieldLabel="Delimiter" AnchorHorizontal="93%" ClientIDMode="Static">
                                        <Items>
                                            <ext:ListItem Text="Comma Delimited (,)" Value="," />
                                            <ext:ListItem Text="Pipe Delimited (|)" Value="|" />
                                            <ext:ListItem Text="Tab Delimited (\t)" Value="\t" />
                                            <ext:ListItem Text="SemiColon Delimited (;)" Value=";" />
                                        </Items>
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="this.clearValue();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container4" runat="server" Layout="Column" Height="50">
                        <Items>
                            <ext:Container ID="Container5" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:NumberField AllowDecimals="false" ID="nfIgnoreFirst" DataIndex="IgnoreFirst"
                                        MaxLength="10" runat="server" FieldLabel="Ignore first # of lines on import"
                                        AnchorHorizontal="93%">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container6" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:NumberField AllowDecimals="false" ID="nfIgnoreLast" DataIndex="IgnoreLast" MaxLength="10"
                                        runat="server" FieldLabel="Ignore last # of lines on import" AnchorHorizontal="95%">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container10" runat="server" Layout="Column" Height="100">
                        <Items>
                            <ext:Container ID="Container11" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextArea ID="tfCondition" DataIndex="Condition" MaxLength="150" runat="server"
                                        FieldLabel="Record Condition - Ignore fields that start with" AnchorHorizontal="93%"
                                        MsgTarget="Side">
                                    </ext:TextArea>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container12" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextArea ID="tfDescription" DataIndex="Description" MaxLength="150" runat="server"
                                        FieldLabel="Description" AnchorHorizontal="93%" AllowBlank="true" BlankText="Description is a required"
                                        MsgTarget="Side" ClientIDMode="Static">
                                    </ext:TextArea>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container7" runat="server" Layout="Column" Height="100">
                        <Items>
                            <ext:Container ID="Container8" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:TextField ID="tfSplit" DataIndex="SplitSelector" MaxLength="150" runat="server"
                                        FieldLabel="File Split Condition - Data Split" AnchorHorizontal="93%" MsgTarget="Side">
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container9" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:NumberField ID="nfSplitIndex" DataIndex="SplitIndex" MaxLength="150" runat="server"
                                        FieldLabel="Data file Split Index" AnchorHorizontal="93%" AllowDecimals="true"
                                        BlankText="Split index is required for a split data file" MsgTarget="Side">
                                        <Listeners>
                                            <Valid Handler="if(#{tfSplit}.getValue() == '') this.allowBlank = true;else this.allowBlank = false;" />
                                        </Listeners>
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSave" runat="server" Text="Save" FormBind="true">
                        <DirectEvents>
                            <Click OnEvent="Save" Method="POST">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
    <ext:Window ID="SchemaColumnAddWindow" runat="server" Width="450" Height="300" Closable="true"
        Hidden="true" Collapsible="false" Title="Link Sensor"
        Maximizable="false" Layout="Fit" ClientIDMode="Static">
        <Listeners>
            <Hide Fn="ClearSchemaColumnAddForm" />
        </Listeners>
        <Content>
            <ext:FormPanel ID="SchemaColumnAddFormPanel" runat="server" Title="" MonitorPoll="500" MonitorValid="true"
                MonitorResize="true" Padding="10" Width="440" Height="370" ButtonAlign="Right"
                Layout="RowLayout" ClientIDMode="Static">
                <LoadMask ShowMask="true" />
                <Items>
                    <ext:Hidden ID="SchemaColumnAddID" DataIndex="Id" runat="server" ClientIDMode="Static">
                    </ext:Hidden>
                    <%--                    <ext:Panel ID="Panel3" runat="server" Border="false" Header="false" Layout="FormLayout"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Value" />
                            <ext:Parameter Name="blankText" Value="Sensor is a required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:ComboBox ID="cbSensor" runat="server" StoreID="SensorStore" Editable="true" DisplayField="Name"
                                ValueField="Id" TypeAhead="true" Mode="Local" ForceSelection="true" TriggerAction="All"
                                AllowBlank="false" DataIndex="SensorID" EmptyText="Select Sensor"
                                SelectOnFocus="true" AnchorHorizontal="95%" ClientIDMode="Static">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="this.clearValue();this.focus();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel10" runat="server" Border="false" Header="false" Layout="FormLayout" LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="Start Date is required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:DateField ID="dfSensorStartDate" DataIndex="StartDate" MaxLength="100" runat="server" ClientIDMode="Static"
                                FieldLabel="Start Date" AnchorHorizontal="95%" Format="dd MMM yyyy">
                            </ext:DateField>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel11" runat="server" Border="false" Header="false" Layout="FormLayout" LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="End Date is required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:DateField ID="dfSensorEndDate" DataIndex="EndDate" MaxLength="100" runat="server" ClientIDMode="Static"
                                FieldLabel="End Date" AnchorHorizontal="95%" Format="dd MMM yyyy">
                            </ext:DateField>
                        </Items>
                    </ext:Panel>--%>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSchemaColumnAddSave" runat="server" Text="Save" FormBind="true" Icon="Accept" ClientIDMode="Static">
                        <DirectEvents>
                            <Click OnEvent="SchemaColumnAddSave">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar4" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
</asp:Content>

