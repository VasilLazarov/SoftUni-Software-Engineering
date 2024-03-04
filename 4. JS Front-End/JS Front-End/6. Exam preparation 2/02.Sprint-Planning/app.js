window.addEventListener('load', solve);


function solve() {
    const tasks = {};
    const domSeletors ={
        createTaskButton: document.querySelector("#create-task-btn"),
        deleteTaskButton: document.querySelector("#delete-task-btn"),
        taskSection: document.querySelector("#tasks-section"),
        totalPoint: document.querySelector("#total-sprint-points"),
    };
    const inputDomSelectors = {
        title: document.querySelector("#title"),
        description: document.querySelector("#description"),
        label: document.querySelector("#label"),
        points: document.querySelector("#points"),
        assignee: document.querySelector("#assignee"),

    };
    const symbols = {
        "High Priority Bug": '&#9888;',
        "Low Priority Bug": '&#9737;',
        "Feature": '&#8865;',
    };
    const labelClassFeature = {
        "High Priority Bug": 'high-priority',
        "Low Priority Bug": 'low-priority',
        "Feature": 'feature',
    };
    domSeletors.createTaskButton.addEventListener("click", createTaskInArticle);
    domSeletors.deleteTaskButton.addEventListener("click", deleteTask);

    function createTaskInArticle(e){
        //const { title, description, label, points, assignee } = inputDomSelectors;
        const hasInvalidInput = Object.values(inputDomSelectors)
        .some((currInput) => currInput.value === '');
        if(hasInvalidInput){
            return;
        }

        const task = {
            id: `task-${Object.values(tasks).length + 1}`,
            title: inputDomSelectors.title.value,
            description: inputDomSelectors.description.value,
            label: inputDomSelectors.label.value,
            points: Number(inputDomSelectors.points.value),
            assignee: inputDomSelectors.assignee.value,
        };
        
        tasks[task.id] = task;

        const taskArticle = createElement('article', null, ["task-card"], task.id);
        createElement('div', `${task.label} ${symbols[task.label]}`, ["task-card-label", labelClassFeature[task.label]], null, taskArticle, true);
        createElement('h3', task.title, ["task-card-title"], null, taskArticle);
        createElement('p', task.description, ["task-card-description"], null, taskArticle);
        createElement('div', `Estimated at ${task.points} pts`, ["task-card-points"], null, taskArticle);
        createElement('div', `Assigned to: ${task.assignee}`, ["task-card-assignee"], null, taskArticle);
        
        const taskAction = createElement('div', null, ["task-card-actions"], null, taskArticle);
        const deleteButton = createElement('button', 'Delete', [], null, taskAction);
        
        deleteButton.addEventListener('click', loadDeleteTaskInForm);

        domSeletors.taskSection.appendChild(taskArticle);
        
        updateTotalPoints();
        clearInputFields();

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

    function deleteTask(e){
        const taskId = document.getElementById('task-id').value;
        const taskToRemove = document.getElementById(taskId);
        taskToRemove.remove();
        delete tasks[taskId];
        domSeletors.deleteTaskButton.setAttribute('disabled', true);
        domSeletors.createTaskButton.removeAttribute('disabled');
        Object.values(inputDomSelectors)
        .forEach((input) => {
            input.removeAttribute('disabled');
        });
        updateTotalPoints();
        clearInputFields();
    };

    function loadDeleteTaskInForm(e){
        const taskId = e.currentTarget.parentElement.parentElement.getAttribute('id');
        document.getElementById('task-id').value = taskId;
        //document.getElementById('task-id').;
       /* Object.entries(inputDomSelectors).forEach(([key, value]) => {
            value = tasks[taskId][key];
        });*/
        for(const key in inputDomSelectors){
            inputDomSelectors[key].value = tasks[taskId][key];
        }
        Object.values(inputDomSelectors)
        .forEach((input) => {
            input.setAttribute('disabled', true);
        });

        domSeletors.createTaskButton.setAttribute('disabled', true);
        domSeletors.deleteTaskButton.removeAttribute('disabled');
        //inputDomSelectors.title = tasks[taskId].title;

    };

    function clearInputFields(){
        Object.values(inputDomSelectors).forEach((input) => {
            input.value = '';
        });
    };

    function updateTotalPoints(){
        const totalPoints = Object.values(tasks).reduce((acc, curr) => acc + curr.points, 0);
        domSeletors.totalPoint.textContent = `Total Points ${totalPoints}pts`;
    };
}