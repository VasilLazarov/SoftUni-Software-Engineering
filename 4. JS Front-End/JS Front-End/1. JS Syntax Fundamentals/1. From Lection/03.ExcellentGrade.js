function checkGrade(grade){
    if(typeof grade !== "number"){
        console.log("Please input number");
    }
    else if(grade < 2 || grade > 6){
        console.log("Please input grade from 2.00 to 6.00");
    }
    else if(grade >= 5.50){
        console.log("Excellent");
    }
    else{
        console.log("Not excellent");
    }
}

checkGrade(5.50);