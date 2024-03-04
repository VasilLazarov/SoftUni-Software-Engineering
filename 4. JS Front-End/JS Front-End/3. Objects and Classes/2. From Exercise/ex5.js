function solve(input){
    const heroes = [];
    input.forEach((line) => {
        const [heroName, heroLevel, heroItems] = line.split(" / ");
        heroes.push({
            name: heroName,
            level: Number(heroLevel),
            items: heroItems,
        });
    });
    heroes.sort((a, b) => {
        return a.level - b.level;
    });
    heroes.forEach((hero) => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    });
}

solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);