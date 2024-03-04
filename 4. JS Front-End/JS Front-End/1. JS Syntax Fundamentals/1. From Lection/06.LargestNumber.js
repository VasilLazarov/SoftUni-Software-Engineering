/*function printLargestNumber(numbersArray){
    let maxNumber = numbersArray[0];
    for (let index = 1; index < numbersArray.length; index++) {
        if(numbersArray[index] > maxNumber){
            maxNumber = numbersArray[index];
        }
    }
    console.log(`The largest number is ${maxNumber}.`);
}
printLargestNumber([5, -3, 16]);
printLargestNumber([-3, -5, -22.5]);
*//*this is better, but we make other for judge */



/* for judge */
/*function printLargestNumber(num1, num2, num3){
    let maxNumber = num1;
    if(num2 > maxNumber){
        maxNumber = num2;
    }
    if(num3 > maxNumber){
        maxNumber = num3;
    }
    console.log(`The largest number is ${maxNumber}.`);
}
printLargestNumber(5, -3, 16);
printLargestNumber(-3, -5, -22.5);*/




//* other way for any count of numbers in function - also work in judge*/
/*function printLargestNumber(...input){
    let maxNumber = input[0];
    for (let index = 1; index < input.length; index++) {
        if(input[index] > maxNumber){
            maxNumber = input[index];
        }
    }
    console.log(`The largest number is ${maxNumber}.`);
}
printLargestNumber(5, -3, 16, -3, -5, -22.5, 69, -55);
printLargestNumber(-3, -5, -22.5);*/



/* other way - with sorting array - also work in judge*/
function printLargestNumber(...input){
    const sortedInput = input.sort(function(a, b){
        return b - a;
    });
    let maxNumber = input[0];
    console.log(`The largest number is ${maxNumber}.`);
}
printLargestNumber(5, -3, 16, -3, -5, -22.5, 69, -55);
printLargestNumber(-3, -5, -22.5);