function createGreeting(greetingText){
    function greet(name){
        return `${greetingText}, ${name}`
    }
    return greet;
}

const morningGreeting = createGreeting("Good morning");
console.log(morningGreeting("Vasil"));
const eveningGreeting = createGreeting("Good evening");
console.log(eveningGreeting("Vasil"));