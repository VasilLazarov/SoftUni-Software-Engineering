function printCityInfo(city){
    /*for (const key in city) {
        console.log(`${key} -> ${city[key]}`);
    }*/

    /*let entries = Object.entries(city);
    for (const [key, value] of entries) {
        console.log(`${key} -> ${value}`);
    }*/

    /*Object.entries(city).forEach(function(pair){
        const key = pair[0];
        const value = pair[1];
        console.log(`${key} -> ${value}`);
    });*/

    Object.entries(city).forEach(function([key, value]){
        console.log(`${key} -> ${value}`);
    });

    /*Object.keys(city).forEach(function(key){
        console.log(`${key} -> ${city[key]}`);
    });*/

    /*Object.keys(city).forEach((key) => {
        console.log(`${key} -> ${city[key]}`);
    });*/
}

printCityInfo({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000",
});