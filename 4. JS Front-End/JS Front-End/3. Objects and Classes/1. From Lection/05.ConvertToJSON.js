function convertObjectToJSON(name, lastName, hairColor){
    const person= {
        name,
        lastName,
        hairColor,
    }
    const personJSON = JSON.stringify(person);
    console.log(personJSON);
}

convertObjectToJSON('George', 'Jones', 'Brown');
convertObjectToJSON('Peter', 'Smith', 'Blond');