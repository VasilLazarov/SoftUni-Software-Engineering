const baseURL = 'http://localhost:3030/jsonstore/tasks';

const inputDomSelectors = {
    location: document.querySelector('#location'),
    temperature: document.querySelector('#temperature'),
    date: document.querySelector('#date'),
};

const buttonsDomSelectors = {
    loadButton: document.querySelector('#load-history'),
    addButton: document.querySelector('#add-weather'),
    editButton: document.querySelector('#edit-weather'),
};

const otherDomSelectors = {
    listOfWeathers: document.querySelector('#list'),
};

let weatherIDForEdit = '';

function attachEvents(){
    buttonsDomSelectors.loadButton.addEventListener('click', loadWeathers);
    buttonsDomSelectors.addButton.addEventListener('click', addWeather);
    buttonsDomSelectors.editButton.addEventListener('click', editedAddWeather);
}

async function loadWeathers(){
    clearListOfWeathers();
    const res = await fetch(baseURL);
    const allWeathers = await res.json();
    Object.values(allWeathers).forEach((weather) => {
        const currWeatherContainer = createElement('div', null, ["container"]);
        createElement('h2', weather.location, [], null, currWeatherContainer);
        createElement('h3', weather.date, [], null, currWeatherContainer);
        createElement('h3', weather.temperature, [], null, currWeatherContainer);

        const buttonsContainer = createElement('div', null, ["buttons-container"]);

        const changeBTN = createElement('button', `Change`, ["change-btn"], weather._id, buttonsContainer);
        changeBTN.addEventListener('click', (e) => {
            weatherIDForEdit = e.target.getAttribute('id');
            const currWeatherElement = document.getElementById(weatherIDForEdit).parentElement.parentElement;
            currWeatherElement.remove();

            Object.keys(inputDomSelectors).forEach((key) => {
                inputDomSelectors[key].value = weather[key];
            });

            buttonsDomSelectors.addButton.setAttribute('disabled', true);
            buttonsDomSelectors.editButton.removeAttribute('disabled');
        });

        const deleteBTN = createElement('button', `Delete`, ["delete-btn"], weather._id, buttonsContainer);
        deleteBTN.addEventListener('click', deleteWeather);

        currWeatherContainer.appendChild(buttonsContainer);

        otherDomSelectors.listOfWeathers.appendChild(currWeatherContainer);
    });
}

function addWeather(){
    // e.preventDefault();
    const {location, temperature, date} = inputDomSelectors;
    const hasInvalidInput = Object.values(inputDomSelectors)
        .some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }
    const headers = {
        method: 'POST',
        body: JSON.stringify({
            location: location.value,
            temperature: temperature.value,
            date: date.value,
        }),
    }
    fetch(baseURL, headers)
    .then(loadWeathers)
    .catch(console.error);

    clearInputFields();
}

function editedAddWeather(){
    // e.preventDefault();
    const {location, temperature, date} = inputDomSelectors;
    const hasInvalidInput = Object.values(inputDomSelectors)
        .some((input) => input.value === '');
    if(hasInvalidInput){
        return;
    }
    const headers = {
        method: 'PUT',
        body: JSON.stringify({
            location: location.value,
            temperature: temperature.value,
            date: date.value,
            _id: weatherIDForEdit,
        }),
    };
    fetch(`${baseURL}/${weatherIDForEdit}`, headers)
    .then(loadWeathers)
    .catch(console.error);

    clearInputFields();
    buttonsDomSelectors.editButton.setAttribute('disabled', true);
    buttonsDomSelectors.addButton.removeAttribute('disabled');
}

function deleteWeather(e){
    const deleteWeatherID = e.target.getAttribute('id');
    const headers = {
        method: 'DELETE',
    };
    fetch(`${baseURL}/${deleteWeatherID}`, headers)
    .then(loadWeathers)
    .catch(console.error);
}


function clearListOfWeathers(){
    otherDomSelectors.listOfWeathers.innerHTML = '';
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

