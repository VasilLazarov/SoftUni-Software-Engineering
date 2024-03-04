function addItem() {
    const textForAdd = document.querySelector('#newItemText').value;
    
    const li = document.createElement('li');
    li.textContent = textForAdd;
    
    /*const list = document.querySelector('#items');
    list.appendChild(li);*/
    document.querySelector('#items').appendChild(li);

    document.querySelector('#newItemText').value = '';

}