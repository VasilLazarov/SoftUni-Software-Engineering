function calculateSumOfEvenAndOddNumbers(input){
    let stringInput = input.toString();
    let oddSum = 0;
    let evenSum = 0;
    for (let element of stringInput) {
        element = parseInt(element);
        if(element % 2 ===0){
            evenSum += element;
        }
        else{
            oddSum += element;
        }
    }
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
calculateSumOfEvenAndOddNumbers(1000435);
calculateSumOfEvenAndOddNumbers(3495892137259234);