/*function printMatrixFromNumber(number){
    let matrix = [];
    for (let row = 0; row < number; row++) {
        matrix[row] = [];
        for (let col = 0; col < number; col++) {
            matrix[row].push(number);
        }
    }
    for (let i = 0; i < matrix.length; i++) {
        console.log(matrix[i].join(' '));
    }
}*//*po intersno s matrici */
function printMatrixFromNumber(number){
    for (let row = 0; row < number; row++) {
        let rowArr = [];
        for (let col = 0; col < number; col++) {
            rowArr.push(number);
        }
        console.log(rowArr.join(' '));
    }
}

/*po lesno za tazi zadacha */
printMatrixFromNumber(3);