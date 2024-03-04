function findSmallestNumber(...numbers){
    let smallestNumbers = numbers[0];
    for (const number of numbers) {
        if(number < smallestNumbers){
            smallestNumbers = number;
        }
    }
    console.log(smallestNumbers);
    //console.log(Math.min(...numbers));
}

findSmallestNumber(2, 5, 3);
findSmallestNumber(600, 342, 123);