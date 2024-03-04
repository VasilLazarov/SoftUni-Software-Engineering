function addItem() {
    const itemForAdd = document.querySelector("#newItemText").value;
    const listItem = createListItem(itemForAdd);
    document.querySelector("#newItemText").value = '';
    
    const ul = document.querySelector("#items");
    ul.appendChild(listItem);
}
function createListItem(item){
    const li = document.createElement("li");
    li.textContent = item;
    li.appendChild(createDeleteLink());
    return li;
}
function createDeleteLink(){
    const link = document.createElement("a");
    link.textContent = "[Delete]";
    link.href = "#";
    link.addEventListener("click", deleteLi);
    
    function deleteLi(e){
        /*console.log(e.currentTarget);
        console.log(this);*/
        const linkA = e.currentTarget;
        //const linkA = this;
        linkA.parentElement.remove();
        /*let li = linkA.parentNode;
        li.parentNode.removeChild(li);*/
    }
    return link;
}