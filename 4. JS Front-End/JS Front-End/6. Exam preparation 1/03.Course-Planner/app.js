const baseURL = 'http://localhost:3030/jsonstore/tasks';
const inputDomSelectors ={
    title: document.querySelector('#course-name'),
    type: document.querySelector('#course-type'),
    description: document.querySelector('#description'),
    teacher: document.querySelector('#teacher-name'),
};
const buttonsDomSelectors ={
    loadButton: document.querySelector('#load-course'),
    addButton: document.querySelector('#add-course'),
    editButton: document.querySelector('#edit-course'),
};
const otherDomSelectors ={
    listOfCourses: document.querySelector('#list'),
};
let courseIDForEdit = '';
const courseTypes = ["Long", "Medium", "Short"];

function attachEvents(){
    buttonsDomSelectors.loadButton.addEventListener('click', loadCourses);
    buttonsDomSelectors.addButton.addEventListener('click', addCourse);
    buttonsDomSelectors.editButton.addEventListener('click', editedAddCourse);
}

async function loadCourses(){
    clearListOfCourses();
    const res = await fetch(baseURL);
    const allCourses = await res.json();
    Object.values(allCourses).forEach((course) => {
        const container = createElement('div', null, ['container']);
        createElement('h2', course.title, [], null, container);
        createElement('h3', course.teacher, [], null, container);
        createElement('h3', course.type, [], null, container);
        createElement('h4', course.description, [], null, container);
        
        const inCourseEditBTN = createElement('button', 'Edit Course', ["edit-btn"], course._id, container);
        inCourseEditBTN.addEventListener('click', (e) => {

            courseIDForEdit = e.target.getAttribute('id');
            const currCourseElement = document.getElementById(courseIDForEdit).parentElement;
            currCourseElement.remove();
        
            Object.keys(inputDomSelectors).forEach((key) => {
                inputDomSelectors[key].value = course[key];
            });
            
            buttonsDomSelectors.addButton.setAttribute('disabled', true);
            buttonsDomSelectors.editButton.removeAttribute('disabled');
        
        });
       
        const inCourseFinishBTN = createElement('button', 'Finish Course', ["finish-btn"], course._id, container);
        inCourseFinishBTN.addEventListener('click', finishCourse);
        
        otherDomSelectors.listOfCourses.appendChild(container);
        
    });
}

function addCourse(e){
    e.preventDefault();
    const {title, type, description, teacher} = inputDomSelectors;
    if(!courseTypes.includes(type.value)){
        clearInputFields();
        return;
    }
    const hasInvalidInput = Object.values(inputDomSelectors)
        .some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }
    const headers = {
        method: 'POST',
        body: JSON.stringify({
            title: title.value,
            type: type.value,
            description: description.value,
            teacher: teacher.value,
        }),
    };
    fetch(baseURL, headers)
    .then(loadCourses)
    .catch(console.error);

    clearInputFields();
}

/*async function returnCourseInFormForEditing(e){

    courseIDForEdit = e.target.getAttribute('id');
    console.log(courseIDForEdit);
    const currCourseElement = document.getElementById(courseIDForEdit).parentElement;
    currCourseElement.remove();

    const currCourseForEdit = await ( await fetch(`${baseURL}/${courseIDForEdit}`)).json();
    Object.keys(inputDomSelectors).forEach((key) => {
        inputDomSelectors[key].value = currCourseForEdit[key];
    });
    
    buttonsDomSelectors.addButton.setAttribute('disabled', true);
    buttonsDomSelectors.editButton.removeAttribute('disabled');

}*/

async function editedAddCourse(e){
    e.preventDefault();
    const {title, type, description, teacher} = inputDomSelectors;
    if(!courseTypes.includes(type.value)){
        clearInputFields();
        return;
    }
    const hasInvalidInput = Object.values(inputDomSelectors)
        .some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }
    const headers = {
        method: 'PUT',
        body: JSON.stringify({
            title: title.value,
            type: type.value,
            description: description.value,
            teacher: teacher.value,
            _id: courseIDForEdit,
        }),
    }
    await fetch(`${baseURL}/${courseIDForEdit}`, headers);
    loadCourses();

    clearInputFields();
    buttonsDomSelectors.editButton.setAttribute('disabled', true);
    buttonsDomSelectors.addButton.removeAttribute('disabled');
}

async function finishCourse(e){
    const finishedCourseID = e.target.getAttribute('id');
    const headers = {
        method: 'DELETE',
    }

    await fetch(`${baseURL}/${finishedCourseID}`, headers);

    loadCourses();
}

function clearListOfCourses(){
    otherDomSelectors.listOfCourses.innerHTML = '';
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

attachEvents();