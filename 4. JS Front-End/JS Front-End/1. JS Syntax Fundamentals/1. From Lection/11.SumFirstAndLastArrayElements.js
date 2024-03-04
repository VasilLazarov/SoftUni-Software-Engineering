/*function sumFirstAndLastArrayElements(inputArray){
    let firstElement = inputArray[0];
    let lastElement = inputArray[inputArray.length - 1];
    console.log(firstElement + lastElement);
}*/

/*with methods */
function sumFirstAndLastArrayElements(inputArray){
    let firstElement = inputArray.shift();/* let [first, ...rest] = inputArray;*/
    let lastElement = inputArray.pop();
    console.log(firstElement + lastElement);
}
sumFirstAndLastArrayElements([20, 30, 40]);
sumFirstAndLastArrayElements([10, 17, 22, 33]);
sumFirstAndLastArrayElements([11, 58, 69]);