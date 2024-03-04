function sum(num1, num2){
    if(typeof num1 === "number" && typeof num2 === "number"){
        console.log(num1 + num2);
    }
    else{
        console.log("Wrong input types!");
    }
}

sum(1, 2);