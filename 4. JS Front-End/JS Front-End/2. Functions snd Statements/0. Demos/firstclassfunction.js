function greet(getMessage, name){
    return `${getMessage()} ${name}`;
}

function sayHello(){
    const currentHout = new Date().getHours();
    //const currentHout = 9;
    if(currentHout >= 19){
        return "Good evening";
    }
    else if(currentHout >= 12){
        return "Good afternoon";
    }
    else{
        return "Good morning";
    }
}
const greeting = greet(sayHello, "Vasil");
//const greeting2 = greet(() => "Goodbye ", "Vasil");
console.log(greeting);
//console.log(greeting2);