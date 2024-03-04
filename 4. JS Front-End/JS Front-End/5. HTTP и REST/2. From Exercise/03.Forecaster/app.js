function attachEvents() {
    document.querySelector("#submit").addEventListener('click', getWeatherDataForLocation);   
};

const fetchURLs ={
    allLocations: `http://localhost:3030/jsonstore/forecaster/locations`,
    locationCurrentConditions: (locationCode) => `http://localhost:3030/jsonstore/forecaster/today/${locationCode}`,
    locationThreeDayForecast: (locationCode) => `http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`,

};
const weatherSymbols = {
    'Sunny': '☀',
    'Partly sunny': '⛅',
    'Overcast': '☁',
    'Rain': '☂',
    'Degrees': '°',
};

async function getWeatherDataForLocation(){
    const locationName = document.querySelector("#location").value;

    const currentContainer = document.querySelector("#current");
    const currentContainerChild = document.querySelector("#current .label");
    const textContent1 = "Current conditions";

    const threeDayForecastContainer = document.querySelector("#upcoming");
    const threeDayForecastContainerChild = document.querySelector("#upcoming .label");
    const textContent2 = "Three-day forecast";
    //TODO: Error handling
    try {
        const locationResponse = await fetch(fetchURLs.allLocations);
        const locations = await locationResponse.json();
        console.log(locations);

        //const location = locations.find((l) => l.name.toLowerCase() === locationName.toLowerCase()); //maybe make .toLowerCase if needed
        const location = locations.find((l) => l.name === locationName);
        if(location){
            const currentConditions = await getCurrentConditions(location.code);
            const threeDayForecast = await getThreeDayForecast(location.code);
            
            console.log(currentConditions);
            console.log(threeDayForecast);

            //Make parent div visible
            document.querySelector("#forecast").style.display = "block";

            
            currentContainer.innerHTML = " ";
            currentContainerChild.textContent = textContent1;
            console.log(textContent1);
            currentContainer.appendChild(currentContainerChild);

            
            threeDayForecastContainer.innerHTML = " ";
            threeDayForecastContainerChild.textContent = textContent2;
            threeDayForecastContainer.appendChild(threeDayForecastContainerChild);

            const currentConditionInfoContainer = createCurrentConditionElementsForDisplaing(currentConditions);
            const threeDayForecastInfoContainer = createThreeDayForecastElementsForDisplaing(threeDayForecast);

            currentContainer.appendChild(currentConditionInfoContainer);
            threeDayForecastContainer.appendChild(threeDayForecastInfoContainer);
        
        }
        else{
            document.querySelector("#forecast").style.display = "block";
            currentContainer.innerHTML = " ";
            currentContainerChild.textContent = "Error";
            currentContainer.appendChild(currentContainerChild);
            threeDayForecastContainer.innerHTML = " ";
            threeDayForecastContainerChild.textContent = "Error";
            threeDayForecastContainer.appendChild(threeDayForecastContainerChild);
        }
        //TODO: validation
        
        
    } catch (error) {
        console.log(error.message);
    }
    

};
async function getCurrentConditions(locationCode){
    const currentConditionsResponse = await fetch(fetchURLs.locationCurrentConditions(locationCode));
    const currentConditionsF = await currentConditionsResponse.json();
    return currentConditionsF;
};
async function getThreeDayForecast(locationCode){
    const threeDayForecastResponse = await fetch(fetchURLs.locationThreeDayForecast(locationCode));
    const threeDayForecastF = await threeDayForecastResponse.json();
    return threeDayForecastF;
};
function createCurrentConditionElementsForDisplaing(currentConditions){
    const currCondInfoContainer = document.createElement("div");
    currCondInfoContainer.classList.add("forecasts");

    const symbolSpan = document.createElement("span");
    symbolSpan.classList.add("condition");
    symbolSpan.classList.add("symbol");
    symbolSpan.textContent = weatherSymbols[currentConditions.forecast.condition];

    const conditionsSpan = document.createElement("span");
    conditionsSpan.classList.add("condition");

    const conditionName = document.createElement("span");
    conditionName.classList.add("forecast-data");
    conditionName.textContent = currentConditions.name;
    const conditionDegrees = document.createElement("span");
    conditionDegrees.classList.add("forecast-data");
    conditionDegrees.textContent = `${currentConditions.forecast.low}${weatherSymbols.Degrees}/${currentConditions.forecast.high}${weatherSymbols.Degrees}`;
    const conditionType = document.createElement("span");
    conditionType.classList.add("forecast-data");
    conditionType.textContent = currentConditions.forecast.condition;

    conditionsSpan.appendChild(conditionName);
    conditionsSpan.appendChild(conditionDegrees);
    conditionsSpan.appendChild(conditionType);

    currCondInfoContainer.appendChild(symbolSpan);
    currCondInfoContainer.appendChild(conditionsSpan);
    
    return currCondInfoContainer;
};
function createThreeDayForecastElementsForDisplaing(threeDayForecast){
    const threeDayInfoContainer = document.createElement("div");
    threeDayInfoContainer.classList.add("forecasts-info");

    
    threeDayForecast.forecast.forEach((day) => {
        const conditionsSpan = document.createElement("span");
        conditionsSpan.classList.add("upcoming");

        const symbolSpan = document.createElement("span");
        symbolSpan.classList.add("symbol");
        symbolSpan.textContent = weatherSymbols[day.condition];

        const conditionDegrees = document.createElement("span");
        conditionDegrees.classList.add("forecast-data");
        conditionDegrees.textContent = `${day.low}${weatherSymbols.Degrees}/${day.high}${weatherSymbols.Degrees}`;
        
        const conditionType = document.createElement("span");
        conditionType.classList.add("forecast-data");
        conditionType.textContent = day.condition;

        conditionsSpan.appendChild(symbolSpan);
        conditionsSpan.appendChild(conditionDegrees);
        conditionsSpan.appendChild(conditionType);

        threeDayInfoContainer.appendChild(conditionsSpan);
    });
    return threeDayInfoContainer;
};
attachEvents();