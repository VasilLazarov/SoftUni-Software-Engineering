function checkWhetherNumberIsPerfect(number){
    if(number <= 0){
        return console.log("It's not so perfect.");
    }
    let currentSum = 0;
    for (let i = 1; i < number; i++) {
        if(number % i === 0){
            currentSum += i;
        }
    }
    if(number === currentSum){
        console.log("We have a perfect number!")
    }
    else{
        console.log("It's not so perfect.")
    }
}
checkWhetherNumberIsPerfect(6);
checkWhetherNumberIsPerfect(28);
checkWhetherNumberIsPerfect(1236498);