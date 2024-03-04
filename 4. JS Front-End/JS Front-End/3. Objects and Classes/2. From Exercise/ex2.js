function solve(input){
    const towns = input.map((town) =>{
        const [name, latitude, longitude] = town.split(" | ");
        return{
            town: name,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2),
        };
    });
    towns.forEach((currTown) => {
        console.log(currTown);
    });
}
solve([
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'
]);