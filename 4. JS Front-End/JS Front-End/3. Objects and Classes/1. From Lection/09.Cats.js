/*class Cat{
    constructor(name, age){
        this.name = name;
        this.age = age;
    }
    meow(){
        return `${this.name}, age ${this.age} says Meow`;
    }
}*/
function createCats(input){
    class Cat{
        constructor(name, age){
            this.name = name;
            this.age = age;
        }
        meow = () => {
            return `${this.name}, age ${this.age} says Meow`;
        }
    }
    input.forEach((line) => {
        const [name, age] = line.split(' ');
        //console.log(name, age);
        const cat = new Cat(name, age);
        console.log(cat.meow());
        //const greet = cat.meow;
        //console.log(greet());
    });
}

createCats(['Mellow 2', 'Tom 5']);