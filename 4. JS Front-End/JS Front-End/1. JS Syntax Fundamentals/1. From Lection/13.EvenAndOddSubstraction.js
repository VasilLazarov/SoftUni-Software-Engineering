function calculateSumOfEvenAndOddElements(arr){
    let sumOfEvenElements = 0;
    let sumOfOddElements = 0;
    arr.forEach(number =>{
        if(number % 2 === 0){
            sumOfEvenElements += number;
        }
        else{
            sumOfOddElements += number;
        }
    });
    console.log(sumOfEvenElements - sumOfOddElements);
}
calculateSumOfEvenAndOddElements([1,2,3,4,5,6]);
calculateSumOfEvenAndOddElements([3,5,7,9]);
calculateSumOfEvenAndOddElements([2,4,6,8,10]);