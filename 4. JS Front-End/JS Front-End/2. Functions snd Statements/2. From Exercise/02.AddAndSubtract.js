
function calculate(num1, num2, num3){
    function sum(a, b){
        return a + b;
    }
    function subtract(a, b){
        return a - b;
    }
    console.log(subtract(sum(num1, num2), num3));
}
calculate(23, 6, 10);
calculate(1, 17, 30);
calculate(42, 58, 100);