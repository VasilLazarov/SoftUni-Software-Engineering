function solve(object){
    /*const myInnerObject = {...object};*//*plitko kopie na obekt*//*suzdavame now obekt s propertita i stoinosti kato na drugiq */
    /*myInnerObject.a = 10;           /*no ako imame obekt v obekt to otnowo ostava s referenciq kum vunshniq i kato go promenim se promenq i otvun */
    /*myInnerObject.b = 20;
    myInnerObject.c = 30;*/
    /*const myInnerObject = JSON.parse(JSON.stringify(object));*/ /*dulboko kopie - na koeto kakwoto i da promenqme ne promenq wynshniq obekt] */
    /*obache ne kopirame ako ima funkcii v obekta */


    /*naj dobriq nachin za kopirane e towa - prawim kopie i na wseki vlojen obekt*/
    const myInnerObject = {
        ...object,
        c: {
            ...object.c,
        }
    };
    myInnerObject.b = 555;
    myInnerObject.c.x = 10;      
}

const myObject = { 
    a: 1, 
    b: 2,
    c: {
        x: 1,
    },
};

solve(myObject);

console.log(JSON.stringify(myObject));