function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   const inputDomSelectors = {
      searchedWord: document.querySelector('#searchField'),
      trElements: document.querySelectorAll('.container tbody tr'),
   };
   function onClick() {
      const searchedWord = inputDomSelectors.searchedWord.value;
      inputDomSelectors.searchedWord.value = '';
      const arrayOfAllTableRows = Array.from(inputDomSelectors.trElements);
      
      arrayOfAllTableRows.forEach((row) => {
         row.classList.remove('select');
         const rowChildrenArray = Array.from(row.children);
         for (const child of rowChildrenArray) {
            if(child.textContent.includes(searchedWord)){
               row.classList.add('select');
               break;
            }
         }
      });
   };
};