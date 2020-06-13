function solve() {
   const query = document.querySelector('#searchField');
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick(e) {
      searchText = query.value.toLocaleLowerCase().trim();
      query.value = '';

      [...document.querySelector('tbody').querySelectorAll('tr')].forEach(row => {
         if (row.textContent.toLocaleLowerCase().includes(searchText) && searchText.length > 0) {
            row.classList.add("select");
         } else {
            row.classList.remove("select");
            console.log(searchText.length);
         }
      });
   }
}