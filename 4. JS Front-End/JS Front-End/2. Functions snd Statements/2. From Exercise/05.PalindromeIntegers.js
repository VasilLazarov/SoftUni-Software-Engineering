/*function checkIfNumbersIsPalindrome(numbers){
    let trueOrFalse = true;
    for (const number of numbers) {
        let numberAsString = number.toString();
        for (let i = 0; i < numberAsString.length/2; i++) {
            if(numberAsString[i] !== numberAsString[numberAsString.length - i - 1]){
                trueOrFalse = false;
                break;
            }
        }
        if(trueOrFalse){
            console.log("true");
        }
        else{
            console.log("false");
        }
        trueOrFalse = true;
    }
}*/


/*easier way */
function checkIfNumbersIsPalindrome(numbers){
    let trueOrFalse = true;
    for (const number of numbers) {
        let numberAsString = number.toString();
        console.log(numberAsString === numberAsString.split("").reverse().join(""));
    }
}
//checkIfNumbersIsPalindrome([12521, 131, 74547, 1331]);
checkIfNumbersIsPalindrome([123,323,421,121]);
checkIfNumbersIsPalindrome([32,2,232,1010]);