
console.log( "5 > 2" && false);
function printHelloUsername(username){
    /*if(!username){
        username = "user";
    }*/
    let usernameForPrint = username || "Vasil";
    console.log(`Hello ${usernameForPrint}`);
}
printHelloUsername("");