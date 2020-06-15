function solve() {
   const tbody = document.querySelector('tbody');
   const rows = tbody.querySelectorAll('tr');
   tbody.addEventListener('click', onClick);

   function onClick(e) {
      const row = e.target.parentNode;

      if (row.nodeName === 'TR') {
         if (row.style.backgroundColor !== '') {
            row.style.backgroundColor = '';
         } else {
            [...rows].forEach(r => r.style.backgroundColor = '');
            row.style.backgroundColor = '#413f5e';
         }
      }
   }
}