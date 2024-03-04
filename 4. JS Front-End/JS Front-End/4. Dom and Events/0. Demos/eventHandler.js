const button = document.getElementsByTagName('button')[0];

button.addEventListener('click', clickMe);

function clickMe(e){
    const targetButton = e.currentTarget;
    const targetButtonText = targetButton.textContent;
    targetButton.textContent = Number.parseInt(targetButtonText) + 1;
}