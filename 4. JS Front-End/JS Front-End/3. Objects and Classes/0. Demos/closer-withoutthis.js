function createGame(){
    let score = 0;
    let name = "Tetris";
    return{
        add: () => score++,
        get: () => console.log(score),
        //printGame: () => { console.log(`Game name: ${name} - score: ${score}`); return "ei pedali" },
        printGame: () => `Game name: ${name} - score: ${score}`,
    }
}
/*function createGame(){
    return{
        score: 0,
        add() { this.score++ },
        get() { console.log(this.score) },
    }
}*/
const game = createGame();
const printGameInfo = game.printGame;
game.get();
game.add();
game.get();
//printGameInfo();
console.log(printGameInfo());