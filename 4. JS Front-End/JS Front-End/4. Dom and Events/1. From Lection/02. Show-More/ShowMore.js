function showText() {
    // TODO
    const elementText = document.getElementById('text');
    if(elementText.style.display === 'none'){
        elementText.style.display = 'inline';
        document.getElementById('more').style.display = 'none';
    }
    /*else{
        elementText.style.display = 'none';
    }
    console.log(elementText);*/


    /*document.getElementById('text').style.display = 'block';
    
    setTimeout(() => {
        document.getElementById('more').style.display = 'none';
    }, 2000);*/

}