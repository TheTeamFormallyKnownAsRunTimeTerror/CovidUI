﻿function GenerateMap(countries) {
    // Themes begin
    am4core.useTheme(am4themes_animated);
    // Themes end

    var continents = {
        "AF": 0,
        "AN": 1,
        "AS": 2,
        "EU": 3,
        "NA": 4,
        "OC": 5,
        "SA": 6
    };

    // Create map instance
    var chart = am4core.create("chartdiv", am4maps.MapChart);
    chart.projection = new am4maps.projections.Miller();

    // Create map polygon series for world map
    var worldSeries = chart.series.push(new am4maps.MapPolygonSeries());
    worldSeries.useGeodata = true;
    worldSeries.geodata = am4geodata_worldLow;
    worldSeries.exclude = ["AQ"];

    var worldPolygon = worldSeries.mapPolygons.template;
    worldPolygon.tooltipText = "Country: {countryName}" +
        "\n Active Cases: {activeCases}" +
        "\n Total Deaths: {totalDeaths}" +
        "\n Recovered: {recovered}";
    worldPolygon.nonScalingStroke = true;
    worldPolygon.strokeOpacity = 0.5;
    worldPolygon.fill = am4core.color("#eee");
    worldPolygon.propertyFields.fill = "color";

    var hs = worldPolygon.states.create("hover");
    hs.properties.fill = chart.colors.getIndex(9);


    // Create country specific series (but hide it for now)
    var countrySeries = chart.series.push(new am4maps.MapPolygonSeries());
    countrySeries.useGeodata = true;
    countrySeries.hide();
    countrySeries.geodataSource.events.on("done", function (ev) {
        worldSeries.hide();
        countrySeries.show();
    });

    var countryPolygon = countrySeries.mapPolygons.template;
    countryPolygon.tooltipText = "Country: {countryName}" +
        "\n Active Cases: {activeCases}" +
        "\n Total Deaths: {totalDeaths}" +
        "\n Recovered: {recovered}";
    countryPolygon.nonScalingStroke = true;
    countryPolygon.strokeOpacity = 0.5;
    countryPolygon.fill = am4core.color("#eee");

    var hs2 = countryPolygon.states.create("hover");
    hs2.properties.fill = chart.colors.getIndex(9);

    // Set up click events
    worldPolygon.events.on("hit", function (ev) {
        ev.target.series.chart.zoomToMapObject(ev.target);
        var map = ev.target.dataItem.dataContext.map;
        if (map) {
            ev.target.isHover = false;
            countrySeries.geodataSource.url = "https://www.amcharts.com/lib/4/geodata/json/" + map + ".json";
            countrySeries.geodataSource.load();
        }
    });


            // Set up data for countries
            var data = [];
            var countryInfo = countries;
    for (var id in am4geodata_data_countries2) {
        if (am4geodata_data_countries2.hasOwnProperty(id)) {
            var country = am4geodata_data_countries2[id];
            if (country.maps.length) {

                var nActiveCases = 0;
                nTotalDeaths = 0;
                nTotalRecovered = 0;
                
                var currentCountryRecord = countryInfo.filter(c => c.countryName.toLowerCase() === country.country.toLowerCase());

                if (typeof currentCountryRecord !== "undefined" && currentCountryRecord !== null && currentCountryRecord[0] !== undefined) {
                    nActiveCases = currentCountryRecord[0].activeCases;
                    nTotalDeaths = currentCountryRecord[0].deaths;
                    nTotalRecovered = currentCountryRecord[0].recovered;
                }


                data.push({
                    id: id,
                    color: chart.colors.getIndex(continents[country.continent_code]),
                    map: country.maps[0],
                    countryName: country.country,
                    activeCases: nActiveCases,
                    totalDeaths: nTotalDeaths,
                    recovered: nTotalRecovered

                });
            }
        }
    }
            

            worldSeries.data = data;

            // Zoom control
            chart.zoomControl = new am4maps.ZoomControl();

            var homeButton = new am4core.Button();
            homeButton.events.on("hit", function () {
                worldSeries.show();
                countrySeries.hide();
                chart.goHome();
            });

            homeButton.icon = new am4core.Sprite();
            homeButton.padding(7, 5, 7, 5);
            homeButton.width = 30;
            homeButton.icon.path = "M16,8 L14,8 L14,16 L10,16 L10,10 L6,10 L6,16 L2,16 L2,8 L0,8 L8,0 L16,8 Z M16,8";
            homeButton.marginBottom = 10;
            homeButton.parent = chart.zoomControl;
            homeButton.insertBefore(chart.zoomControl.plusButton);
        
}
