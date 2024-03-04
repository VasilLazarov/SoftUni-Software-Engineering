function storeAddresses(inputArr){
    const addressBookObj = inputArr.reduce((acc, curr) => {
        const [name, address] = curr.split(':');
        acc[name] = address;
        return acc;
    }, {});
    Object.entries(addressBookObj).sort((a, b) => a[0].localeCompare(b[0])).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
    console.log(`----------------------------------`);
}

storeAddresses([
    'Tim:Doe Crossing',
    'Bill:Nelson Place',
    'Peter:Carlyle Ave',
    'Bill:Ornery Rd',
]);
storeAddresses([
    'Bob:Huxley Rd',
    'John:Milwaukee Crossing',
    'Peter:Fordem Ave',
    'Bob:Redwing Ave',
    'George:Mesta Crossing',
    'Ted:Gateway Way',
    'Bill:Gateway Way',
    'John:Grover Rd',
    'Peter:Huxley Rd',
    'Jeff:Gateway Way',
    'Jeff:Huxley Rd',
]);