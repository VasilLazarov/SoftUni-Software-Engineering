function convertJSONToObject(input){
    const person = JSON.parse(input);
    Object.keys(person).forEach((key) => {
        console.log(`${key}: ${person[key]}`);
    });
}
convertJSONToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertJSONToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');