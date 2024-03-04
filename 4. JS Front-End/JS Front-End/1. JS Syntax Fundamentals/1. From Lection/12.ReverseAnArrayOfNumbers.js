/*first way - with for loops */
/*function GetAnyCountOfElementsFromArrayAndReverseThem(n, inputArray){
    let arrayWithCountElements = [];
    for (let index = 0; index < n; index++) {
        arrayWithCountElements[index] = inputArray[index];
    }
    let output = "";
    for (let i = arrayWithCountElements.length - 1; i >= 0; i--) {
        output+= `${arrayWithCountElements[i]} `;
    }
    console.log(output);
}*/

/*second way - with methods */
function GetAnyCountOfElementsFromArrayAndReverseThem(n, inputArray){
    let arrayWithCountElements = inputArray.slice(0, n);
    let output = arrayWithCountElements.reverse().join(' ');
    console.log(output);
}



GetAnyCountOfElementsFromArrayAndReverseThem(3, [10, 20, 30, 40, 50]);
GetAnyCountOfElementsFromArrayAndReverseThem(4, [-1, 20, 99, 5]);
GetAnyCountOfElementsFromArrayAndReverseThem(2, [66, 43, 75, 89, 47]);