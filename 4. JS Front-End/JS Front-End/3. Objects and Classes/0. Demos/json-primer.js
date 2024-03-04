const person ={
    firstName: "Vasil",
    lastName: "Lazarov",
    age: 23,
    programmingLanguages: ['js', 'C#'],
};
const jsonPerson = JSON.stringify(person);
console.log(jsonPerson);

const parsedJSON = JSON.parse(jsonPerson);
console.log(parsedJSON);