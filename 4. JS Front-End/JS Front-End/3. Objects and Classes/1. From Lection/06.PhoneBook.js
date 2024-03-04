function collectPhones(arr){
    const phoneObj = arr.reduce((acc, curr) =>{
        const [name, phone] = curr.split(' ');
        acc[name] = phone;
        return acc;
    }, {});
    /*Object.keys(phoneObj).forEach((key) => {
        console.log(`${key} -> ${phoneObj[key]}`);
    });*/
    Object.entries(phoneObj).forEach(([key, value]) => {
        console.log(`${key} -> ${value}`);
    });
}
/*function collectPhones(input) {
    let phonebook = {};
    for (let line of input) {
    let tokens = line.split(' ');
    let name = tokens[0];
    let number = tokens[1];
    phonebook[name] = number;
    }
    for (let key in phonebook) {
    console.log(`${key} -> ${phonebook[key]}`);
    }
}*/
    
collectPhones([
    'Tim 0834212554',
    'Peter 0877547887',
    'Bill 0896543112',
    'Tim 0876566344'
]);