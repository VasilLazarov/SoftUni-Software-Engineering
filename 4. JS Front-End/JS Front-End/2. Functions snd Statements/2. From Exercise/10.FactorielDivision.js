function calculateFactoriels(num1, num2){
    const factoriel = (n) =>{
        if(n <=1){
            return 1;
        }
        return n * factoriel(n - 1);
    }
    const num1Factoriel = factoriel(num1);
    const num2Factoriel = factoriel(num2);
    const result = (num1Factoriel/num2Factoriel).toFixed(2);
    console.log(result);
}

calculateFactoriels(5, 2);
calculateFactoriels(6, 2);
