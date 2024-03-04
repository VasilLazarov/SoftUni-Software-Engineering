async function getInfo() {
    const busStopID = document.querySelector("#stopId").value;

    const busStopName = document.querySelector("#stopName");

    const service = {
        busInfoURL: (id) => `http://localhost:3030/jsonstore/bus/businfo/${id}`,
    };

    let busStopInfo;
    try {
        const getInfo = await fetch(service.busInfoURL(busStopID));
        busStopInfo = await getInfo.json();
    } catch (error) {
        busStopName.textContent = "Error";
    }

    busStopName.textContent = busStopInfo.name;

        const listOfBuses = document.querySelector("#buses");
        listOfBuses.innerHTML = "";
        Object.entries(busStopInfo.buses).forEach(([busNumber, minutes]) =>{
            const newBus = document.createElement("li");
            newBus.textContent = `Bus ${busNumber} arrives in ${minutes} minutes`;

            listOfBuses.appendChild(newBus);
        });

}