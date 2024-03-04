/*function calculator(num1, num2, operator){
    switch(operator){
        case 'multiply':
            return num1 * num2;
        case 'divide':
            return num1 / num2;
        case 'add':
            return num1 + num2;
        case 'subtract':
            return num1 - num2;
    }
}
let result1 = calculator(5, 5, 'multiply');
let result2 = calculator(40, 8, 'divide');
let result3 = calculator(12, 19, 'add');
let result4 = calculator(50, 13, 'subtract');*/


/*const calculate = (num1, num2, operator) =>{
    switch(operator){
        case 'multiply':
            return num1 * num2;
        case 'divide':
            return num1 / num2;
        case 'add':
            return num1 + num2;
        case 'subtract':
            return num1 - num2;
    }
}
let result1 = calculate(5, 5, 'multiply');
let result2 = calculate(40, 8, 'divide');
let result3 = calculate(12, 19, 'add');
let result4 = calculate(50, 13, 'subtract');*/


/*const multiply = (x, y) => x * y;
const divide = (x, y) => x / y;
const add = (x, y) => x + y;
const subtract = (x, y) => x - y;*/

const calculator = {
multiply: (x, y) => x * y,
divide: (x, y) => x / y,
add: (x, y) => x + y,
subtract: (x, y) => x - y,
};
/*const calculate = (num1, num2, operator) =>{
    const func = calculator[operator];
    if(!func){
        return -0;
    }
    return func(num1, num2);
}*/
const calculate = (num1, num2, operator) => calculator[operator] ? calculator[operator](num1, num2) : -0;


let result1 = calculate(5, 5, 'multiply');
let result2 = calculate(40, 8, 'divide');
let result3 = calculate(12, 19, 'add');
let result4 = calculate(50, 13, 'subtract');

console.log(result1);
console.log(result2);
console.log(result3);
console.log(result4);


/*for judge - 100/100 work*/
function calculate7(num1, num2, operator){
    const calculator = {
      multiply: (x, y) => x * y,
      divide: (x, y) => x / y,
      add: (x, y) => x + y,
      subtract: (x, y) => x - y,
  };
  return console.log(calculator[operator](num1, num2));
}
/*for try in judge - dont work */
const calculate11 = (num1, num2, operator)=>{
    const calculator = {
      multiply: (x, y) => x * y,
      divide: (x, y) => x / y,
      add: (x, y) => x + y,
      subtract: (x, y) => x - y,
  }
  return console.log(calculator[operator](num1, num2));
}
calculate11(9, 5, "multiply");
