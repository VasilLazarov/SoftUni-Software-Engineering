let numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

/*.pop - remove last element from array and returns that element*/
/*console.log(numbers.length);
let removedElement = numbers.pop();
console.log(removedElement);
console.log(numbers.length);*/

/*.push - add element to the end of an array and returns new length of array*/
/*console.log(numbers.length);
let newLength = numbers.push(11);
console.log(numbers.length);*/

/*.shift - remove first element from array and returns that element*/
/*console.log(numbers.length);
let removedElement = numbers.shift();
console.log(removedElement);
console.log(numbers.length);*/

/*.unshift - add element to the start of an array and returns new length of array */
/*console.log(numbers.length);
let newLength = numbers.unshift(11);
console.log(numbers.length);*/

/*.splice - removing or replacing element at the given position*/
/*numbers.splice(0, 0, 0); /*insert 0 on index 0 - first number is index, last in number for /
console.log(numbers);
numbers.splice(0, 1, 17);/*replace 1 element(second number) on index 0(first number) with 17(third number) /
console.log(numbers);
let removedNumber = numbers.splice(0, 1);/*remove 1 element(second number) on index 0 (first number) /
console.log(removedNumber);
console.log(numbers);*/

/*.reverse - make array reversed */
/*console.log(numbers);
numbers.reverse();
console.log(numbers);*/

/*.join - make new string from elements in array by concatenating elements separated by coma by default or specified separator*/
/*console.log(numbers);
console.log(numbers.join());
console.log(numbers.join("_"));
console.log(numbers.join("-"));
console.log(numbers.join(":)"));
console.log([12, 13].join("."));*/

/*.slice - returns a copy of a portion of an array into new array .slice(startIndex(include), endIndex(exclude))*/
/*console.log(numbers);
let numberFrom3To7 = numbers.slice(2, 7);
console.log(numberFrom3To7);
let copyFullArray = numbers.slice();
console.log(copyFullArray);*/

/*.includes - check if array contains element */
/*console.log(numbers);
console.log(numbers.includes(8));
console.log(numbers.includes(9, 7)); /*search for 9 but start from index 7 */

/*.indexOf - serch for element and if find return its index, id dont find return -1 */
/*console.log(numbers);
console.log(numbers.indexOf(7));
console.log(numbers.indexOf(7, 5)); /*starting from index 5 /
console.log(numbers.indexOf(15));*/

/*.foreach - executes a provided function once for each array element*/
/*console.log(numbers);
let copyNumbers = [];
numbers.forEach(num => {copyNumbers.push(num)});
console.log(copyNumbers);*/
/*we cant do same thing with for loop, but with .foreach is easier
for(let i = 0; i < numbers.length; i++){
    copyNumbers.push(numbers[i])
}*/

/*.map - creates a new array with the results of calling a provided function on every element is the calling array*/
/*let numbers2 = [1, 4, 9, 16, 25];
let roots = numbers2.map(function(num, i, arr){
    return Math.sqrt(num)
});
console.log(roots);*/

/*.find - return first found in the array if found, if dont found return undefined*/
/*console.log(numbers);
let foundNumber = numbers.find(function(element){
    return element > 7
});
console.log(foundNumber);*/

/*.filter -  create new array with filltered elements only*/
/*let array2 = ["Vasil", "Dimitar", "Georgi", "Pedril", "Dicho"];
for (let index = 0; index < array2.length; index++) {
    let index2 = array2[index].indexOf("il");
    console.log(index2);
    
}*//*primer za da vidq kak raboti indexOF - bez .filter */
/*use .filter*/
let fruits = ['apple', 'banana', 'grapes', 'mango', 'orange'];

function filterFruits(arr, query){
    return arr.filter(function(el){
        return el.toLowerCase().indexOf(query.toLowerCase()) !== -1;
    });
}
let filteredArray = filterFruits(fruits, 'ap');
console.log(filteredArray);
console.log(fruits);