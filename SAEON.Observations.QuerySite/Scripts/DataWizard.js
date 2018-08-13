var DataWizard;
(function (DataWizard) {
    function ShowWaiting() {
        var wp = $("#waiting").data("ejWaitingPopup");
        wp.show();
    }
    DataWizard.ShowWaiting = ShowWaiting;
    function HideWaiting() {
        var wp = $("#waiting").data("ejWaitingPopup");
        wp.hide();
    }
    DataWizard.HideWaiting = HideWaiting;
    function ShowResults() {
        $("#TableTab").removeClass("hidden");
        $("#ChartTab").removeClass("hidden");
        //$("#CardsTab").removeClass("hidden");
    }
    DataWizard.ShowResults = ShowResults;
    function HideResults() {
        $("#TableTab").addClass("hidden");
        $("#ChartTab").addClass("hidden");
        //$("#CardsTab").addClass("hidden");
    }
    DataWizard.HideResults = HideResults;
    function ErrorInFunc(msg) {
        HideWaiting();
        alert(msg);
    }
    function EnableButtons() {
        var btnLoadQuery = $("#btnLoadQuery").data("ejButton");
        var btnSaveQuery = $("#btnSaveQuery").data("ejButton");
        var btnSearch = $("#btnSearch").data("ejButton");
        var btnDownload = $("#btnDownload").data("ejButton");
        var locationsSelected = $("#treeViewLocations").data('ejTreeView').getCheckedNodes().length > 0;
        var featuresSelected = $("#treeViewFeatures").data('ejTreeView').getCheckedNodes().length > 0;
        SetApproximation();
        btnLoadQuery.enable();
        if (locationsSelected && featuresSelected) {
            btnSaveQuery.enable();
            btnSearch.enable();
        }
        else {
            btnSaveQuery.disable();
            btnSearch.disable();
        }
        btnLoadQuery.disable(); // remove later
        btnSaveQuery.disable(); // remove later
        btnDownload.disable();
    }
    DataWizard.EnableButtons = EnableButtons;
    function DisableButtons() {
        var btnLoadQuery = $("#btnLoadQuery").data("ejButton");
        var btnSaveQuery = $("#btnSaveQuery").data("ejButton");
        var btnSearch = $("#btnSearch").data("ejButton");
        var btnDownload = $("#btnDownload").data("ejButton");
        btnLoadQuery.disable();
        btnSaveQuery.disable();
        btnSearch.disable();
        btnDownload.disable();
    }
    DataWizard.DisableButtons = DisableButtons;
    var featuresSelected = false;
    function TabActive() {
        var tab = $("#DataWizardTabs").data("ejTab");
        if (tab.selectedItemIndex() == 1) {
            if (!featuresSelected) {
                UpdateFeaturesSelected();
                featuresSelected = true;
            }
        }
        else if (tab.selectedItemIndex() == 3) {
            FitMap();
        }
    }
    DataWizard.TabActive = TabActive;
    var locationsReady = false;
    function LocationsReady() {
        locationsReady = true;
        CheckReady();
    }
    DataWizard.LocationsReady = LocationsReady;
    function UpdateLocationsSelected() {
        var treeObj = $("#treeViewLocations").data('ejTreeView');
        var nodes = treeObj.getCheckedNodes();
        var selected = [];
        var i;
        for (i = 0; i < nodes.length; i++) {
            var nodeData = treeObj.getNode(nodes[i]);
            selected.push(nodeData.id);
        }
        $.post("/DataWizard/UpdateLocationsSelected", { locations: selected })
            .done(function (data) {
            $('#PartialLocationsSelected').html(data);
            UpdateMap();
            EnableButtons();
            HideResults();
        })
            .fail(function () { ErrorInFunc("Error in UpdateLocationsSelected"); });
    }
    DataWizard.UpdateLocationsSelected = UpdateLocationsSelected;
    var featuresReady = false;
    function FeaturesReady() {
        featuresReady = true;
        CheckReady();
    }
    DataWizard.FeaturesReady = FeaturesReady;
    function CheckReady() {
        if (locationsReady && featuresReady) {
            HideWaiting();
        }
    }
    function UpdateFeaturesSelected() {
        var treeObj = $("#treeViewFeatures").data('ejTreeView');
        var nodes = treeObj.getCheckedNodes();
        var selected = [];
        var i;
        for (i = 0; i < nodes.length; i++) {
            var nodeData = treeObj.getNode(nodes[i]);
            selected.push(nodeData.id);
        }
        $.post("/DataWizard/UpdateFeaturesSelected", { features: selected })
            .done(function (data) {
            $('#PartialFeaturesSelected').html(data);
            EnableButtons();
            HideResults();
        })
            .fail(function () { ErrorInFunc("Error in UpdateFeaturesSelected"); });
    }
    DataWizard.UpdateFeaturesSelected = UpdateFeaturesSelected;
    function UpdateFilters(startDate, endDate) {
        $.post("/DataWizard/UpdateFilters", { startDate: startDate, endDate: endDate })
            .done(function (data) {
            EnableButtons();
            HideResults();
        })
            .fail(function () { ErrorInFunc("Error in UpdateFilters"); });
    }
    DataWizard.UpdateFilters = UpdateFilters;
    var MapPoint = /** @class */ (function () {
        function MapPoint() {
        }
        return MapPoint;
    }());
    var map;
    var markers = [];
    var mapPoints;
    var mapBounds;
    var mapFitted = false;
    function InitMap() {
        var mapOpts = {
            center: new google.maps.LatLng(-34, 25.5),
            zoom: 5
        };
        map = new google.maps.Map(document.getElementById('mapLocations'), mapOpts);
        UpdateMap();
        FitMap();
    }
    DataWizard.InitMap = InitMap;
    function UpdateMap() {
        $.getJSON("/DataWizard/GetMapPoints")
            .done(function (json) {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
            mapPoints = json;
            mapBounds = new google.maps.LatLngBounds();
            for (var i = 0; i < mapPoints.length; i++) {
                var mapPoint = mapPoints[i];
                var marker = new google.maps.Marker({
                    position: { lat: mapPoint.Latitude, lng: mapPoint.Longitude },
                    map: map,
                    title: mapPoint.Title
                });
                markers.push(marker);
                mapBounds.extend(marker.getPosition());
                if (mapPoint.IsSelected) {
                    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png');
                }
                else {
                    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png');
                }
            }
        })
            .fail(function () { ErrorInFunc('Error in GetMapPoints'); });
    }
    DataWizard.UpdateMap = UpdateMap;
    function FitMap(override) {
        if (override === void 0) { override = false; }
        if (override || (!mapFitted && (mapBounds != null) && !mapBounds.isEmpty())) {
            map.setCenter(mapBounds.getCenter());
            map.fitBounds(mapBounds);
            mapFitted = true;
        }
    }
    DataWizard.FitMap = FitMap;
    function FixMap() {
        UpdateMap();
        FitMap(true);
    }
    DataWizard.FixMap = FixMap;
    function GetApproximation() {
        var approximation = "{}";
        $.get("/DataWizard/GetApproximation")
            .done(function (data) {
            approximation = data;
        })
            .fail(function () { ErrorInFunc("Error in GetApproximation"); });
        return approximation;
    }
    DataWizard.GetApproximation = GetApproximation;
    function SetApproximation() {
        $.get("/DataWizard/SetApproximation")
            .done(function (data) {
            $('#PartialApproximation').html(data);
        })
            .fail(function () { ErrorInFunc("Error in SetApproximation"); });
    }
    DataWizard.SetApproximation = SetApproximation;
    function Test() {
        SetApproximation();
    }
    DataWizard.Test = Test;
})(DataWizard || (DataWizard = {}));
//# sourceMappingURL=DataWizard.js.map