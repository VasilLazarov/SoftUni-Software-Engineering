/*with .replaceAll - but dont work in judge */
/*function replaceWordWithSymbols(text, word){
    let replacedText = text.replaceAll(word, '*'.repeat(word.length));
    console.log(replacedText);
}*/

/*with while loop and .replace - for judge */
function replaceWordWithSymbols(text, word){
    let replacedText = text.replace(word, '*'.repeat(word.length));
    while(replacedText.includes(word)){
        replacedText = replacedText.replace(word, '*'.repeat(word.length));
    }
    console.log(replacedText);
}
replaceWordWithSymbols('A small sentence word with some words', 'small');
replaceWordWithSymbols('Find the hidden word', 'hidden' );
