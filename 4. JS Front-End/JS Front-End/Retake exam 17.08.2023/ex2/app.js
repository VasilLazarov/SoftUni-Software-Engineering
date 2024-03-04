window.addEventListener("load", solve);

function solve() {
  const inputDomSelectors = {
    player: document.querySelector('#player'),
    score: document.querySelector('#score'),
    round: document.querySelector('#round'),
  };
  const domSelectors = {
    addButton: document.querySelector('#add-btn'),
    sureList: document.querySelector('#sure-list'),
    scoreboardList: document.querySelector('#scoreboard-list'),
    clearButton: document.querySelector('.clear'),
  };

  domSelectors.addButton.addEventListener('click', addScoreToSureList);
  domSelectors.clearButton.addEventListener('click', reloadApplication);
  let playerScore = {};
  function addScoreToSureList(){
    const hasInvalidInput = Object.values(inputDomSelectors)
      .some((currInput) => currInput.value === '');
    if(hasInvalidInput){
      return;
    }
    playerScore = {
      player: inputDomSelectors.player.value,
      score: inputDomSelectors.score.value,
      round: inputDomSelectors.round.value,
    };

    const currLi = createElement('li', null, ["dart-item"]);
    const infoArticle = createElement('article');
    createElement('p', playerScore.player, [], null, infoArticle);
    createElement('p', `Score: ${playerScore.score}`, [], null, infoArticle);
    createElement('p', `Round: ${playerScore.round}`, [], null, infoArticle);

    const editBTN = createElement('button', `edit`, ["btn", "edit"]);
    const okBTN = createElement('button', `ok`, ["btn", "ok"]);
    editBTN.addEventListener('click', returnScoreForEditing);
    okBTN.addEventListener('click', addScoreToScoreboard);

    currLi.appendChild(infoArticle);
    currLi.appendChild(editBTN);
    currLi.appendChild(okBTN);

    domSelectors.sureList.appendChild(currLi);

    domSelectors.addButton.setAttribute('disabled', true);
    clearInputFields();
  }

  function returnScoreForEditing(){
    for (const key in inputDomSelectors) {
      inputDomSelectors[key].value = playerScore[key];
    }
    domSelectors.sureList.innerHTML = '';
    domSelectors.addButton.removeAttribute('disabled');
  }

  function addScoreToScoreboard(){
    domSelectors.sureList.innerHTML = '';

    const currLi = createElement('li', null, ["dart-item"]);
    const infoArticle = createElement('article');
    createElement('p', playerScore.player, [], null, infoArticle);
    createElement('p', `Score: ${playerScore.score}`, [], null, infoArticle);
    createElement('p', `Round: ${playerScore.round}`, [], null, infoArticle);

    currLi.appendChild(infoArticle);
    domSelectors.scoreboardList.appendChild(currLi);
    domSelectors.addButton.removeAttribute('disabled');
  }
  
  function reloadApplication(){
    location.reload();
  }
    


  function clearInputFields(){
    Object.values(inputDomSelectors).forEach((input) => {
      input.value = '';
  });
  }

  function createElement(type, content, classes, id, parentNode, useInnerHTML){
    const element = document.createElement(type);

    if(content && useInnerHTML){
        element.innerHTML = content;
    }
    else if(content){
        element.textContent = content;
    }
    if(classes && classes.length > 0){
        element.classList.add(...classes);
    }
    if(id){
        element.setAttribute("id", id);
    }
    if(parentNode){
        parentNode.appendChild(element);
    }
    return element;
  };
}
  