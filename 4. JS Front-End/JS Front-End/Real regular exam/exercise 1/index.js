function solve(input){
    const ridersLines = Number(input.shift());
    const ridersInfo = input.slice(0, ridersLines);
    const commands = input.slice(ridersLines);

    const riders = ridersInfo.reduce((acc, curr) => {
        const [rider, fuelCapacity, position] = curr.split("|");
        if(fuelCapacity > 100){
            fuelCapacity = 100;
        }
        acc.push({
            riderName: rider,
            fuelCapacity: Number(fuelCapacity),
            position: Number(position),
        });
        return acc;
    }, []);
    let sortedRiders = riders.sort((a, b) => a.position - b.position);
    //console.log(JSON.stringify(sortedRiders, null, 2));

    const commandRunner ={
        'StopForFuel': stopForFuel,
        'Overtaking': overtaking,
        'EngineFail': engineFail,
    };

    commands.forEach((command) => {
        if(command === "Finish"){
            return;
        }
        const arrayCurrenCmd = command.split(" - ");
        const commandName = arrayCurrenCmd.shift();
        commandRunner[commandName](...arrayCurrenCmd);
    });

    function stopForFuel(currRiderName, minimumFuel, changePosition){
        const currRider = sortedRiders.find((riderC) => {
            return riderC.riderName === currRiderName;
        });
        //console.log(JSON.stringify(currRider, null, 2));
        if(currRider.fuelCapacity < Number(minimumFuel)){
            currRider.position = Number(changePosition);
            console.log(`${currRider.riderName} stopped to refuel but lost his position, now he is ${Number(changePosition)}.`);
            sortedRiders = riders.sort((a, b) => a.position - b.position);
        }
        else{
            console.log(`${currRider.riderName} does not need to stop for fuel!`);
        }
    }
    function overtaking(rider1, rider2){
        const currRider1 = sortedRiders.find((riderC) => {
            return riderC.riderName === rider1;
        });
        const currRider2 = sortedRiders.find((riderC) => {
            return riderC.riderName === rider2;
        });
        
        if(currRider1.position < currRider2.position){
            let temp = currRider1.position;
            currRider1.position = currRider2.position;
            currRider2.position = temp;
            sortedRiders = riders.sort((a, b) => a.position - b.position);
            console.log(`${rider1} overtook ${rider2}!`);
        }
    }
    function engineFail(riderN, laps){
        const currRider1 = sortedRiders.find((riderC) => {
            return riderC.riderName === riderN;
        });
        const index = sortedRiders.indexOf(currRider1);
        sortedRiders.splice(index, 1);
        console.log(`${riderN} is out of the race because of a technical issue, ${Number(laps)} laps before the finish.`);
    }
    sortedRiders.forEach((riderr) => {
        console.log(riderr.riderName);
        console.log(`  Final position: ${riderr.position}`);
    });
}

/*solve(["3",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|2",
    "Jorge Lorenzo|80|3",
    "StopForFuel - Valentino Rossi - 50 - 1",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"
]);*/
solve(["4",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|3",
    "Jorge Lorenzo|80|4",
    "Johann Zarco|80|2",
    "StopForFuel - Johann Zarco - 90 - 5",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"
]);