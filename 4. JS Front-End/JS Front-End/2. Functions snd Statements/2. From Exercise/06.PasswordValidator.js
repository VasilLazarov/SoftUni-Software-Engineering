
function validatePassword(password){
    function isWrongLength(password){
        return password.length < 6 || password.length >10;
    }
    function isOnlyLettersAndDigits(password){
        return password.match("^[A-Za-z0-9]+$");
    }
    function hasAtleastTwoDigits(password){
        const digitCount = password.match(/\d/g);
        //return !digitCount || digitCount.length < 2;
        return digitCount ? digitCount.length >= 2 : false;
    }
    const errors = [];
    if(isWrongLength(password)){
        errors.push("Password must be between 6 and 10 characters");
    }
    
    if(!isOnlyLettersAndDigits(password)){
        errors.push("Password must consist only of letters and digits");
    }

    if(!hasAtleastTwoDigits(password)){
        errors.push("Password must have at least 2 digits");
    }
    
    if(errors.length > 0){
        console.log(errors.join("\n"));
    }
    else{
        console.log("Password is valid");
    }
}

validatePassword('LogIn7');