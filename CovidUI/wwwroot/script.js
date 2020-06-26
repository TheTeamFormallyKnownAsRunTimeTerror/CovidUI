var map, infobox;

function loadBingMap(active, recovered) {
    map = new Microsoft.Maps.Map(document.getElementById('map'), {});
    infobox = new Microsoft.Maps.Infobox(map.getCenter(), { visible: false });
    infobox.setMap(map);

    console.log(active, recovered);
    var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), null);

    pushpin.metadata = {
        activeCases: active,
        recoveredCases: recovered
    };

    map.entities.push(pushpin);

    Microsoft.Maps.Events.addHandler(pushpin, 'click', pushpinClicked);
    return "";
}

function pushpinClicked(e) {

    if (e.target.metadata) {
        var description = "Active: " + e.target.metadata.activeCases + " Recovered: " + e.target.metadata.recoveredCases;
        infobox.setOptions({
            location: e.target.getLocation(),
            title: "Covid stats",
            description: description,
            visible: true
        });
    }
    
}