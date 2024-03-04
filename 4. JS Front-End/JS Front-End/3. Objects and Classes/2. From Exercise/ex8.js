function solve(inputArray){
    const parking = new Set();
    inputArray.forEach((line) => {
        const [command, number] = line.split(', ');
        if(command === "IN"){
            parking.add(number);
            
        }else if(command === "OUT"){
            parking.delete(number);
        }
    });

    const arrayParkingForPrint = Array.from(parking);
    arrayParkingForPrint.sort((a, b) => a.localeCompare(b));

    arrayParkingForPrint.forEach((value) => {
        console.log(value);
    });
}
solve([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);