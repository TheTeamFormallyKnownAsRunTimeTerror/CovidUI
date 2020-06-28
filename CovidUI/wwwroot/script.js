var map, infobox;
var pushpins = [];


function loadBingMap(countries) {

    map = new Microsoft.Maps.Map(document.getElementById('map'),
        {
            zoom: 6
        });
    infobox = new Microsoft.Maps.Infobox(map.getCenter(), { visible: false });
    infobox.setMap(map);
    
    countries.forEach(country => {
        var pushpin = new Microsoft.Maps.Pushpin({ latitude: country["latitude"], longitude: country["longitude"]}, null);
        pushpin.metadata = {
            countryCode: country["countryCode"],
            countryName: country["countryName"],
            active: country["activeCases"],
            recovered: country["recovered"],
            deaths: country["deaths"],
            latitude: country["latitude"],
            longitude: country["longitude"]
        };

        Microsoft.Maps.Events.addHandler(pushpin, 'click', pushpinClicked);
        pushpins.push(pushpin); //check if this is needed
        map.entities.push(pushpin);
    });

    return "";
}

function pushpinClicked(e) {
    showInfoBox(e.target);
}

function showInfoBox(target) {
    if (target.metadata) {
        var description = createDescription(target.metadata);
        infobox.setOptions({
            location: target.getLocation(),
            title: target.metadata.countryName,
            description: description,
            visible: true
        });
    }
}

function changeMapView(latitude, longitude) {
    map.setView({
        center : new Microsoft.Maps.Location(latitude, longitude),
        zoom: 8
    });
}

function createDescription(data) {
    return "<p>Active: " + data.active + "<br/>Recovered: " + data.recovered + "<br/>Deaths: " + data.deaths + "</p>";
}

function searchCountryOnMap(country)
{
    var countryPushpin = undefined;

    for (let i = 0; i < pushpins.length; ++i) {
        var pushpin = pushpins[i];
        if (pushpin.metadata && pushpin.metadata.countryName === country) {
            countryPushpin = pushpin;
            break;
        }
    }

    if (countryPushpin) {
        changeMapView(countryPushpin.metadata["latitude"], countryPushpin.metadata["longitude"]);
        showInfoBox(countryPushpin);
    }
}