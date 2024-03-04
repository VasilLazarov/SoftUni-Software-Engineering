function deleteByEmail() {
    const email = document.getElementsByName('email')[0].value;
    const emailsInTable = document.querySelectorAll('#customers tr td:nth-child(2)');

   for (const em of emailsInTable) {
        if(em.textContent === email){
            //let row = em.parentNode;
            //row.parentNode.removeChild(row);
            em.parentElement.remove();
            document.getElementById('result').textContent = "Deleted.";
            return;
        }
    };
    
    document.getElementById('result').textContent = "Not found.";
}