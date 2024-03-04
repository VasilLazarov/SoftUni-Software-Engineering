const person = {
    firstName: 'Peter',
    lastName: 'Johnson',
    fullName() {
    return this.firstName + ' ' + this.lastName;
    }
    };

    const getFullName = person.fullName;
    console.log(person.fullName()); // 'Peter Johnson'
    console.log(getFullName()); /*this raboti samo ako funkciqta e izvikana na obekt */