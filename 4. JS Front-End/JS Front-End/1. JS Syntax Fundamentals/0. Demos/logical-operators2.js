let signedinStatus = true;

function signOutUser(){
    console.log("User is signed out!");
    signedinStatus = false;
}


/*if(signedinStatus){
    signOutUser();
}*/
/* other way to do same thing*/
signedinStatus && signOutUser();
signedinStatus && signOutUser();