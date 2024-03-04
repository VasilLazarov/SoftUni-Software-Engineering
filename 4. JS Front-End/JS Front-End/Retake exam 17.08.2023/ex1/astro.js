function solve(inputArray){
    const numberOfAstronauts = Number(inputArray.shift());
    const astronautsArray = inputArray.slice(0, numberOfAstronauts);
    const commandsArray = inputArray.slice(numberOfAstronauts);
    
    const astronautsObj = astronautsArray.reduce((acc, curr) => {
        const [name, oxygen, energy] = curr.split(' ');
        if(Number(oxygen) > 100){
            oxygen = 100;
        }
        if(Number(energy) > 200){
            energy = 200;
        }

        acc[name] = {
            name: name,
            oxygen: Number(oxygen),
            energy: Number(energy),
        };
        return acc;

    }, {});
    //console.log(JSON.stringify(astronautsObj, null, 2));

    const commandRunner = {
        'Explore': explore,
        'Refuel': refuel,
        'Breathe': breathe,
    };

    commandsArray.forEach((command) => {
        if(command === "End"){
            return;
        }
        const commandElements = command.split(" - ");
        const commandName = commandElements[0];
        const astroName = commandElements[1];
        const amount = Number(commandElements[2]);
        if(commandName && astroName && amount){
            commandRunner[commandName](astroName, amount);
        }
    });

    function explore(astroName, neededEnergy){
        if(!astronautsObj.hasOwnProperty(astroName)){
            return;
        }
        if(astronautsObj[astroName].energy < neededEnergy){
            console.log(`${astroName} does not have enough energy to explore!`);
            return;
        }

        astronautsObj[astroName].energy -= neededEnergy;
        console.log(`${astroName} has successfully explored a new area and now has ${astronautsObj[astroName].energy} energy!`);
    }
    function refuel(astroName, amount){
        if(!astronautsObj.hasOwnProperty(astroName)){
            return;
        }
        let recoveredEnergy = 0;
        if(astronautsObj[astroName].energy === 200){
            recoveredEnergy = 0;
        }else if((astronautsObj[astroName].energy + amount) > 200){
            recoveredEnergy = 200 - astronautsObj[astroName].energy;
            astronautsObj[astroName].energy = 200;
        }else{
            recoveredEnergy = amount;
            astronautsObj[astroName].energy += amount;
        }
        console.log(`${astroName} refueled their energy by ${recoveredEnergy}!`);
    }
    function breathe(astroName, amount){
        if(!astronautsObj.hasOwnProperty(astroName)){
            return;
        }
        let recoveredOxygen = 0;
        if(astronautsObj[astroName].oxygen === 100){
            recoveredOxygen = 0;
        }else if((astronautsObj[astroName].oxygen + amount) > 100){
            recoveredOxygen = 100 - astronautsObj[astroName].oxygen;
            astronautsObj[astroName].oxygen = 100;
        }else{
            recoveredOxygen = amount;
            astronautsObj[astroName].oxygen += amount;
        }
        console.log(`${astroName} took a breath and recovered ${recoveredOxygen} oxygen!`);
    }
    Object.values(astronautsObj).forEach((astronaut) => {
        console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygen}, Energy: ${astronaut.energy}`);
    });
}

/*solve([  
    '3',
    'John 50 120',
    'Kate 80 180',
    'Rob 70 150',
    'Explore - John - 50',
    'Refuel - Kate - 30',
    'Breathe - Rob - 20',
    'End'
]);*/
solve([    
    '4',
    'Alice 60 100',
    'Bob 40 80',
    'Charlie 70 150',
    'Dave 80 180',
    'Explore - Bob - 60',
    'Refuel - Alice - 30',
    'Breathe - Charlie - 50',
    'Refuel - Dave - 40',
    'Explore - Bob - 40',
    'Breathe - Charlie - 30',
    'Explore - Alice - 40',
    'End'
]);