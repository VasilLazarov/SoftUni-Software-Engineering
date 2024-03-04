function searchWordCount(text, searchedWord){
    let wordsFromText = text.split(' ');
    let counter = 0;
    for (const word of wordsFromText) {
        if(word === searchedWord){
            counter++;
        }
    }
    console.log(counter);
}

/*other way with method */
/*function searchWordCount(text, searchedWord){
    let wordsFromText = text.split(' ');
    let occurrences = wordsFromText.filter(word =>{
        return word === searchedWord;
    });
    console.log(occurrences.length);
}*/
searchWordCount('This is a word and it also is a sentence', 'is');
searchWordCount('softuni is great place for learning new programming languages', 'softuni');