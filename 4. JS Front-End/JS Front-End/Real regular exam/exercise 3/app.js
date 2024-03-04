const baseURL = "http://localhost:3030/jsonstore/tasks/";
const loadButton = document.getElementById('load-vacations');
const addButton = document.getElementById('add-vacation');
const editButton = document.getElementById('edit-vacation');
const inputDomSelectors = {
    name: document.getElementById('name'),
    numberOfDays: document.getElementById('num-days'),
    fromDate: document.getElementById('from-date'),
};
const divAllDomSelector = document.getElementById('list');


function attachEvents() {
    loadButton.addEventListener('click', loadTasks);
    addButton.addEventListener('click', addNewTask);
    editButton.addEventListener('click', editTask);
};

async function loadTasks(){
    try {
        const res = await fetch(baseURL);
        const allTasks = await res.json();
        Object.values(allTasks)
        .forEach((task) => {
            const divForAll = createElement('div', null, ["container"], task._id);
            createElement('h2', task.name, [], null, divForAll);
            createElement('h3', task.date, [], null, divForAll);
            createElement('h3', task.days, [], null, divForAll);
            
            const changeButton = createElement('button', "Change", ["change-btn"], task._id, divForAll);
            const doneButton = createElement('button', "Done", ["done-btn"], task._id, divForAll);
            changeButton.addEventListener('click', changeTask);
            doneButton.addEventListener('click', taskDone);

            divAllDomSelector.appendChild(divForAll);

        });
    } catch (error) {
        console.log(console.error);
    }
};

function addNewTask(){
    const {name, numberOfDays, fromDate} = inputDomSelectors;
    const hasInvalidInput = Object.values(inputDomSelectors)
    .some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }

    const headers = {
        method: 'POST',
        body: JSON.stringify({
            name: name.value,
            numberOfDays: numberOfDays.value,
            fromDate: fromDate.value,
        }),
    };
    fetch(baseURL, headers)
    .then(loadTasks)
    .catch(console.error);

    Object.values(inputDomSelectors).forEach((input) => {
        input.value = '';
    });
}

function editTask(){
    editButton.removeAttribute("disabled");
    addButton.setAttribute("disabled", true);
    const {name, numberOfDays, fromDate} = inputDomSelectors;

    const headers = {
        method: 'PUT',
        body: JSON.stringify({
            name: name.value,
            numberOfDays: numberOfDays.value,
            fromDate: fromDate.value,
        }),
    };
    fetch(`${baseURL}/${taskId}`, headers)
    .then(loadTasks)
    .catch(console.error);
    editButton.setAttribute("disabled", true);
    addButton.removeAttribute("disabled");
};

function changeTask(e){
    const taskId = e.parentElement.getAttribute('id');

    fetch(`${baseURL}/${taskId}`).then((res) => res.json())
    .then((task) => {
        for(const key in inputDomSelectors){
            inputDomSelectors[key].value = task[key];
        }
    })
    .catch((error) => console.error(error));
    const taskToRemove = document.getElementById(taskId);
    taskToRemove.remove();

    
};

function taskDone(e){
    const taskId = e.parentElement.getAttribute('id');

    const headers = {
        method: 'DELETE',
    }

    fetch(`${baseURL}/${taskId}`, headers)
    .then(loadTasks)
    .catch(console.error);
};

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

function clearDivWithTasks(){
    divAllDomSelector.innerHTML = '';
};