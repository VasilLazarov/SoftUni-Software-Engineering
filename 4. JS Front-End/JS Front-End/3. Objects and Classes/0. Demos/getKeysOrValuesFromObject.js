function createPerson(firstName, lastName, age, gender){
    return {
        firstName,
        lastName,
        age,
        gender,
    }
};

const person = createPerson("Vasil", "Lazarov", 23, "male");

console.log(Object.keys(person));
console.log(Object.values(person));
console.log(Object.entries(person));
console.log(JSON.stringify(Object.entries(person)));