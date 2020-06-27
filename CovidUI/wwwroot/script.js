var map, infobox;
var pushpins = [];

function loadBingMap(countryInfo) {

    map = new Microsoft.Maps.Map(document.getElementById('map'),
        {
            zoom: 6
        });
    infobox = new Microsoft.Maps.Infobox(map.getCenter(), { visible: false });
    infobox.setMap(map);

    var countries = JSON.parse(countryInfo);

    countries.forEach(country => {
        var pushpin = new Microsoft.Maps.Pushpin({ latitude: country["latitude"], longitude: country["longitude"]}, null);
        pushpin.metadata = {
            countryCode: country["countryId"],
            countryName: country["countryName"],
            active: country["activeCases"],
            recovered: country["recovered"],
            deaths: country["deaths"]
        };

        Microsoft.Maps.Events.addHandler(pushpin, 'click', pushpinClicked);
        pushpins.push(pushpin); //check if this is needed
        map.entities.push(pushpin);
    });

    return "";
}

function pushpinClicked(e) {

    if (e.target.metadata) {
        var description = createDescription(e.target.metadata);
        infobox.setOptions({
            location: e.target.getLocation(),
            title: e.target.metadata.countryName,
            description: description,
            visible: true
        });
    }
}

function createDescription(data) {
    return "<p>Active: " + data.active + "<br/>Recovered: " + data.recovered + "<br/>Deaths: " + data.deaths + "</p>";
}