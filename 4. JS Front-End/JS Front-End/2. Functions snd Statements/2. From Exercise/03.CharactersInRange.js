function printCharactersInRange(char1, char2){
    let output = [];
    if(char1 > char2){
        let temp = char1;
        char1 = char2;
        char2 = temp;
    }
    for (let index = char1.charCodeAt(0) + 1; index < char2.charCodeAt(0); index++) {
        output.push(String.fromCharCode(index));
    }
    console.log(output.join(' '));
}
printCharactersInRange('a', 'd');
printCharactersInRange('#', ':');
printCharactersInRange('C', '#');