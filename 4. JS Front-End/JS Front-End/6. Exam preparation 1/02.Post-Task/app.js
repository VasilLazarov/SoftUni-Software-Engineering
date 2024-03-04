window.addEventListener("load", solve);

function solve() {
  const inputDomSelectors = {
    title: document.querySelector('#task-title'),
    category: document.querySelector('#task-category'),
    content: document.querySelector('#task-content'),
  };
  const otherDomSelectors = {
    publishBTN: document.querySelector('#publish-btn'),
    reviewList: document.querySelector('#review-list'),
    publishedList: document.querySelector('#published-list'),
  };

  otherDomSelectors.publishBTN.addEventListener('click', addTaskToReviewList);


  function addTaskToReviewList(){
    const hasInvalidInput = Object.values(inputDomSelectors).some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }
    const task = {
        title: inputDomSelectors.title.value,
        category: inputDomSelectors.category.value,
        content: inputDomSelectors.content.value,
    };
    const currLi = createElement('li', null, ["rpost"]);
    const article = createElement('article');
    createElement('h4', task.title, [], null, article);
    createElement('p', `Category: ${task.category}`, [], null, article);
    createElement('p', `Content: ${task.content}`, [], null, article);

    const editBTN = createElement('button', 'Edit', ["action-btn", "edit"]);
    editBTN.addEventListener('click', editTask);
    const postBTN = createElement('button', 'Post', ["action-btn", "post"]);
    postBTN.addEventListener('click', postTask);

    currLi.appendChild(article);
    currLi.appendChild(editBTN);
    currLi.appendChild(postBTN);

    otherDomSelectors.reviewList.appendChild(currLi);

    clearInputFields();


    function editTask(){
        Object.keys(inputDomSelectors).forEach((key) => {
            inputDomSelectors[key].value = task[key];
        });
        currLi.remove();
    }

    function postTask(){
        editBTN.remove();
        postBTN.remove();

        otherDomSelectors.publishedList.appendChild(currLi);
    }
  };
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