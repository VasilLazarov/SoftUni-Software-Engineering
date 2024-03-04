function calculator(num1, num2, operator){
    if(typeof num1 !== "number" || typeof num2 !== "number"){
        console.log("Please input numbers!");
    }
    else{
        switch(operator){
            case "+":
                console.log(num1 + num2);
                break;
            case "-":
                console.log(num1 - num2);
                break;
            case "*":
                console.log(num1 * num2);
                break;
            case "/":
                console.log(num1 / num2);
                break;
            case "%":
                console.log(num1 % num2);
                break;
            case "**":
                console.log(num1 ** num2);
                break;
            default:
                console.log("Please input valid operator!");
        }
    }
}

calculator(5, 3, "%");