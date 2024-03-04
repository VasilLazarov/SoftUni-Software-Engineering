const person ={
    name: "Vasil",
    age: 22,
    gender: "male",
    printNames: function(){
        console.log(this.name + " " + this.lastname);
    }
};
person.lastname = "Lazarov";

person.printNames();

/*const person2 = {};
person2.name = "Anelia";
person2.age = 19;
person2.gender = "female";
person2.lastname = "Ahmedova";*/


function createPerson(firstName, lastName, age, gender){
    /*const person3 ={
        firstName,
        lastName,
        age,
        gender,
        printNames: function(){
            console.log(this.firstName + " " + this.lastName);
        }
    };
    return person3;*/
    return {
        firstName,
        lastName,
        age,
        gender,
        /*printNames: function(){
            console.log(this.firstName + " " + this.lastName);*//*other way */
        printNames(){
            console.log(this.firstName + " " + this.lastName);
        },
        printNames2: () =>{
            console.log(this.firstName + " " + this.lastName);/*dont work with arrow function? */
        },
        sayHello: () => {
            console.log("Hello!");
        },
    }
};
const person3 = createPerson("Anelia", "Ahmedova", 19, "female");
person3.printNames();
person3.sayHello();
person3.printNames2();