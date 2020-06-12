function create(words) {
   const contentDiv = document.querySelector('#content');

   words.forEach(element => {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');
      paragraph.textContent = element;
      paragraph.setAttribute("style", "display: none;");
      div.appendChild(paragraph);
      contentDiv.appendChild(div);
   });

   contentDiv.addEventListener('click', onClick);

   function onClick(e){
      e.target.querySelector('p').setAttribute("style", "display: block;");
   }
}