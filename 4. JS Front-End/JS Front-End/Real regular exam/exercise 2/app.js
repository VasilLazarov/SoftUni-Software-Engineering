window.addEventListener("load", solve);

function solve() {
    
  const inputDomSelectors = {
    student: document.querySelector("#student"),
    university: document.querySelector("#university"),
    score: document.querySelector("#score"),
  };
  const domSeletors ={
    buttonNext: document.querySelector("#next-btn"),
    previewList: document.querySelector("#preview-list"),
    candidatesList: document.querySelector("#candidates-list"),
  };

  domSeletors.buttonNext.addEventListener('click', addToPreviewList);
  let apply = {};
  function addToPreviewList(){
    const hasInvalidInput = Object.values(inputDomSelectors)
        .some((currInput) => currInput.value === '');
        if(hasInvalidInput){
            return;
        }
        apply = {
          student: inputDomSelectors.student.value,
          university: inputDomSelectors.university.value,
          score: inputDomSelectors.score.value,
        }

        const currLi = createElement('li', null, ["application"]);
        const articleForLi = createElement("article", null, []);
        createElement('h4', apply.student, [], null, articleForLi);
        createElement('p', `University: ${apply.university}`, [], null, articleForLi);
        createElement('p', `Score: ${apply.score}`, [], null, articleForLi);
        
        const editBTN = createElement('button', `edit`, ["action-btn", "edit"]);
        const applyBTN = createElement('button', `apply`, ["action-btn", "apply"]);
        editBTN.addEventListener('click', editCurrApply);
        applyBTN.addEventListener('click', applyCurrApply);

        currLi.appendChild(articleForLi);
        currLi.appendChild(editBTN);
        currLi.appendChild(applyBTN);

        domSeletors.previewList.appendChild(currLi);

        clearInputFields();
        domSeletors.buttonNext.setAttribute('disabled', true);
  }

  function editCurrApply(){
    for (const key in inputDomSelectors) {
      inputDomSelectors[key].value = apply[key];
    }
    document.querySelector("#preview-list").innerHTML = '';
    domSeletors.buttonNext.removeAttribute('disabled');
  }
  function applyCurrApply(){
    document.querySelector("#preview-list").innerHTML = '';
    
    const currLi = createElement('li', null, ["application"]);
    const articleForLi = createElement("article", null, []);
    createElement('h4', apply.student, [], null, articleForLi);
    createElement('p', `University: ${apply.university}`, [], null, articleForLi);
    createElement('p', `Score: ${apply.score}`, [], null, articleForLi);
    
    currLi.appendChild(articleForLi);
    document.querySelector("#candidates-list").appendChild(currLi);
    domSeletors.buttonNext.removeAttribute('disabled');

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

  function clearInputFields(){
    Object.values(inputDomSelectors).forEach((input) => {
      input.value = '';
  });
  }

}
  