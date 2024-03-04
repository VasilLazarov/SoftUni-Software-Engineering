const baseURL = "http://localhost:3030/jsonstore/tasks/";
const loadButton = document.getElementById('load-board-btn');
const createtaskButton = document.getElementById('create-task-btn');
const inputDomSelectors = {
    title: document.getElementById('title'),
    description: document.getElementById('description'),
};
const ulDomSelectors = {
    'ToDo': document.querySelector('#todo-section > .task-list'),
    'In Progress': document.querySelector('#in-progress-section > .task-list'),
    'Code Review': document.querySelector('#code-review-section > .task-list'),
    'Done': document.querySelector('#done-section > .task-list'),
};
const textForButtonInTask = {
    'ToDo': "Move to In Progress",
    'In Progress': "Move to Code Review",
    'Code Review': "Move to Done",
};
const forMoveTasks = {
    "Move to In Progress": 'In Progress',
    "Move to Code Review": 'Code Review',
    "Move to Done": 'Done',
};


function attachEvents() {
    loadButton.addEventListener('click', loadTasks);
    createtaskButton.addEventListener('click', addNewTask);
}

async function loadTasks(){
    clearUls();
    try {
        const res = await fetch(baseURL);
        const allTasks = await res.json();
        Object.values(allTasks)
        .forEach((task) => {
            const currUl = ulDomSelectors[task.status];
            const currLi = createElement('li', null, ["task"], null, currUl);
            createElement('h3', task.title, [], null, currLi);
            createElement('p', task.description, [], null, currLi);
            const buttonInTask = createElement('button', null, [], task._id, currLi);
            
            if(task.status != 'Done'){
                buttonInTask.textContent = textForButtonInTask[task.status];
                buttonInTask.addEventListener('click', moveTask);
            }
            else{
                buttonInTask.textContent = 'Close';
                buttonInTask.addEventListener('click', deleteTask);
            }
        });
    } catch (err) {
        console.log(err.message);
    }

}
function addNewTask(){
    const {title, description} = inputDomSelectors;
    const hasInvalidInput = Object.values(inputDomSelectors)
    .some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }

    const headers = {
        method: 'POST',
        body: JSON.stringify({
            title: title.value,
            description: description.value,
            status: 'ToDo',
        }),
    };
    fetch(baseURL, headers)
    .then(loadTasks)
    .catch(console.error);

    Object.values(inputDomSelectors).forEach((input) => {
        input.value = '';
    });
}
function moveTask(e){
    const buttonFrom = e.target;
    const taskId = buttonFrom.getAttribute('id');

    const headers = {
        method: 'PATCH',
        body: JSON.stringify({
            status: forMoveTasks[buttonFrom.textContent]
        }),
    }

    fetch(`${baseURL}/${taskId}`, headers)
    .then(loadTasks)
    .catch(console.error);

}
function deleteTask(e){
    const buttonFrom = e.target;
    const taskId = buttonFrom.getAttribute('id');

    const headers = {
        method: 'DELETE',
    }

    fetch(`${baseURL}/${taskId}`, headers)
    .then(loadTasks)
    .catch(console.error);
}

function clearUls(){
    Object.values(ulDomSelectors).forEach((ul) => {
        ul.innerHTML = '';
    })
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

attachEvents();