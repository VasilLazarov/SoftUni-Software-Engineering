function createCity(name, population, treasury){
    return{
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes(){
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage){
            this.population += Math.floor(this.population * (percentage/100));
        },
        applyRecession(percentage){
            this.treasury -= Math.floor(this.treasury * (percentage/100));
        },
    };
}
const city = createCity('Tortuga', 7000, 15000);
console.log(city);
city.collectTaxes();
city.applyGrowth(14);
city.applyRecession(14);
console.log(city);
