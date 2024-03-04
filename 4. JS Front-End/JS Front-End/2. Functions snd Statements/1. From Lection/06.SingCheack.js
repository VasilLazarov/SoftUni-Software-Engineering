function negativeOrPositiveRresultAfterMultiply(...numbers){
    let countOfNegativeNumbers = 0;
    for (const number of numbers) {
        if(number < 0){
            countOfNegativeNumbers++;
        }
    }
    if(countOfNegativeNumbers % 2 === 0){
        console.log("Positive");
    }
    else{
        console.log("Negative");
    }
}
negativeOrPositiveRresultAfterMultiply(5, 12, -15);
negativeOrPositiveRresultAfterMultiply(-6, -12, 14);
negativeOrPositiveRresultAfterMultiply(-1, -2, -3);