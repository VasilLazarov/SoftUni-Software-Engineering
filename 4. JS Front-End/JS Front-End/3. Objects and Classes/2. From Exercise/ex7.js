function solve(inputString){
    const wordsCounter = new Map();
    const inputWords = inputString.toLowerCase().split(' ');

    inputWords.forEach((word) => {
        if(!wordsCounter.has(word)){
            wordsCounter.set(word, 0);
        }
        wordsCounter.set(word, wordsCounter.get(word) + 1);
    });


    const oddPairs = Array.from(wordsCounter.entries()).filter(([key, value]) => { 
        return value % 2 !== 0;
    });
    const oddWords = oddPairs.map(([key, value]) => {
        return key;
    });
    console.log(oddWords.join(' '));
};


solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
solve('Cake IS SWEET is Soft CAKE sweet Food');