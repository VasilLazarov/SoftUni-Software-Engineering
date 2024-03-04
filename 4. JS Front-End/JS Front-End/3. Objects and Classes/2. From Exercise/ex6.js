function solve(input){
    const wordsCounter = {};
    const searchedWords = input.shift().split(' ');

    searchedWords.forEach(word => {
        wordsCounter[word] = 0;
    });
    input.forEach((currWord) =>{
        if(wordsCounter.hasOwnProperty(currWord)){
            wordsCounter[currWord] += 1;
        }
    });
    const countedWordsArray = Object.entries(wordsCounter);
    countedWordsArray.sort((a, b) => b[1] - a[1]);
    countedWordsArray.forEach(([word, count]) => {
        console.log(`${word} - ${count}`);
    });
}


solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
]);