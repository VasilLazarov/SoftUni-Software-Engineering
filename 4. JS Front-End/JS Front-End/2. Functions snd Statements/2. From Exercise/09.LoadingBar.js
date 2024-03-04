function visualizesLoadingBar(number){
    let loadingBarText = "%".repeat(number/10).padEnd(10, '.');
    if(number === 100){
        console.log(`${number}% Complete!`);
        console.log(`[${loadingBarText}]`);
    }
    else{
        console.log(`${number}% [${loadingBarText}]`);
        console.log(`Still loading...`);
    }
}

visualizesLoadingBar(30);
visualizesLoadingBar(50);
visualizesLoadingBar(100);