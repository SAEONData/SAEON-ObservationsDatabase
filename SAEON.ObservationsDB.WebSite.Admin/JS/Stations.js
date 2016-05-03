﻿function onCommand(e, record) {
    DetailsFormPanel.getForm().reset();
    DetailsFormPanel.getForm().loadRecord(record);
    DetailsFormPanel.getForm().clearInvalid();

    tfCode.rvConfig.remoteValidated = false;
    tfCode.rvConfig.remoteValid = false;

    tfName.rvConfig.remoteValidated = false;
    tfName.rvConfig.remoteValid = false;

    tfCode.markAsValid();
    tfName.markAsValid();
    DetailWindow.show();
}

function New() {

    DetailsFormPanel.getForm().reset();
    tfCode.rvConfig.remoteValidated = false;
    tfCode.rvConfig.remoteValid = false;

    tfName.rvConfig.remoteValidated = false;
    tfName.rvConfig.remoteValid = false;

    DetailWindow.show();

}

function MasterRowSelect(e, record) {
    if (pnlSouth.isVisible())
        DataSourcesGrid.getStore().reload();
    if (pnlEast.isVisible())
        OrganisationLinksGrid.getStore().reload();
}

function CloseAvailableDataSources() {
    AvailableDataSourcesGrid.selModel.clearSelections();
}

function ClearOrganisationLinkForm() {
    OrganisationLinkFormPanel.getForm().reset();
}

function onOrganisationLinkCommand(e, record) {
    if (e === 'Delete') {
        DirectCall.ConfirmDeleteOrganisationLink(record.get('Id'), { eventMask: { showMask: true } });
    } else if (e === 'Edit') {
        OrganisationLinkFormPanel.getForm().reset();
        OrganisationLinkFormPanel.getForm().loadRecord(record);
        OrganisationLinkFormPanel.getForm().clearInvalid();
        OrganisationLinkWindow.show();
    }
}

function onDataSourceLinkCommand(e, record) {
    if (e === 'Delete') {
        DirectCall.ConfirmDeleteDataSourceLink(record.get('Id'), { eventMask: { showMask: true } });
    } else if (e === 'Edit') {
        DataSourceLinkFormPanel.getForm().reset();
        DataSourceLinkFormPanel.getForm().loadRecord(record);
        DataSourceLinkFormPanel.getForm().clearInvalid();
        DataSourceLinkWindow.show();
    }
}
